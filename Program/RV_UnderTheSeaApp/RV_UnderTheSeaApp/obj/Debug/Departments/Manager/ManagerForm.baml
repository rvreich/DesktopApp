   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5       RV_UnderTheSeaApp7   1RV_UnderTheSeaApp.Departments.Manager.ManagerForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5        � Title$  ManagerForm��5	   	   $	��750��6   $
��1000��6*    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ workerDataGrid��5      $
��Left=�6+   $	��313��6F   $��	10,10,0,0q�6S   $	��Top=�6f   $	��330��6~   �� 5   
   -   5         ��Name$ refreshWorkerButton��5      $��refresh data��6.   $
��Left=�6g   $��121,340,0,0q�6�   $	��Top=�6�   $��79��6�     5   
   -   5        $ reportDataGrid��5      $
��Left=�6+   $	��313��6F   $��
381,10,0,0q�6S   $	��Top=�6g   $	��582��6   �� 5   
   -   5         ��Name$ id_box��5      $
��Left=�6"   $��23��6=   $��381,360,0,0q�6I    �� TextWrapping$
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   �� 5   
   -   5         ��Name$ label��5      $��ID��6   $
��Left=�6,   $��381,334,0,0q�6G   $	��Top=�6\   �� 5   
   -   5         ��Name$ approvalComboBox��5      $
��Left=�6-   $��561,360,0,0q�6H   $	��Top=�6]   $	��120��6u   .@�5      �� $��Approved��6   �� 5      $��Disapproved��6   5      �� 5   
   -   5        $ label1��5      $��Approval Status��6    $
��Left=�6:   $��561,334,0,0q�6U   $	��Top=�6j   �� 5   
   -   5        $ updateDataButton��5      $��update status��6+   $
��Left=�6b   $��742,360,0,0q�6}   $	��Top=�6�   $��77��6�   $��22��6�   �� 5   
   -	   5        $ logoutButton��5      $��log out��6'   $
��Left=�6T   $��444,691,0,0q�6o   $	��Top=�6�   $��75��6�     5   
   -
   5        $ auditDataGrid��5      $
��Left=�6*   $	��279��6E   $��
10,400,0,0q�6R   $	��Top=�6f   $	��330��6~   � 5   
   $
��Left=�6   $	��279��6*   $��381,400,0,0q�67   $	��Top=�6L   $	��582��6d   .+�5      #   LiveCharts.Wpf.CartesianChart  &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$
 Left=�6E   	   Series	 6!   �� *SeriesCollection+
   AxisX
 5         LiveCharts.Wpf.Axis     Title$ Amount��6      Labels 6.   �� *Labels+6J      AxisY 5        $ 
Department��6      LabelFormatter 62   �� *Labels+6V   5!      5"      5#      5$      