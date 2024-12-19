using UnityEngine;

[CreateAssetMenu(fileName = "KeybindObj", menuName = "Scriptable Objects/KeybindObj")]
public class KeybindObj : ScriptableObject
{
    public string actionName;
    public KeyCode defaultKey;
    [Header("Keybinds")]
    public KeyCode Accelerate;
    public KeyCode Brake;
}
