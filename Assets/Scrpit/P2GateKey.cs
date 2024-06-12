using UnityEngine;

public class P2GateKey : MonoBehaviour
{  
    public GameObject key2;
    private void Awake()
    {
        key2 = GameObject.FindGameObjectWithTag("P2GateKey");   
    }
    private void Update()
    {
        if(P2Movement.hedkey)
        {
            key2.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2") // check if the player is collide with the key or not
        {
            P2Movement.hedkey = true;
        }
    }
}//class