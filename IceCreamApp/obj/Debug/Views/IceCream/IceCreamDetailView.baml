   M S B A M L   `   `   `  ����F  BIceCreamApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:IceCreamApp.ConvertersIceCreamApp.Converters  5      I)clr-namespace:IceCreamApp.ValidationRulesIceCreamApp.ValidationRules  5	      3    -IceCreamApp.Views.IceCream.IceCreamDetailView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5      5
converters$clr-namespace:IceCreamApp.Converters  5      ?validationRules)clr-namespace:IceCreamApp.ValidationRules  5	        � 	Resources  5      +   %IceCreamApp.Converters.ImageConverter   imageConverter �� 
StartPoint �� EndPoint 
 LBrush � Offset � Color��%�   &	        &	        5   
   6$   �� 5   
   $	 0 0&�6   $	 0 1&�6/   ��5      � $	 0.1Q�6   $ CornflowerBlue��6,   � 5      $ 1Q�6   $ 	AliceBlue��6*   5      5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+5       .��5#      ]� .+�5$      � $	��Top=�6   	 � ColumnDefinitions	 5%   
   �� 5&      6!   �� 5'      6!   
 � RowDefinitions
 5)   
   �� 5*      $
��Auto �6   6,   �� 5+      $
��Auto �6   6,   �� 5,      $
��Auto �6   6,   �� 5-      $
��Auto �6   6,   .+�50   
   �� $��0��6   $��0��6   .��6-   
Ice Creams69   �� 51   
   $��0��6   $��1��6    $��Stretch=�52      $��Stretch=�53      ��54      �� *	IceCreams+ �� SelectedItem 65   �� *SelectedIceCream+��56      �� 57      .R�58      � $��Stretch=�6   #��[ 69   	 5;      �� 5<      $	��150 �6/   6=   �� 5=      $��* �6/   6;   �� 5>      $��50 �6/   6<   .+�5A      �� $��0��6:   ��6$   �� *Name+6:   �� 5C      $��2��6    $��50��61   $��50��6<   $��
0, 0, 5, 0q�6H   ��5D      ��  �� 	Converter# [  5F      5G      5I      �� 5K   
   $��1��6   $��0��6   .��6-   Name63   �� 5L   
   $��1��6   $��1��6   .��6/   ��5M      �� 5N       �� Path$
 Name�6    �� UpdateSourceTrigger$ PropertyChanged=�5O       �� ValidatesOnDataErrors .  �� NotifyOnValidationError .  �� ValidatesOnExceptions .  �� ValidationRules 5T      .   (IceCreamApp.ValidationRules.IceCreamRule  5U      5X      .��5Y      5Z      �� 5\   
   $��2��6   $��0��6   .��6-   Creation Cost6<   �� 5]   
   $��2��60   $��1��6=   ��6   �� *CreationCost+6O   �� 5_   
   $��3��6   $��0��6   .��6-   No Frills Combo6>   �� 5`   
   $��3��6   $��1��6!    �� DisplayMemberPath$
 Name��6}   ��61   �� *	IceCreams+ 6S   �� *SelectedIceCream+6�   5a      �� 5b   
   $��Bottom=�61     ButtonControlTemplate#��[ 5c      ��5b      �� *SaveCommand+.��5c   C   Save6I   5f      5h      