using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUIOpacity : MonoBehaviour
{
    public CanvasGroup menuCanvasGroup;  // �޴��� CanvasGroup (���� ����)
    public Transform wristTransform;     // �ո�(��Ʈ�ѷ�)�� Transform
    public Transform centerEyeAnchor;   // CenterEyeAnchor Transform
    public float maxAngle = 30f;        // �ִ� ��� ���� (�� ���� �̻��� �� Opacity�� 0)
    public float opacityChangeSpeed = 5f; // Opacity ��ȭ �ӵ�

    void Update()
    {
        // �ո�(��Ʈ�ѷ�)�� forward ����
        Vector3 wristForward = wristTransform.up;

        // �ո񿡼� �����(����) ���� ���
        Vector3 toUserDirection = (centerEyeAnchor.position - wristTransform.position).normalized;

        // �ո� forward�� ����� ���� ������ ���� ���
        float angle = Vector3.Angle(wristForward, toUserDirection);

        // Opacity ��� (������ �������� 1�� �����, maxAngle���� 0�� ��)
        float targetOpacity = Mathf.Clamp01(1 - (angle / maxAngle));

        // CanvasGroup�� Alpha�� ���� �������� ����
        menuCanvasGroup.alpha = Mathf.Lerp(menuCanvasGroup.alpha, targetOpacity, Time.deltaTime * opacityChangeSpeed);

        // Alpha ���� 0.5 ������ �� Interaction ����
        menuCanvasGroup.interactable = menuCanvasGroup.alpha > 0.5f;
    }
}
