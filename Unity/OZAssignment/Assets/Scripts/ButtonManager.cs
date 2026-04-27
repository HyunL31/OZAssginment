using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OnClickStart()
    {
        Debug.Log("게임을 시작합니다.");

        gameObject.SetActive(false);
    }
}