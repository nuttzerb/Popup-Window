using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuilderPattern;

public class DemoBuilder : MonoBehaviour
{
    [SerializeField] DialogController dialogController;
    private void Start()
    {
        Dialog dialogBuild = GetDialogData();
        dialogController.InitDialog(dialogBuild);
    }
    private Dialog GetDialogData()
    {
        return gameObject.AddComponent<DialogBuilder>()
              .SetTitle("Notification")
              .SetMessage("Helloooo")
              .SetButtonText("OK")
              .SetButtonColor(DialogButtonColor.Blue)
              .SetFadeInDuration(1f)
              .OnClose( delegate { Debug.Log("Closed"); } )
              .Build();
    }
}
