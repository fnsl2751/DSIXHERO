using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DefineCommons;

// �׽�Ʈ �� ����� ������ ���� GM
public class DevTool : Singleton<DevTool>
{
    [SerializeField] Button button;
    [SerializeField] Button button_2;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() =>
        {
            OnClickButton();
            StateManager.I.ChangeState(State.TurnPlay);
        });
        button_2.onClick.AddListener(() =>
        {
            DiceRoller.I.ClearAllDices();
            DiceRoller.I.AddDice(DiceType.ActionDice);
            DiceRoller.I.AddDice(DiceType.ActionDice);
            DiceRoller.I.AddDice(DiceType.ActionDice);
            DiceRoller.I.RollDice();
        });
    }

    void OnClickButton()
    {
        //��ư Ŭ���� buildsetting�� ��ϵ� 2�� �� �ε�
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
    }

}
