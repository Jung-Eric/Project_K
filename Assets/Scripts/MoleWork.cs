using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleWork : MonoBehaviour
{
    
    private float moleSpeed;

    private float positionX;

    private float positionY;

    private bool direction;

    public bool moleAvail;

    public DooGameController controller;

    private SpriteRenderer render;

    private Rigidbody2D rb;

    private float jumpDelayTimer;

    public float waitingUnderTime;

    public float waitingAboveTime;

    public float nowElapsedTimer;
    
    enum moleMode
    {
        waitingUnder,
        goingUp,
        waitingAbove,
        goingDown,

    }

    private moleMode nowMoleMode;

    void Awake()
    {
        moleSpeed = 3f;

        positionY = transform.position.y;

        jumpDelayTimer = 4f;

    }

    void Start()
    {
        positionX = transform.position.x;

        waitingAboveTime = randomAboveTime();

        waitingUnderTime = randomUnderTime();

        render = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (moleAvail)
        {
            moveVertical();
        }

        
    }

    public void moveVertical()
    {

        if(nowMoleMode == moleMode.goingDown)
        {

            positionY = positionY - moleSpeed * Time.deltaTime;

            if(positionY < -3)
            {

                nowMoleMode = moleMode.waitingUnder;

                nowElapsedTimer = randomUnderTime();

            }

        }
        else if(nowMoleMode == moleMode.waitingUnder)
        {
            resetMole();

            nowElapsedTimer = nowElapsedTimer - Time.deltaTime;

            if(nowElapsedTimer < 0)
            {
                nowElapsedTimer = 0f;

                nowMoleMode = moleMode.goingUp;
            }
        }
        else if(nowMoleMode == moleMode.goingUp)
        {
            positionY = positionY + moleSpeed * Time.deltaTime;

            if (positionY > 3)
            {

                nowMoleMode = moleMode.waitingAbove;

                nowElapsedTimer = randomAboveTime();

            }
        }
        else if(nowMoleMode == moleMode.waitingAbove)
        {
            nowElapsedTimer = nowElapsedTimer - Time.deltaTime;

            if (nowElapsedTimer < 0)
            {
                nowElapsedTimer = 0f;

                nowMoleMode = moleMode.goingDown;
            }
        }

            /*
            if (positionY > 3)
            {
                direction = false;
            }
            else if (positionY < -3)
            {
                jumpDelayTimer = jumpDelayTimer - Time.deltaTime;

                if (jumpDelayTimer < 0)
                {

                    direction = true;

                }

            }

            if (direction)
            {
                positionY = positionY + moleSpeed * Time.deltaTime;
            }
            else
            {
                positionY = positionY - moleSpeed * Time.deltaTime;
            }
            */

            transform.position = new Vector3(positionX, positionY, 0);
    }

    public void getClick()
    {

        nowMoleMode = moleMode.goingDown;

        render.color = new Color(1,0,0,1);

        controller.catchMole();
        
    }

    public void resetMole()
    {
        render.color = new Color(1, 1, 1, 1);
    }
    public void setAvail(bool tempBool)
    {
        moleAvail = tempBool;

    }

    public float randomAboveTime()
    {
        return Random.Range(0.2f, 0.5f);
    }

    public float randomUnderTime()
    {
        return Random.Range(0.5f, 3f);
    }

    public void moleDelay()
    {

    }
  

}
