   M S B A M L   `   `   `  ����  ActiveWinery.Configuration?    9ActiveWinery.Configuration.Views.ObservationsCategoryView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      M INeoOrange.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null.	neoorangehttp://neoorange/xaml/controls  5        J� SnapsToDevicePixels  .  � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5	      $3 -/NeoOrange.Styles;component/DefaultStyle.xaml?�6%   %    5      .��5      � $	��400��6     .  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      .+�5   
   �� $��0��6   $��3��6!   $��0��65      WindowTitle#���   6B     . ._�5      �   .  � ColumnDefinitions 5      �� 5      $	��100 �6'   �� 5      �� 5      $
��Auto �6'   .+�5      �� -   5         ��Name$ 
WindowIcon��5   !   $��0��65     ConfigWindowTitleImage#���  6E     . ;  5NeoOrange.Controls.Extensions.GeneralControlExtension   IsDirty 5   !   �� *	IsDirty+6_   �� 5       -   5         ��Name$ Title��5       $��1��6+     WindowTitleText#���  6;   $��Center=�5!      $��10, 0, 0, 0q�67   $��Observations Categories��6L     . 5"      �� 5#      $��2��6   $��0��6)     WindowButtonBorder#���  66     . ._�5$      �� 	 �� Orientation$	 
Horizontal=�6!   $��Center=�6:   $��Center=�5%   "   $��0,0,2,0q�6@     . .+�5&      �� -   5        
 ��Name$
 DockWindowLeft��5&   !     DockLeftButton#���  69     . 6   �� 5'      -   5        $
 CentreWindow��5'   !     CentreButton#���  67     . 6{   �� 5(      -   5        $
 DockWindowRight��5(   !     DockRightButton#���  6:     . 6�   �� 5)      -   5        $
 CloseWindow��5)   !     CloseButton#���  66     . 6y   5*      5+      5,      5-      �� 5/   
   $��1��6     
WindowBody#���  6     . ._�50      �   .  51      �� 52      $	��100 �6'   �� 53      .+�56      �� $	��Top=�6   $��	0,15,0,15q�60   $	��400��6C   $	��100��6P   $��0��6]   $
��None=�57      $>��8/NeoOrange.Styles;component/Images/Orange/windowside.png��6'     . 58      � 59      $��1��6     .  5:      �� 5;      $��25 �6(   �� 5<      $��25 �6(   �� 5=      $	��200 �6(   �� 5>      $��25 �6(   �� 5?       5B      �� 5C      $��5 �6+   �� 5D      $	��150 �6+   �� 5E      �� 5F      $��5 �6+   .+�5I      �� $��1��6    $��1��6-   $��Center=�6=   Available Categories6n   �� 5J      -   5         ��Name$ 
Categories��5J   O   $��2��6   $��1��6+   $��2��6;   6e   �� 5K      $��3��6!   $��1��6.   $��2��6>   $	 
Horizontal=�6R   $��Right=�6k   .+�5L      �� -   5        $
 AddCategory��5L   !   .��66   Add6;   �� 5M      -	   5        $
 DeleteCategory��5M   !   .��69   Delete6A   �� 5N      -
   5        $
 RenameCategory��5N   !   .��69   Rename6A   5O      5P      5Q      5R      5T      5U      