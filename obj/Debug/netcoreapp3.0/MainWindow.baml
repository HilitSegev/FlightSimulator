   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFWPF  5   	   clr-namespace:WPFWPF  5   	   clr-namespace:WPFWPF  5	   	   clr-namespace:WPFWPF  5
   	   clr-namespace:WPFWPF  5   	       WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5   	   localclr-namespace:WPF  5   	   !	DashBoardclr-namespace:WPF  5   	    JoyStickclr-namespace:WPF  5	   	   %PlaybackSpeedclr-namespace:WPF  5
   	   Graphsclr-namespace:WPF  5   	     � Title$  
MainWindow��5   	   $	��750��6   $
��1400��6)    � 
ResizeMode$ NoResize=�66   .��5      � ��5   
   �� 5       �� ImageSource$ Resources/1234.jpg��6   .+�5   
   �� -   5        $��FLY & TRAIN��5      $
��Left=�6+   $��	10,10,0,0q�6F   $	��Top=�6Y   $��42��6�   $��84��6�   �� 5   
   -   5        $��DLL SELECTION��5      $
��Left=�6)   $��
100,33,0,0q�6D   $	��Top=�6X   $	��125��6�   �� 5   
   -   5        $��DETECT ANOMALIES��5      $
��Left=�6,   $��
100,10,0,0q�6G   $	��Top=�6[   $	��125��6�   ���	#FFDDDDDD6�   �� 5   
   -   5         ��Name$ 
playButton��5      $
��Left=�6%   $��	10,0,0,10q�6@   $��Bottom=�6S   $��25��6n   $��25��6z   ���	#00DDDDDD.��5      �� $��Resources/playButton.png��6   5      �� 5   
   -   5        $ pauseButton��5      $
��Left=�6&   $��	40,0,0,10q�6A   $��Bottom=�6T   $��25��6o   $��25��6{   ���	#00DDDDDD.��5      �� $��Resources/pauseButton.png��6   $y�Visible=�67   5      �� 5   
   -   5        $ 
stopButton��5      $
��Left=�6%   $��	70,0,0,10q�6@   $��Bottom=�6S   $��25��6n   $��25��6z   ���	#00DDDDDD.��5      �� $��Resources/stopButton.png��6   5      �� 5    
   -   5         ��Name$ 
timeSlider��5       $
��Left=�6%   $��
100,0,0,10q�6@   $��Bottom=�6T   $	��970��6o    � Value 6{   �� *VM_CurrentRow+ � Maximum 6�   �� *VM_NumOfCSVRows+�� 5!   
   $
��Left=�62   $��1805,10,0,0q�6M   $��Bottom=�6b   ��6   �� *VM_CurrentRow+6b      WPF.DashBoard  5#   
   -   5          Name$ 	dashBoard��5#      $��	10,80,0,0q�61   $
��Left=�6D   $	��Top=�6_      WPF.JoyStick  5$   
   -	   5          Name$ joyStick��5$      $��
10,240,0,0q�6.   $	��Top=�6B   $
��Left=�6Z   $	��200��6u      WPF.PlaybackSpeed  5%   
   -
   5        	  Name$	 playbackSpeed��5%   &   $��10,254,10,10q�6=   $
��Left=�6S   $��Right=�6u   $��Bottom=�6�   $	��300��6�      
WPF.Graphs  5&   
   -   5        
  Name$
 graphs��5&      $	��550��6(   $
��1150��65   $��Right=�6B   $	��Top=�6^   5'      5(      