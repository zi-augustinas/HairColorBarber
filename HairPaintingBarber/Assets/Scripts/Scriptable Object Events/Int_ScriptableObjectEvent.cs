using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Int Game Event", menuName = "Create Game Event/Integer Event", order = 1)]
public class Int_ScriptableObjectEvent : ScriptableObject
{
    event Action<int> SimpleGameEvent;
    
    public void RaiseEvent(int value)
    {
        SimpleGameEvent?.Invoke(value);
    }

    public void AddListener(Action<int> func)
    {
        SimpleGameEvent += func;
    }

    public void RemoveListener(Action<int> func)
    {
        SimpleGameEvent -= func;
    }
}
