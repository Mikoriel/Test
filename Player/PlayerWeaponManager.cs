using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    //装備している武器の管理、撃ち出す弾の角度制御を行う

    //弾を格納する配列、撃つ場所、方向、発射位置
    //カメラ

    public  GameObject[] bullets;
    [SerializeField]
    private Transform bulletSpawnObj;//弾が出るべきポジション
    private Vector2 targetPos, direction, bulletSpawnPos;
    private Camera cam;

    


    //変数(武器格納用の配列、武器の識別用数値)

    [SerializeField]
    protected GameObject[] WeaponManager;
    
    public static int weaponIndex;
  

    //awakeで初期設定

    protected void Awake()
    {
        weaponIndex = 0;
        WeaponManager[weaponIndex].gameObject.SetActive(true);

        cam = Camera.main;
    }


    //Updateで武器切り替え、撃った時の関数を呼ぶ
    protected void Update()
    {
        ChangeWeapon();
        Shooting();
        
    }

    //武器切り替え
    protected void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {            WeaponManager[weaponIndex].gameObject.SetActive(false);
            weaponIndex++;

            if (weaponIndex >= WeaponManager.Length)
            {
                weaponIndex = 0;
            }

            WeaponManager[weaponIndex].gameObject.SetActive(true);

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            WeaponManager[weaponIndex].gameObject.SetActive(false);
            weaponIndex--;

            if (weaponIndex < 0)
            {
                weaponIndex = WeaponManager.Length - 1;
            }

            WeaponManager[weaponIndex].gameObject.SetActive(true);
        }
       
        }


    
    void Shooting()
    {
        if (weaponIndex == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time > WeaponPistol.shootTimer)      //ゲーム内時間が射撃タイマーを超えたら
                {
                    WeaponPistol.shootTimer = Time.time + WeaponPistol.shootTimerDeley; //shootTimerを更新する
                                            //発射関数を呼ぶ
                    Shoot(bulletSpawnObj.position);
                }
            }
        }
        else if (weaponIndex == 1)
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time > WeaponSMGone.shootTimer)
                {
                    WeaponSMGone.shootTimer = Time.time + WeaponSMGone.shootTimerDeley;

                    Shoot(bulletSpawnObj.position);
                }
            }
        }
        else if (weaponIndex == 2)
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time > WeaponSmgTwo.shootTimer)
                {
                    WeaponSmgTwo.shootTimer = Time.time + WeaponSmgTwo.shootTimerDeley;

                    Shoot(bulletSpawnObj.position);
                }
            }
        }
        else if (weaponIndex == 3)
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time > SG_One.shootTimer)
                {
                    SG_One.shootTimer = Time.time + SG_One.shootTimerDeley;

                    Shoot(bulletSpawnObj.position);
                }
            }
        }
        else if (weaponIndex == 4)
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time > SG_Two.shootTimer)
                {
                    SG_Two.shootTimer = Time.time + SG_Two.shootTimerDeley;

                    Shoot(bulletSpawnObj.position);
                }
            }
        }
        else if (weaponIndex == 5)
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time > AR_One.shootTimer)
                {
                    AR_One.shootTimer = Time.time + AR_One.shootTimerDeley;

                    Shoot(bulletSpawnObj.position);
                }
            }
        }
        else if (weaponIndex == 6)
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time > AR_Two.shootTimer)
                {
                    AR_Two.shootTimer = Time.time + AR_Two.shootTimerDeley;

                    Shoot(bulletSpawnObj.position);
                }
            }
        }
        else if (weaponIndex == 7)
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time > LMG_One.shootTimer)
                {
                    LMG_One.shootTimer = Time.time + LMG_One.shootTimerDeley;

                    Shoot(bulletSpawnObj.position);
                }
            }
        }
        else if (weaponIndex == 8)
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time > LMG_Two.shootTimer)
                {
                    LMG_Two.shootTimer = Time.time + LMG_Two.shootTimerDeley;

                    Shoot(bulletSpawnObj.position);
                }
            }
        }
        else if (weaponIndex == 9)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time > Heavy_One.shootTimer)
                {
                    Heavy_One.shootTimer = Time.time + Heavy_One.shootTimerDeley;

                    Shoot(bulletSpawnObj.position);
                }
            }
        }
        else if (weaponIndex == 10)
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time > Heavy_Two.shootTimer)
                {
                    Heavy_Two.shootTimer = Time.time + Heavy_Two.shootTimerDeley;

                    Shoot(bulletSpawnObj.position);
                }
            }
        }
    }
    
    public void Shoot(Vector2 bulletSpawnObj) //撃つ
    {
        targetPos = cam.ScreenToWorldPoint(Input.mousePosition);

        direction = (targetPos - bulletSpawnObj).normalized;

        GameObject newBullet = Instantiate(bullets[weaponIndex]);



        if (weaponIndex == 0) //武器がピストルなら
        {
            newBullet.GetComponent<WeaponPistol>().MoveDirection(direction);     
            newBullet.transform.position = bulletSpawnObj;
        }
        else if (weaponIndex == 1) //武器がsmg_1なら
        {
            newBullet.GetComponent<WeaponSMGone>().MoveDirection(direction);
            newBullet.transform.position = bulletSpawnObj;
        }
        else if (weaponIndex == 2) 
        {
            newBullet.GetComponent<WeaponSmgTwo>().MoveDirection(direction);
            newBullet.transform.position = bulletSpawnObj;
        }
        else if (weaponIndex == 3)
        {
            newBullet.GetComponent<SG_One>().MoveDirection(direction);
            newBullet.transform.position = bulletSpawnObj;
        }
        else if (weaponIndex == 4)
        {
            newBullet.GetComponent<SG_Two>().MoveDirection(direction);
            newBullet.transform.position = bulletSpawnObj;
        }
        else if (weaponIndex == 5)
        {
            newBullet.GetComponent<AR_One>().MoveDirection(direction);
            newBullet.transform.position = bulletSpawnObj;
        }
        else if (weaponIndex == 6)
        {
            newBullet.GetComponent<AR_Two>().MoveDirection(direction);
            newBullet.transform.position = bulletSpawnObj;
        }
        else if (weaponIndex == 7)
        {
            newBullet.GetComponent<LMG_One>().MoveDirection(direction);
            newBullet.transform.position = bulletSpawnObj;
        }
        else if (weaponIndex == 8)
        {
            newBullet.GetComponent<LMG_Two>().MoveDirection(direction);
            newBullet.transform.position = bulletSpawnObj;
        }
        else if (weaponIndex == 9)
        {
            newBullet.GetComponent<Heavy_One>().MoveDirection(direction);
            newBullet.transform.position = bulletSpawnObj;
        }
        else if (weaponIndex == 10)
        {
            newBullet.GetComponent<Heavy_Two>().MoveDirection(direction);
            newBullet.transform.position = bulletSpawnObj;
        }






    }
        
    }
