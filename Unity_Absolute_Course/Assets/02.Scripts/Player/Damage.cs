using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private const string bulletTag = "BULLET";
    private const string enemyTag = "ENEMY";

    private float iniHP = 100.0f;
    private float currHP;

    //델리게이트 및 이벤트 선언
    public delegate void PlayerDieHandler();
    public static event PlayerDieHandler OnPlayerDie;

    // Start is called before the first frame update
    void Start()
    {
        currHP = iniHP;
    }

    //충돌한 Collider의 IsTrigger 옵션이 체크됐을 때 발생
    void OnTriggerEnter(Collider coll)
    {
        //충돌한 Collider의 태그가 BULLET이면 Player의 currHP를 차감
        if(coll.tag == bulletTag)
        {
            Destroy(coll.gameObject);

            currHP -= 5.0f;
            Debug.Log("Plater HP = " + currHP.ToString());

            //Player의 생명이 0 이하이면 사망 처리
            if(currHP <= 0.0f)
            {
                PlayerDie();
            }
        }
    }

    //Player의 사망 처리 루틴
    void PlayerDie()
    {
        OnPlayerDie();
        //Debug.Log("PlayerDie !");
        ////"ENEMY" 태그로 지정된 모든 적 캐릭터를 추출해 배열에 저장
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        //
        ////배열 청므부터 순회하면서 적 캐릭터의 OnPlayerDie함수를 호출
        //for (int i = 0; i < enemies.Length; i++)
        //{
        //    enemies[i].SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);
        //}
    }
}
