   M S B A M L   `   `   `  ����L  HRV_UnderTheSeaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Oclr-namespace:RV_UnderTheSeaApp.Departments.HotelDepartment.FrontOfficeDivisionARV_UnderTheSeaApp.Departments.HotelDepartment.FrontOfficeDivision  5   	   W    QRV_UnderTheSeaApp.Departments.HotelDepartment.FrontOfficeDivision.FrontOfficeForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   alocalOclr-namespace:RV_UnderTheSeaApp.Departments.HotelDepartment.FrontOfficeDivision     5   	     � Title$  FrontOfficeForm��5   	   $	��500��6!   $	��800��6.    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   �� -   5         ��Name$ logoutButton��5      $��log out��6'   $
��Left=�6T   $��361,441,0,0q�6o   $	��Top=�6�   $��80��6�    J� RenderTransformOrigin$ 0.496,1.073&�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ visitorDataGrid��5      $
��Left=�6,   $	��230��6G   $��	10,10,0,0q�6T   $	��Top=�6g   $	��228��6   �� 5   
   -   5         ��Name$ id_box��5      $
��Left=�6"   $��23��6=   $��
10,266,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��120��6�   �� 5   
   -   5         ��Name$ label��5      $��ID��6   $
��Left=�6,   $��	5,240,0,0q�6G   $	��Top=�6Z   �� 5   
   -   5        $ name_box��5      $
��Left=�6$   $��23��6?   $��
10,315,0,0q�6K   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��120��6�   �� 5   
   -   5        $ label1��5      $
��Name��6    $
��Left=�6/   $��	5,289,0,0q�6J   $	��Top=�6]   �� 5   
   -   5        $ 	email_box��5      $
��Left=�6%   $��23��6@   $��
10,363,0,0q�6L   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   �� 5   
   -   5        $ label2��5      $��Email��6    $
��Left=�60   $��	5,338,0,0q�6K   $	��Top=�6^   �� 5   
   -	   5        $ verifyButton��5      $��verify visitor��6'   $
��Left=�6[   $��148,266,0,0q�6v   $	��Top=�6�   $��90��6�   $��23��6�   �� 5   
   -
   5        $ insertVisitorButton��5      $��insert data��6.   $
��Left=�6f   $��148,315,0,0q�6�   $	��Top=�6�   $��90��6�   $ 
0.64,0.431&�6�   $��23��6�   �� 5   
   -   5        $ updateVisitor��5      $��update data��6(   $
��Left=�6Z   $��148,363,0,0q�6u   $	��Top=�6�   $��90��6�   $ 0.156,0.708&�6�   $��23��6�     5   
   -   5        $ reservationDataGrid��5      $
��Left=�60   $	��230��6K   $��
261,10,0,0q�6X   $	��Top=�6l   $	��510��6�   �� 5   
   -   5        $ visitor_id_box��5      $
��Left=�6*   $��23��6E   $��261,266,0,0q�6Q   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ label3��5      $��
Visitor ID��6    $
��Left=�65   $��256,240,0,0q�6P   $	��Top=�6e   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ checkInDatePicker��5      $
��Left=�60   $��402,265,0,0q�6K   $	��Top=�6`     5   
   -   5        $ checkOutDatePicker��5      $
��Left=�61   $��540,266,0,0q�6L   $	��Top=�6a   �� 5   
   -   5        $ roomnum_box��5      $
��Left=�6'   $��23��6B   $��261,317,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   �� 5   
   -   5        $ label4��5      $��Room Number��6    $
��Left=�66   $��256,291,0,0q�6Q   $	��Top=�6f   �� 5   
   -   5        $ label5��5      $��Check In��6    $
��Left=�63   $��395,240,0,0q�6N   $	��Top=�6c   �� 5   
   -   5        $ label6��5      $��	Check Out��6    $
��Left=�64   $��534,240,0,0q�6O   $	��Top=�6d   �� 5   
   -   5        $ damagefee_box��5      $
��Left=�6)   $��23��6D   $��659,265,0,0q�6P   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   �� 5    
   -   5        $ label7��5       $��
Damage Fee��6    $
��Left=�65   $��654,240,0,0q�6P   $	��Top=�6e   �� 5!   
   -   5        $ 	resid_box��5!      $
��Left=�6%   $��23��6@   $��261,363,0,0q�6L   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   �� 5"   
   -   5        $ label8��5"      $��Reservation ID��6    $
��Left=�69   $��256,340,0,0q�6T   $	��Top=�6i   �� 5#   
   -   5        $ reserveButton��5#      $��reserve room��6(   $
��Left=�6[   $��659,302,0,0q�6v   $	��Top=�6�   $��75��6�   �� 5$   
   -   5        $ updateReservationButton��5$      $��update check��62   $
��Left=�6o   $��659,338,0,0q�6�   $	��Top=�6�   $��75��6�   �� 5%   
   -   5        $ updateDamageFeeButton��5%      $��
update fee��60   $
��Left=�6i   $��659,371,0,0q�6�   $	��Top=�6�   $��75��6�   �� 5&   
   -   5        $ showFeedbackButton��5&      $��feedback��6-   $
��Left=�6a   $��659,404,0,0q�6|   $	��Top=�6�   $��75��6�   �� 5'   
   -   5        $ auditButton��5'      $��audit��6&   $
��Left=�6P   $��659,437,0,0q�6k   $	��Top=�6�   $��75��6�   5)      5*      