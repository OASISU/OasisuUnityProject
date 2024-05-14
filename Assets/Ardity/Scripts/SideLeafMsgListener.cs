using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideLeafMsgListener : MonoBehaviour
{
    public Animator animator;
    // AudioSource 컴포넌트에 대한 참조 추가
    public AudioSource audioSource;

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

    // 소환할 Object
    //public GameObject flower;
    public GameObject[] FlowerPrefabs;



    void Start()
    {
        animator = GetComponent<Animator>();
        // AudioSource 컴포넌트를 자동으로 찾아 할당
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }


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


    public void OnMessageArrived(string msg)
    {
        // 애니메이션이 재생 중이 아닐 때만 메시지 처리
        if (animator.GetBool("isAnimationPlaying") == false)
        {
            Debug.Log("Message Arrived: " + msg);

            // isTouched의 현재 값을 반전시켜 애니메이션 상태 변경
            bool isTouched = animator.GetBool("isTouched");
            animator.SetBool("isTouched", !isTouched);

            // 오디오 재생
            if (audioSource != null)
            {
                audioSource.Play();
            }

        }
    }

    public void AnimationStart()
    {
        Debug.Log("Animation has started.");
        animator.SetBool("isAnimationPlaying", true);
    }

    public void AnimationEnd()
    {
        Debug.Log("Animation has ended.");
        animator.SetBool("isAnimationPlaying", false);
    }
}