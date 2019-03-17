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


    public float minDelay = 0.1f;
    public float maxDelay = 1.0f;

    public static bool isLose;
    public static int index;
    public GameObject[] _Stars;
   

    public static int Count;
	void Start () {

        isLose = false;
        Count = 0;
        for (int i = 0; i < _Stars.Length; i++)
        {
            _Stars[i].SetActive(false);
        }

        for (int i = 0; i < Message.Length; i++)
        {
            Message[i].SetActive(false);
        }


        index = 0;
        
        StartCoroutine(SpawnFruits());
	}

    private void Update()
    {
        if (index <= 4)
        {
            if((int)Down > 0)
              Down -= Time.deltaTime;
        }

        CountDown.text = ((int)Down).ToString();

        if((int)Down == 0 && index <= 4)
        {
            isLose = true;
            Message[0].SetActive(true);
            Message[1].SetActive(false);
        }
        else if(index > 4)
        {
            isLose = false;
            Message[1].SetActive(true);
            Message[0].SetActive(false);
        }

        if(Count % numberOfCut == 0 && Count!=0 && index <= 4)
        {
            _Stars[index].SetActive(true);
            index++;
            Count = 0;
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
        if(index<=4 && !isLose)
          StartCoroutine(SpawnFruits());
        
    }


}
