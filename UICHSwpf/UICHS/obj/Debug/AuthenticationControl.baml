   M S B A M L   `   `   `  ����@  <UICHS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UICHSUICHS  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      !    UICHS.AuthenticationControl   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:UICHS     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1-Custom http://www.galasoft.ch/mvvmlight  5        � DataContext  5
   9   ��    Locator �� Source# [   �� Path$ AuthenticationVM�.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Unloaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      /  )GalaSoft.MvvmLight.Command.EventToCommand     MustToggleIsEnabledValue .    Command 6E   �� *UnLoadedCommand+5      .��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   	 � ColumnDefinitions	 5   
   �� 5      6!   �� 5      6!   .+�5   
   (� $��3��6   $��4��6&   .��5      F� 
 �� Stretch$

 Fill=�6     
userStyle0#��[ 6"   
�������6E   5      �� 5    
   $��
Логин��6   $��Center=�6    $��Right=�6;   �� 5!   
   $��1��6   $��3q�6"   ��6-   �� *Login+ �� Mode$ TwoWay=��� 5"   
   $��Center=�6   $��1��6,   $��Пароль��69   $��Right=�6J   G� 5#   
   -   5        $��PasswordBox��5#   ?   $��1��6   $��1��6#   $��3q�63    G� PasswordChar$ *��6R   6e   �� 5%      $��2��6   $��2��6   $��0��60   $��70��6@   $��25��6K   $��
Войти��6W    �� 	IsDefault . ��5&      �� *LoginCommand+��62   ��  �� ElementName$ PasswordBox��6g   �� 5'   
   $��2��6   $��2��6   $��2��6/   $��70��6?   $��25��6J   $��Отмена��5(      ��5)      �� *CancelCommand+5-      5.      