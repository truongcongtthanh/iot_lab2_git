using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using static uPLibrary.Networking.M2Mqtt.MqttClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace M2MqttUnity
//{
public class Manager : MonoBehaviour
{	
	public Image On_led;
	public Image Off_led;
    	
	public Image On_pump;
	public Image Off_pump;		
	
	public InputField Input_broker;
	public InputField Input_username;
	public InputField Input_password;

	public static MqttClient client;
	public static string mess;
	
    // Start is called before the first frame update
    void Start()
    {
     	  
    }

    // Update is called once per frame
    void Update()
    {
	
    }
	
	private void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string message = Encoding.UTF8.GetString(e.Message);
	    Debug.Log("receive data 1: ");
	    Debug.Log(message);
	    Debug.Log(message.GetType());
	    mess = message;
	    //Debug.Log(mess);
            //text_temp.text = "Thanh";
	    //text_humi.text = message;
        }
    public void ChangScene()
    {
	client = new MqttClient(Input_broker.text);
	client.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
        client.Subscribe(new string[] { "/bkiot/1814036/status" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

	var state = client.Connect("ThanhTest", Input_username.text, Input_password.text, false, 0, false, null, null, true, 60);

	//client.Publish("/bkiot/1814111/status", Encoding.UTF8.GetBytes("Thanh dep trai"));
	Debug.Log("Connect success!");
     	SceneManager.LoadScene("Scene2");

	// subcribe
	
	
    }

	public void ON_led()
	{	
		Debug.Log("LED OFF");
		Off_led.gameObject.SetActive(true);
		On_led.gameObject.SetActive(false);
		Manager.client.Publish("/bkiot/1814036/led", Encoding.UTF8.GetBytes(@"{""device"":""LED"",""status"":""OFF""}"));
		Debug.Log("published data!");
	}

    public void OFF_led()
	{
		Debug.Log("LED ON");
		On_led.gameObject.SetActive(true);
		Off_led.gameObject.SetActive(false);
		Manager.client.Publish("/bkiot/1814036/led", Encoding.UTF8.GetBytes(@"{""device"":""LED"",""status"":""ON""}"));
		Debug.Log("published data!");
	}

	public void ON_pump()
	{	
		Debug.Log("PUMP OFF");
		Off_pump.gameObject.SetActive(true);
		On_pump.gameObject.SetActive(false);
		Manager.client.Publish("/bkiot/1814036/pump", Encoding.UTF8.GetBytes(@"{""device"":""PUMP"",""status"":""OFF""}"));
		Debug.Log("published data!");
	}

    public void OFF_pump()
	{
		Debug.Log("PUMP ON");
		On_pump.gameObject.SetActive(true);
		Off_pump.gameObject.SetActive(false);
		Manager.client.Publish("/bkiot/1814036/pump", Encoding.UTF8.GetBytes(@"{""device"":""PUMP"",""status"":""ON""}"));
		Debug.Log("published data!");
	}
}
//}
