using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float runSpeedHorizontal = 0;
    float runSpeedVertical = 0;

    public float maxSpeed = 20.0f;
    public float force = .5f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool keyD = Input.GetKey(KeyCode.D);
        bool keyA = Input.GetKey(KeyCode.A);

        bool keyW = Input.GetKey(KeyCode.W);
        bool keyS = Input.GetKey(KeyCode.S);

        if (keyD || keyA)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal"); // return 1 or -1

            if(horizontal == 1 && horizontalInput == -1 && runSpeedHorizontal > 1f) // pokud se snažíme změnit směr ale rychlost je stále velká
            {
                runSpeedHorizontal = System.Math.Max(runSpeedHorizontal - force, 0); // snížíme rychlost
                return;
            } else if (horizontal == 1 && horizontalInput == -1 && runSpeedHorizontal < 1f) // pokud máme dostatečně nízkou rychlost na pohyb na druhou stranu
            {
                horizontal = -1; // změna směru na druhou stranu
            }

            if (horizontal == -1 && horizontalInput == 1 && runSpeedHorizontal > 1f) // to samé co nahoře, ale počítáme na druhou stranu
            {
                runSpeedHorizontal = System.Math.Max(runSpeedHorizontal - force, 0);
                return;
            }
            else if (horizontal == -1 && horizontalInput == 1 && runSpeedHorizontal < 1f)
            {
                horizontal = 1;
            }

            if (horizontal == 0) // pokud nemáme žádný směr
            {
                horizontal = horizontalInput; // směr podlě vstupu
            }

            if (runSpeedHorizontal < maxSpeed) // pokud nedosahujeme maximální rychlosti zrychlujeme
            {
                runSpeedHorizontal += force;
            }
        } else { // pokud nemačkáme A a nebo D
        
            if(runSpeedHorizontal > 0) // pokud rychlost je vyšší než 0, zpomalíme - horizon nebo-li směr nemusí být 0 protože zpomalení je přesný
            {
                runSpeedHorizontal = System.Math.Max(runSpeedHorizontal - force, 0);
            }
        }

        if (keyW || keyS)
        {
            float verticalInput = Input.GetAxisRaw("Vertical"); // return 1 or -1

            if (vertical == 1 && verticalInput == -1 && runSpeedVertical > 1f) // pokud se snažíme změnit směr ale rychlost je stále velká
            {
                runSpeedVertical = System.Math.Max(runSpeedVertical - force, 0); // snížíme rychlost
                return;
            }
            else if (vertical == 1 && verticalInput == -1 && runSpeedVertical < 1f) // pokud máme dostatečně nízkou rychlost na pohyb na druhou stranu
            {
                vertical = -1; // změna směru na druhou stranu
            }

            if (vertical == -1 && verticalInput == 1 && runSpeedVertical > 1f) // to samé co nahoře, ale počítáme na druhou stranu
            {
                runSpeedVertical = System.Math.Max(runSpeedVertical - force, 0);
                return;
            }
            else if (vertical == -1 && verticalInput == 1 && runSpeedVertical < 1f)
            {
                vertical = 1;
            }

            if (vertical == 0) // pokud nemáme žádný směr
            {
                vertical = verticalInput; // směr podlě vstupu
            }

            if (runSpeedVertical < maxSpeed) // pokud nedosahujeme maximální rychlosti zrychlujeme
            {
                runSpeedVertical += force;
            }
        }
        else
        { // pokud nemačkáme W a nebo S

            if (runSpeedVertical > 0) // pokud rychlost je vyšší než 0, zpomalíme - horizon nebo-li směr nemusí být 0 protože zpomalení je přesný
            {
                runSpeedVertical = System.Math.Max(runSpeedVertical - force, 0);
            }
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeedHorizontal, vertical * runSpeedVertical);
    }
}
