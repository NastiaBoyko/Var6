   M S B A M L   `   `   `  ����F  BExpenseList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ExpenseListExpenseList  5   	       ExpenseList.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ExpenseList     5   	     � Title$  
MainWindow��5	   	   $	��500��6   $	��800��6)   
��� ��� � WindowStartupLocation$ CenterScreen=�5
   	   .��5      ]� .+�5   
   �  � ColumnDefinitions 5      �� 5      $	��200��6#   $��2* �62   �� 5      $
��Auto �6#   �� 5      $	��110��6#   $��* �62   �� 5      $
��Auto �6#   �� 5      $	��110��6#   $��* �62   .+�5      �� $��0��5      
��� ���$��Stretch=�5      $��2��67   ��5      �� *
Expenses+ �� SelectedItem 5      ��  �� Path$ SelectedExpense���5      �� 5      .R�5      �  � RowDefinitions 5      �� 5   "   �� 5   "    5       �� 5!   "   �� 5"   "   .+�5$      �� $��./money.png��6$   $��32��69   $��0,0,10,0q�6D   $
��Left=�6V   $��2��6q   ]� 5%      $��1��6(   $��0��68   .+�5&   "   �� $��18(�6O   $
��Bold"�6]   
���������6,   �� $ PurchaseName�6�   5'      ]� 5(      $��1��6(   $��1��68   ��.  .+�5)   "   �� $��Light"�6,   
��������� 5*   &   �6*   �� $ Price� �� Mode$ OneWay=�6U    �� 5+   &   .�6*   $6.   5,   #   �� 5-   "   $��DemiBold"�6X   $��Right=�6n   
���������6,   �� $ ShopName�$ OneWay=�6�   5.      5/      50      52      �� 53      $��Center=�6   $��Stretch=�54      ���#FF7F50$��3��55      $��1��6!   64   �� 56      $��2��6   
�������.+�57      �� $��Center=�6   $��0,13,0,0q�65   .��6G   Назва предмета6W   �� 58      $��Center=�6   .��65   
Дата6;   �� 59      $��Center=�6   .��65   Час6:   �� 5:      $��Center=�6   .��65   Номер чека6A   �� 5;      $��Center=�6   .��65   Вартість6?   �� 5<      $��Center=�6   .��65   Місце витрати6D   5=      ]� 5>      $��4��6   
���������.  .+�5?      ��  �� 
IsReadOnly . $	��Top=�6,      textBoxTemplate#��[  6o   $��0,10,0,0q�6�   ��6A   �� *SelectedExpense.PurchaseName+6�   �� 5@       . $	��Top=�6,   #��[  6   ��6A   �� *!SelectedExpense.PurchaseDateStr+$ OneWay=�6�   �� 5A       . $	��Top=�6,   #��[  6   ��6A   �� *!SelectedExpense.PurchaseTimeStr+$ OneWay=�6�   �� 5B       . $	��Top=�6,   #��[  6o   ��6A   �� *SelectedExpense.TicketNumber+6�   �� 5C       . $	��Top=�6,   #��[  6h   ��6A   �� *SelectedExpense.Price+6�   �� 5D       . $	��Top=�6,   #��[  6k   ��6A   �� *SelectedExpense.ShopName+6�   �� 5F      
���Gc��$��
20 20 20 0q�6-   $	��Top=�6A     	actionBtn#��[ 6|   ��6V   �� *AddExpenseCommand+.��6�   Додати витрату6�   5H      �� 5I      $��Center=�6   $��Stretch=�5J      $��2��5K      $��3��6!   ���#FF7F506H   5L      5M      5N      