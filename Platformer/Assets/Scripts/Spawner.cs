using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour

{

    public GameObject Enemy;
    public float SpawnRate = 1f;

    public float minHeight = -5f;
    public float maxHeight = 5f;

    // Start is called before the first frame update


    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), SpawnRate, SpawnRate);
    }

    // Update is called once per frame
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn(){
        GameObject Bat = Instantiate(Enemy, transform.position, Quaternion.identity);
        Bat.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
