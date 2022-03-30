using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject sample;
    [SerializeField] private float interval;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0f, interval);
    }

    private void Spawn()
    {
        float y = Random.Range(-1.1f, 0.8f);
        GameObject clone = Instantiate(sample);
        clone.transform.position = new Vector3(transform.position.x, y, 0);
    }
}
