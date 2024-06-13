using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private int _itemCoinSpinCounter, _itemCoinShineCounter, _itemHeartCounter;
    [Header("Need To Un Lock")]
    [SerializeField] private int _needToUnlockDoubleJump, _needToUnlockDash, _needToUnlockBallModeAndDropsBombs;
    private PlayerExtrasTracker playerExtrasTracker;
    private UIManager uiManager;

    public int NeedToUnlockDoubleJump { get => _needToUnlockDoubleJump; set => _needToUnlockDoubleJump = value; } 
    public int NeedToUnlockDash { get => _needToUnlockDash;  set => _needToUnlockDash = value; }
    public int NeedToUnlockBallModeAndDropsBombs { get => _needToUnlockBallModeAndDropsBombs;  set => _needToUnlockBallModeAndDropsBombs = value; }

    public int ItemCoinSpinCounter { get => _itemCoinSpinCounter;   set => _itemCoinSpinCounter = value; }

    public int ItemCoinShineCounter { get => _itemCoinShineCounter; set => _itemCoinShineCounter = value; }
    public int ItemHeartCounter { get => _itemHeartCounter; set => _itemHeartCounter = value; }

    private void Start()
    {
        playerExtrasTracker = GameObject.Find("Player").GetComponent<PlayerExtrasTracker>();
        uiManager = GameObject.Find("UIManager").GetComponent <UIManager>();
    }

    public void AddHeart()
    {
        if (ItemHeartCounter < NeedToUnlockDoubleJump)
        {
            ItemHeartCounter++;
            uiManager.HeartCounter = ItemHeartCounter;
            if (ItemHeartCounter >= NeedToUnlockDoubleJump)
            {
                playerExtrasTracker.CanDoubleJump = true;
            }
        }
    }
    public void AddCoinSpin()
    {
        if (ItemCoinSpinCounter < NeedToUnlockDash)
        {
            ItemCoinSpinCounter++;
            uiManager.CoinSpinCounter = ItemCoinSpinCounter;
            if (ItemCoinSpinCounter >= NeedToUnlockDash)
            {
                playerExtrasTracker.CanDash = true;
            }
        }
    }

    public void AddCoinShine()
    {
        if (ItemCoinShineCounter < NeedToUnlockBallModeAndDropsBombs)
        {
            ItemCoinShineCounter ++;
            uiManager.CoinShineCounter = ItemCoinShineCounter;
            if (ItemCoinShineCounter >= NeedToUnlockBallModeAndDropsBombs)
            {
                playerExtrasTracker.CanDropBombs = true;
                playerExtrasTracker.CanEnterBallMode = true;
            }
        }
    }

}
