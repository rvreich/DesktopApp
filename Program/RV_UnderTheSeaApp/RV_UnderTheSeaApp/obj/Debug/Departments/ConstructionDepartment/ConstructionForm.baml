   M S B A M L   `   `   `  ����L  HRV_UnderTheSeaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null{Bclr-namespace:RV_UnderTheSeaApp.Departments.ConstructionDepartment4RV_UnderTheSeaApp.Departments.ConstructionDepartment  5   	   K    ERV_UnderTheSeaApp.Departments.ConstructionDepartment.ConstructionForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   TlocalBclr-namespace:RV_UnderTheSeaApp.Departments.ConstructionDepartment     5   	     � Title$  ConstructionForm��5   	   $	��450��6"   $
��1600��6/    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   �� -   5         ��Name$ request_box��5      $
��Left=�6'   $	��337��6B   $��	10,10,0,0q�6O    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��375��6�   " �� VerticalScrollBarVisibility$ Visible=�6�    �� AcceptsReturn . 6�   �� 5   
   -   5         ��Name$ gridSplitter��5      $
��Left=�6-   $	��337��6H   $��
395,10,0,0q�6U   $	��Top=�6i   $��5��6�   �� 5   
   -   5         ��Name$ logoutButton��5      $��log out��6'   $
��Left=�6T   $��570,391,0,0q�6o   $	��Top=�6�   $��75��6�   �� 5   
   -   5        $ requestButton��5      $��send request��6(   $
��Left=�6[   $��152,366,0,0q�6v   $	��Top=�6�   $��75��6�    J� RenderTransformOrigin$ 0.987,0.615&�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 reportDataGrid��5      $
��Left=�6+   $	��337��6F   $��
412,10,0,0q�6S   $	��Top=�6g   $	��372��6   
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 6�     5   
   -   5        $	 attractionDataGrid��5      $
��Left=�6/   $	��286��6J   $��
807,10,0,0q�6W   $	��Top=�6k   $	��372��6�   $
 * 6�   �� 5   
   -   5        $ insertAttractionButton��5      $��create attraction��61   $
��Left=�6r   $��807,390,0,0q�6�   $	��Top=�6�   $��99��6�   �� 5   
   -   5        $ updateStatusButton��5      $��update status��6-   $
��Left=�6f   $��1090,391,0,0q�6�   $	��Top=�6�   $��89��6�   �� 5   
   -	   5        $ attraction_name_box��5      $
��Left=�6/   $��23��6J   $��933,324,0,0q�6V   $
 Wrap=�6k   $�� ��6   $	��Top=�6�   $	��120��6�   �� 5   
   -
   5         ��Name$ label��5      $
��Name��6   $
��Left=�6.   $��927,301,0,0q�6I   $	��Top=�6^   �� 5   
   -   5        $ capacity_box��5      $
��Left=�6(   $��23��6C   $��1059,324,0,0q�6O   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ label1��5      $��Capacity��6    $
��Left=�63   $��1053,301,0,0q�6N   $	��Top=�6d   �� 5   
   -   5        $ id_box��5      $
��Left=�6"   $��23��6=   $��807,324,0,0q�6I   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   �� 5   
   -   5        $ label2��5      $��ID��6    $
��Left=�6-   $��801,301,0,0q�6H   $	��Top=�6]   �� 5   
   -   5         ��Name$ comboBox��5      $
��Left=�6%   $��933,366,0,0q�6@   $	��Top=�6U   $	��120��6m   .@�5      �� $��	ESTABLISH��6   �� 5      $��WORKING��6   �� 5      $��	CONSTRUCT��6   �� 5      $��UPGRADE��6   �� 5      $��REMOVAL��6   �� 5      $��	DESTROYED��6   5       �� 5!   
   -   5        $ label3��5!      $��Construction Status��6    $
��Left=�6>   $��927,345,0,0q�6Y   $	��Top=�6n     5"   
   -   5        $	 confirmationDataGrid��5"      $
��Left=�61   $	��337��6L   $��1203,10,0,0q�6Y   $	��Top=�6n   $	��329��6�   5$      5%      