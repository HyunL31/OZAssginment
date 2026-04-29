using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI slotText;
    [SerializeField] private Button slotButton;

    public int SlotIndex {  get; private set; }

    public event Action<int> OnClickEvent;

    private void OnEnable()
    {
        slotText.text = this.SlotIndex.ToString();
        slotButton.onClick.AddListener(OnClickSlot);
    }

    public void Init(int slotIndex)
    {
        SlotIndex = slotIndex;
        slotText.text = slotIndex.ToString();
    }

    public void BindEvent(Action<int> onClickEvent)
    {
        OnClickEvent = onClickEvent;
    }

    public void OnClickSlot()
    {
        OnClickEvent?.Invoke(SlotIndex);
    }
}