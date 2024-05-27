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

    // Start is called before the first frame update
    void Start()
    {
        textMesh.text = dt.ToString("H:mm");

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
        }
    }

}
