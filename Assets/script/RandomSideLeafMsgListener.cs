using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSideLeafMsgListener : MonoBehaviour
{
    // Plane�� �ڽ��� RespawnRange ������Ʈ
    public GameObject rangeObject;
    BoxCollider rangeCollider;

    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider>();

    }
    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeCollider.bounds.center;
        // �ݶ��̴��� ����� �������� bound.size ���
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }

    //�� ������Ʈ
    public GameObject[] FlowerPrefabs;
    public List<GameObject> spawnedFlowers = new List<GameObject>();  // ������ ���� ������ ����Ʈ



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
        yield return new WaitForSeconds(1f); // 1�� ��ٸ� �Ŀ� ����
        int i = Random.Range(0, FlowerPrefabs.Length); // �� ������ �迭�� ���̸� �������� ���� �ε��� ����
        GameObject flower = Instantiate(FlowerPrefabs[i], Return_RandomPosition(), Quaternion.identity);
        spawnedFlowers.Add(flower); // ������ ���� ����Ʈ�� �߰�
    }
    public void DeleteAllSpawnedFlowers()
    {
        foreach (GameObject flower in spawnedFlowers)
        {
            Destroy(flower);
        }
        spawnedFlowers.Clear();  // ����Ʈ�� ���ϴ�.
    }

}