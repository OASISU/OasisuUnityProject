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
    public List<GameObject> spawnedFlowers = new List<GameObject>();  // 생성된 꽃을 저장할 리스트



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
        yield return new WaitForSeconds(1f); // 1초 기다린 후에 실행
        int i = Random.Range(0, FlowerPrefabs.Length); // 꽃 프리팹 배열의 길이를 기준으로 랜덤 인덱스 생성
        GameObject flower = Instantiate(FlowerPrefabs[i], Return_RandomPosition(), Quaternion.identity);
        spawnedFlowers.Add(flower); // 생성된 꽃을 리스트에 추가
    }
    public void DeleteAllSpawnedFlowers()
    {
        foreach (GameObject flower in spawnedFlowers)
        {
            Destroy(flower);
        }
        spawnedFlowers.Clear();  // 리스트를 비웁니다.
    }

}