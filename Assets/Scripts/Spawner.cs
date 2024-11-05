using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObj());
    }

    IEnumerator SpawnObj()
    {
        int xPos = 0;
        int temp = Random.Range(0,2);
        if (temp == 0)
            xPos = -3;
        else
            xPos = 3;

        Instantiate(obstacles[Random.Range(0,obstacles.Length)], new Vector3(xPos, 1, player.position.z + 100) , Quaternion.identity);
        yield return new WaitForSeconds(3);
        StartCoroutine(SpawnObj());
    }

}
