using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public float speed= 6;
    SpriteRenderer rend;
    Rigidbody2D rg;
    Vector2 move;

private void Start() 
{
    rg = GetComponent<Rigidbody2D>(); 
    rend = GetComponent<SpriteRenderer>();    
}
    void Update()
    {
        move.x = Joystick.JoyVector.x;
        move.y = Joystick.JoyVector.y;
    }
    void FixedUpdate() => rg.MovePosition(rg.position + move * speed * Time.deltaTime);
}
