using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
namespace BuilderPattern
{
    public enum DialogButtonColor
    {
        Black,
        Red,
        Blue,
        Green,
        Yellow,
        Pink,
        Purple,
        Orange
    }
    public class Dialog : MonoBehaviour
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string ButtonText { get; set; }
        public float FadeInDuration { get; set; }
        public DialogButtonColor ButtonColor { get; set; }
        public UnityAction OnClose { get; set; } 

    public Dialog(string title, string message, string buttonText, float duration, DialogButtonColor color, UnityAction action )
        {
            Title = title;
            Message = message;
            ButtonText = buttonText;
            FadeInDuration = duration;
            ButtonColor = color;
            OnClose = action;
        }
    }
}


