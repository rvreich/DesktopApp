   M S B A M L   `   `   `  ����L  HRV_UnderTheSeaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Gclr-namespace:RV_UnderTheSeaApp.Departments.AccountingFinanceDepartment9RV_UnderTheSeaApp.Departments.AccountingFinanceDepartment  5   	   U    ORV_UnderTheSeaApp.Departments.AccountingFinanceDepartment.AccountingFinanceForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   YlocalGclr-namespace:RV_UnderTheSeaApp.Departments.AccountingFinanceDepartment     5   	     � Title$  AccountingFinanceForm��5   	   $	��450��6'   $	��675��64    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   �� -   5         ��Name$ response_box��5      $
��Left=�6(   $	��311��6C   $��	10,10,0,0q�6P    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��231��6�   " �� VerticalScrollBarVisibility$ Visible=�6�    �� AcceptsReturn . 6�   �� 5   
   -   5         ��Name$ departmentComboBox��5      $
��Left=�6/   $��
10,341,0,0q�6J   $	��Top=�6^   $	��120��6v   .@�5      �� $��
Attraction��6   �� 5      $��Maintenance��6   �� 5      $��Ride Attraction��6   �� 5      $��Construction��6   �� 5      $��Dining Room��6   �� 5      $��Kitchen��6   �� 5      $��
Purchasing��6   �� 5      $��Front Office��6   �� 5      $��House Keeping��6   �� 5      $��Sales Marketing��6   �� 5      $��Human Resource��6   �� 5      $��Manager��6   5      �� 5   
   -   5         ��Name$ sendResponseButton��5      $��send response��6-   $
��Left=�6f   $��160,340,0,0q�6�   $	��Top=�6�   $��81��6�   $��22��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ confirmationDataGrid��5      $
��Left=�61   $	��311��6L   $��
262,10,0,0q�6Y   $	��Top=�6m   $	��376��6�   �� 5   
   -   5        $ id_box��5      $
��Left=�6"   $��23��6=   $��262,340,0,0q�6I   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   �� 5   
   -   5        	 ��Name$	 label��5      $��
Department��6   $
��Left=�64   $��	3,319,0,0q�6O   $	��Top=�6b   �� 5   
   -   5        $	 label1��5      $��ID��6    $
��Left=�6-   $��257,319,0,0q�6H   $	��Top=�6]   �� 5   
   -   5        $ confirmationComboBox��5      $
��Left=�61   $��400,340,0,0q�6L   $	��Top=�6a   $	��120��6y   .@�5       �� $��Approved��6   �� 5!      $��Disapproved��6   5"      �� 5#   
   -	   5        $	 label2��5#      $��Confirmation��6    $
��Left=�67   $��395,319,0,0q�6R   $	��Top=�6g   �� 5$   
   -
   5        $ updateButton��5$      $��update data��6'   $
��Left=�6X   $��540,341,0,0q�6s   $	��Top=�6�   $��80��6�   �� 5%   
   -   5        $ refreshButton��5%      $��refresh data��6(   $
��Left=�6[   $��540,380,0,0q�6v   $	��Top=�6�   $��80��6�   �� 5&   
   -   5        $ logoutButton��5&      $��log out��6'   $
��Left=�6T   $��262,380,0,0q�6o   $	��Top=�6�   $��75��6�   5(      5)      