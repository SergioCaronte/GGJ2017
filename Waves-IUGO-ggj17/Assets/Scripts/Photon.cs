﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photon : MonoBehaviour
{
  private SpriteRenderer sprite;
  private Rigidbody2D rb;
  private float alpha;
  private float lifeSpan;
  private Vector3 color;

  private void Awake()
  {
    color = new Vector3(0, 0, 0);
    sprite = GetComponent<SpriteRenderer>();
    rb = GetComponent<Rigidbody2D>();
    sprite.color = new Color(color.x, color.z, color.y, alpha);
  }

  private void Update()
  {
    alpha -= Time.deltaTime * 1.0f/lifeSpan;
    sprite.color = new Color(color.x, color.z, color.y, alpha);
  }

  public void Setup(Vector2 dir, float _lifeSpan, float speed)
  {
    lifeSpan = _lifeSpan;
    rb.velocity = dir.normalized * speed;
    Invoke("Die", lifeSpan);
    alpha = 1.0f;
  }

  public void OnCollisionEnter2D(Collision2D collision)
  {
    float r = Random.Range(0.0f, 1.0f);
    if (r > 0.7f)
    {
      color = new Vector3(0, 0.6f, 0);
      rb.velocity = Vector2.zero; // -collision.relativeVelocity.normalized;
    }
  }

  // Update is called once per frame
  void Die()
  {
    Destroy(gameObject);
	}
}