using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript3 : MonoBehaviour {

    void Start()
    {
        //文本1响应所有按钮，响应函数在本脚本上定义
        //文本2响应所有按钮，响应函数在本脚本上定义，区别于文本1的响应
        //文本3响应1，2，5按钮，响应函数也可以另写，这里使用文本1 的函数

        EventCenter.AddListener(EventType.noParam, Show);
        EventCenter.AddListener<string>(EventType.oneParam, Show1);
        //EventCenter.AddListener<string, string>(EventType.twoParam, Show2);
        //EventCenter.AddListener<string, int, float>(EventType.threeParam, Show3);
        EventCenter.AddListener<string, string, string>(EventType.threeParam2, Show3_2);
    }

    void OnDestroy()
    {
        EventCenter.RemoveListener(EventType.noParam, Show);
        EventCenter.RemoveListener<string>(EventType.oneParam, Show1);
        //EventCenter.RemoveListener<string, string>(EventType.twoParam, Show2);
        //EventCenter.RemoveListener<string, int, float>(EventType.threeParam, Show3);
        EventCenter.RemoveListener<string, string, string>(EventType.threeParam2, Show3_2);
    }


    // Update is called once per frame
    void Update()
    {

    }

    void Show()
    {
        GetComponent<Text>().text = "hell0";
    }
    void Show1(string s)
    {
        GetComponent<Text>().text += s;
    }

    void Show2(string s1, string s2)
    {
        GetComponent<Text>().text += "\n" + s1 + s2;
    }

    void Show3(string s, int i, float f)
    {
        GetComponent<Text>().text += "\n" + s + i + f;
    }

    void Show3_2(string s1, string s2, string s3)
    {
        GetComponent<Text>().text = s1 + s2 + s3;
    }
}
