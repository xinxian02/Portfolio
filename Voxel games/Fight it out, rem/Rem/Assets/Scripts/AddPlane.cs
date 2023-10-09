using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlane : MonoBehaviour
{

    const float width = 10f;//这里是平面的宽度
    public Transform player;
    Vector3 initPos;
    void Start()
    {
        initPos = transform.position;
    }

    void Update()
    {
        float totalWidth = width * 2f;// * backGroundNum;
        float distZ = player.position.z - initPos.z;//实时计算玩家与插入点的距理
        int n = Mathf.RoundToInt(distZ / totalWidth);//四舍五入一下 

        var pos = initPos;
        pos.z += n * totalWidth;
        transform.position = pos;
    }
}
