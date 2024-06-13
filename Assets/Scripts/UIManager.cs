using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private ItemManager itemManager;
   
    private int _coinSpinCounter, _coinShineCounter, _heartCounter;
    public int CoinSpinCounter { get => _coinSpinCounter;  set => _coinSpinCounter = value; }
    public int CoinShineCounter { get =>_coinShineCounter;  set => _coinShineCounter = value; }
    public int HeartCounter { get => _heartCounter;  set => _heartCounter = value; }

    private void Start()
    {
        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
        
        
    }
    private void OnGUI()
    {
        GUILayout.BeginVertical();
        GUILayout.Box("Hearts: " + HeartCounter + " Unlock double jump: " + itemManager.NeedToUnlockDoubleJump);
        GUILayout.Box("Coins Spin: " + CoinSpinCounter + " Unlock dash: " + itemManager.NeedToUnlockDash);
        GUILayout.Box("Coins shine: " + CoinShineCounter + " Unlock ball mode and drops bombs: " + itemManager.NeedToUnlockBallModeAndDropsBombs);
        GUILayout.EndVertical();
    }
}
