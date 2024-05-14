using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSideLeafMsgListener : MonoBehaviour
{
    // Plane의 자식인 RespawnRange 오브젝트
    public GameObject rangeObject;
    BoxCollider rangeCollider;

    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider>();

    }
    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeCollider.bounds.center;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }

    //꽃 오브젝트
    public GameObject[] FlowerPrefabs;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMessageArrived(string msg)
    {
        Debug.Log("Message Arrived: " + msg);
        StartCoroutine(RandomRespawn_Coroutine());

    }

    IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            int i = Random.Range(0, 4);
            // 생성 위치 부분에 위에서 만든 함수 Return_RandomPosition() 함수 대입
            GameObject instantCapsul = Instantiate(FlowerPrefabs[i], Return_RandomPosition(), Quaternion.identity);
        }
    }


}