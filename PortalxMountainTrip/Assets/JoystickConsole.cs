using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickConsole : MonoBehaviour {

    public InputField myInput;
    public Text myLog;


    public Button btnStart;
    public Button btnStageA;
    public Button btnStageB;
    public Button btnStageC;
    public int timeIndex;
    public Button[] btnTime;

    public Button btnHide;
    public Button btnShow;
    public Button btnEnd;

    public void DetectInput(string val)
    {
        if(val != "")
            myLog.text = "DetectInput: " + val;


        if(val == "l" && btnStart.isActiveAndEnabled)
        {
            btnStart.onClick.Invoke();
        }
        else if(val == "a" && btnStageA.isActiveAndEnabled)
        {
            btnStageA.onClick.Invoke();
        }
        else if (val == "w" && btnStageB.isActiveAndEnabled)
        {
            btnStageB.onClick.Invoke();
        }
        else if (val == "d" && btnStageC.isActiveAndEnabled)
        {
            btnStageC.onClick.Invoke();
        }
        else if (val == "l" && btnHide.isActiveAndEnabled)
        {
            btnHide.onClick.Invoke();
        }
        else if (val == "l" && btnShow.isActiveAndEnabled)
        {
            btnShow.onClick.Invoke();
        }
        else if (val == "o" && btnEnd.isActiveAndEnabled)
        {
            btnEnd.onClick.Invoke();
        }
        else if (val == "a" && btnTime[0].isActiveAndEnabled)
        {
            timeIndex = timeIndex == 0 ? 4 : timeIndex - 1;

            btnTime[timeIndex].onClick.Invoke();
        }
        else if (val == "d" && btnTime[0].isActiveAndEnabled)
        {
            timeIndex = timeIndex == 4 ? 0 : timeIndex + 1;

            btnTime[timeIndex].onClick.Invoke();
        }

        myInput.text = "";
    }
}
