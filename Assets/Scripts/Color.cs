using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public List<GameObject> color;
    public GameObject Player;
    public int colors = 0; 

    // Start is called before the first frame update
    void Start()
    {
        Player = color[1];
    }
    private void OnEnable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Changecolor();
        }
    }
    public void Changecolor()
    {
        Player.SetActive(false);
        Player = color[colors++];
        if (colors == color.Count)
        {
            colors = 0;
        }
        Player.SetActive(true);
    }
}
