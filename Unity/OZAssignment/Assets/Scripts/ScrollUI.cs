using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollUI : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform scrollParent;
    [SerializeField] private Button createButton;

    private int generateNum = 1;
    public Dictionary<int, SlotUI> slots = new Dictionary<int, SlotUI>();

    public void OnEnable()
    {
        createButton.onClick.AddListener(CreateSlot);
    }

    private void CreateSlot()
    {
        var slot = Instantiate(slotPrefab, scrollParent);
        slot.name = $"Slot: {generateNum}";

        var slotComponent = slot.GetComponent<SlotUI>();

        slotComponent.Init(generateNum);

        slots.Add(slotComponent.SlotIndex, slotComponent);

        generateNum++;

        slotComponent.BindEvent(OnClickSlotButton);
    }

    private void OnClickSlotButton(int slotIndex)
    {
        Debug.Log($"자식 슬롯 {slotIndex}을 눌렀습니다.");
    }
}