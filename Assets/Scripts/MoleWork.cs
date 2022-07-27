using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleWork : MonoBehaviour
{
    
    private float moleSpeed;

    private float positionY;

    private bool direction;

    public bool moleAvail;

    public DooGameController controller;

    private SpriteRenderer render;

    private Rigidbody2D rb;
    

    void Awake()
    {
        moleSpeed = 3f;

        positionY = transform.position.y;
    }

    void Start()
    {
        render = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        getClick();

        if (moleAvail)
        {
            moveVertical();
        }

        
    }

    public void moveVertical()
    {
        if (positionY > 3)
        {
            direction = false;
        }
        else if (positionY < -3)
        {
            direction = true;
        }

        if (direction)
        {
            positionY = positionY + moleSpeed * Time.deltaTime;
        }
        else
        {
            positionY = positionY - moleSpeed * Time.deltaTime;
        }

        transform.position = new Vector3(0, positionY, 0);
    }

    public void getClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            render.color = new Color(1,0,0,1);

            direction = false;

            controller.catchMole();
        }
    }

    public void setAvail(bool tempBool)
    {
        moleAvail = tempBool;
    }

   
}
