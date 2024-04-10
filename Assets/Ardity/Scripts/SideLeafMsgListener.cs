using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideLeafMsgListener : MonoBehaviour
{
    private Animator animator;
    // AudioSource ������Ʈ�� ���� ���� �߰�
    public AudioSource audioSource;
    void Start()
    {
        animator = GetComponent<Animator>();
        // AudioSource ������Ʈ�� �ڵ����� ã�� �Ҵ�
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void OnMessageArrived(string msg)
    {
        // �ִϸ��̼��� ��� ���� �ƴ� ���� �޽��� ó��
        if (animator.GetBool("isAnimationPlaying") == false)
        {
            Debug.Log("Message Arrived: " + msg);

            // isTouched�� ���� ���� �������� �ִϸ��̼� ���� ����
            bool isTouched = animator.GetBool("isTouched");
            animator.SetBool("isTouched", !isTouched);

            // ����� ���
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
