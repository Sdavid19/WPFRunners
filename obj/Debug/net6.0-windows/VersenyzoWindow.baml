   M S B A M L   `   `   `  ����F  BFutoverseny, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:FutoversenyFutoverseny  5   	   !    Futoverseny.VersenyzoWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Futoverseny     5   	     � Title$$  Versenyző adatok rögzítése��5      $	��350��6+   $	��400��68   $��16(�6D    � 
ResizeMode$ NoResize=�6R   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��auto �6   �� 5      �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��
Rajtszám:��6   $��Center=�61   �� 5   
   $��1��6   $��Név:��6   $��Center=�6,   �� 5   
   $��2��6   $��Távolság:��6   $��Center=�61   �� 5   
   $��3��6   $��Neme:��6   $��Center=�6-   �� 5   
   $��4��6   $��Korosztály:��6   $��Center=�63   �� 5   
   $��5��6   $��Szül. dátum:��6   $��Center=�64   �� 5!   
   -   5        $��txtRajtszam��5!      $��0��6%   $��1��62   $��28��6B   $��60��6N   $
��Left=�6Y   ��5"      �� *
Rajtszam+�� 5#   
   $��1��6   $��1��6   $��28��6/   ��5$      �� *Nev+�� 5%   
   -   5        $��cboTavolsag��5%      $��2��6&   $��1��63   $��28��6C    �� SelectedValue 5&      �� *
TavolsagId+�� 5'   
   $��3��6   $��1��6   $��28��6/   $	��120��6;   $
��Left=�6G   ��5(      �� *Neme+�� 5)   
   $��4��6   $��1��6   $��28��6/   $	��120��6;   $
��Left=�6G   ��5*      �� *
Korosztaly+(  "System.Windows.Controls.DatePicker  5+   
   $��5��6   $��1��6"   $��28��62   $	��130��6>   $
��Left=�6J      SelectedDate 5,      �� *SzuletesiDatum+� 5.   
   $��6��6   $��2��6!   $��Center=�65   $��Center=�6R   .+�5/      �� -   5        $��Mentés��5/      $	��100��6&   $��28��62   $��0 0 10 0q�6>   6P   �� 50      -   5        $��Mégsem��50      $	��100��6&   $��28��62   $��10 0 0 0q�6>   6P   51      52      53      