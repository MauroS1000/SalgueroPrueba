using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnOverPlayer : MonoBehaviour
{
    public float maxSpawnOffset;
    public float timeToSpawn;
    private float currentTime;
    public GameObject player;
    public GameObject starPrefab;

    private void Start()
    {
        currentTime = timeToSpawn;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime < Mathf.Epsilon) 
        {
            currentTime = timeToSpawn;
            SpawnStars();
        }
    }

    Vector3 GetRandomPositionOverPlayer() 
    {
        if (!player)
            return Vector3.zero;
        float currentXPos = player.transform.position.x;
        float randomNearPlayerXPos = currentXPos +Random.Range(-maxSpawnOffset, +maxSpawnOffset);
        return new Vector3(randomNearPlayerXPos, transform.position.y, transform.position.z);
    }
    private void SpawnStars()
    {
        if (starPrefab != null)
        {
            GameObject starInstance = Instantiate(starPrefab);
            starInstance.transform.position = GetRandomPositionOverPlayer();
        }
    }
}
