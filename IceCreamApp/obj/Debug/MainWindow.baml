   M S B A M L   `   `   `  ����F  BIceCreamApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:IceCreamAppIceCreamApp  5   	   5clr-namespace:IceCreamApp.ViewsIceCreamApp.Views  5   	   ?$clr-namespace:IceCreamApp.ViewModelsIceCreamApp.ViewModels  5   	       IceCreamApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:IceCreamApp     5   	   1viewsclr-namespace:IceCreamApp.Views     5   	   ;
viewModels$clr-namespace:IceCreamApp.ViewModels     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5
   	     � Title$  
MainWindow��5   	   $	��550��6   $	��825��6)    
  BBrush#��[  65   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� -   5         ��Name$ 	tbMessage��5      $��0��6(    J� Opacity$ 0Q�5      $��60��5      $��Center=�5      $��20(�5      $��	ExtraBold"�5      
����  ���5      �� *	Message+ �� NotifyOnTargetUpdated .  � Triggers 5      :� 5       :� RoutedEvent$ Binding.TargetUpdated��6   .[�5      �� .��5      �� .��5      W�  �� 
TargetName$ 	tbMessage��6.    �� TargetProperty$ Opacity�5   .   		 W� To$	 1X�6R   
 g� 	BeginTime$
 0:0:0X�6Y    g� Duration$ 0:0:1D�6k   W� 5       $ 	tbMessage��6.   $ Opacity�5!   .   $	 0X�6R   $
 0:0:3X�6Y   $ 0:0:1D�6k   5"      5#      5$      5&      � 5'      $��1��6    5(   
   �� 5)      $��30 �6   6*   �� 5*      $��* �6   6)   �� 5+      $
��Auto �6   6,   .+�5/   
   #   IceCreamApp.Views.WelcomeView  $��0��6   6,   �� 52   
   $��1��6   .��55      �� ��6    �� *MainWindowView+57      58      �� 5:   
    �� Orientation$ 
Horizontal=�6   $��2��6.   .+�5;      �� 
������   ButtonControlTemplate#��[ 6T   ��6   �� *AListCommand+.��5<      �� $ 
Horizontal=�6   .+�5=      "  FontAwesome.WPF.ImageAwesome     Icon$
 List=�6&   $��15��63   ��5>      �� 5?       �� 
TargetType"  6$    �� Triggers 5@   "   �� 5A   &    �� Binding 62   �� *IsListSelected+ �� Value True6U   .a�5B   *   ��  �� Property �@ 
Foreground �� Value
 �   �6G   5C   '   �� 5D   &    62   �� *IsListSelected+	 False6U   .a�5E   *   ��  �@ 
Foreground
 ��� �6G   5F   '   5H      5J      �� 5L      $��5,0,0,0q�6    ��5M      �� 5N      " ��6$    5O   "   �� 5P   &    62   �� *IsListSelected+ True6U   .a�5Q   *   ��  � ��$
 Bold"�6G   5R   '   5T      $��
Store List��5V   D   5W      5X      5Y      �� 5Z      $��Center=�6:   
������ #��[ 6r   ��6   �� *AGridCommand+.��5[      �� $ 
Horizontal=�6   .+�5\        $ Table=�6&      
Foreground
 ��� �$��15��6L   ��5]      �� 5^      "  6$    5_   "   �� 5`   &    62   �� *IsTableSelected+ True6V   .a�5a   *   ��  �@ 
Foreground
 �   �6G   5b   '   �� 5c   &    62   �� *IsTableSelected+	 False6V   .a�5d   *   ��  �@ 
Foreground
 ��� �6G   5e   '   5g      5i      �� 5j      $��5,0,0,0q�6    ��5k      �� 5l      " ��6$    5m   "   �� 5n   &    62   �� *IsTableSelected+ True6V   .a�5o   *   ��  � ��$
 Bold"�6G   5p   '   5r      $��Table��5t   ?   5u      5v      5w      �� 5x      $��Right=�6<   
������ #��[ 6s   ��6   �� *ADetailCommand+.��5y      �� $ 
Horizontal=�6   .+�5z        $ FileText=�6&   
 ��� �$��15��6O   ��5{      �� 5|      "  6$    5}   "   �� 5~   &    62   �� *IsDetailSelected+ True6W   .a�5   *   ��  �@ 
Foreground
 �   �6G   5�   '   �� 5�   &    62   �� *IsDetailSelected+	 False6W   .a�5�   *   ��  �@ 
Foreground
 ��� �6G   5�   '   5�      5�      �� 5�      $��5,0,0,0q�6    ��5�      �� 5�      " ��6$    5�   "   �� 5�   &    62   �� *IsDetailSelected+ True6W   .a�5�   *   ��  � ��$
 Bold"�6G   5�   '   5�      $��Ice Cream Detail��5�   J   5�      5�      5�      5�      5�      5�      5�      