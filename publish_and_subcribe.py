import time
import paho.mqtt.client as paho
import random

broker="mqttserver.tk"
user_name = 'bkiot'
password = '12345678'
#define callback
def on_message(client, userdata, message):
    time.sleep(1)
    print("received message =",str(message.payload.decode("utf-8")))

client= paho.Client("Thanh_Truong_pub") #create client object client1.on_publish = on_publish #assign function to callback client1.connect(broker,port) #establish connection client1.publish("house/bulb1","on")
######Bind function to callback
client.username_pw_set(username=user_name,password=password)
client.on_message=on_message
#####
print("connecting to broker ",broker)
client.connect(host=broker,port=1883)#connect
#client.loop_start() #start loop to process received messages
print("subscribing ")
client.subscribe("/bkiot/1814036/status") #subscribe
time.sleep(2)
while True:
    print("publishing ")
    temp1 = random.randint(-31,30)
    humi1 = random.randint(-1,100)
    pub_text = "{\"temp\":"+str(temp1)+",\"humidity\":"+str(humi1)+"}"
    client.publish("/bkiot/1814036/status",pub_text)#publish
    print(pub_text)

    time.sleep(2)

client.disconnect() #disconnect
client.loop_stop() #stop loop
#client.loop_forever()