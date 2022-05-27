using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
namespace EasyUI.Dialogs
{
    public enum DialogButtonColor
    {
        Black,
        Purple,
        Magneta,
        Blue,
        Green,
        Yellow,
        Orange,
        Red
    }
    public class Dialog
    {
        public string Title="Title";
        public string Message="Message goes here";
        public string ButtonText = "Close";
        public float FadeInDuration = .3f;
        public DialogButtonColor ButtonColor = DialogButtonColor.Black;
        public UnityAction OnClose=null;
    }

    public class DialogUI : MonoBehaviour
    {
        [SerializeField] GameObject canvas;
        [SerializeField] Text titleUIText;
        [SerializeField] Text messageUIText;
        [SerializeField] Button closeUIButton;
        
        Image closeUIButtonImage;
        Text closeUIButtonText;
        CanvasGroup canvasGroup;

        [Space(20f)]
        [Header("Close button colors")]
        [SerializeField] Color[] buttonColors;

        Queue<Dialog> dialogsQueue = new Queue<Dialog>();
        Dialog tempDialog;
        Dialog dialog = new Dialog();
        public bool IsActive = false;
        //singeton pattern
        public static DialogUI Instance;
        private void Awake()
        {
            Instance = this;
            closeUIButtonImage = closeUIButton.GetComponent<Image>();
            closeUIButtonText = closeUIButton.GetComponentInChildren<Text>();
            canvasGroup = canvas.GetComponent<CanvasGroup>();
            //add close event listener
            closeUIButton.onClick.RemoveAllListeners();
            closeUIButton.onClick.AddListener(Hide);    
        }

        //Set dialog title
        public DialogUI SetTitle(string title)
        {
            dialog.Title = title;
            return Instance;
        }
        //Set dialog message
        public DialogUI SetMessage(string message)
        {
            dialog.Message = message;
            return Instance;
        }
        public DialogUI SetButtonText(string text)
        {
            dialog.ButtonText = text;
            return Instance;
        }
        public DialogUI SetButtonColor(DialogButtonColor color)
        {
            dialog.ButtonColor = color;
            return Instance;
        }
        public DialogUI SetFadeInDuration(float duration)
        {
            dialog.FadeInDuration = duration;
            return Instance;
        }
        public DialogUI OnClose(UnityAction action)
        {
            dialog.OnClose = action;
            return Instance;
        }
        //Show Dialog
        public void Show()
        {
            dialogsQueue.Enqueue(dialog);
            //Reset dialog
            dialog = new Dialog();
            if(!IsActive)
            {
                ShowNextDialog();
            }
        }
        void ShowNextDialog()
        {
            tempDialog = dialogsQueue.Dequeue();
            titleUIText.text = tempDialog.Title;
            messageUIText.text = tempDialog.Message;
            closeUIButtonText.text = tempDialog.ButtonText.ToUpper();
            closeUIButtonImage.color = buttonColors[(int)tempDialog.ButtonColor];
            
            canvas.SetActive(true);
            IsActive = true;
            StartCoroutine(FadeIn(tempDialog.FadeInDuration));
        }

        //Hide Dialog
        public void Hide()
        {
            canvas.SetActive(false);
            IsActive = false;

            //Invoke OnCloseEvent
            if (tempDialog.OnClose != null) tempDialog.OnClose.Invoke();

            StopAllCoroutines();

            if(dialogsQueue.Count!=0)
            {
                ShowNextDialog();
            }
        }

        IEnumerator FadeIn (float duration)
        {
            float startTime = Time.time;
            float alpha = 0f;
            while (alpha < 1f)
            {
                alpha = Mathf.Lerp(0f, 1f, (Time.time - startTime) / duration);
                canvasGroup.alpha = alpha;

                yield return null;
            }
        }
    }


}