using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //このスクリプトはBoss以外の全てのキャラの移動を扱う(PlayerもEnemyも)


    //やること
    //変数の作成(各軸の移動スピード、移動量)
    [SerializeField]
    protected float xSpeed = 1.5f, ySpeed = 1.5f;
    private Vector2 moveDelta;

    //関数の作成(キャラクターを移動させる)
    protected void CharacterMovement(float x, float y)
    {
        moveDelta = new Vector2(x * xSpeed, y * ySpeed);

        transform.Translate(moveDelta.x * Time.deltaTime, moveDelta.y * Time.deltaTime, 0);
    }
    
}

