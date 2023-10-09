using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController2 : MonoBehaviour {

    public AudioSource HelicopterSound;
    public ControlPanel ControlPanel;
    public Rigidbody HelicopterModel;
    public HeliRotorController MainRotorController;
    public HeliRotorController SubRotorController;

    public float TurnForce = 3f;
    public float ForwardForce = 10f;
    public float ForwardTiltForce = 20f;
    public float TurnTiltForce = 30f;
    public float EffectiveHeight = 100f;

    public float turnTiltForcePercent = 1.5f;
    public float turnForcePercent = 1.3f;

    private float _engineForce;
    public float EngineForce
    {
        get { return _engineForce; }  //得到值
        set   //取值
        {
            MainRotorController.RotarSpeed = value * 80;
            SubRotorController.RotarSpeed = value * 40;
            HelicopterSound.pitch = Mathf.Clamp(value / 40, 0, 1.2f);
            if (UIGameController.runtime.EngineForceView != null)
                UIGameController.runtime.EngineForceView.text = string.Format("Engine value [ {0} ] ", (int)value);//将指定的 String 中的格式项替换为指定的 Object 实例的值的文本等效项。

            _engineForce = value;//value指的是engine force
        }
    }

    private Vector2 hMove = Vector2.zero;  //二维坐标在（0，0）这个位置
    private Vector2 hTilt = Vector2.zero;
    private float hTurn = 0f;
    public bool IsOnGround = true;

    // Use this for initialization
    void Start()
    {
        ControlPanel.KeyPressed += OnKeyPressed;  //点击键盘开始启动
    }

    void Update()
    {  //每一帧的时间不固定，即第一帧与第二帧的时间t1和第三帧与第四帧的时间t2不一定相同,Update受当前渲染的物体影响，这与当前场景中正在被渲染的物体有关（比如人物的面数，个数等）
    }

    void FixedUpdate()  //FixedUpdate则不受帧率的变化影响，它是以固定的时间间隔来被调用
    {
        LiftProcess();
        MoveProcess();
        TiltProcess();
    }

    private void MoveProcess()
    {
        var turn = TurnForce * Mathf.Lerp(hMove.x, hMove.x * (turnTiltForcePercent - Mathf.Abs(hMove.y)), Mathf.Max(0f, hMove.y));
        //(1)var 其实也就是弱化类型的定义 VAR可代替任何类型 编译器会根据上下文来判断你到底是想用什么类型的
        //(2)Mathf.Lerp两个浮点值之间的插值：public static float Lerp(float a, float b, float t) 
        hTurn = Mathf.Lerp(hTurn, turn, Time.fixedDeltaTime * TurnForce);
        //(1)time是从程序开始执行到现在的时间，deltaTime上一帧完成的时间，fixedTime表示FixedUpdate已经执行的时间，而fixedDeltatime是一个固定的时间增量,可以通过fixedDeltatime来改变FixedUpdate的跟新速率
        HelicopterModel.AddRelativeTorque(0f, hTurn * HelicopterModel.mass, 0f);
        //(1)public void AddRelativeTorque(float x, float y, float z),在刚体中加入相对于其坐标系的扭矩,x是沿局部x轴的扭矩大小，扭矩俗称为发动机的“转劲”
        HelicopterModel.AddRelativeForce(Vector3.forward * Mathf.Max(0f, hMove.y * ForwardForce * HelicopterModel.mass));
        //(1) public void AddRelativeForce(Vector3 force),在刚体中加入相对于其坐标系的力,参数是局部坐标中的力矢量 
        //(2)public static Vector3 forward { get; },Vector3(0, 0, 1)的简写
    }

    private void LiftProcess()
    {
        var upForce = 1 - Mathf.Clamp(HelicopterModel.transform.position.y / EffectiveHeight, 0, 1);
        //(1)public static float Clamp(float value, float min, float max),在最小浮点数和最大浮点数之间夹紧一个值。
        //public Transform transform { get; }:附加到此游戏对象的转换;public Vector3 position { get; set; }:世界空间中变换的位置
        upForce = Mathf.Lerp(0f, EngineForce, upForce) * HelicopterModel.mass;
        HelicopterModel.AddRelativeForce(Vector3.up * upForce);
        // public static Vector3 up { get; }:Vector3(0, 1, 0)的简写

    }

    private void TiltProcess()
    {
        hTilt.x = Mathf.Lerp(hTilt.x, hMove.x * TurnTiltForce, Time.deltaTime);
        hTilt.y = Mathf.Lerp(hTilt.y, hMove.y * ForwardTiltForce, Time.deltaTime);
        HelicopterModel.transform.localRotation = Quaternion.Euler(hTilt.y, HelicopterModel.transform.localEulerAngles.y, -hTilt.x);
        //(1)localRotation:变换相对于父变换的旋转。 
        //(2) public static Quaternion Euler(float x, float y, float z):返回围绕z轴旋转z度、围绕x轴旋转x度和围绕y轴旋转y度的旋转
        //(3) public Vector3 localEulerAngles { get; set; }:旋转作为欧拉角(欧拉角是按照既定的顺序,如依次绕z,y,x分别旋转一个固定角度)，相对于父变换的旋转度 
    }

    private void OnKeyPressed(PressedKeyCode[] obj)
    {
        float tempY = 0;
        float tempX = 0;

        // stable forward
        if (hMove.y > 0)//Vector2.zero:二维坐标在（0，0）这个位置
            tempY = -Time.fixedDeltaTime;
        else
            if (hMove.y < 0)
                tempY = Time.fixedDeltaTime;

        // stable lurn
        if (hMove.x > 0)
            tempX = -Time.fixedDeltaTime;
        else
            if (hMove.x < 0)
                tempX = Time.fixedDeltaTime;


        foreach (var pressedKeyCode in obj)
        {
            switch (pressedKeyCode)
            {
                case PressedKeyCode.SpeedUpPressed:

                    EngineForce += 0.1f;
                    break;
                case PressedKeyCode.SpeedDownPressed:

                    EngineForce -= 0.12f;
                    if (EngineForce < 0) EngineForce = 0;
                    break;

                case PressedKeyCode.ForwardPressed:

                    if (IsOnGround) break;
                    tempY = Time.fixedDeltaTime;
                    break;
                case PressedKeyCode.BackPressed:

                    if (IsOnGround) break;
                    tempY = -Time.fixedDeltaTime;
                    break;
                case PressedKeyCode.LeftPressed:

                    if (IsOnGround) break;
                    tempX = -Time.fixedDeltaTime;
                    break;
                case PressedKeyCode.RightPressed:

                    if (IsOnGround) break;
                    tempX = Time.fixedDeltaTime;
                    break;
                case PressedKeyCode.TurnRightPressed:
                    {
                        if (IsOnGround) break;
                        var force = (turnForcePercent - Mathf.Abs(hMove.y)) * HelicopterModel.mass;
                        HelicopterModel.AddRelativeTorque(0f, force, 0);
                    }
                    break;
                case PressedKeyCode.TurnLeftPressed:
                    {
                        if (IsOnGround) break;

                        var force = -(turnForcePercent - Mathf.Abs(hMove.y)) * HelicopterModel.mass;
                        HelicopterModel.AddRelativeTorque(0f, force, 0);
                    }
                    break;

            }
        }

        hMove.x += tempX;
        hMove.x = Mathf.Clamp(hMove.x, -1, 1);

        hMove.y += tempY;
        hMove.y = Mathf.Clamp(hMove.y, -1, 1);

    }

    private void OnCollisionEnter()  //碰撞入口
    {
        IsOnGround = true;
    }

    private void OnCollisionExit()   //碰撞出口
    {
        IsOnGround = false;
    }
}
