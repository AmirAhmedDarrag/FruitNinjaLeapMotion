using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fruit : MonoBehaviour {

    public GameObject[] fruitPrefab;
    public Transform[] spawnPoints;

    public Text CountDown;

    public GameObject[] Message;

    public float Down = 30.0f;

    public int numberOfCut = 5;


    public int cDown = 3;
    public Text counDown;
    public float minDelay = 0.1f;
    public float maxDelay = 1.0f;
    private bool isStart;

    public static bool isLose;
    public static int index;
    public GameObject[] _Stars;


    public GameObject[] _TextIns;

    public static int Count;
	void Start () {

        isStart = false;
        isLose = false;
        Count = 0;
        for (int i = 0; i < _Stars.Length; i++)
        {
            _Stars[i].SetActive(false);
        }

        _TextIns[0].SetActive(true);
        for (int i = 1; i < _TextIns.Length; i++)
        {
            _TextIns[i].SetActive(false);
        }
        
        index = 0;
        
        StartCoroutine(startFInstructions());
	}

    private void Update()
    {
        if (isStart)
        {
            if (index <= 2)
            {
                if ((int)Down > 0)
                    Down -= Time.deltaTime;
            }

            CountDown.text = ((int)Down).ToString();

            if ((int)Down == 0 && index <= 2)
            {
                isLose = true;
                Message[0].SetActive(true);
                Message[1].SetActive(false);
            }
            else if (index > 2)
            {
                isLose = false;
                Message[1].SetActive(true);
                Message[0].SetActive(false);
            }

            if (Count % numberOfCut == 0 && Count != 0 && index <= 2)
            {
                _Stars[index].SetActive(true);
                index++;
                Count = 0;
            }
        }
    }

    IEnumerator startFInstructions()
    {
        yield return new WaitForSeconds(3.0f);
        _TextIns[0].SetActive(false);
        _TextIns[1].SetActive(true);

        StartCoroutine(startSInstructions());
    }

    IEnumerator startSInstructions()
    {
        counDown.text = cDown.ToString();
        yield return new WaitForSeconds(1.0f);
        if (cDown > 0)
        {
            cDown--;
            StartCoroutine(startSInstructions());
        }
        else
        {
            _TextIns[1].SetActive(false);
            isStart = true;
            StartCoroutine(SpawnFruits());
        }
    }
    IEnumerator SpawnFruits()
    {
        float delay = Random.Range(minDelay, maxDelay);

        
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < fruitPrefab.Length; i++)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);

            Transform spawnPoint = spawnPoints[spawnIndex];


            GameObject spawnFruit = Instantiate(fruitPrefab[i], spawnPoint.position, spawnPoint.rotation);
            
            Destroy(spawnFruit, 3.0f);

        }
        if(index<=2 && !isLose)
          StartCoroutine(SpawnFruits());
        
    }


}
