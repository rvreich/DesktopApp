   M S B A M L   `   `   `  ����L  HRV_UnderTheSeaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null}Cclr-namespace:RV_UnderTheSeaApp.Departments.HumanResourceDepartment5RV_UnderTheSeaApp.Departments.HumanResourceDepartment  5   	   M    GRV_UnderTheSeaApp.Departments.HumanResourceDepartment.HumanResourceForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   UlocalCclr-namespace:RV_UnderTheSeaApp.Departments.HumanResourceDepartment     5   	     � Title$  HumanResourceForm��5   	   $	��750��6#   $	��900��60    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ workerDataGrid��5      $
��Left=�6+   $	��271��6F   $��	10,10,0,0q�6S   $	��Top=�6f   $	��540��6~   �� 5   
   -   5         ��Name$ 
requestBox��5      $
��Left=�6&   $	��271��6A   $��
581,10,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��299��6�    �� AcceptsReturn . " �� VerticalScrollBarVisibility$ Visible=�6�   �� 5   
   -   5        $ username_box��5      $
��Left=�6(   $��23��6C   $��
10,301,0,0q�6O   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   �� 5   
   -   5        $ password_box��5      $
��Left=�6(   $��24��6C   $��
10,340,0,0q�6O   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   �� 5   
   -   5        $ workername_box��5      $
��Left=�6*   $��23��6E   $��
10,380,0,0q�6Q   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ 
salary_box��5      $
��Left=�6&   $��23��6A   $��161,301,0,0q�6M   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   �� 5   
   -   5         ��Name$ label��5      $��Username��6   $
��Left=�62   $��	5,281,0,0q�6M   $	��Top=�6`   �� 5   
   -   5        $ label1��5      $��Password��6    $
��Left=�63   $��	5,322,0,0q�6N   $	��Top=�6a   �� 5   
   -	   5        $ label2��5      $��Worker Name��6    $
��Left=�66   $��	5,362,0,0q�6Q   $	��Top=�6d   �� 5   
   -
   5        $ label3��5      $��Salary��6    $
��Left=�61   $��155,281,0,0q�6L   $	��Top=�6a   �� 5   
   -   5        $ position_box��5      $
��Left=�6(   $��23��6C   $��161,340,0,0q�6O   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ label4��5      $��Position��6    $
��Left=�63   $��155,322,0,0q�6N   $	��Top=�6c   �� 5   
   -   5        $ performance_box��5      $
��Left=�6+   $��23��6F   $��161,380,0,0q�6R   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ label5��5      $��Performance Index��6    $
��Left=�6<   $��155,362,0,0q�6W   $	��Top=�6l   �� 5   
   -   5        $ worker_id_box��5      $
��Left=�6)   $��23��6D   $��320,301,0,0q�6P   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ label6��5      $��	Worker ID��6    $
��Left=�64   $��314,281,0,0q�6O   $	��Top=�6d   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dobDatePicker��5      $
��Left=�6,   $��320,340,0,0q�6G   $	��Top=�6\   �� 5   
   -   5        $ label7��5      $��
Worker DOB��6    $
��Left=�65   $��314,322,0,0q�6P   $	��Top=�6e   �� 5   
   -   5        	 ��Name$	 genderComboBox��5      $
��Left=�6+   $��320,380,0,0q�6F   $	��Top=�6[   $	��120��6s   .@�5      �� $
��MALE��6   �� 5      $��FEMALE��6   5       �� 5!   
   -   5        $ label8��5!      $��Gender��6    $
��Left=�61   $��314,361,0,0q�6L   $	��Top=�6a   �� 5"   
   -   5        
 ��Name$
 insertWorkerButton��5"      $��insert data��6-   $
��Left=�6d   $��475,301,0,0q�6   $	��Top=�6�   $��75��6�   �� 5#   
   -   5        $
 updateWorkerIndexButton��5#      $��update index��62   $
��Left=�6o   $��475,340,0,0q�6�   $	��Top=�6�   $��75��6�   �� 5$   
   -   5        $
 deleteWorkerButton��5$      $��delete data��6-   $
��Left=�6d   $��475,380,0,0q�6   $	��Top=�6�   $��75��6�   �� 5%   
   -   5        $	 departmentComboBox��5%      $
��Left=�6/   $��581,302,0,0q�6J   $	��Top=�6_   $	��120��6w   .@�5&      �� $��Manager��6   �� 5'      $��Accounting Finance��6   5(      �� 5)   
   -   5        $
 sendRequestButton��5)      $��send request��6,   $
��Left=�6c   $��721,302,0,0q�6~   $	��Top=�6�   $��78��6�   $��23��6�     5*   
   -   5        $ reportDataGrid��5*      $
��Left=�6+   $	��240��6F   $��
10,441,0,0q�6S   $	��Top=�6g   $	��310��6   �� 5+   
   -   5        $
 refreshReportButton��5+      $��refresh data��6.   $
��Left=�6g   $��122,692,0,0q�6�   $	��Top=�6�   $��75��6�     5,   
   -   5        $ permitDataGrid��5,      $
��Left=�6+   $	��240��6F   $��380,441,0,0q�6S   $	��Top=�6h   $	��260��6�   �� 5-   
   -   5        $
 logoutButton��5-      $��log out��6'   $
��Left=�6T   $��809,693,0,0q�6o   $	��Top=�6�   $��75��6�   �� 5.   
   -   5        $ permit_id_box��5.      $
��Left=�6)   $��23��6D   $��660,460,0,0q�6P   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   �� 5/   
   -   5        $ label9��5/      $��	Permit ID��6    $
��Left=�64   $��655,441,0,0q�6O   $	��Top=�6d   �� 50   
   -    5        $	 permitStatusComboBox��50      $
��Left=�61   $��660,507,0,0q�6L   $	��Top=�6a   $	��120��6y   .@�51      �� $��Approved��6   �� 52      $��Disapproved��6   53      �� 54   
   -!   5        $ label10��54      $��Permit Status��6!   $
��Left=�69   $��655,489,0,0q�6T   $	��Top=�6i   �� 55   
   -"   5        $
 updatePermitButton��55      $��update permit��6-   $
��Left=�6f   $��660,541,0,0q�6�   $	��Top=�6�   $��81��6�   �� 56   
   -#   5        $
 updateWorkerSalaryButton��56      $��update salary��63   $
��Left=�6r   $��581,340,0,0q�6�   $	��Top=�6�   $��75��6�   �� 57   
   -$   5        $
 refreshPermitButton��57      $��refresh permit��6.   $
��Left=�6i   $��475,692,0,0q�6�   $	��Top=�6�   $��81��6�    J� RenderTransformOrigin$ 0.307,0.281&�6�   58      59      