   M S B A M L   `   `   `  ����@  <UICHS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UICHSUICHS  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5          UICHS.UserSettingControl   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:UICHS     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1-Custom http://www.galasoft.ch/mvvmlight  5      $��244.353��5
   #     � DataContext  63   ��    Locator �� Source# [   �� Path$ UserSettingVM�.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      /  )GalaSoft.MvvmLight.Command.EventToCommand     MustToggleIsEnabledValue .    Command 6E   �� *UnLoadedCommand+5      .��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   	 � ColumnDefinitions	 5   
   �� 5      $
��0.5* �6   6.   �� 5      6!   .+�5   
   �� $��0��6   $��0��6    $��ФИО��6-   $
��Left=�6;   $��Center=�6V   6s   �� 5   
   $��0��6   $��1��6    $��Должность��6-   $
��Left=�6A   $��Center=�6\   6y   �� 5   
   $��0��6   $��2��6    $��
Логин��6-   $
��Left=�6=   $��Center=�6X   6u   �� 5    
   $��0��6   $��3��6    $��Пароль��6-   $
��Left=�6>   $��Center=�6Y   6v   �� 5!   
   $��1��6@   $��0��6P   ��6   �� *DutyOfficer.NameDutyOfficer+6a   �� 5"   
   $��1��6<   $��1��6L   ��6   �� *DutyOfficer.PositionDuty+6]   �� 5#   
   $��1��6@   $��2��6P   ��6   �� *DutyOfficer.LoginDutyOfficer+6b   �� 5$   
   $��1��6C   $��3��6S   ��6   �� *!DutyOfficer.PasswordDutyOfficer+6d   �� 5%   
   
 �� Orientation$
 
Horizontal=�6   $��1��6.   $��4��6>   .+�5&      �� $��Сохранить��65   $��65��6I   $��30��6T   $��10q�6`   ��6   �� *SaveCommand+6n   �� 5'      $��Отмена��67   $��10q�6H   $��65��6T   $��30��6_   ��6   �� *CancelCommand+6n   5(      5)      5*      