using System.Collections.Generic;
using UnityEngine;

public class KeybindManager : MonoBehaviour
{
    public List<KeybindObj> keybinds;

    void Update()
    {
        foreach (var keybind in keybinds)
        {
            if (Input.GetKeyDown(keybind.defaultKey))
            {
                Debug.Log($"Action {keybind.actionName} triggered!");
            }
        }
    }
}