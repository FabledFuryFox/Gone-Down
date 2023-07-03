using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float angle;

    public Camera cam;

    public Rigidbody2D rB;
    public GameObject EndofBarrel;

    Vector2 movement;
  public  Vector2 mousePos;
    


    void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");

       mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rB.MovePosition(rB.position + movement * moveSpeed * Time.fixedDeltaTime);
        
        if (3 > Vector2.Distance(mousePos, (Vector2)EndofBarrel.transform.position))
        {
            Vector2 lookDir2 = mousePos - rB.position;
             angle = Mathf.Atan2(lookDir2.y, lookDir2.x) * Mathf.Rad2Deg;
           
        }
        else
        {
           
            Vector2 lookDir = mousePos - (Vector2)EndofBarrel.transform.position;
            angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        }
       
        rB.rotation = angle;
    }
}
