using UnityEngine;
using System.Collections;

public class InputHelper : MonoBehaviour
{
    public static bool IsJoystick = Screen.width > 1024 ? true : false;
    public static string Joystick_left = "left";
    public static string Joystick_right = "right";
    public static string Joystick_up = "up";
    public static string Joystick_down = "down";
    public static string Joystick_A = "joystick 1 button 0";//i
    public static string Joystick_B = "joystick 1 button 1";//k
    public static string Joystick_X = "joystick 1 button 2";//l
    public static string Joystick_Y = "joystick 1 button 3";//j
    public static string Joystick_Start = "joystick 1 button 10";
    public static string Joystick_Select = "joystick 1 button 11";
    public static string Joystick_LeftFlipper = "joystick 1 button 4";
    public static string Joystick_RightFlipper = "joystick 1 button 5";

    public static bool GetKeyDown(string keyValue)
    {
        return Input.GetKeyDown(keyValue);
    }
    public static bool GetKeyDown(KeyCode key)
    {
        bool go = false;
#if JOYSTICK_ONLY
#else
        go = Input.GetKeyDown(key);
#endif
        if (go)
            return go;
        switch (key)
        {
            case KeyCode.A:
                return GetKeyDown(Joystick_left);
            case KeyCode.W:
                return GetKeyDown(Joystick_up);
            case KeyCode.S:
                return GetKeyDown(Joystick_down);
            case KeyCode.D:
                return GetKeyDown(Joystick_right);
            case KeyCode.I:
                return GetKeyDown(Joystick_A);
            case KeyCode.K:
                return GetKeyDown(Joystick_B);
            case KeyCode.L:
                return GetKeyDown(Joystick_X) || Input.GetKeyDown(KeyCode.Escape);
            case KeyCode.J:
                return GetKeyDown(Joystick_Y);
        }
        return go;
    }
    public static bool GetKeyUp(string keyValue)
    {
        return Input.GetKeyUp(keyValue);
    }
    public static bool GetKeyUp(KeyCode key)
    {
        bool go = false;
#if JOYSTICK_ONLY
#else
        go = Input.GetKeyUp(key);
#endif
        if (go)
            return go;
        switch (key)
        {
            case KeyCode.A:
                return GetKeyUp(Joystick_left);
            case KeyCode.W:
                return GetKeyUp(Joystick_up);
            case KeyCode.S:
                return GetKeyUp(Joystick_down);
            case KeyCode.D:
                return GetKeyUp(Joystick_right);
            case KeyCode.I:
                return GetKeyUp(Joystick_A);
            case KeyCode.K:
                return GetKeyUp(Joystick_B);
            case KeyCode.L:
                return GetKeyUp(Joystick_X) || Input.GetKeyUp(KeyCode.Escape);
            case KeyCode.J:
                return GetKeyUp(Joystick_Y);
        }
        return go;
    }
    public static bool GetKey(string keyValue)
    {
        return Input.GetKey(keyValue);
    }
    public static bool GetKey(KeyCode key)
    {
        bool go = false;
#if JOYSTICK_ONLY
#else
        go = Input.GetKey(key);
#endif
        if (go)
            return go;
        switch (key)
        {
            case KeyCode.A:
                return GetKey(Joystick_left);
            case KeyCode.W:
                return GetKey(Joystick_up);
            case KeyCode.S:
                return GetKey(Joystick_down);
            case KeyCode.D:
                return GetKey(Joystick_right);
            case KeyCode.I:
                return GetKey(Joystick_A);
            case KeyCode.K:
                return GetKey(Joystick_B);
            case KeyCode.L:
                return GetKey(Joystick_X) || Input.GetKey(KeyCode.Escape);
            case KeyCode.J:
                return GetKey(Joystick_Y);
        }
        return go;
    }
}