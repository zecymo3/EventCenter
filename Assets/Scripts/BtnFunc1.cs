using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnFunc1 : MonoBehaviour
{
	// Use this for initialization
	void Start () {
		GetComponent<Button>().onClick.AddListener(() =>
		{
            EventCenter.Broadcast<string>(EventType.oneParam,name);
		});
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
