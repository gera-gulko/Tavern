using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Action OnTriggerAction;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnTriggerAction?.Invoke();
        }
    }
}
