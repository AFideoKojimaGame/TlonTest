using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour {

    //Globals holds values accessed by various classes. Script execution order has been modified to make sure Globals is initialized before all other classes.

    public static Globals instance;

    public int hitsPerSecond;
    public int rate;
    public float speed;

    public List<Alien> activeAliens = new List<Alien>();

    void Awake() {
        instance = this;
    }

    public float GetAvgAngle() {

        float angle = 0;

        for (int i = 0; i < activeAliens.Count; i++) {
            angle += activeAliens[i].transform.eulerAngles.y;
        }

        if (activeAliens.Count > 0)
            angle /= activeAliens.Count;

        //angle value is modified to match current overhead view (with up being 0/360 degrees)
        angle -= 270;
        if (angle < 0)
            angle += 360;

        return angle;
    }

}
