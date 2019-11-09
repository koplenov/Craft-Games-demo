using System.Collections;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyPerTime());
    }

    private void Update()
    {
        transform.Rotate(1.0f, 2.0f, 0.5f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" )
        {
            ScoresManager.Instance.AddCounter();
            this.GetComponent<BoxCollider>().isTrigger = true;
            Destroy(this.gameObject);
        }
    }

    private IEnumerator DestroyPerTime()
    {

        yield return new WaitForSeconds(1.0f);
        this.gameObject.AddComponent<Rigidbody>();// Простая анимация падения  ¯\_(ツ)_/¯

        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }
}
