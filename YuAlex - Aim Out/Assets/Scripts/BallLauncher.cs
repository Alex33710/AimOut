using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public Transform ShootPoint;
    public GameObject Ball;
    public float force = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shootBallsContinuously());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator shootBallsContinuously()
    {
        while (true)
        {
            int waitTime = Random.Range(2, 10);

            yield return new WaitForSeconds(waitTime);

            GameObject obj = Instantiate(Ball, ShootPoint.position, Quaternion.identity);
            obj.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
