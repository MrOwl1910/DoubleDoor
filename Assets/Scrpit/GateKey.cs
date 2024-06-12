using UnityEngine;
public class GateKey : MonoBehaviour
{  
    public GameObject key;
    private void Awake()
    {
        key = GameObject.FindGameObjectWithTag("P1GateKey");   
    }
    private void Update()
    {
        if(player_control.hadkey)
        {
            key.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // check if the player is collide with the key or not
        {
            player_control.hadkey = true;
        }
    }
}//class
