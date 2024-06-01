using SharpUI.Source.Common.UI.Elements.Toggle;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeUIScript : MonoBehaviour
{

    public TextMeshProUGUI textMesh;
    public Light light;
    private float timeLeft = (60f*11f);
    private int previousInterval = 60 * 11;
    DateTime dt = new DateTime(2024, 1, 1, 1, 0, 0);
    System.Timers.Timer timer;
    private List<GameObject> trailers = new List<GameObject>();
    private List<DateTime> arrivalTimes = new List<DateTime>();
    private List<GameObject> trailerDoors = new List<GameObject>();
    public GameObject trailerTemplate;
    public GameObject trailerDoorTemplate;
    int currTrailer = 0;
    int trailerDepart = 0;

    // Start is called before the first frame update
    void Start()
    {
        textMesh.text = dt.ToString("H:mm");
        NewDay(2, 2);
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        if (previousInterval != (int)timeLeft && (int)timeLeft % 5 == 0)
        {
            light.transform.eulerAngles += Vector3.right;
            light.intensity = (60f * 11f - timeLeft)/(60f * 11f);
            dt = dt.AddMinutes(5);
            textMesh.text = dt.ToString("H:mm");
            previousInterval = (int)timeLeft;

            if (arrivalTimes.Contains(dt))
            {
                TrailerArrival(currTrailer, currTrailer);
                currTrailer++;
            }
            if (arrivalTimes.Contains(dt.AddHours(-3)))
            {
                TrailerDepart(trailerDepart, trailerDepart);
                trailerDepart++;
            }
        }

    }

    private void NewDay(int trailerNum, int doorNum)
    {
        trailers.Clear();
        for (int i = 0; i < trailerNum; i++)
        {
            var trailer = Instantiate(trailerTemplate, Vector3.zero, Quaternion.identity);
            trailer.SetActive(false);
            trailers.Add(trailer);
            arrivalTimes.Add(dt.AddHours(i*2 + 1));
        }

        for (int i = 0; i < doorNum; i++)
        {
            var trailerDoor = Instantiate(trailerDoorTemplate, new Vector3(-37.8f, 0f, -7.4f + 14.8f * i), Quaternion.identity);
            trailerDoors.Add(trailerDoor);
        }
    }

    private void TrailerArrival(int index, int doorNum)
    {
        trailers[index].transform.position = new Vector3(-53f, -2.8f, -8f + 14.5f*doorNum);
        trailers[index].SetActive(true);
        trailerDoors[index].transform.position += 4 * Vector3.up;
    }

    private void TrailerDepart(int index, int doorNum)
    {
        trailers[index].SetActive(false);
        trailerDoors[index].transform.position -= 4 * Vector3.up;
    }

}
 