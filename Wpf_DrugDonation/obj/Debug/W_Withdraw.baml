   M S B A M L   `   `   `  ����K  GWpf_DrugDonation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Wpf_DrugDonationWpf_DrugDonation  5   	   !    Wpf_DrugDonation.W_Withdraw   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Wpf_DrugDonation     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	      Sty_win#��[  5
   	   .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   $��5q�6,   .+�5      �� $ 
Horizontal=�6   $��	0,10,0,10q�62   $��50��6E   $	��680��6Q   .+�5      �� $ Vertical=�6   $
��Left=�64   $��5q�6O   .+�5      �� $��Withdrawals��6    $��22(�63   $
��Bold"�6A    �� Padding$ 5q�6S   5      �� 5      $ Vertical=�6   $��Center=�64   $	��550��6O   .+�5      �� $ 
Horizontal=�6!   $��Right=�6:   $��0,0,30,0q�6V   .+�5      �� $ Vertical=�6%   .+�5      �� -   5         ��Name$ 
Btn_Donate��5   %   $��Donate��69     Sty_Header_Btn#��[ 6J   6r   5      �� 5      $ Vertical=�6%   $��3,0,10,0q�6<   .+�5      �� -   5        $ Btn_Withdraw��5   %   $��Withdraw��6;   #��[ 6N   {�. 
�������6�   5      5      5      5      �� 5      $ 
Horizontal=�6   $	��Top=�62   $	��330��6J   $
��10,0q�6W   .+�5      �� 
���   �$��1q�6-   $
��Left=�6A   $	��Top=�6\   $	��315��6t   $	��256��6�   $��
0,0,0,-0.4q�6�   ._�5       �� $ Vertical=�6!   $��0.2,0.2,0.2,-1.2q�68   .+�5"      �� $ 
Horizontal=�6%   $��90��6>   $	��256��6J   $	��Top=�6V   $
��Left=�6n   .+�5#      �� 
���   �$��0,0,0,1q�69   $	��256��6S   ._�5$   "   �� $ Vertical=�6-   $
��Left=�6D   $	��Top=�6_   $��80��6w   $	��245��6�   $��5q�6�   .+�5%   &   �� $ 
Horizontal=�61   $
��Left=�6J   $	��Top=�6e   .+�5&   *   �� $��Search Medicine��64   $��16(�6K   $
��Bold"�6Y   5'   '   �� 5(   &   $ 
Horizontal=�61   $��0,2,0,0q�6J   .+�5)   *   �� $��Find Medicine��64   $��12(�6I   $��	0,10,13,0q�6W   $	��Top=�6j   �� 5*   *   -   5         ��Name$ 
Tbx_filter��5*   2   $�� ��6F   $	��140��6N   $��20��6Z   $��Bottom=�6f   $��10q�6�    � ToolTip$6 0Please Enter Medicine Name or Serial Number here��6�   6�   5+   '   �� 5,   &   $ 
Horizontal=�61   $��98,0,-0.2,0q�6K   .+�5-   *   �� -   5         ��Name$ chckBx_Withdrawn��5-   3   $��Withdrawn Medicines��6M   6�   5.   '   5/   #   50      51      � 53      $	��235��6   $��	0,0,0.4,0q�6,   .+�54      &   System.Windows.Controls.DataGrid  -   5          Name$ Dg_AllMedicines��54   '   $   HorizontalScrollBarVisibility$ Disabled=�6@   	   
IsReadOnly	 . $	��225��6{   $	��Top=�6�   
   Columns
 55   "   0  *System.Windows.Controls.DataGridTextColumn  56   &   ,  &System.Windows.Controls.DataGridColumn   Header$ Medicine Name��69      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6P   �� *	medName+6l     57   &   $ Strength��69   $	 155 6h    6K   �� *
strength+6h   59      5:      5;      5<      �� 5>      
���   �$��0,1,1,1q�6-   $	��397��6G   $��
0,0,0,14.6q�6S   
�������._�5?      �� $ Vertical=�6c   $
��Left=�6z   $	��Top=�6�   $	��314��6�   $��0,0.2,-1,-0.6q�6�   $	��397��6�    � DataContext 6!   �� *SelectedItem+ �� ElementName$ Dg_AllMedicines��.+�5@      �� $ 
Horizontal=�6%   $��20,10q�6>   .+�5A      �� -   5         ��Name$ Tblck_withdrawals_details��5A   (   $��Medicine Details��6K   $��20(�6c   $
��Bold"�6q   $��
0,0,-0.2,0q�6�   5B      �� 5C      $ Vertical=�6%   $
��Left=�6<   $	��Top=�6W   $��	20,15,0,0q�6o   .+�5D      �� $ 
Horizontal=�6)   $
��Left=�6B   $	��Top=�6]   $��5,5,0,10q�6u   .+�5E   "   �� $��Serial Number��6,     Sty_withdraw_dtls#��[ 6A   �� 5F   "   -   5        $ Tbx_Med_sNum��5F   *   $	��170��6^   {�.  ��6@   �� *serialNumber+6j   5G      �� 5H      $ 
Horizontal=�6)   $
��Left=�6B   $	��Top=�6]   $��5,5,0,10q�6u   .+�5I   "   �� $��Medicine Name��6,   #��[ 6B   �� 5J   "   -	   5        $ Tbx_Med_Name��5J   *   $	��170��6Y   {�.  ��6@   �� *	medName+6e   5K      �� 5L      $ 
Horizontal=�6)   $
��Left=�6B   $	��Top=�6]   $��5,5,0,10q�6u   .+�5M   "   �� $��Strength��6,   #��[ 6<   �� 5N   "   -
   5        $ Tbx_Med_Strength��5N   *   $	��170��6^   {�.  ��6D   �� *
strength+6j   5O      �� 5P      $ 
Horizontal=�6)   $
��Left=�6B   $	��Top=�6]   $��5,5,0,10q�6u   .+�5Q   "   �� $��Expiry��6,   #��[ 6:   (  "System.Windows.Controls.DatePicker  5R   "   -   5          Name$ Tbx_Med_Expiry��5R   -   $	��170��6k   {�.     SelectedDate 6E   �� *
expiryDate+6w   5S      �� 5T      $ 
Horizontal=�6)   $
��Left=�6B   $	��Top=�6]   $��5,5,0,10q�6u   .+�5U   "   �� $��	Pack Size��6,   #��[ 6=   �� 5V   "   -   5        $ Tbx_Med_PackSize��5V   *   $	��170��6^   {�.  ��6D   �� *
packSize+6j   5W      �� 5X      $ 
Horizontal=�6)   $��
115,10,0,0q�6B   .+�5Y   "   �� -   5        $ Btn_Withdraw_med��5Y   )   $��Withdraw��6C   $��70��6V   $��24��6a   {�.  $��0,0,10,0q�6�   $" Click to withdraw a medicine��6�   �� 5Z   "   -   5        $ Btn_DonorDetails��5Z   )   $��Donor Details��6C   $��80��6[   $��24��6f   {�.  6�   5[      5\      5]      5_      5`      5b      5c      5d      