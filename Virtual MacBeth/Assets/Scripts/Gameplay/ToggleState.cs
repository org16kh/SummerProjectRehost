using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleState : MonoBehaviour {

    HashSet<GameObject> obj_Red;
    HashSet<GameObject> obj_Blue;

    bool obj_is_red;
    // Use this for initialization
    void Start () {
        obj_Red = new HashSet<GameObject>(GameObject.FindGameObjectsWithTag("Red"));
        obj_Blue = new HashSet<GameObject>(GameObject.FindGameObjectsWithTag("Blue"));

        foreach(GameObject Red in obj_Red)
        {
            Red.SetActive(false);
            Debug.Log("Red Object(s) are hidden");
        }

        foreach(GameObject Blue in obj_Blue)
        {
            Blue.SetActive(true);  
        }

        obj_is_red = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeGameState()
    {
        // which objects will be active
        bool blue_active = !obj_is_red;
        bool red_active = obj_is_red;
        // update game state
        obj_is_red = !obj_is_red;
        foreach (GameObject Red in obj_Red)
        {
            //Debug.Log(light);
            Red.SetActive(red_active);
        }

        foreach(GameObject Blue in obj_Blue)
        {
            //Debug.Log(dark);
            Blue.SetActive(blue_active);
        }

    }

    public void ChangeItemState(GameObject toChange)
    {
        // alternate between objects labeled Red & Blue
        if (obj_is_red)
        {
            if (obj_Blue.Remove(toChange))
            {
                obj_Red.Add(toChange);
            }
            else
            {
                Debug.Log("Game object not found to be switched");
            }
        }
        else
        {
            if (obj_Red.Remove(toChange))
            {
                obj_Blue.Add(toChange);
            }
            else
            {
                Debug.Log("Game object not found to be switched");
            }
        }
    }
}
