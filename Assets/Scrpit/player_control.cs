using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class player_control : MonoBehaviour
{    
    public static float _PlayerSpeed = 3f;
    public Rigidbody2D _rb;
    public static Vector2 _MovementValue;
    public static bool _IsAlive;
    public static bool P1isongate;
    public static bool P1passGate;
    public static bool hadkey;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _IsAlive = true;
        hadkey = false;
        P1isongate = false;
        P1passGate = false;
    }

    private void Update()
    {
        intraction(); //to use key in every frame without frames restricson
    }
    private void FixedUpdate()
    {
        if (_IsAlive) // to run movement smooth 
        {
            _rb.velocity = _MovementValue * _PlayerSpeed; 
        }
    }
    void intraction()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (P1isongate && hadkey && P2Movement.hedkey && P2Movement.P2isongate) // check if both players has key or not
            {
                P1passGate = true;
                Debug.Log("Pass the Gate " + gameObject.name);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                _IsAlive = false; 
            }
        }
    }
    private void OnMove(InputValue inputValue)// keys input 
    {
            _MovementValue = inputValue.Get<Vector2>(); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")//player 1 daeth check
        {
            _IsAlive = false;
            Debug.Log("Player is dead");
        }
        if (collision.gameObject.tag == "P1_Gate" )//player on gate check
        {
            P1isongate = true;
            Debug.Log("player is on gate" + gameObject.name);
        }
        if (collision.gameObject.tag == "P1GateKey") //key check
        { 
            hadkey = true;
            Debug.Log(" player has key" + gameObject.name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "P1_Gate") // player off the gate check
        {
            P1isongate = false;
            Debug.Log("is not on the gate" + gameObject.name);
        }
    }
}//class