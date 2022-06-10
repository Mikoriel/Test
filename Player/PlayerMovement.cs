using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{

    //変数の作成(入力受け取り用)


    //キャラをマウスのZ軸に向かせる
    //WASDで上下左右に移動できるようにする
    void Update()
    {
        if (PlayerWeaponManager.weaponIndex == 0)
        {
            xSpeed = 8;
            ySpeed = 8;
        }
        else if (PlayerWeaponManager.weaponIndex == 1)
        {
            xSpeed = 6;
            ySpeed = 6;
        }
        else if (PlayerWeaponManager.weaponIndex == 2)
        {
            xSpeed = 6;
            ySpeed = 6;
        }
        else if (PlayerWeaponManager.weaponIndex == 3)
        {
            xSpeed = 7;
            ySpeed = 7;
        }
        else if (PlayerWeaponManager.weaponIndex == 4)
        {
            xSpeed = 7;
            ySpeed = 7;
        }
        else if (PlayerWeaponManager.weaponIndex == 5)
        {
            xSpeed = 6;
            ySpeed = 6;
        }
        else if (PlayerWeaponManager.weaponIndex == 6)
        {
            xSpeed = 5.5f;
            ySpeed = 5.5f;
        }
        else if (PlayerWeaponManager.weaponIndex == 7)
        {
            xSpeed = 5;
            ySpeed = 5;
        }
        else if (PlayerWeaponManager.weaponIndex == 8)
        {
            xSpeed = 5;
            ySpeed = 5;
        }
        else if (PlayerWeaponManager.weaponIndex == 9)
        {
            xSpeed = 4;
            ySpeed = 4;
        }
        else if (PlayerWeaponManager.weaponIndex == 10)
        {
            xSpeed = 3;
            ySpeed = 3;
        }
        else if (PlayerWeaponManager.weaponIndex == 11)
        {
            xSpeed = 4;
            ySpeed = 4;
        }



        Vector3 lookAtPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAtPosition.z = transform.position.z;
        transform.right = lookAtPosition - transform.position;

        Vector3 pos = transform.position;
        if (Input.GetKey("w"))
        {
            pos.y += xSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= xSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += xSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= xSpeed * Time.deltaTime;
        }

        transform.position = pos;


    }
}

