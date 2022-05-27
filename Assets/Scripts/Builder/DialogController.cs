using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
namespace BuilderPattern
{
    public class DialogController : MonoBehaviour
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
        private void Awake()
        {
            closeUIButtonImage = closeUIButton.GetComponent<Image>();
            closeUIButtonText = closeUIButton.GetComponentInChildren<Text>();
            canvasGroup = canvas.GetComponent<CanvasGroup>();
            //add close event listener
            closeUIButton.onClick.RemoveAllListeners();
            closeUIButton.onClick.AddListener(Hide);
        }
        //Show Dialogq
        public void InitDialog(Dialog dialog)
        {
            canvas.SetActive(true);
            titleUIText.text = dialog.Title;
            messageUIText.text = dialog.Message;
            closeUIButtonText.text = dialog.ButtonText;
            closeUIButtonImage.color = buttonColors[(int)dialog.ButtonColor];
            StartCoroutine(FadeIn(dialog.FadeInDuration));
        }

        //Hide Dialog
        public void Hide()
        {
            canvas.SetActive(false);
            StopAllCoroutines();
            //Invoke Close event

        }
        IEnumerator FadeIn(float duration)
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

