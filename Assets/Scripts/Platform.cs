using UnityEngine;

public class Platform : MonoBehaviour
{
    private float length = 3f;




    private void Update()
    {
        if (length == Spawner.ObjectMoveDistance)
            return;

        length = Spawner.ObjectMoveDistance;

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, length + 1f);
        Spawner.SetFinishPoint();
    }
}
