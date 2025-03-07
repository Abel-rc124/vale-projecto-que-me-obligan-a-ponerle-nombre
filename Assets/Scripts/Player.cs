using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int points;



    public float shootInterval;
    public float shootTimer;


    public Transform shootPoints;
    private float fixedY;


    private void Awake()
    {
        fixedY = -4f;
    }

    private void Update()
    {
        Move();

        shootTimer -= Time.deltaTime;
    }

    void Move()
    {
         if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 realPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = new Vector2(realPos.x, fixedY);


        }




    }

  
}
