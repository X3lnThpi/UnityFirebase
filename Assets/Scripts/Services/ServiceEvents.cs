using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceEvents : Singleton<ServiceEvents>
{
    public event Action OnChestClicked;
    public event Action<int> OnUnlockWithGem;
    public event Action OnTimerUnlock;
    
    public void UnlockWithGems(int gems)
    {
        OnUnlockWithGem.Invoke(gems);
        Debug.Log("Observer & Listner");
    }

    private void OnEnable() {
        OnUnlockWithGem += UnlockWithGems;
        OnUnlockWithGem?.Invoke(60);
    }
}
