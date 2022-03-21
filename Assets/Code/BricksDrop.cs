using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksDrop : MonoBehaviour
{
    private void Update()
    {
        EmptyLine();
    }
    public void Drop()
    {
        transform.position += new Vector3(0, -0.7f, 0);
        if (transform.position.y < -5.58f && hasBricks)
            Debug.Log("Danger");
        if (transform.position.y < -6.28f && hasBricks)
            Debug.Log("Fail");
    }
    private void EmptyLine()
    {
        if (transform.childCount == 0)
            Destroy(gameObject);
    }
    private bool hasBricks => transform.GetComponentInChildren<Brick>() ? true : false;
}
