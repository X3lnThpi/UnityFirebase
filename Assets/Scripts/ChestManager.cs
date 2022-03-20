using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestManager : MonoBehaviour
{
    public Button generateChest;
    public GameObject commonChest;
    public GameObject epicChest;
    public GameObject legendaryChest;
    public GameObject rareChest;
    public Transform[] slots;
    public TMP_Text coinCount;
    public TMP_Text gemCount;
    int coins, gems;

    GameObject[] ChestList = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
       // chestList = new GameObject[4];
        generateChest.onClick.AddListener(SpawnChest);
    }

   void SpawnChest()
    {

        for(int i = 0; i < slots.Length; i++)
        {
            if(ChestList[i] == null)
            {
                int value = Random.Range(1, 65);
                if (value >= 1 && value <= 30)
                    ChestList[i] = Instantiate(commonChest, slots[i].position - new Vector3(0,0, 0), Quaternion.identity);
                else if (value >= 31 && value <= 51)
                    ChestList[i] = Instantiate(epicChest, slots[i].position - new Vector3(0,0,0), Quaternion.identity);
                else if (value >= 52 && value <= 62)
                    ChestList[i] = Instantiate(legendaryChest, slots[i].position - new Vector3(0,0,0), Quaternion.identity);
                else 
                    ChestList[i] = Instantiate(rareChest, slots[i].position - new Vector3(0,0,0), Quaternion.identity);

            }
        }
        Debug.Log("Chest Spawned");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null)
            {
                if(hit.transform.gameObject.tag == "Chest")
                {
                    coinCount.text = ""+18;
                    //coins += hit.transform.GetComponent<ChestObject>().maxCoins;
                    coinCount.text = coins.ToString();
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
