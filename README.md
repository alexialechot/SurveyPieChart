# Simple Survey - PieChart - Unity 2D


#### Unity 2D - 2018.3.1f1
App that makes a percentage / Pie Chart / of the answers in realtime.

#### This Read me contain:
* Screenshot of the World Wild Web Scenes
* Screenshot of the construction Scenes
* How to use 

<br><hr><br>

# World Wild Web SCENES

### Q2-2OptionsTogggleGroup
![Screenshot](Screenshot/WWWScene/Q2-2OptionsTogggleGroup-Select.png)

### Q3-2OptionsTogggleGroup
![Screenshot](Screenshot/WWWScene/Q3-2OptionsTogggleGroup-select.png)

### Q4-4OptionsTogggle
![Screenshot](Screenshot/WWWScene/Q4-4OptionsTogggle.png)

<br><hr><br>

# CONSTRUCTION SCENES
### OptionsButton Scene
- Script on the GameObject "Pie"
- > Assets/Script/Contruction/PieChart.cs

![Screenshot](Screenshot/ConstructionScene/Buttons.png)


### 3OptionsToggle Scene
- Multiple choice
- Enter button (only when something is selected)
- Thanks page (3s.)
- Reset timer (60s.)
- Script on the GameObject "Pie"
- > Assets/Script/Contruction/PieChartToggleDefault.cs _*_

![Screenshot](Screenshot/ConstructionScene/Toggle.png)


### 3OptionsToggleGroup Scene
- One choice
- Enter button (only when something is selected)
- Thanks page (3s.)
- Reset timer (60s.)
- Script on the GameObject "Pie"
- > Assets/Script/Contruction/PieChartToggleDefault.cs _*_

**_*_**
Same Script 

![Screenshot](Screenshot/ConstructionScene/ToggleGroup.png)

<br><hr><br>

# How to use 

### Pie GameObject:

-> in the inspector:
- The main script is on the GameObject "Pie" 
- Don't forget to link all the elements! -> Like below 
- Change the size of all the arrays to change the number of buttons & add/delete the involved GameObject  

![Screenshot](Screenshot/GameObjectPie.png)

### Enter Button:

-> in the inspector:
- On click () called the "Enter" public function inside the script
- Script on the GameObject "Pie"

![Screenshot](Screenshot/EnterButton.png)

### Toggle Option:

-> in the inspector:
- On Value Changed (Boolean) called the "TimeOut" public function inside the script
- Script on the GameObject "Pie"
- This function reset the options if no ones press enter in the next 60s.

![Screenshot](Screenshot/ToggleOption.png)

<br><hr><br>

&copy; 2018 [Alexia Lechot](https://uxmilk.co)
