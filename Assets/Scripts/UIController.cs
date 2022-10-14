using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("Input Fields")]
    [SerializeField] private TMP_InputField spawnInterval = null;
    [SerializeField] private TMP_InputField objectMoveSpeed = null;
    [SerializeField] private TMP_InputField objectMoveDistance = null;


    [Header("Cautions")]
    [SerializeField] private GameObject wrongSpawnInterval = null;
    [SerializeField] private GameObject wrongMoveSpeed = null;
    [SerializeField] private GameObject wrongMoveDistance = null;




    private void Start()
    {
        spawnInterval.text = Spawner.SpawnInterval.ToString();
        objectMoveSpeed.text = Spawner.ObjectMoveSpeed.ToString();
        objectMoveDistance.text = Spawner.ObjectMoveDistance.ToString();
    }


    public void Submit()
    {
        if (float.TryParse(spawnInterval.text, out var spawnIntervalValue))
        {
            if (spawnIntervalValue < 0.1f)
            {
                spawnIntervalValue = 0.1f;
                spawnInterval.text = spawnIntervalValue.ToString();
            }

            wrongSpawnInterval.SetActive(false);
            Spawner.SetSpawnInterval(spawnIntervalValue);
        }
        else
            wrongSpawnInterval.SetActive(true);

        if (float.TryParse(objectMoveSpeed.text, out var objectMoveSpeedValue))
        {
            if (objectMoveSpeedValue < 0.1f)
            {
                objectMoveSpeedValue = 0.1f;
                objectMoveSpeed.text = objectMoveSpeedValue.ToString();
            }

            wrongMoveSpeed.SetActive(false);
            Spawner.SetObjectMoveSpeed(objectMoveSpeedValue);
        }
        else
            wrongMoveSpeed.SetActive(true);

        if (float.TryParse(objectMoveDistance.text, out var objectMoveDistanceValue))
        {
            if (objectMoveDistanceValue < 2f)
            {
                objectMoveDistanceValue = 2f;
                objectMoveDistance.text = objectMoveDistanceValue.ToString();
            }

            wrongMoveDistance.SetActive(false);
            Spawner.SetObjectMoveDistance(objectMoveDistanceValue);
        }
        else
            wrongMoveDistance.SetActive(true);
    }
}
