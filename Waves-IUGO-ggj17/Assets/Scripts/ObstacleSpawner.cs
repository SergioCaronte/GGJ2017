﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

  public GameObject[] primitives;
  private int objectCount = 60;
  private int counter = 0;
  public Transform player;
  private int maxDistance = 20;
  private List<GameObject> obstacles;
  private float maxSpeed = 0.1f;
  private float maxSpin = 0.5f;
  private float minScale = 1;
  private float maxScale = 10;

  // Use this for initialization
  void Start ()
  {
    obstacles = new List<GameObject>();

    for (int i = 0; i < objectCount; i++)
    {
      SpawnerARandomObstacle();
    }

    InvokeRepeating ("SpawnerARandomObstacle", 1.0f, 5.0f);
  }
	
  void SpawnerARandomObstacle()
  {
    var go = Instantiate(primitives[Random.Range(0, primitives.Length)], new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance)), Quaternion.identity);
    float slc = Random.Range(minScale, maxScale);
    go.transform.localScale = new Vector3(slc, slc, 1);
    go.transform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 360));
    go.transform.parent = transform;

    var body = go.GetComponent<Rigidbody2D> ();
    body.velocity = new Vector2(Random.Range(-maxSpeed, maxSpeed), Random.Range(-maxSpeed, maxSpeed));
    body.angularVelocity = Random.Range(-maxSpin, maxSpin);

    body.drag = 0;
    body.angularDrag = 0;
    obstacles.Add(go);
  }

  void Update()
  {
    ++counter;
    int index = counter % objectCount;
    
    if ((obstacles[index].transform.position - player.position).magnitude > maxDistance)
    {
      if (Random.Range(0.0f, 1.0f) < 0.8f)
      {
        obstacles[index].transform.position = new Vector2(player.position.x + Random.Range(-maxDistance / 2, maxDistance / 2), player.position.y - (maxDistance / 2) - Random.Range(maxDistance / 2, 0));
      }
      else
      {
        obstacles[index].transform.position = new Vector3(player.position.x + Random.Range(-maxDistance / 2, maxDistance / 2), player.position.y + (maxDistance / 2) + Random.Range(0, maxDistance / 2));
      }
      float slc = Random.Range(1, 10);
      obstacles[index].transform.localScale = new Vector3(slc, slc, 1);
      obstacles[index].transform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 360));
      obstacles[index].transform.parent = transform;
    }
  }
}
