using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DefineCommons;

// 테스트 및 디버깅 단축을 위한 GM
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
        //버튼 클릭시 buildsetting에 등록된 2번 씬 로드
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
    }

}
