using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObject : MonoBehaviour
{
    [SerializeField] GameObject[] fruitPrefab;

    [SerializeField] float secondSpawn = 1f;

    [SerializeField] float minTrans;

    [SerializeField] float maxTrans;

    public static float destroyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnFruit());
    }

    IEnumerator spawnFruit(){
        var wanted = Random.Range(minTrans, maxTrans);
        var position = new Vector3(wanted, transform.position.y);
        GameObject gameObject = Instantiate(fruitPrefab[Random.Range(0, fruitPrefab.Length)], position, Quaternion.identity);
        yield return new WaitForSeconds(secondSpawn);
        Destroy(gameObject, destroyCount);
        StartCoroutine(spawnFruit());
    }

    void Update(){
        if(scoreManager.bossDie){
            Destroy(gameObject);
        }
    }
}