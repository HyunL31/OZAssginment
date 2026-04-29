using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text descriptionText;

    private string playerName = "플레이어 이름입니다.";
    private string playerDescription = "어쩌구 저쩌구";

    void Awake()
    {
        nameText.text = playerName;
        descriptionText.text = playerDescription;
    }
}
