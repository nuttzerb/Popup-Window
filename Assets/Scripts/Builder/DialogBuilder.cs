using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace BuilderPattern
{
    public class DialogBuilder :MonoBehaviour,IBuilder
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string ButtonText { get; set; }
        public float FadeInDuration { get; set; }
        public DialogButtonColor ButtonColor { get; set; }
        public UnityAction onClose { get; set; }

        public DialogBuilder SetTitle(string title)
        {
            Title = title;
            return this;
        }
        public DialogBuilder SetMessage(string message)
        {
            Message = message;
            return this;

        }
        public DialogBuilder SetButtonText(string text)
        {
            ButtonText = text;
            return this;
        }

        public DialogBuilder SetButtonColor(DialogButtonColor color)
        {
            ButtonColor = color;
            return this;
        }

        public DialogBuilder SetFadeInDuration(float duration)
        {
            FadeInDuration = duration;
            return this;
        }

        public DialogBuilder OnClose(UnityAction action)
        {
            onClose = action;
            return this;
        }

        public Dialog Build()
        {
            return new Dialog(Title, Message, ButtonText, FadeInDuration, ButtonColor, onClose);
        }
    }
}
