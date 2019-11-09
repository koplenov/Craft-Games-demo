using System.Collections;
using UnityEngine;

public class GenPlit : MonoBehaviour
{
    public Transform RodokPlitka;
    public GameObject PrefabPlitki;
    public GameObject Cristall;
    public bool CanGen = true;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player" & CanGen)
        {
            if (Random.Range(0f, 1f) > 0.5f) //Куда повернешь?)
                Instantiate(PrefabPlitki, new Vector3(transform.position.x - transform.lossyScale.x, 0, transform.position.z), Quaternion.Euler(new Vector3(0, 90, 0)), RodokPlitka);
            else
                Instantiate(PrefabPlitki, new Vector3(transform.position.x, 0, transform.position.z - transform.lossyScale.z), Quaternion.Euler(new Vector3(0, 90, 0)), RodokPlitka);

            Vector3 offset = new Vector3(Random.Range(0.1f, 0.6f), 0, Random.Range(0.1f, 0.6f));
            if(Random.Range(0, 100) < 20)
                Instantiate(Cristall, new Vector3(transform.position.x, 0.5f, transform.position.z) - offset, Quaternion.Euler(new Vector3(30, 45, 30)), RodokPlitka);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
            StartCoroutine(DestroyPerTime());
    }

    private IEnumerator DestroyPerTime()
    {
        CanGen = false;
        yield return new WaitForSeconds(0.2f);
        this.gameObject.AddComponent<Rigidbody>();// Простая анимация падения  ¯\_(ツ)_/¯

        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }
}
