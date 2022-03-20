using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float force;
    [SerializeField] private Text textBalls;
    public int balls;
    public List<GameObject> ballList = new List<GameObject>();
    private RaycastHit2D ray;
    private float angle;
    private LineRenderer lr;
    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        ChangeTextBalls();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (IsShooting())
            {
                ShowLine();
                BallLook();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (IsShooting())
            {
                if (angle > 10 && angle < 170)
                {
                    StartCoroutine(ShootBall());
                    lr.enabled = false;
                }
            }
        }
    }
    private void ShowLine()
    {
        lr.enabled = true;

        ray = Physics2D.Raycast(transform.position, transform.right);
        Debug.DrawRay(transform.position, transform.right * ray.distance, Color.red);
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, ray.point);
        Vector2 poss = Vector2.Reflect(new Vector3(ray.point.x, ray.point.y) - transform.position, ray.normal);
        lr.SetPosition(2, ray.point + poss.normalized * 2);
    }
    private void BallLook()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    public void ClearList()
    {
        ballList.Clear();
    }
    private void ChangeTextBalls()
    {
        textBalls.text = "x" + balls.ToString();
    }
    private bool IsShooting() => ballList.Count == 0 ? true : false;
    public void ShowSpawner()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        ChangeTextBalls();
    }
    private IEnumerator ShootBall()
    {
        for (int i = 0; i < balls; i++)
        {
            yield return new WaitForSeconds(0.1f);
            GameObject newBall = Instantiate(ballPrefab, gameObject.transform.position, Quaternion.identity);
            ballList.Add(newBall);
            newBall.GetComponent<Rigidbody2D>().AddForce(transform.right * force);
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
