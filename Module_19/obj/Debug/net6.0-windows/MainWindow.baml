   M S B A M L   `   `   `  ����D  @Module_19, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Module_19.ViewModelsModule_19.ViewModels  5   	       Module_19.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1vm"clr-namespace:Module_19.ViewModels     5   	   $	��500��5	   	   $
��1000��5
   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title 5   	   �� *Title+ � DataContext 5      .  (Module_19.ViewModels.ViewModelMainWindow  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $	��36* �6   �� 5      $	��47* �6   �� 5      $	��47* �6   �� 5      $	��47* �6   �� 5      $	��47* �6   �� 5      $	��47* �6   �� 5      $	��47* �6   �� 5      $	��47* �6   �� 5      $	��47* �6   �� 5      $	��13* �6    � ColumnDefinitions 5   
   �� 5      $
��527* �6   �� 5      $
��165* �6   �� 5       $
��165* �6   �� 5!      $
��152* �6   .+�5$   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridAnimal��5$         AutoGenerateColumns$ False��5%      $��5q�5&      $��10��5)      ��5'      �� *CollectionAnimal+ �� SelectedItem 5(      �� *SelectedAnimalDataGrid+   Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��5,   %   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 40 5-   %      
IsReadOnly$
 True��5.   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5+   %   �� *Id+5/        51      $	 Тип животного��52   %   $	
 120 53   %   $ False��54   %    51   %   �� *
TypeAnimal+55        57      $	 Название��58   %   $	
 100 59   %   $ False��5:   %    57   %   �� *Name+5;        5=      $	 Возраст��5>   %   $
 60 5?   %   $ False��5@   %    5=   %   �� *Age+5A        5C      $	 Вес��5D   %   $
 60 5E   %   $ False��5F   %    5C   %   �� *Weight+5G      5I      �� 5K   
   $��5q�5L      $��10��5M      $��1��5N      $��3��5O      ��5K      �� *GroupboxTitleAnimal+5P      �� 5R   
   $��Center=�5S      $��Center=�5T      $��10,5,5,5q�5U      $��1��5V      $��1��5W      ��5R      �� *Type+5X      �� 5Z   
   $��Center=�5[      $��Center=�5\      $��2��5]      $��5q�5^       �� TextWrapping$
 Wrap=�5_      $��1��5`      ��5Z      �� *TextboxType+ �� Mode$ TwoWay=�.��5`      5a      �� 5c   
   $��Center=�5d      $��Center=�5e      $��10,5,5,5q�5f      $��1��5g      $��2��5h      ��5c      �� *	TitleName+5i      �� 5k   
   $��Center=�5l      $��Center=�5m      $��2��5n      $��5q�5o      $
 Wrap=�5p      $��2��5q      ��5k      �� *TextboxTitleName+$ TwoWay=�.��5q      5r      �� 5t   
   $��Center=�5u      $��Center=�5v      $��10,5,5,5q�5w      $��1��5x      $��3��5y      ��5t      �� *Age+5z      �� 5|   
   $��Center=�5}      $��Center=�5~      $��2��5      $��5q�5�      $
 Wrap=�5�      $��3��5�      ��5|      �� *
TextboxAge+$ TwoWay=�.��5�      5�      �� 5�   
   $��Center=�5�      $��Center=�5�      $��10,5,5,5q�5�      $��1��5�      $��4��5�      ��5�      �� *Weight+5�      �� 5�   
   $��Center=�5�      $��Center=�5�      $��2��5�      $��5q�5�      $
 Wrap=�5�      $��4��5�      ��5�      �� *TextboxWeight+$ TwoWay=�.��5�      5�      �� 5�   
   $��3��6   $)��#Добавить животного��5�      $��5,5,10,5q�5�      $��1��5�      ��5�      �� *CommandAddAnimal+5�      �� 5�   
   $��3��6   $'��!Удалить животного��5�      $��5,5,10,5q�5�      $��2��5�      ��5�      �� *CommandDeleteAnimal+5�      �� 5�   
   $��3��6   $#��Обновить данные��5�      $��5,5,10,5q�5�      $��3��5�      ��5�      �� *CommandUpdateAnimal+5�      �� 5�   
   $��Center=�5�      $��Center=�5�      $��10,5,5,5q�5�      $��1��5�      $��5��5�      ��5�      �� *SaveFileSelection+5�      �� 5�   
   $��5,5,5,5q�6   $��2��5�      $��5��5�      $��Center=�5�      $��Center=�5�      ��5�      �� *
SaveFile+ 5�      �� *SelectedSaveFileComboBox+5�      �� 5�   
   $��3��6   $��Сохранить��5�      $��5,5,10,5q�5�      $��5��5�      ��5�      �� *CommandSaveFile+5�      5�      5�      