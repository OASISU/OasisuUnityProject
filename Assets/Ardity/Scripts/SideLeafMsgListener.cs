using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideLeafMsgListener : MonoBehaviour
{
    private Animator animator;
    // AudioSource 컴포넌트에 대한 참조 추가
    public AudioSource audioSource;
    void Start()
    {
        animator = GetComponent<Animator>();
        // AudioSource 컴포넌트를 자동으로 찾아 할당
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
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
