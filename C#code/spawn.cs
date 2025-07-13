using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public Transform[] spawnpoint;
    public GameObject enemyprefad;
    public float respawninterval = 5f;
    public int[] index = { 5, 4, 3, 2};
    private int runindex = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (runindex < index.Length)
                {
                int currentindex = index[runindex];
                List<Transform> availablepoint = new List<Transform>(spawnpoint);    


                for (int i = 0; i < currentindex; i++)
                {
                    int randompoint = Random.Range(0, availablepoint.Count);
                    Instantiate(enemyprefad, availablepoint[randompoint].position, Quaternion.identity);

                    availablepoint.RemoveAt(randompoint);
                }



                yield return new WaitForSeconds(respawninterval);

                runindex++;
                if (runindex == 4)
                    runindex = 0;
            }
        }
}