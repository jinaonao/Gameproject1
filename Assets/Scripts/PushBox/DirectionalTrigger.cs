using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalTrigger : MonoBehaviour
{
    public bool isObstructed = false;  //  «∑Ò”–’œ∞≠ŒÔ

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BoxObstacle") || other.CompareTag("PushBox"))
        {
            isObstructed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("BoxObstacle") || other.CompareTag("PushBox"))
        {
            isObstructed = false;
        }
    }
}
