   M S B A M L   `   `   `  ����F  BIceCreamApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:IceCreamApp.ViewsIceCreamApp.Views  5      '    !IceCreamApp.Views.Store.StoreView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:IceCreamApp.Views     5      .��5      � $��5q�6   $	��500��6     � ColumnDefinitions  5   
   �� 5      $	��115 �6   6-   �� 5      $��25 �6   6,   �� 5       � RowDefinitions 5   
   �� 5      $��25 �6   6*   �� 5      $��25 �6   6*   �� 5      $��25 �6   6*   �� 5      $��2* �6   6*   .+�5   
   �� $��0��6   $��0��6    $��2��6/   .��6B   Store6I   �� 5   
   $��2��6   $��0��6$   ��61   �� *	StoreName+�� 5   
   $��0��6   $��1��6    .��6.   	Manager67   �� 5   
   $��2��6   $��1��6$   ��61   �� *ManagerName+�� 5   
   $��0��6   $��2��6    .��6.   Phone65   �� 5    
   $��2��6   $��2��6$   ��61   �� *Phone+�� 5"   
   $��0��6   $��3��6    .��6.   Operational Status6B   �� 5#   
   $��2��6   $��3��6%   $
��Bold"�5$      ��6'   �� *OperationalStatus+��5%      �� 5&       �� Triggers 5'      �� 5(       �� Binding 6&   �� *OperationalStatus+   IsStoreOperationalConverter �� 	Converter# [   �� Value	 False6�   .a�5)      ��  �� Property � �� �� Value
 �����6Z   �� 5*       � ��$ 	ExtraBold"�6E   6Y   5+      5-      5/      51      52      