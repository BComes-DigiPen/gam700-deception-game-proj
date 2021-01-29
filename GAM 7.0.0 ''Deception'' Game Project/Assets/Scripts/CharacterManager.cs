using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject NPCPrefab;
    public GameObject PlayerPrefab;
    public int numberOfNPCs = 10;
    public float startLineXValue = -8;
    public float startLineYValueRange = 8;

    GameObject[] NPCs;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfNPCs; i++)
        {
            Instantiate(NPCPrefab, new Vector2(startLineXValue, (startLineYValueRange / 2) - i * (startLineYValueRange / (numberOfNPCs - 1))), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
