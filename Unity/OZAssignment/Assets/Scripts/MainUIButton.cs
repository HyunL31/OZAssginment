using UnityEngine;
using UnityEngine.UI;

public class MainUIButton : MonoBehaviour
{
    [SerializeField] private Button popupButton;
    [SerializeField] private GameObject popupScreen;

    public void OnClickPopup()
    {
        popupScreen.SetActive(true);
        popupButton.image.color = Color.red;
    }

    public void UnClickPopup()
    {
        popupButton.image.color = Color.white;
    }
}
