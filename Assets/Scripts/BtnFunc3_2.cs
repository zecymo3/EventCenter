using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnFunc3_2 : MonoBehaviour {

	// Use this for initialization
    void Start()
    {

        GetComponent<Button>().onClick.AddListener(() =>
        {
            EventCenter.Broadcast<string, string, string>(EventType.threeParam2, "aa", "bb", "cc");
        });


}
	
	// Update is called once per frame
	void Update () {
		
	}
}
