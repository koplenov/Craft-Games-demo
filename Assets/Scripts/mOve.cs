using UnityEngine;
using UnityEngine.SceneManagement;

public class mOve : MonoBehaviour
{
    public float speed = 0.0f;
    private bool isRight = false;

    public Vector3 direction;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Turn();
    }
    void LateUpdate()
    {
        if (transform.position.y <= -1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void FixedUpdate()
    {
        transform.Translate(direction.normalized * speed);
    }

    void Turn()
    {
        if (isRight)
        {
            direction = new Vector3(-1, 0, 0) * speed;
            isRight = !isRight;
        }
        else
        {
            direction = new Vector3(0, 0, -1) * speed;
            isRight = !isRight;
        }
    }
}
