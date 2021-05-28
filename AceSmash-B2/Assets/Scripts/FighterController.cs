using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using System;

public class FighterController : MonoBehaviour
{
    public Transform groundPoint;
    public float groundRadius;
    public LayerMask groundBase;

    public bool isGrounded;

    public KeyCode gauche;
    public KeyCode droite;
    public KeyCode lancerBalle;
    public KeyCode saut;

    public float vitesseDeplacement;
    public float hauteurSaut;

    public GameObject cherryBall;
    public Transform cherryThrow;

    private Animator anim;

    private Rigidbody2D RB; // rigobody 2D

    [Serializable]
    public class Jsonmessage
    {
        public string stick;
        public string player;
        public string button;
        //public string evenenement;
    }
    public List<String> PlayersId;
    private MqttClient client;
    private string message;
    private string brokerHostName = "51.158.79.224";

    public string stick;
    public string button;


    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // create client instance 
        client = new MqttClient(brokerHostName);
        // register to message received 
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
        string clientId = Guid.NewGuid().ToString();
        client.Connect(clientId);
        client.Publish("ROBIER/TestUnity", System.Text.Encoding.UTF8.GetBytes("connect"), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
        client.Subscribe(new string[] { "ROBIER/joystick" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //client.Publish("ROBIER/joystick", System.Text.Encoding.UTF8.GetBytes("{\"stick\": \"C\", \"player\": \"bac2\"}"), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);

    }

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {

        //Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
        message = System.Text.Encoding.UTF8.GetString(e.Message);
        var jsoncommand = JsonUtility.FromJson<Jsonmessage>(message);
        //Debug.Log("player" + jsoncommand.player);
        //Debug.Log("stick" + jsoncommand.stick);
        //Debug.Log("button" + jsoncommand.button);
        stick = jsoncommand.stick;
        button = jsoncommand.button;

        //Debug.Log("evenement" + jsoncommand.evenenement);
    }

    // Update is called once per frame
    void Update()
    { 
       
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, groundRadius, groundBase);
        if (Input.GetKey(gauche) || FindObjectOfType<FighterController>().stick == "W")
        {
            RB.velocity = new Vector2(-vitesseDeplacement, RB.velocity.y);
        }
        else if (Input.GetKey(droite) || FindObjectOfType<FighterController>().stick == "E")
        {
            RB.velocity = new Vector2(vitesseDeplacement, RB.velocity.y);
        }
        else
        {
            RB.velocity = new Vector2(0, RB.velocity.y);
        }

        if ((Input.GetKeyDown(saut) || FindObjectOfType<FighterController>().button == "yellow") && isGrounded)
        {
            RB.velocity = new Vector2(RB.velocity.x, hauteurSaut);
        }

        if (Input.GetKeyDown(lancerBalle) || FindObjectOfType<FighterController>().button == "green")
        {
            GameObject cherryBallClone = (GameObject)Instantiate(cherryBall, cherryThrow.position, cherryThrow.rotation);
            cherryBallClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Lancer");
        }

        if (RB.velocity.x <0)
            {
                transform.localScale = new Vector3(-3,3,1);
            } else if (RB.velocity.x > 0) {
                transform.localScale = new Vector3(3,3,1);
            }

        anim.SetFloat("Speed", Mathf.Abs(RB.velocity.x));
        anim.SetBool("Grounded", isGrounded);
    }
 
}
