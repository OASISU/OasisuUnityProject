using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlower : MonoBehaviour
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

    // ��ȯ�� Object
    //public GameObject flower;
    public GameObject[] FlowerPrefabs;

    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            int i = Random.Range(0, 4);
            // ���� ��ġ �κп� ������ ���� �Լ� Return_RandomPosition() �Լ� ����
            GameObject instantCapsul = Instantiate(FlowerPrefabs[i], Return_RandomPosition(), Quaternion.identity);
        }
    }

}
