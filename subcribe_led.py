import time
import paho.mqtt.client as paho
broker="mqttserver.tk"
user_name = 'bkiot'
password = '12345678'
#define callback
def on_message(client, userdata, message):
    time.sleep(1)
    print("received message =",str(message.payload.decode("utf-8")))

client= paho.Client("Thanh_Truong_led") #create client object client1.on_publish = on_publish #assign function to callback client1.connect(broker,port) #establish connection client1.publish("house/bulb1","on")
######Bind function to callback
client.username_pw_set(username=user_name,password=password)
client.on_message=on_message
#####
print("connecting to broker ",broker)
client.connect(host=broker,port=1883)#connect
#client.loop_start() #start loop to process received messages
print("subscribing ")
client.subscribe("/bkiot/1814036/led") #subscribe
# time.sleep(2)
# while True:
#     print("publishing ")
#     client.publish("/bkiot/1814111/status","Thanh")#publish
#     time.sleep(1)
#
# client.disconnect() #disconnect
# client.loop_stop() #stop loop
client.loop_forever()