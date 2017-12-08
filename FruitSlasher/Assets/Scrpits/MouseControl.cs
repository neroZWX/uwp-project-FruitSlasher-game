using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour {
    [SerializeField]
    public AudioSource audioSource;
    [SerializeField]
   private  LineRenderer lineRenderer;
    //是否鼠标第一次按下
    private bool firstMouseDown = false;
    //是否鼠标一直按下
    private bool mouseDown = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            firstMouseDown = true;
            mouseDown = true;
            audioSource.Play();
        }
        if (Input.GetMouseButtonUp(0)) {
            mouseDown = false;
        }
        onDrawLine();
        firstMouseDown = false;//只需要检查鼠标点击一瞬间 然后就可以关闭
    }
    //保存的所有的坐标
    private Vector3[] positions = new Vector3[10];//已经设置为10再Unity上面
    //当前保存的坐标数量
    private int posCount = 0;
    private Vector3 head;//代表这一帧的鼠标位置
    private Vector3 last;//代表上一帧的位置

    

    private void onDrawLine() {//控制画线
        if (firstMouseDown)
        {
            //先把计数器设为0
            posCount = 0;
            head = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            last = head;
        }
        
        if (mouseDown) {
            head = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(head, last) > 0.01f) {
                //如果距离远了 就保存到数组里面
                savePosition(head);
                posCount++;
                //发射一条射线
                onRayCast(head);
            }
            last = head;//需要先保存last当完成上一步骤的时候
        }
        else
        {
            this.positions = new Vector3[10];//当鼠标不安的时候 重新创建一个画线，就是让上次画线消失
        }
        changePositions(positions);
    }
    private void onRayCast(Vector3  worldPos) {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        //检测到所有的物体
        RaycastHit[] hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++) {
            hits[i].collider.gameObject.SendMessage("OnCut", SendMessageOptions.DontRequireReceiver);
        }


    }
   

    //保存坐标点
    private void savePosition(Vector3 pos) {
        pos.z = 0;//鼠标的坐标要和Z坐标一样
        if (posCount <= 9) {
            for (int i = posCount; i < 10; i++) 
                positions[i] = pos;
            }
            else {
            for (int i = 0; i < 9; i++)
                positions[i] = positions[i + 1];
            positions[9] = pos;
        }
        }
    private void changePositions(Vector3[] positions) {
        lineRenderer.SetPositions(positions);
    }
    }
    

