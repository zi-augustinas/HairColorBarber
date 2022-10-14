using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Bool Game Event", menuName = "Create Game Event/Bool Game Event", order = 1)]
public class Bool_ScriptableObjectEvent : ScriptableObject
{ 
    event Action<bool> SimpleGameEvent;
    
    public void RaiseEvent(bool value)
    {
        SimpleGameEvent?.Invoke(value);
    }

    public void AddListener(Action<bool> func)
    {
        SimpleGameEvent += func;
    }

    public void RemoveListener(Action<bool> func)
    {
        SimpleGameEvent -= func;
    }
}
