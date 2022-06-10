using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_One : MonoBehaviour
{
    //�჌�[�g�A��ΉA���ђ�
    public static float shootTimer;
    public static float shootTimerDeley = 1.0f; //�ˌ��^�C�}�[�A�ˌ��Ԋu

    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed = 2.5f, deactiveTimer = 1f; //���x�A������܂ł̎���
    [SerializeField]
    private int damageAmount = 1;   //�U����
    private bool damage;           //�ђʂ��邩���Ȃ���
    [SerializeField]
    private bool destroyObj;        //�I�u�W�F�N�g���폜���邩�̔���

    [SerializeField]                //�g����������Ȃ�����
    private bool getTrailRanderer;  //�O�Ղ̗L������
    private TrailRenderer trail;    //�O�Ղ��i�[����ϐ�








    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (getTrailRanderer)        //�O�Ղ�true�Ȃ�
        {                            //�O�Ղ��擾����
            trail = GetComponent<TrailRenderer>();
        }


    }

    private void OnEnable()     //SetActive���I���ɂȂ�����
    {
        damage = false;

        Invoke("DeactiveBullet", deactiveTimer);
    }

    private void OnDisable()    //SetActive���I�t�ɂȂ�����
    {
        rb.velocity = Vector2.zero;  //���x��0�ɂ���

        if (getTrailRanderer)         //�O�Ղ�true�Ȃ�
        {                            //�O�Ղ��N���A����
            trail.Clear();
        }
    }

    public void MoveDirection(Vector3 direction) //�e�̕����ݒ�A��\���ݒ�
    {
        rb.velocity = direction * moveSpeed;
    }

    void DeactiveBullet()
    {
        if (destroyObj)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //�e���G�AMap�ɓ�����Ƃ����ɏ��ł���悤��
    {
        if (collision.CompareTag("Enemy") ||
            collision.CompareTag("Boss"))
        {
            rb.velocity = Vector2.zero;

            CancelInvoke("DeactiveBullet");

            DeactiveBullet();
        }

        if (collision.CompareTag("Map"))
        {
            rb.velocity = Vector2.zero;

            CancelInvoke("DeactiveBullet");

            DeactiveBullet();
        }
    }

}
