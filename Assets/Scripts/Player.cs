using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;

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
            //transform.position = new Vector2(realPos.x, fixedY);
            StopAllCoroutines();
            StartCoroutine(MoveGradually(realPos));
        }
      
        

    }

    private IEnumerator MoveGradually(Vector2 _target_position)
    {
        float distance = Mathf.Abs(transform.position.x - _target_position.x);
        
        while (distance > 0.2f)
        {
            yield return new WaitForFixedUpdate();

            if (transform.position.x > _target_position.x) 
            {
                transform.position = new Vector2(transform.position.x - 0.2f, fixedY);
            }
            else
            {
                transform.position = new Vector2(transform.position.x + 0.2f, fixedY);
            }
            distance = Mathf.Abs(transform.position.x - _target_position.x);
        }
        transform.position = new Vector2(_target_position.x , fixedY);


    }
}
