using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLocation : MonoBehaviour
{
    public List<GameObject> spawnList;
    public List<float> spawnTimes;
    private float timeElapsed = 0;
    void Update()
    {
        for (int i = 0; i < spawnList.Count; i++) {
            if (0f < spawnTimes[i] - timeElapsed && spawnTimes[i] - timeElapsed < 0.1f) {
                Instantiate(spawnList[i], transform.position,transform.rotation);
                spawnList.RemoveAt(i);
                spawnTimes.RemoveAt(i);
            }
        }
        timeElapsed += Time.deltaTime;
    }
}
