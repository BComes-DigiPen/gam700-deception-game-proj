using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject NPCPrefab;
    public GameObject playerPrefab;
    public int numberOfNPCs = 10;
    public float startLineXValue = -8;
    public float startLineYValueRange = 8;

    private int playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = Random.Range(1, numberOfNPCs);

        for (int i = 0; i < numberOfNPCs; i++)
        {
            if (i == playerPosition)
            {
                Instantiate(playerPrefab, new Vector2(startLineXValue, (startLineYValueRange / 2) - i * (startLineYValueRange / (numberOfNPCs - 1))), Quaternion.identity);
            }
            else
            {
                Instantiate(NPCPrefab, new Vector2(startLineXValue, (startLineYValueRange / 2) - i * (startLineYValueRange / (numberOfNPCs - 1))), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
