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
The right-hand side is a live updating multiple graphs for each data member according to the data of the flight.
You will also find in the left side the data of the dashboard of the plane e.g. the altimeter/airspeed/flight direction/pitch/roll/yaw.
The left-hand side shows the status of the controllers of the plane, e.g. the Joystick and the rudder/throttle data.

## Application Features
There are 9 main features of our simulator:

### Flying the aircraft
First, run the simulator, click on the 'Fly!' icon in the bottom left corner.
The aircraft flight is being dictated by the CSV file uploaded in the main controller window and shown to the user, Therefore click on it and upload the wanted flight file.
Make sure the playback_small.xml file is in the right place with the right headlines for the CSV.

![flyandtrain](https://user-images.githubusercontent.com/73164258/114630490-63b08280-9cc3-11eb-8421-25e9b13e92f3.png)

After uploading the CSV file, when you're ready to fly- fasten your seatbelts and click the PLAY button on the playback bar:
![Play](https://user-images.githubusercontent.com/73164258/114630923-48924280-9cc4-11eb-86a3-dafe1ba88686.png)

### Controlling the flight investigation
Using the playback bar you are able to control the exact playback speed in which the flight will be executed.
Further more you can use the bar below to reset/stop/continue the flight and change the location of the bar pointer to jump to a specific time in the flight.

![5676](https://user-images.githubusercontent.com/73164258/114635251-002b5280-9ccd-11eb-855e-6a9a71266294.png)

### Main rudders
In the buttom left side of the application, you are able to view all the main rudders with their current values updated by time.
You can view the rudder value and the two throttles values with sliders that indicate their values. 
For the aileron and elevetor values you can view the joystick- its up and down motions indicates the elevator value and its left and right motions indicates the aileron.

![55555](https://user-images.githubusercontent.com/73164258/114635274-0d484180-9ccd-11eb-9532-25bb8d1a1ef4.png)

### Playback speed
When watching the simulator you can choose to watch some parts faster and other parts slower.
The default speed is 10Hz.
Move the playbackspeed slider in the buttom of the application- right for faster and left for slower.

![playback speed](https://user-images.githubusercontent.com/73164258/114632164-c2c3c680-9cc6-11eb-8db1-2002c4e0668e.png)

### Data
You can also view other data values of the flight- altimeter, airspeed, flight direction, pitch, roll and yaw.
In the left side of the application you can view all the exact values of this parameters changes by time.

![3424](https://user-images.githubusercontent.com/73164258/114635329-29e47980-9ccd-11eb-96d6-cac6a4e54eb1.png)

### Chosen feature graph
Right in the middle of the appliction you can choose any feature you want from the list and view its graph.
The X axis indicates the time and the Y axis indicates the value of the chosen feature.
The graph right next to the list will be the graph of the feature you chose.

![22](https://user-images.githubusercontent.com/73164258/114635348-3799ff00-9ccd-11eb-8153-459803f261a2.png)

### Correlative graph
Pay attention to read the feature above.
The right graph in the top will display the most correlated feature for the feature you chose from the list.
Notice we set no minimum for a correlation- the best correlated feature will be displayed and will be defined as the correlated feature.
The X axis indicates the time and the Y axis indicates the value of the most correlated feature for the chosen feature from the list.

![31241](https://user-images.githubusercontent.com/73164258/114635376-45e81b00-9ccd-11eb-8fa9-ac2c7fbe13c1.png)

### Regression line
Pay attention to read the two features above.
In the next graph you are going to view the regression line of the two features (the feature which is chosen from the list and its most correlative feature).
The green line in the graph indicates of the regression line
The black points in the graph indicates both the chosen feature and the most correlative feature points.
The orange points in the graph indicates the points of the last 30 seconds of the flight- you can enjoy watching it move with time.
An explanation of the red points is in the feature below.

![8888](https://user-images.githubusercontent.com/73164258/114635393-4ed8ec80-9ccd-11eb-906c-0be13b5db052.png)

### Anomalies graph
Pay attention to read the three features above.
You can choose to add another CSV file and detect anomalies.
The first CSV file you uploaded will be the train file and the next CSV will be for detect anomalies in it.
![anomalies](https://user-images.githubusercontent.com/73164258/114633886-1257c180-9cca-11eb-9bfd-4707c5abeb29.png)

Pay attention there is no default algorithm for detecting anomalies. 
You will also need to upload a .dll file of the algorithm you will to use.
In the plugins folder you can use one of our two .dll files- FirstDLL is for detecting anomalies using regression line and SecondDLL is for detecting anomalies using a circle.
You will need to upload the .dll file to the appliction.
![dll](https://user-images.githubusercontent.com/73164258/114634085-78dcdf80-9cca-11eb-91ee-ed2abd55cfeb.png)

Our application will use the .dll file and display the anomalies returned from the .dll.
You can view the anomalies in the exact same graph from the feature above- the anomalies are in red points.

Notice! To make it easiear following the anomalies, the list in the left side of the graph will display the time of the anomalies and the anomaly itself.
You can choose an anomaly from the list and go to the exact time the anomaly has happened in the flight.

![99999](https://user-images.githubusercontent.com/73164258/114635415-5a2c1800-9ccd-11eb-802d-6442f9ad728c.png)



## UML Diagram of the project

![FlightGear UML](https://user-images.githubusercontent.com/72696075/114566337-d47f7c80-9c7a-11eb-82d1-84b8367a3c06.png)

Enjoy your flight!
