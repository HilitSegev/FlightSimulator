   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFWPF  5          
WPF.Graphs   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5      localclr-namespace:WPF  5      .��5
      � $
��1150��6   $	��550��6     � ColumnDefinitions  5   
   �� 5      $
��529* �6   �� 5      $
��543* �6   �� 5      $	��27* �6   �� 5      $	��51* �6   .+�5   
   �� -   5         ��Name$ featureNamesList��5      $
��Left=�6,   $��	10,10,0,0q�6G   $	��Top=�6Z   $	��250��6r   $	��270��6~    �� SelectedIndex 6�   �� *VM_SelectedFeatureIndex+�� 5   
   -   5        $ anomaliesListView��5      $
��Left=�6-   $��
10,285,0,0q�6H   $	��Top=�6\   $	��250��6t   $	��255��6�   ��6�   �� *VM_AnomalyIdxList+ 6�   �� *VM_SelectedAnomaly+  OxyPlot.Wpf.Plot  5   
   -   5          Name$ SelectedFeaturePlot��5      $��
270,10,0,0q�60   ���	#A0FFFFFF$
��Left=�6�   $	��Top=�6�   $	��435��6�   $	��270��6�   $��2��6�      InvalidateFlag 6[   �� *VM_InvalidateFlag+   Axes 5        OxyPlot.Wpf.LinearAxis  5        OxyPlot.Wpf.Axis   IsAxisVisible$ False��6!      Series 5        OxyPlot.Wpf.LineSeries  5      ��6!   �� *VM_PointsSelectedFeature+5        5   
   -   5        $ correlatedFeaturePlot��5      $��	0,10,10,0q�62   ���	#A0FFFFFF$	��430��6�   $	��270��6�   $��Right=�6�   $	��Top=�6�   $��3��6�   $��1��6�    6\   �� *VM_InvalidateFlag+ 5        5      $ False��6!    5!        5"      ��6!   �� *VM_PointsCorrelatedFeature+5$        5&   
   -   5        $ regressionLinePlot��5&      $��	0,0,10,10q�6/   ���	#A0FFFFFF   IsLegendVisible$
 True��6Y   $	��870��6�   $��4��6�   $��Right=�6�   $��Bottom=�6�   $	��255��6�    6p   �� *VM_InvalidateFlag+ 5'        5(      $ False��6!    5*        5+        OxyPlot.Wpf.Series	   Title$		 all��6X   
   Color$
 Black��6d      
MarkerSize$ 2Q�6r      StrokeThickness$ 0Q�6�      
MarkerType$ Circle=�6�   ��6!   �� * VM_PointsSelectedAndCorrelated+6�     5,      $	 last 30 seconds��6L   $
 Orange��6d   $ 2Q�6s   $ 0Q�6�   $ Circle=�6�   ��6!   �� *VM_Last30SecPoints+6�     5-      $	 	anomalies��6J   $	
 Red��6\   $ 3Q�6h   $ 0Q�6w   $ Circle=�6�   ��6!   �� *VM_AnomalyPoints+6�     5.      $	 regression line��6Q   $
 Green��6i   $ 1Q�6w   ��6!   �� *VM_RegressionLinePoints+6w   50      52      53      