   M S B A M L   `   `   `  ����L  HRV_UnderTheSeaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Lclr-namespace:RV_UnderTheSeaApp.Departments.RideAttractionCreativeDepartment>RV_UnderTheSeaApp.Departments.RideAttractionCreativeDepartment  5   	   W    QRV_UnderTheSeaApp.Departments.RideAttractionCreativeDepartment.RideAttractionForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^localLclr-namespace:RV_UnderTheSeaApp.Departments.RideAttractionCreativeDepartment     5   	     � Title$  RideAttractionForm��5   	   $	��450��6$   $
��1600��61    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   �� -   5         ��Name$ 	reportBox��5      $
��Left=�6%   $	��320��6@   $��	10,10,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��360��6�   " �� VerticalScrollBarVisibility$ Visible=�6�    �� AcceptsReturn . 6�   �� 5   
   -   5         ��Name$ gridSplitter��5      $��Center=�6-   $	��330��6J   $��380,3,1199.6,0q�6W   $	��Top=�6o   $��5��6�   �� 5   
   -   5         ��Name$ reportButton��5      $��send report��6'   $
��Left=�6X   $��150,390,0,0q�6s   $	��Top=�6�   $��75��6�   �� 5   
   -   5         ��Name$ comboBox��5      $
��Left=�6%   $��130,352,0,0q�6@   $	��Top=�6U   $	��120��6m   .@�5      �� 	 �� 
IsSelected	 . $��Manager��6-   �� 5      $��
Purchasing��6   5      �� 5   
   -   5        $ logoutButton��5      $��log out��6B   $
��Left=�6T   $��556,390,0,0q�6o   $	��Top=�6�   $��75��6�   
 J� RenderTransformOrigin$
 
0.224,0.62&�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ attractionDataGrid��5      $
��Left=�6/   $	��249��6J   $��
405,40,0,0q�6W   $	��Top=�6k   $	��343��6�   �� 5   
   -   5         ��Name$ label��5      $��Attraction List��6   $
��Left=�69   $��
399,10,0,0q�6T   $	��Top=�6h     5   
   -   5        $ reportDataGrid��5      $
��Left=�6+   $	��249��6F   $��
806,40,0,0q�6S   $	��Top=�6g   $	��343��6   �� 5   
   -	   5        $ label1��5      $��Report List��6    $
��Left=�66   $��
800,10,0,0q�6Q   $	��Top=�6e   �� 5   
   -
   5        $ updateAttractionButton��5      $��update capacity��61   $
��Left=�6p   $��407,352,0,0q�6�   $	��Top=�6�   $	��118��6�   �� 5   
   -   5        $ id_box��5      $
��Left=�6"   $��23��6=   $��405,311,0,0q�6I   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   �� 5   
   -   5        $ capacity_box��5      $
��Left=�6(   $��23��6C   $��540,311,0,0q�6O   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ label2��5      $��ID��6    $
��Left=�6-   $��399,289,0,0q�6H   $	��Top=�6]   �� 5   
   -   5        $ label3��5      $��Capacity��6    $
��Left=�63   $��534,289,0,0q�6N   $	��Top=�6c   �� 5   
   -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��201,369,0,0q�6B   $
��Wrap=�6W   $��	TextBlock��6k   $	��Top=�6|   �� 5   
   -   5        $ aid_box��5      $
��Left=�6#   $��23��6>   $��806,311,0,0q�6J   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��120��6�   $
 1.295,0.148&�6�   �� 5   
   -   5        $ constructionComboBox��5      $
��Left=�61   $��959,311,0,0q�6L   $	��Top=�6a   $	��120��6y   .@�5      �� $��	ESTABLISH��6   �� 5       $��WORKING��6   �� 5!      $��	CONSTRUCT��6   �� 5"      $��UPGRADE��6   �� 5#      $��REMOVE��6   �� 5$      $��	DESTROYED��6   5%      �� 5&   
   -   5        $ label4��5&      $��ID��6    $
��Left=�6-   $��800,289,0,0q�6H   $	��Top=�6]   �� 5'   
   -   5        $ label5��5'      $��Construction Status��6    $
��Left=�6>   $��953,289,0,0q�6Y   $	��Top=�6n   �� 5(   
   -   5        $ updateStatusButton��5(      $��update status��6-   $
��Left=�6f   $��806,352,0,0q�6�   $	��Top=�6�   $��75��6�     5)   
   -   5        $ confirmationDataGrid��5)      $
��Left=�61   $	��249��6L   $��1206,40,0,0q�6Y   $	��Top=�6n   $	��304��6�   �� 5*   
   -   5        $ label6��5*      $��Confirmation Report��6    $
��Left=�6>   $��1201,10,0,0q�6Y   $	��Top=�6n   5,      5-      