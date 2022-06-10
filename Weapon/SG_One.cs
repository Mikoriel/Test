using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_One : MonoBehaviour
{
    //低レート、低火力、高貫通
    public static float shootTimer;
    public static float shootTimerDeley = 1.0f; //射撃タイマー、射撃間隔

    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed = 2.5f, deactiveTimer = 1f; //速度、消えるまでの時間
    [SerializeField]
    private int damageAmount = 1;   //攻撃力
    private bool damage;           //貫通するかしないか
    [SerializeField]
    private bool destroyObj;        //オブジェクトを削除するかの判定

    [SerializeField]                //使うか分からないもの
    private bool getTrailRanderer;  //軌跡の有無判定
    private TrailRenderer trail;    //軌跡を格納する変数








    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (getTrailRanderer)        //軌跡がtrueなら
        {                            //軌跡を取得する
            trail = GetComponent<TrailRenderer>();
        }


    }

    private void OnEnable()     //SetActiveがオンになった時
    {
        damage = false;

        Invoke("DeactiveBullet", deactiveTimer);
    }

    private void OnDisable()    //SetActiveがオフになった時
    {
        rb.velocity = Vector2.zero;  //速度を0にする

        if (getTrailRanderer)         //軌跡がtrueなら
        {                            //軌跡をクリアする
            trail.Clear();
        }
    }

    public void MoveDirection(Vector3 direction) //弾の方向設定、非表示設定
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

    private void OnTriggerEnter2D(Collider2D collision) //弾が敵、Mapに当たるとすぐに消滅するように
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
