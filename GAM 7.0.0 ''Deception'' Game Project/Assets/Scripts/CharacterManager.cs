using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject NPCPrefab;
    public GameObject PlayerPrefab;
    //public int numberOfNPCs = 6;

    GameObject[] NPCs;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            Instantiate(NPCPrefab, new Vector2(-9, 4-i), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
