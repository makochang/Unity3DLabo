using UnityEngine;
using System.Collections;

public class InputCheck : MonoBehaviour
{
    public GUIStyle DefaultGUIStyle;

    public KeyCode latestKeyCode;
    public KeyCode currentKeyCode;

    string[] keymap = {
        "1","2","3","4","5","6","7","8","9","0",
        "Q","W","E","R","T","Y","U","I","O","P",
        "A","S","D","F","G","H","J","K","L",";",
        "Z","X","C","V","B","N","M","<",">","/",
    };

    // OnGUI is called for rendering and handling GUI events
    public void OnGUI()
    {
        //キーイベント.
        if (Event.current.isKey)
        {
            Debug.Log("キーイベントを検出しました"+Event.current.keyCode+"("+(int)Event.current.keyCode+")");
            if (Event.current.type == EventType.KeyDown)
            {
                latestKeyCode = Event.current.keyCode;
                currentKeyCode = Event.current.keyCode;
            }
            if (Event.current.type == EventType.keyUp)
            {
                currentKeyCode = KeyCode.None;
            }
            Debug.Log(Event.current.character);
        }
        //マウスイベント.
        if (Event.current.isMouse)
        {
            Debug.Log("マウスイベントを検出しました");
        }

        //キーボード図を表示する.
        Rect baseRect = new Rect(0, 0, Screen.width / 10, Screen.width / 10);
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Rect drawRect = baseRect;
                drawRect.x = baseRect.width * j;
                drawRect.y = baseRect.height * i;
                GUI.Box(drawRect, keymap[i * 10 + j]);
            }
        }
    }
}
