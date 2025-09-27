using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruits;
    public float spawnRate = 1f;
   // [SerializeField] AudioClip FruitFalling;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFruit", 1f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnFruit()
    {
        GameObject OneFruit;
        int randomIndex = Random.Range(0, fruits.Length);
        OneFruit = Instantiate(fruits[randomIndex], new Vector2(Random.Range(-100f, 100f), 60f), Quaternion.identity);
       // SoundManager.instance.playSound(FruitFalling);
    }
}
