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
        {
            Debug.Log("Danger");

        }
        if (transform.position.y < -6.8f && hasBricks)
        {
            FindObjectOfType<UIGameScene>().ShowFailPanel();
        }
    }
    private void EmptyLine()
    {
        if (transform.childCount == 0)
            Destroy(gameObject);
    }
    private bool hasBricks => transform.GetComponentInChildren<Brick>() ? true : false;
}
