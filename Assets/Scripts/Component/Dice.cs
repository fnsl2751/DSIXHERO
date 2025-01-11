using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineCommons;

public class Dice : MonoBehaviour
{
    public int Value = -1;
    public DiceType Type = DiceType.None;
    public int[] DiceValues = new int[6];
    public int[] AttactBuffs = new int[6];

    Rigidbody Rigidbody;
    bool Rolled = true;

    // public Texture 나 Material등 설정


    public static Vector3 diceVelocity;
    public float RollingMinTime = 4.0f;
    float t_Time;


    private int[] angles = { 0, 90, 180, 270, 360 };










    private void FixedUpdate()
    {
        diceVelocity = Rigidbody.velocity; // 움직임이 있는지 확인하기 위한 변수
        t_Time += Time.deltaTime;

        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && !Rolled && t_Time > RollingMinTime)
        {
            Rolled = true;

            GameObject UpSide = null;

            for(int i = 0; i < 6; i++)
            {
                if (UpSide == null || UpSide.transform.position.y < this.transform.GetChild(i).position.y)
                {
                    UpSide = this.transform.GetChild(i).gameObject;
                }
            }

            switch (UpSide.gameObject.name)
            {
                case "1":
                    Value = DiceValues[0];
                    break;
                case "2":
                    Value = DiceValues[1];
                    break;
                case "3":
                    Value = DiceValues[2];
                    break;
                case "4":
                    Value = DiceValues[3];
                    break;
                case "5":
                    Value = DiceValues[4];
                    break;
                case "6":
                    Value = DiceValues[5];
                    break;
            }

            RollFinished();
        }
    }






    public void Roll()
    {
        Rolled = false;

        // 회전 랜덤 변수
        float dirX = Random.Range(0, 3000);
        float dirY = Random.Range(0, 3000);
        float dirZ = Random.Range(0, 3000);

        // 초기 회전값 (랜덤 부여)
        Quaternion currentRotation = transform.localRotation;
        float randomIndex_x = Random.Range(0, angles.Length);
        float randomIndex_z = Random.Range(0, angles.Length);

        transform.localRotation = Quaternion.Euler(angles[(int)randomIndex_x], currentRotation.eulerAngles.y, angles[(int)randomIndex_z]);
        // 윗 방향으로 힘을 가해 공중에 띄우면서, 랜덤한 방향으로 회전
        float ForceRand = Random.Range(200, 500);
        Rigidbody.AddForce(Vector3.up * ForceRand);
        Rigidbody.AddForce(Vector3.right * ForceRand);
        Rigidbody.AddForce(Vector3.forward * ForceRand);
        Rigidbody.AddTorque(new Vector3(dirX, dirY, dirZ), ForceMode.VelocityChange);
    }

    public void RollFinished()
    {
        if(this.GetComponentInParent<DiceRoller>() != null)
        {
            this.GetComponentInParent<DiceRoller>().RollFinished(this);
        }
    }









    public void SetDice(int[] m_DiceValues, int[] m_AttactBuffs, DiceType m_Type = DiceType.None)
    {
        Type = m_Type;
        DiceValues = m_DiceValues;
        AttactBuffs = m_AttactBuffs;

        Rigidbody = GetComponent<Rigidbody>();

        switch (Type)
        {
            case DiceType.ActionDice:
                break;
            case DiceType.AttackDice:
                break;
            case DiceType.DefenceDice:
                break;
            default:
                break;
        }
    }

}
