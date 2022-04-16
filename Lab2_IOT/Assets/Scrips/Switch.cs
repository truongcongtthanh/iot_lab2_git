using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Switch : MonoBehaviour
{	
    public Text text_temp;
    public Text text_humidity;
    // Start is called before the first frame update
    void Start()
    {
	
	
    }

    // Update is called once per frame
    void Update()
    {	
	Thread.Sleep(150);
	string data1 = Manager.mess;
	char[] data = data1.ToCharArray();
        string[] keys = new string[100];
        string[] values = new string[100];
        int count = 0;
        for (int i = 1;i<data.Length;i++)
        {
         
            if ((data[i].CompareTo('\"')) == 0) 
            {
                char[] key = new char[300];
                int count_key = 0;
                int count_number = 0;
                while ((data[i+1].CompareTo('\"')) != 0) 
                {
                    key[count_key] = data[i+1];
                    i=i+1;
                    count_key = count_key+1;
                    count_number = count_number+1;
                }
                i = i+1;
                char[] key1 = new char[count_number];
                for (int j = 0; j < count_number;j++)
                {
                    key1[j]=key[j];
                }
                keys[count] = new string(key1);
                count = count+1;
            } 
            else if ((data[i].CompareTo(':')) == 0)
            {   
                char[] value = new char[300];
                int count_value = 0;
                int count_number = 0;	
		if((data[i+1].CompareTo(' ')) == 0 || (data[i+1].CompareTo('\"')) == 0){
                    i = i + 1;//space    
                }
                
                while ((data[i+1].CompareTo(',')) != 0 && (data[i+1].CompareTo('}')) != 0 )
                {
                    value[count_value] = data[i+1];
                    i=i+1;
                    count_value = count_value +1;
                    count_number = count_number+1;
                }
                i=i+1; 
                char[] value1 = new char[count_number];
                for (int j = 0; j < count_number;j++)
                {
                    value1[j]=value[j];
                }
                values[count-1] = new string(value1);
                
            }
             
        }
      
        Debug.Log(count);
        for (int j = 0;j < count; j++){
            if(keys[j].Equals("humidity")){
                text_humidity.text = "Humi\n"+values[j] + "%";	
		Debug.Log(values[j]);
            }
	else if(keys[j].Equals("HUMI")){
                text_humidity.text = "Humi\n"+values[j] + "%";	
		Debug.Log(values[j]);
            }	

	else if(keys[j].Equals("temperature")){
                text_temp.text = "Temp\n"+values[j] + "°C";
		Debug.Log(values[j]);
            }
	else if(keys[j].Equals("temp")){
                text_temp.text = "Temp\n"+values[j] + "°C";
		Debug.Log(values[j]);
            }
	else if(keys[j].Equals("TEMP")){
                text_temp.text = "Temp\n"+values[j] + "°C";
		Debug.Log(values[j]);
            }
        }
// end	
	
	//text_temp.text = Manager.mess;
	//Debug.Log(Manager.mess);
	//text_humi.text = "%";      
    }

   
}
