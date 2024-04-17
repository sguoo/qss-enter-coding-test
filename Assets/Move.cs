using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    public Transform gameObject; //이동하려는 객체 지정을 위한 변수 선언
    public float speed; //속도 지정을 위한 변수 선언
    public Transform target; //피하려는 객체 지정을 위한 변수 선언
    private Vector2 scale; //피하려는 개체의 스케일측정을 위한 변수 선언
    private Vector2 myPosition; //피해야하는 객체를 만났을때 움직일 위치를 저장할 변수 선언
    private Vector2 myScale; //내 스케일 측정을 위한 변수 선언

    private void Start()
    {
        scale = target.lossyScale / 2; //크기를 알기위해 스케일 반으로 나눔
	myScale = gameObject.lossyScale / 2; // scale만으로는 square의 중심만 안들어가니까 전체가 안들어가기 위해 내 scale을 반으로 나눔
        myPosition = new  Vector2(0f, transform.position.y + scale.y + myScale.y); //y좌표가 같으니까 y좌표를 scale변수로 피해야하는 객체위로 설정

    }

    private void Update()
    {
        myPosition.x = transform.position.x; //x좌표는 그대로여야 하기 때문에 업데이트에 내 x좌표 입력
        if (transform.position.x > scale.x + myScale.x | transform.position.x < -scale.x - myScale.x) //x좌표가 Box C의 좌표는 0, 0, 0이기 때문에 반으로 나눈 값은 변의 반의 길이가 됨 + 내 중심으로부터 변의 반을 더하면 전체가 안들어갈때 실행 
        {
            transform.position = Vector2.MoveTowards(transform.position, gameObject.position, speed * Time.deltaTime); //gameObject의 위치로 천천히 움직임
        }
        else
        {
             if (transform.position.y != myPosition.y) //target의 맨 위 변이 내 y좌표와 같지 않을때 실행
                   transform.position = Vector2.MoveTowards(transform.position, myPosition, speed * Time.deltaTime); //target의 맨 위 변 + 내 변의 반 이동
             else
                 transform.Translate(new Vector2(gameObject.position.x,0) * speed * Time.deltaTime); //y좌표가 같을때 오른쪽으로 이동
        }
    }

    

}
