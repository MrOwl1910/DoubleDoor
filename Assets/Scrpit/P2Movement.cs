using UnityEngine;
public class P2Movement : MonoBehaviour
{
    public Rigidbody2D _rb;
    public static bool P2isongate;
    public static bool P2passGate;
    public static bool hedkey;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
       player_control._IsAlive = true;
        P2isongate = false;
        P2passGate = false;
        hedkey = false;
    }
    private void Update()
    {
        intraction();//to use key in every frame without frames restricson
    }
    private void FixedUpdate()
    {
        if (player_control._IsAlive) // check if player 1 is alive let this one move
        {
            _rb.velocity = -player_control._MovementValue * player_control._PlayerSpeed;
        }   
    }
    void intraction()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (player_control.P1isongate && player_control.hadkey && hedkey && P2isongate) // check if both players has key or not
            {
                P2passGate = true;
                Debug.Log("Pass the Gate " + gameObject.name);
            }
            else
            {
                player_control._IsAlive = false;
                FindObjectOfType<AudioManeger>().Play("PlayerDeath");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Death") //player 1 daeth check
        {
            player_control._IsAlive = false;
            FindObjectOfType<AudioManeger>().Play("PlayerDeath");
            Debug.Log("Player is dead");
        }
        if (collision.gameObject.tag == "P2_Gate") //player on gate check 
        {
            P2isongate = true;
            Debug.Log("player is on gate" + gameObject.name);
        }
        if (collision.gameObject.tag == "P2GateKey") //key check 
        {
            hedkey = true;
            FindObjectOfType<AudioManeger>().Play("PickUp");
            Debug.Log(" player has key" + gameObject.name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "P2_Gate") // player off the gate check
        {
            P2isongate = false;
            Debug.Log("is not on the gate" + gameObject.name);
        }
    }
}//class