using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnFunc3 : MonoBehaviour
{
    private int num = 0;
	// Use this for initialization
	void Start () {
		GetComponent<Button>().onClick.AddListener(() =>
		{
            EventCenter.Broadcast<string, int,float>(EventType.threeParam,name,num++,3.1415f);
		});
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
