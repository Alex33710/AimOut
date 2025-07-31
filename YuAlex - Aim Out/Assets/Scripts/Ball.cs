using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyAfter", 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            collision.gameObject.SetActive(false);
            GameManager.Instance.UpdateTargets(1);
            Destroy(gameObject);
        }
    }

    private void DestroyAfter()
    {
        GameManager.Instance.DecreaseHP(1);
        Destroy(gameObject);
    }
}
