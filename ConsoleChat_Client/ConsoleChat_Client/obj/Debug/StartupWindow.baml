   M S B A M L   `   `   `  ����M  IConsoleChat_Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ConsoleChat_ClientConsoleChat_Client  5   	   &     ConsoleChat_Client.StartupWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ConsoleChat_Client     5   	     � Title$  StartupWindow��5   	   $	��250��6   $	��600��6,    � 
ResizeMode$ NoResize=�68   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6    �� 5      �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0��6   $��0��6   $��15(�6-   $��Ник:��6;   $��Center=�6J   �� 5   
   -   5        $��
ClientName��5   /   $��0��6   $��1��6   $��	5,23,5,23q�6A   �� 5   
   $��0��6   $��2��6   $��15(�6-   $	��IP:��6;   $��Center=�6I   �� 5   
   -   5        $��ClientConnectIp��5   /   $��0��6   $��3��6   $��	5,23,5,23q�6F   $��	127.0.0.1��6Y   �� 5   
   $��0��6   $��4��6   $��15(�6-   $��	Порт:��6;   $��Center=�6K   �� 5   
   -   5        $��ClientConnectPort��5   /   $��0��6   $��5��6   $��	5,23,5,23q�6H   $
��1213��6[   �� 5   
   -   5        $��bConnect��5   .   $��2��6   $��5��6   $&�� Подконнектиться!1��6>   $��10,20,10,20q�6Z   6o   5      5       