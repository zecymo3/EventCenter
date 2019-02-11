using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnFunc2 : MonoBehaviour
{
	// Use this for initialization
	void Start () {
		GetComponent<Button>().onClick.AddListener(() =>
		{
            EventCenter.Broadcast<string,string>(EventType.twoParam,name,"hello world");
		});
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
