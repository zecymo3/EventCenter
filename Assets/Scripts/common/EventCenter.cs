
using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

public class EventCenter
{
    //定义一个字典保存事件类型和事件委托
    //key:EventType
    //valua:Delegate

    private static Dictionary<EventType,Delegate> e_table = new Dictionary<EventType, Delegate>();

    //添加监听条件判断
    static void OnAdding(EventType et, Delegate a)
    {
        //判断是否已经有事件类型，没有进行添加
        if (!e_table.ContainsKey(et))
        {
            e_table.Add(et, null);
        }
        //判断要添加的方法类型是否符合要求
        Delegate d = e_table[et];
        if (d != null && d.GetType() != a.GetType())
        {
            //类型不符合，抛出一个异常提示
            Console.WriteLine(d.GetType() + "--" + a.GetType());
            throw new Exception(string.Format("要添加事件类型{0}与当前类型{1}不一致\n事件类型{2}", a.GetType(), d.GetType(), et));
        }

    }
    //移除监听条件判断
    static void OnRemoving(EventType et, Delegate a)
    {
        if (!e_table.ContainsKey(et))
        {
            //事件不存在，抛出异常提示
            throw new Exception(string.Format("事件{0}不存在", et));
        }

        Delegate d = e_table[et];
        if (d == null)
        {
            //没有对应委托
            throw new Exception(String.Format("事件类型{0}没有对应委托{1}", et, a.GetType()));
        }
        else if (d.GetType() != a.GetType())
        {
            //类型不一致
            throw new Exception(String.Format("移除监听错误：尝试为事件{0}移除不同类型的委托，当前委托类型为{1}，要移除的委托类型为{2}", et, d.GetType(), a.GetType()));
        }
    }

    //no param 先编写无参数的监听移除与广播
    //添加监听,et事件类型，a表示执行的方法
    public static void AddListener(EventType et,Action a)
    {
        //添加监听条件判断
        OnAdding(et,a);
        //将事件添加到表里
        e_table[et] = (Action) e_table[et] + a;
    }
    //移除监听,et事件类型，a表示执行的方法
    public static void RemoveListener(EventType et, Action a)
    {
        //移除监听条件判断
        OnRemoving(et,a);
        //移除监听
        e_table[et] = (Action) e_table[et] - a;
    }
    //广播 et事件类型
    public static void Broadcast(EventType et)
    {
        Delegate d;
        if (e_table.TryGetValue(et ,out d))
        {
            //判断类型是否一致
            Action a = d as Action;
            if (a==null)
            {
                //强转不成功，说明类型不一致
                throw new Exception("类型不一致");
            }
            else
            {
                //一致执行委托
                a();
            }
        }
    }

    //one param 1个参数
    public static void AddListener<T>(EventType et, Action<T> a)
    {

        OnAdding(et,a);
        //将事件添加到表里
        e_table[et] = (Action<T>)e_table[et] + a;
    }
    //移除监听,et事件类型，a表示执行的方法
    public static void RemoveListener<T>(EventType et, Action<T> a)
    {
        OnRemoving(et,a);
        //移除监听
        e_table[et] = (Action<T>)e_table[et] - a;
    }

    //广播 et事件类型
    public static void Broadcast<T>(EventType et,T arg)
    {
        Delegate d;
        if (e_table.TryGetValue(et, out d))
        {
            //判断类型是否一致
            Action<T> a = d as Action<T>;
            if (a == null)
            {
                //强转不成功，说明类型不一致
                throw new Exception("类型不一致");
            }
            else
            {
                //一致执行委托
                a(arg);
            }
        }
    }

    //one param 2个参数
    public static void AddListener<T1,T2>(EventType et, Action<T1,T2> a)
    {

        OnAdding(et, a);
        //将事件添加到表里
        e_table[et] = (Action<T1, T2>)e_table[et] + a;
    }
    //移除监听,et事件类型，a表示执行的方法
    public static void RemoveListener<T1,T2>(EventType et, Action<T1, T2> a)
    {
        OnRemoving(et, a);
        //移除监听
        e_table[et] = (Action<T1, T2>)e_table[et] - a;
    }

    //广播 et事件类型
    public static void Broadcast<T1, T2>(EventType et, T1 arg1,T2 arg2)
    {
        Delegate d;
        if (e_table.TryGetValue(et, out d))
        {
            //判断类型是否一致
            Action<T1, T2> a = d as Action<T1, T2>;
            if (a == null)
            {
                //强转不成功，说明类型不一致
                throw new Exception("类型不一致");
            }
            else
            {
                //一致执行委托
                a(arg1,arg2);
            }
        }
    }

    //three param 3个参数
    public static void AddListener<T1, T2,T3>(EventType et, Action<T1, T2,T3> a)
    {

        OnAdding(et, a);
        //将事件添加到表里
        e_table[et] = (Action<T1, T2, T3>)e_table[et] + a;
    }
    //移除监听,et事件类型，a表示执行的方法
    public static void RemoveListener<T1, T2, T3>(EventType et, Action<T1, T2, T3> a)
    {
        OnRemoving(et, a);
        //移除监听
        e_table[et] = (Action<T1, T2, T3>)e_table[et] - a;
    }
    //广播 et事件类型
    public static void Broadcast<T1, T2, T3>(EventType et, T1 arg1, T2 arg2,T3 arg3)
    {
        Delegate d;
        if (e_table.TryGetValue(et, out d))
        {
            //判断类型是否一致
            Action<T1, T2, T3> a = d as Action<T1, T2, T3>;
            if (a == null)
            {
                //强转不成功，说明类型不一致
                throw new Exception("类型不一致");
            }
            else
            {
                //一致执行委托
                a(arg1, arg2,arg3);
            }
        }
    }


}
