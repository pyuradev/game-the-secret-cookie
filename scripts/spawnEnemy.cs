using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab;

    [SerializeField] float secondSpawn = 1f;

    [SerializeField] float minTrans;

    [SerializeField] float maxTrans;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnmy());
    }

    IEnumerator spawnEnmy(){
        var wanted = Random.Range(minTrans, maxTrans);
        var position = new Vector3(wanted, transform.position.y);
        GameObject gameObject = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], position, Quaternion.identity);
        yield return new WaitForSeconds(secondSpawn);
        StartCoroutine(spawnEnmy());
    }
}