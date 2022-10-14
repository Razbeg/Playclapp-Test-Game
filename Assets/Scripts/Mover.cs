using UnityEngine;

public class Mover : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.z > Spawner.FinishPoint.z)
            gameObject.SetActive(false);

        transform.Translate(Vector3.forward * Spawner.ObjectMoveSpeed * Time.deltaTime);
    }
}
