   M S B A M L   `   `   `  ����L  HRV_UnderTheSeaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullDclr-namespace:RV_UnderTheSeaApp.Departments.SalesMarketingDepartment6RV_UnderTheSeaApp.Departments.SalesMarketingDepartment  5   	   O    IRV_UnderTheSeaApp.Departments.SalesMarketingDepartment.SalesMarketingForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   VlocalDclr-namespace:RV_UnderTheSeaApp.Departments.SalesMarketingDepartment     5   	     � Title$  SalesMarketingForm��5   	   $	��450��6$   $
��1400��61    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   �� -   5         ��Name$ 
report_box��5      $
��Left=�6&   $	��289��6A   $��	10,10,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��230��6�   " �� VerticalScrollBarVisibility$ Visible=�6�    �� AcceptsReturn . 6�   �� 5   
   -   5         ��Name$ departmentComboBox��5      $
��Left=�6/   $��
10,319,0,0q�6J   $	��Top=�6^   $	��120��6v   .@�5      �� $��Purchase��6   �� 5      $��Accounting Finance��6   5      �� 5   
   -   5        $ ads_box��5      $
��Left=�6#   $	��289��6>   $��
281,10,0,0q�6K   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��230��6�   $ Visible=�6�    . 6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ adsDataGrid��5      $
��Left=�6(   $	��289��6C   $��
560,10,0,0q�6P   $	��Top=�6d   $	��424��6|   �� 5   
   -   5         ��Name$ logoutButton��5      $��log out��6'   $
��Left=�6T   $��679,381,0,0q�6o   $	��Top=�6�   $��79��6�   �� 5   
   -   5        $ sendRequestButton��5      $��send request��6,   $
��Left=�6c   $��
81,360,0,0q�6~   $	��Top=�6�   $��79��6�   �� 5   
   -   5        $ id_box��5      $
��Left=�6"   $��23��6=   $��281,319,0,0q�6I   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   	 J� RenderTransformOrigin$	 -1.668,0.383&�6�   �� 5   
   -   5        
 ��Name$
 label��5      $��ID��6   $
��Left=�6,   $��275,299,0,0q�6G   $	��Top=�6\   �� 5   
   -	   5        $ insertAdsButton��5      $��
insert ads��6*   $
��Left=�6]   $��436,322,0,0q�6x   $	��Top=�6�   $��75��6�   �� 5   
   -
   5        $ updateAdsButton��5      $��
update ads��6*   $
��Left=�6]   $��436,346,0,0q�6x   $	��Top=�6�   $��75��6�   �� 5   
   -   5        $ deleteAdsButton��5      $��
delete ads��6*   $
��Left=�6]   $��436,370,0,0q�6x   $	��Top=�6�   $��75��6�     5   
   -   5        $ reportDataGrid��5      $
��Left=�6+   $	��289��6F   $��1019,10,0,0q�6S   $	��Top=�6h   $	��365��6�   �� 5   
   -   5        $ refreshReportButton��5      $��refresh data��6.   $
��Left=�6g   $��1161,319,0,0q�6�   $	��Top=�6�   $��78��6�   5      5      