   M S B A M L   `   `   `  ����L  HRV_UnderTheSeaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyAclr-namespace:RV_UnderTheSeaApp.Departments.MaintenanceDepartment3RV_UnderTheSeaApp.Departments.MaintenanceDepartment  5   	   I    CRV_UnderTheSeaApp.Departments.MaintenanceDepartment.MaintenanceForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   SlocalAclr-namespace:RV_UnderTheSeaApp.Departments.MaintenanceDepartment     5   	     � Title$  MaintenanceForm��5   	   $	��275��6!   $
��1000��6.    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ 
datePicker��5      $
��Left=�6)   $��
547,10,0,0q�6D   $	��Top=�6X    J� RenderTransformOrigin$ 0.445,2.017&�6p   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $	��223��6@   $��	12,10,0,0q�6M   $	��Top=�6`   $	��517��6x   �� 5   
   -   5         ��Name$ comboBox��5      $
��Left=�6%   $��
547,81,0,0q�6@   $	��Top=�6T   $	��120��6l   .@�5      �� $��
MAINTAINED��6   �� 5      $��BROKEN��6   �� 5      $��FIXING��6   5      �� 5   
   -   5         ��Name$ label��5      $��Maintenance Status��6   $
��Left=�6<   $��
543,55,0,0q�6W   $	��Top=�6k   �� 5   
   -   5         ��Name$ id_box��5      $
��Left=�6"   $��23��6=   $��547,150,0,0q�6I    �� TextWrapping$
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   �� 5   
   -   5        $ label1��5      $��Attraction Id��6    $
��Left=�68   $��543,128,0,0q�6S   $	��Top=�6h   �� 5   
   -   5        	 ��Name$	 updateAttractionButton��5      $��update��61   $
��Left=�6g   $��547,214,0,0q�6�   $	��Top=�6�   $��75��6�   �� 5   
   -   5        $ 
report_box��5      $
��Left=�6&   $	��165��6A   $��
744,35,0,0q�6N   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��240��6�   "
 �� VerticalScrollBarVisibility$
 Visible=�6�    �� AcceptsReturn . 6�   �� 5   
   -	   5        $ label2��5      $��Report��6    $
��Left=�61   $��
740,10,0,0q�6L   $	��Top=�6`   �� 5   
   -
   5        $	 reportButton��5      $��send report��6'   $
��Left=�6X   $��744,214,0,0q�6s   $	��Top=�6�   $��75��6�   $ 0.701,0.521&�6�   �� 5   
   -   5        $	 logoutButton��5      $��log out��6'   $
��Left=�6T   $��909,214,0,0q�6o   $	��Top=�6�   $��75��6�   5      5      