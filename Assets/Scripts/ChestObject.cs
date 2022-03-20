using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestObject : MonoBehaviour
{
    public Chest chest;
    public int minCoins;
    public int maxCoins;
    int minGems;
    int maxGems;

    public void Start()
    {
        minCoins = chest.minCoins;
        maxCoins = chest.maxCoins;
        minGems = chest.minGems;
        maxGems = chest.maxGems;
    }

    public int RewardCoin()
    {
        return Random.Range(minCoins, maxCoins + 1);
    }

    public int RewardGem()
    {
        return Random.Range(minGems, maxGems + 1);
    }

}

