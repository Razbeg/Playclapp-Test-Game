using UnityEngine;

public class Spawner : MonoBehaviour
{
    private static Spawner instance = null;
    public static Spawner self
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Spawner>();
            return instance;
        }
    }


    [Header("Points")]
    [SerializeField] private Transform spawnPoint = null;
    [SerializeField] private Transform finishPoint = null;


    [Header("Spawn Objects")]
    [SerializeField] private GameObject spawnObject = null;


    [Header("Game Settings")]
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float objectMoveSpeed = 1f;
    [SerializeField] private float objectMoveDistance = 3f;


    public static Transform Transform => self.transform;
    public static Vector3 FinishPoint => self.finishPoint.position;
    public static float SpawnInterval => self.spawnInterval;
    public static float ObjectMoveSpeed => self.objectMoveSpeed;
    public static float ObjectMoveDistance => self.objectMoveDistance;


    private SpawnerPool pool = null;
    private GameObject spawnedObject = null;
    private float interval = 0f;




    private void Start() => pool = new SpawnerPool(spawnObject);

    private void Update()
    {
        interval -= Time.deltaTime;
        if (interval < 0f)
        {
            interval = spawnInterval;

            CreateObject();
        }
    }

    private void CreateObject()
    {
        spawnedObject = pool.GetObject();
        spawnedObject.transform.position = spawnPoint.position;
    }


    public static void SetFinishPoint() => self.finishPoint.transform.position = new Vector3(0f, 0f, self.objectMoveDistance + 0.5f);

    public static void SetSpawnInterval(float spawnInterval) => self.spawnInterval = spawnInterval;
    public static void SetObjectMoveSpeed(float objectMoveSpeed) => self.objectMoveSpeed = objectMoveSpeed;
    public static void SetObjectMoveDistance(float objectMoveDistance) => self.objectMoveDistance = objectMoveDistance;
}
