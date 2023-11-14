using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float pushDistance = 1.0f; // Ҫ�ƶ��ľ���

    private float collisionTime = 0f; // ��ʱ��
    private bool isPlayerColliding = false; // �Ƿ����ҷ�����ײ
    private const float REQUIRED_COLLISION_TIME = 0.1f; // �����Ҫ��ײ��ʱ�䳤��
    public DirectionalTrigger upTrigger;
    public DirectionalTrigger downTrigger;
    public DirectionalTrigger leftTrigger;
    public DirectionalTrigger rightTrigger;

    private void Update()
    {
        // ��������ײ�����Ҽ�ʱ�����������ʱ��
        if (isPlayerColliding && collisionTime > REQUIRED_COLLISION_TIME)
        {
            Vector2 pushDirection = DeterminePushDirection();

            if (pushDirection != Vector2.zero)  // ����Ƿ��п��ƶ��ķ���
            {
                StartCoroutine(MoveToNextPosition(pushDirection));
            }

            isPlayerColliding = false; // ����
            collisionTime = 0f;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerColliding = true;
            collisionTime += Time.deltaTime; // ���Ӽ�ʱ����ʱ��
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerColliding = false; // ����
            collisionTime = 0f;
        }
    }

    private Vector2 DeterminePushDirection()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 directionToPlayer = playerTransform.position - transform.position;
        Vector2 pushDirection = Vector2.zero;

        // ���������������ӵ�λ�þ����ƶ�����
        if (Mathf.Abs(directionToPlayer.x) > Mathf.Abs(directionToPlayer.y))
        {
            if (directionToPlayer.x > 0 && !IsDirectionObstructed(Vector2.left))
            pushDirection = Vector2.left;
        else if (directionToPlayer.x < 0 && !IsDirectionObstructed(Vector2.right))
            pushDirection = Vector2.right;
        }
        else
        {
            if (directionToPlayer.y > 0 && !IsDirectionObstructed(Vector2.down))
                pushDirection = Vector2.down;
            else if (directionToPlayer.y < 0 && !IsDirectionObstructed(Vector2.up))
                pushDirection = Vector2.up;
        }

        return pushDirection;
    }

    private bool IsDirectionObstructed(Vector2 direction)
    {
        DirectionalTrigger triggerToCheck = null;

        if (direction == Vector2.up)
            triggerToCheck = upTrigger;
        else if (direction == Vector2.down)
            triggerToCheck = downTrigger;
        else if (direction == Vector2.left)
            triggerToCheck = leftTrigger;
        else if (direction == Vector2.right)
            triggerToCheck = rightTrigger;

        if (triggerToCheck != null)
        {
            return triggerToCheck.isObstructed;
        }

        return false; // Ĭ�����������û���ϰ���
    }


    private System.Collections.IEnumerator MoveToNextPosition(Vector2 pushDirection)
    {
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = startPosition + pushDirection * pushDistance;
        float journeyLength = Vector2.Distance(startPosition, targetPosition);
        float startTime = Time.time;

        float distanceCovered = 0;
        while (distanceCovered < journeyLength)
        {
            distanceCovered = (Time.time - startTime) * pushDistance;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector2.Lerp(startPosition, targetPosition, fractionOfJourney);

            yield return null;
        }
        transform.position = targetPosition; // ȷ����ȷ�ƶ���Ŀ��λ��
    }
}