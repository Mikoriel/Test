using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    //�������Ă��镐��̊Ǘ��A�����o���e�̊p�x������s��

    //�e���i�[����z��A���ꏊ�A�����A���ˈʒu
    //�J����

    public  GameObject[] bullets;
    [SerializeField]
    private Transform bulletSpawnObj;//�e���o��ׂ��|�W�V����
    private Vector2 targetPos, direction, bulletSpawnPos;
    private Camera cam;

    


    //�ϐ�(����i�[�p�̔z��A����̎��ʗp���l)

    [SerializeField]
    protected GameObject[] WeaponManager;
    
    public static int weaponIndex;
  

    //awake�ŏ����ݒ�

    protected void Awake()
    {
        weaponIndex = 0;
        WeaponManager[weaponIndex].gameObject.SetActive(true);

        cam = Camera.main;
    }


    //Update�ŕ���؂�ւ��A���������̊֐����Ă�
    protected void Update()
    {
        ChangeWeapon();
        Shooting();
        
    }

    //����؂�ւ�
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
                if (Time.time > WeaponPistol.shootTimer)      //�Q�[�������Ԃ��ˌ��^�C�}�[�𒴂�����
                {
                    WeaponPistol.shootTimer = Time.time + WeaponPistol.shootTimerDeley; //shootTimer���X�V����
                                            //���ˊ֐����Ă�
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
    
    public void Shoot(Vector2 bulletSpawnObj) //����
    {
        targetPos = cam.ScreenToWorldPoint(Input.mousePosition);

        direction = (targetPos - bulletSpawnObj).normalized;

        GameObject newBullet = Instantiate(bullets[weaponIndex]);



        if (weaponIndex == 0) //���킪�s�X�g���Ȃ�
        {
            newBullet.GetComponent<WeaponPistol>().MoveDirection(direction);     
            newBullet.transform.position = bulletSpawnObj;
        }
        else if (weaponIndex == 1) //���킪smg_1�Ȃ�
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
