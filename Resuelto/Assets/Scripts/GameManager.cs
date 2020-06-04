using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GeneradorAnimales generadorAnimales = null;

    public bool isGameOn = false;

    public float totalPlayTime = 10;

    private float timeLeft;
    public float PlayTimeLeft
    {
        get { return timeLeft; }
        set
        {
            timeLeft = value;
            onPlayTimeLeftChanged.Invoke(value);
        }
    }

    public UnityEventFloat onPlayTimeLeftChanged;

    public UnityEvent onTimeOut;

    private void Start()
    {
        InitGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            StartGame();
    }

    public void StartGame()
    {
        if (!isGameOn)
        {
            generadorAnimales.StartAnimalSpawn();
            isGameOn = true;
            StartCoroutine(DecreasePlayTime());
        }
    }

    IEnumerator DecreasePlayTime()
    {
        do
        {
            yield return null;
            PlayTimeLeft -= Time.deltaTime;
            Debug.Log("Time left: " + PlayTimeLeft);
        } while (PlayTimeLeft > 0);

        PlayTimeLeft = 0;
        onTimeOut.Invoke();
    }

    public void StopTimer()
    {
        StopCoroutine(DecreasePlayTime());
    }

    private void InitGame()
    {
        isGameOn = false;
        PlayTimeLeft = totalPlayTime;
    }
}

[Serializable]
public class UnityEventFloat : UnityEvent<float>
{

}