using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksDrop : MonoBehaviour
{
    public void Drop()
    {
        transform.position += new Vector3(0, -0.7f, 0);
    }
}
