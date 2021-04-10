# FlightGear Simulator Desktop Application
A desktop application for the FlightGear flight simulator, used to fly an aircraft using a stream of data given as a CSV file by the user. <br/>
Implmented using WPF technology and MVVM architecture.

### Installing 
* Download and install the simulator on your computer- https://www.flightgear.org/download/
* Add the  playback_small.xml file to the /data/Protocol directory where you installed the simulator
* Config the following settings in the 'Settings' tab in the simulator:
```
--generic=socket,in,10,127.0.0.1,5400,tcp,playback_small
--fdm=null
```
![flightGear-config](https://user-images.githubusercontent.com/72696075/114277280-351c7880-9a33-11eb-9ef8-b71fbd385865.png)

This will open a communication socket for sending data to the simulator.

### About the app
On startup, the main window will be presented:

![MainController1](https://user-images.githubusercontent.com/72696075/114277397-aeb46680-9a33-11eb-96af-2bd0d4dcfc82.png)

This is the window which will be used in order to control the simulator:
The left-hand side is a live updating multiple graphs for each data member according to the data of the flight.
You will also find in the buttom left side the data of the dashboard of the plane e.g. the altimeter/airspeed/flight direction/pitch/roll/yaw.
The right-hand side shows the status of the controllers of the plane, e.g. the Joystick and the rudder/throttle data.

## Flying the aircraft
First, run the simulator, click on the 'Fly!' icon in the bottom left corner.
The aircraft flight is being dictated by the CSV file uploaded in the main controller window and shown to the user, Therefore flick on it and upload the wanted flight file.

![uploadBtn](https://user-images.githubusercontent.com/72696075/114277427-d1df1600-9a33-11eb-9481-2697820bbccf.png)

### Controlling the flight investigation
Using the playback bar you are able to control the exact playback speed in which the flight will be executed.
Further more you can use the bar below to reset/stop/continue the flight and change the location of the bar pointer to jump to a specific time in the flight.

![flightPic](https://user-images.githubusercontent.com/72696075/114277649-b3c5e580-9a34-11eb-86b4-dce3f628d699.png)

Enjoy your flight!
