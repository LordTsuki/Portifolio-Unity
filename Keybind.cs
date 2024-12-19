using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Keybind : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Button button;

    public KeybindObj keybindObj;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeKeybind);
    }

    void ChangeKeybind()
    {
        StartCoroutine(WaitForKeyPress());
    }

    private System.Collections.IEnumerator WaitForKeyPress()
    {
        bool keyPressed = false;

        while(!keyPressed)
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kcode))
                    {
                        keybindObj.defaultKey = kcode;
                        keyPressed = true;
                        break;
                    }
                }
            }
            yield return null;
        }
    }
}
