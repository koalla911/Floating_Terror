using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progectile : MonoBehaviour
{
    [SerializeField] private float speed = 100f;

    public Vector2 Direction { get; set; }
}
