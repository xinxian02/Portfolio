using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
//(1)冒号表示继承关系；(2)继承构造
{
    [Header("Options")]
    [Range(0f, 2f)]
    public float handleLimit = 1f;
    public JoystickMode joystickMode = JoystickMode.AllAxis;

    protected Vector2 inputVector = Vector2.zero;

    [Header("Components")]
    public RectTransform background;
    public RectTransform handle;

    public float Horizontal { get { return inputVector.x; } }
    public float Vertical { get { return inputVector.y; } }
    public Vector2 Direction { get { return new Vector2(Horizontal, Vertical); } }
    //public Vector2(float x, float y):构造具有给定x，y分量的新向量 

    public virtual void OnDrag(PointerEventData eventData)
    {
        //当出现拖放时，这将在每次移动游标时调用。 
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {

    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {

    }

    protected void ClampJoystick()
    {
        if (joystickMode == JoystickMode.Horizontal)
            inputVector = new Vector2(inputVector.x, 0f);
        if (joystickMode == JoystickMode.Vertical)
            inputVector = new Vector2(0f, inputVector.y);
    }
}

public enum JoystickMode { AllAxis, Horizontal, Vertical }
