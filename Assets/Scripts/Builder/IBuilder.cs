using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace BuilderPattern
{
    interface IBuilder 
    {
        DialogBuilder SetTitle(string title);
        DialogBuilder SetMessage(string message);
        DialogBuilder SetButtonText(string text);
        DialogBuilder SetButtonColor(DialogButtonColor color);
        DialogBuilder SetFadeInDuration(float duration);
        DialogBuilder OnClose(UnityAction action);
        Dialog Build();


    }

}
