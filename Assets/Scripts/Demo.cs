using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.Dialogs;
public class Demo : MonoBehaviour
{
    void Start()
    {
        //
        DialogUI.Instance.SetTitle("Notification")
                         .SetMessage("Hello")
                         .SetButtonColor(DialogButtonColor.Blue)
                         .SetFadeInDuration(1f)
                         .SetButtonText("ok")
                         .OnClose( () => Debug.Log("Closed") )
                         .Show();
        //
        DialogUI.Instance.SetTitle("Notification")
                         .SetMessage("Hello again")
                         .SetButtonColor(DialogButtonColor.Blue)
                         .SetFadeInDuration(1f)
                         .SetButtonText("ok")
                         .OnClose(() => Debug.Log("Closed"))
                         .Show();
        //
        DialogUI.Instance.SetTitle("Notification")
                         .SetMessage("End")
                         .SetButtonColor(DialogButtonColor.Blue)
                         .SetFadeInDuration(1f)
                         .SetButtonText("ok")
                         .OnClose(() => Debug.Log("Closed"))
                         .Show();
    }

}
