# FlightGear Simulator Desktop Application
A desktop application for the FlightGear flight simulator, used to fly an aircraft using a stream of data given as a CSV file by the user. <br/>
Implmented using WPF technology and MVVM architecture.

### Installing 
* Download and install the simulator on your computer- https://www.flightgear.org/download/
* Add the playback_small.xml file to the /data/Protocol directory where you installed the simulator
* Config the following settings in the 'Settings' tab in the simulator:
```
--generic=socket,in,10,127.0.0.1,5400,tcp,playback_small
--fdm=null
```
![flightGear-config](https://user-images.githubusercontent.com/72696075/114277280-351c7880-9a33-11eb-9ef8-b71fbd385865.png)

This will open a communication socket for sending data to the simulator.

### About the app
On startup, the main window will be presented:

![startup app](https://user-images.githubusercontent.com/73164258/114630182-af166100-9cc2-11eb-907c-8fc7e0b58f17.png)

This is the window which will be used in order to control the simulator:
The left-hand side is a live updating multiple graphs for each data member according to the data of the flight.
You will also find in the buttom left side the data of the dashboard of the plane e.g. the altimeter/airspeed/flight direction/pitch/roll/yaw.
The right-hand side shows the status of the controllers of the plane, e.g. the Joystick and the rudder/throttle data.

## Our Features
There are 9 main features for our simulator:

### Flying the aircraft
First, run the simulator, click on the 'Fly!' icon in the bottom left corner.
The aircraft flight is being dictated by the CSV file uploaded in the main controller window and shown to the user, Therefore click on it and upload the wanted flight file.
Make sure the playback_small.xml file is in the right place with the right headlines for the CSV.

![flyandtrain](https://user-images.githubusercontent.com/73164258/114630490-63b08280-9cc3-11eb-8421-25e9b13e92f3.png)

After uploading the CSV file, when you're ready to fly- fasten your seatbelts and click the PLAY buttom on the playback bar:
![Play](https://user-images.githubusercontent.com/73164258/114630923-48924280-9cc4-11eb-86a3-dafe1ba88686.png)

### Controlling the flight investigation
Using the playback bar you are able to control the exact playback speed in which the flight will be executed.
Further more you can use the bar below to reset/stop/continue the flight and change the location of the bar pointer to jump to a specific time in the flight.

![playback bar](https://user-images.githubusercontent.com/73164258/114630983-695a9800-9cc4-11eb-8b7b-db060349cd6b.png)


### UML Diagram of the project

![FlightGear UML](https://user-images.githubusercontent.com/72696075/114566337-d47f7c80-9c7a-11eb-82d1-84b8367a3c06.png)

Enjoy your flight!
