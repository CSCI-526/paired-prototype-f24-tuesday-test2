using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    public int gold = 100;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        string goldText = "Gold: " + gold;   
        GameObject.Find("Money").GetComponent<UnityEngine.UI.Text>().text = goldText;
    }
}
