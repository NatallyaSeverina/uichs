   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   @ <UICHS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UICHSUICHS 5	   	      UICHS.MainWindow   5   	   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1-Custom http://www.galasoft.ch/mvvmlight  5   	   localclr-namespace:UICHS  5	   	   *cmd http://www.galasoft.ch/mvvmlight  5
   	     � Title$  УИЧС��5   	    � WindowState$ Normal=�6    � WindowStartupLocation$ CenterScreen=�6,   $	��850��6Q   $	��800��6a    � Icon$ Images\Icon.ico��6q      WindowStyle#��[  6�    � DataContext 5   	   ��   Locator �� Source# [  �� Path$
 Main�.   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase	   Actions.	 5      /  )GalaSoft.MvvmLight.Command.EventToCommand  
   MustToggleIsEnabledValue
 .    Command 6E   �� *UnLoadedCommand+5       � 	Resources 5      $  UICHS.PurishedToColorConverter  PerishedToColorConverter*  $UICHS.ToRegistrationToColorConverter " ToRegistrationToColorConverter  PerishedStyle �� 
TargetType*  $System.Windows.Controls.DataGridCell �� Property �� Value �� 	Converter  ControlForegroundWhite)  #System.Windows.Controls.DataGridRow  PerishedChildrenStyle��%  &	       &	      &	 &     7  7  '  �     7  &	 )    7  7    5   
   6)     5   
   6X   �� 5   
   "  6&   .�5      ��  � �� 6+   �� *
Perished+8   �� 5       � ��8  6^   �� 5       � ��$ 1 0 0 0q�60   5      �� 5   
   "  6   .�5      ��  � �� 6+   �� *ToRegistration+8   5      �� 5   
   "  6.   .�5       ��  � �� 6+   �� *PerishedChildren+8   �� 5!       � ��8  6^   �� 5"       � ��$ 1 0 0 0q�60   5#      5$      .��5%   
   �  6   �� # [ $
 Main� � RowDefinitions 5&   
   �� 5'      $
��auto �6   6,   �� 5(      $
��auto �6   6,   �� 5)      $
��0.4* �6   6,   �� 5*      $
��1.3* �6   6,   �� 5+      $��3* �6   6*   �� 5,      $
��auto �6   6,    � ColumnDefinitions 5.   
   �� 5/      $
��1.5* �6   6.   �� 50      $
��0.6* �6   6.   �� 51      $
��2.2* �6   6.   .+�54   
   o� $��Center=�6   $��3��6+   $��0��6?   .@�55      m� $
��ЧС��6   .@�56      m� $��Добавить��6    m� Command 6-   �� *AddEmergencyCommand+6X   m� 57      $ ��Редактировать��6    62   �� *EditEmergencyCommand+{�6[   �� *IsEditEmergencyEnable+6�   m� 58      $��Удалить��6    6,   �� *DeleteEmergencyCommand+{�6W   �� *IsEditEmergencyEnable+6�   59      m� 5:      $��Сводка��6   .@�5;      m� $��Добавить��6h    6   �� *AddReportCommand+{�6@   �� *IsAddReportEnable+6}   m� 5<      $��Просмотреть��6l    6   �� *OpenReportCommand+{�6A   �� *IsDeleteReportEnable+6�   m� 5=      $��Удалить��6n    6   �� *DeleteReportCommand+{�6C   �� *IsDeleteReportEnable+6�   5>      m� 5?      $��Справка��6   .@�5@      m� $��О программе��6D    6   �� *AboutProgrammCommand+6D   5A      m� 5B      $��XML документ��6   .@�5C      m� $��Записать��6B    6   �� *WriteXMLDocCommand+6B   m� 5D      $)��#Считать информацию��6A    6   �� *ReadXMLDocCommand+6A   5E      5F      `� 5G   
     ControlLightBackground `� 
Background# [ 6   $��1��6L   $��3��6Y   .�5I      c� .@�5J      �� $��5,3,0,0q�6   $
��ЧС��6/   6;   �� 5K      $��	10,0,10,0q�6   ��6-   �� *AddEmergencyCommand+.��5L      ��   add_messageStyle0#��[ 6&   6V   5M      �� 5N      $��	10,0,10,0q�6   {�6-   �� *IsEditEmergencyEnable+��6[   �� *EditEmergencyCommand+.��5O      ��  	 edit_messageStyle0#��[	 6&   6W   5P      �� 5Q      $��	10,0,10,0q�6   {�6-   �� *IsEditEmergencyEnable+��6Z   �� *DeleteEmergencyCommand+.��5R      ��  
 delete_messageStyle0#��[
 6&   6Y   5S      �� 5T      6   �� 5U      $��0,3,0,0q�6   $��Сводка��6/   6?   �� 5V      $��	10,0,10,0q�6   ��6-   �� *AddReportCommand+{�6R   �� *IsAddReportEnable+.��5W      ��   add_reportStyle0#��[ 6&   6U   5X      �� 5Y      $��	10,0,10,0q�6   ��6-   �� *OpenReportCommand+{�6S   �� *IsDeleteReportEnable+.��5Z      ��   open_reportStyle0#��[ 6&   6V   5[      �� 5\      $��	10,0,10,0q�6B   ��6   �� *DeleteReportCommand+{�6U   �� *IsDeleteReportEnable+.��5]      ��   delete_reportStyle0#��[ 6&   6X   5^      �� 5_      6   �� 5`      $	��660��6   6&   5a      c� 5b      .@�5c      �� $��0,3,0,0q�6   $��Пользователь��6.   6D   �� 5d      $��	10,0,10,0q�6   ��6.   �� *ChangeUserCommand+.��5e      ��   reply_peopleStyle0#��[ 6&   6W   5f      �� 5g      $��	10,0,10,0q�6   ��6.   �� *UserSettingCommand+.��5h      ��   settingsStyle0#��[ 6&   6R   5i      5k      5l      �� 5m   
   $��5��6   $��5��6)   .@�5n      �� ��6   �� *StatusBarInfo+68   5o      �� 5p   
   $��1��6   $��2��6#   $��2��60   $2��,Выберите дату дежурства��6A   .��5q      �� .+�5r      �� $��	0,20,0,15q�66   $��1��6I   ���	#FFEEEFFF$��Center=�6q   $��2��6�   $��Center=�6�   $
��Bold"�6�   $��30(�6�   ��6   �� $
 Time�6�   (	  "System.Windows.Controls.DatePicker	  5s      $��	0,15,0,20q�6   $��36��60   $	��130��6<   $��18(�6H    	  SelectedDate 6V   �� *SelectedDate+ 5t        5u      $ SelectedDatesChanged��6)   .	 5v        
 .  6U   �� *SelectedDateCommand+5w      5y      &
   System.Windows.Controls.Calendar
  5z      $y�Hidden=�6    
  IsTodayHighlighted .  
  FirstDayOfWeek$ Monday=�6J    
  SelectedDate 6b   �� *SelectedDate+ 5{        5|      $ SelectedDatesChanged��6!   .	 5}        
 .  6M   �� *SelectedDateCommand+5~      5�      5�      5�      �� 5�   
   $C��=Информация о ЧС за дежурные сутки��6   $��0,5,0,0q�6@   $��4��6Q   $��4��6e   .��5�      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     
IsReadOnly . $��Stretch=�5�      $	��Top=�67   $
��auto��6O   $
��auto��6]   ��5�      �� *EmergencySituations+ �� SelectedItem 6D   �� *CurrentEmergency+ � ContextMenu 5�      �� 5�      .@�5�      m� $ ��Редактировать��6L    6#   �� *EditEmergencyCommand+{�6c   �� *IsEditEmergencyEnable+6�   m� 5�      $��Удалить��6N    6#   �� *DeleteEmergencyCommand+{�6_   �� *IsEditEmergencyEnable+6�   5�       5�        5�      $ SelectionChanged��6!   .	 5�        
 .  6M   �� *!SelectionChangedDataGridCommand+5�        5�      $ MouseDoubleClick��6!   .	 5�        
 .  6M   �� *EditEmergencyCommand+5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Дата��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *DateOfEmergency+  �� StringFormat$  
dd.MM.yyyy��6t     5�      $ 
Время��6%    64   �� *RegistrationTime+6[     5�      $ Область��6%    66   �� *Region+6S     5�      $ 
Район��6%    64   �� *Neighborhood+6W     5�      $% Населенный пункт��6%    6?   �� *PopylatedLocality+6g     5�      !   Width5  /System.Windows.Controls.DataGridLengthConverter$	! 450 6%   $ Описание��61    6C   �� *DescriptionOfEmergency+"   ElementStyle" 5�      �� 5�      .�5�   "   ��  � ��$
 Wrap=�6K   5�      5�        5�      $ Пог.��6%   #   	CellStyle## [ 6P    63   �� *
Perished+6}     5�      $ Пог.дет.��6%   ## [ 6\    67   �� *PerishedChildren+6�   4  .System.Windows.Controls.DataGridCheckBoxColumn  5�      $   
IsReadOnly$ . $ В сводку��6;    6M   �� *
ToReport+" 5�      �� 5�      " ��6    % �� BasedOn#% [B��6?   5�      5�        5�      $ . $ Учетный��67    6H   �� *ToRegistration+" 5�      �� 5�      " ��6   #% [B��6;   5�      5�      5�      5�      �� 5�   
   $��0��6   $��2��6#   $��2��60   $@��:Количество ЧС за дежурные сутки��6A   .��5�        UICHS.ChartControl  6$   5�      �� 5�   
   $��3��6   $��2��6#   $��2��60   $8��2Количество ЧС с начала года��6A   .��5�      #  UICHS.EmergenciesInfoByRegion  60   5�      5�      5�      