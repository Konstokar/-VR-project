using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _clutterLevel;
    
    public int ClutterLevel
    {
        get=>_clutterLevel;
    }
    
    private GameManager _instance;
    
    public GameManager Instance => _instance;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
