using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;
using TMPro;

public class Player : MonoBehaviour
{
    public int points;

    public float shootInterval;
    public float shootTimer;
    public GameObject projectilePrefab;

    public Transform shootPoints;

    private float fixedY;
    private const float MIN_X = -2.7f;
    private const float MAX_X = 2.7f;

    public AudioSource source;

    int contador = 0;


    private void Awake()
    {
        fixedY = -4f;
        source = GetComponent<AudioSource>();
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "eSTRELLA")
        {
            Destroy(collision.gameObject);

        
            contador++;
            label.text = contador.ToString();

        }

    }
    public TextMeshProUGUI label;
    private void OnAnimatorIK(int layerIndex)
    {
        
    }


    private void Update()
    {
        Move();

        shootTimer -= Time.deltaTime;
        Shoot();
    }


    void Move()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 realPos = Camera.main.ScreenToWorldPoint(mousePos);

            if (realPos.x > MIN_X && realPos.x < MAX_X) 
            {
                StopAllCoroutines();
                StartCoroutine(MoveGradually(realPos));

            }

     
            
        }



    }
    void Shoot()
    {
        if (Input.GetMouseButton(0) && shootTimer <= 0)
        {
            shootTimer = 0.3f;
            source.Play();
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
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
