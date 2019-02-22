using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace akazukin_GameJam
{
    //Player単位で加速値が異なる場合も考えてクラスにする。
    public class AccelTimer
    {
        private float accelTime;
        private float accelWeight;
        private bool isTimerStart = false;
        
        void setAccelTime(float time)
        {
            accelTime = time;
        }

        void setAccelWeight(float weight)
        {
            accelWeight = weight;
        }

        float getAccelTime()
        {
            return accelTime;
        }
        
        float getAccelWeight()
        {
            if (isTimerStart)
            {
                //加速中は加速できない。
                //(加速時の計算は値 * accelWeightなので1を返しておけばおｋ)
                return 1.0f;
            }
            return accelWeight;
        }
        
        void timerStart()
        {
            isTimerStart = true;
        }

        void timerFinish()
        {
            isTimerStart = false;
        }
        

    }    

}

