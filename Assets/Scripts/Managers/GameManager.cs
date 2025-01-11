using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DefineCommons;

public class GameManager : Singleton<GameManager>
{
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }

    public Camera MainCamera;



    void Start()
    {
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        // scene load가 완료되면 callback 호출
        SceneManager.sceneLoaded += SceneLoadComplete;
    }

    void SceneLoadComplete(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Scene Load Complete : {scene.name}, {mode}");
        
        if(SceneManager.GetActiveScene().name != "DiceScene")
        {
            MainCamera.gameObject.SetActive(false);
        }

        //로드 완료된 씬을 활성화
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene.name));
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        if(!MainCamera.gameObject.activeSelf) MainCamera.gameObject.SetActive(true);

        Debug.Log($"Active Scene : {SceneManager.GetActiveScene().name}");

        if(SceneManager.GetActiveScene().name == "Map_Sample")
        {
            StateManager.I.ChangeState(State.RoundStart);
        }
    }





























}
