   M S B A M L   `   `   `  ����W  SAgriProductsManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:AgriProductsManagementSystem.Views"AgriProductsManagementSystem.Views  5      3    -AgriProductsManagementSystem.Views.SignUpView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:AgriProductsManagementSystem.Views     5      $	��450��5   +   $	��800��6;   .��5	      �   � RowDefinitions  5
   
   �� 5      $��36.108 �6   �� 5      $��28 �6   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��17* �6   �� 5      $
��143* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   $��3��6   ��5      �� 5       �� Color$ #80B60E��6"   5      �� 5    
   $��0��6   $��0��6   $"��/Images/AgriProductsLogo.png��6-   $��2��6S   �� 5#   
   $��2��6   $
��Left=�6$   $	��Top=�6?   $��20(�6W   $
��Bold"�6e   $��Kanit)�6w   $	��301��6�   $��	200,2,0,0q�6�   $��36��6�   $��2��6�   $�� ��6�   �� 5&   
   $��1��6   $��0,35,1,2q�6%   $��2��67   ���#E5F3DE$��3��6`   .+�5'      �� $
��13px(�6   $��Kanit)�6(   $	��168��6;   $��44��6G   �� 6T   �� 6Z   �� 6f   $�Welcome To Agri-Products!��6j   6�   �� 5)      $
��13px(�6   $��Kanit)�6(   $	��385��6;   $��43��6G   �� 6T   �� 6Z   �� 6f   $�First Name:��6j   6�   �� 5,      -   5         ��Name$ FirstnameTextBox��5,      $��21��6X   $	��187��6d   
���   �$	��0.5q�6�   ��60   �� *	FirstName+ �� Mode$ TwoWay=�.��6�    J� Effect 5-      3  -System.Windows.Media.Effects.DropShadowEffect  5.         ShadowDepth$ 1Q�6'      	Direction$	 270Q�67      Color$ Black��6G   .��5/   "   50      �� 52      $
��13px(�6   $��Kanit)�6(   $	��385��6;   $��25��6G   $��
Last Name:��6S   �� 55      -   5        $ LastnameTextBox��55      $��21��6V   $	��187��6b   
���   �$	��0.5q�6�   ��6/   �� *
LastName+$ TwoWay=�.��6�    56        57      $ 1Q�6'   $	 270Q�67   $ Black��6G   .��58   "   59      �� 5;      $
��13px(�6   $��Kanit)�6(   $	��385��6;   $��25��6G   $��	Username:��6S   �� 5>      -   5        $ UsernameTextBox��5>      $��21��6V   $	��187��6b   
���   �$	��0.5q�6�   ��6/   �� *
Username+$ TwoWay=�.��6�    5?        5@      $ 1Q�6'   $	 270Q�67   $ Black��6G   .��5A   "   5B      �� 5D      $��	Password:��6   $
��13px(�6)   $��Kanit)�69   $	��385��6L   $��25��6X   �� 5E      -   5        $ PasswordTextBox��5E      $
��16pt��5G   
   $��140pt��6   
���   �$	��0.5q�6:   $��0,0,0,5q�6P   ��5F   
   �� *
Password+$ TwoWay=�.��5G   a    5H        5I      $ 1Q�6'   $	 270Q�67   $ Black��6G   .��5J   "   5K      �� 5O      $��Email:��6   $
��13px(�6&   $��Kanit)�67   $	��385��6J   $��20��6V   �� 5P      -   5        $ EmailTextBox��5P      $
��16pt��6P   $��140pt��6^   
���   �$	��0.5q�6�   $��0,0,0,5q�6�   ��6,   �� *Email+$ TwoWay=�.��6�    5Q        5R      $ 1Q�6'   $	 270Q�67   $ Black��6G   .��5S   "   5T      �� 5V      -   5        $��Sign Up��5V      $��23��6'   $	��187��63   $��298,25,298,0q�6?   ���#80B60E
�������$��Kanit)�6}   6�   �� 5W      	 �� TextAlignment$	 Center=�6   $��0,15,0,0q�6/   $��Kanit)�6A   $��30��6T   �� 5X   
   $�Already Signed Up? ��6    �� 5Y   
   -   5        
 �Name$
 	LoginLink��5Y      
���   �.�6P   .�5Z      �� $��Click Here to Login��6   ��5\      |� }� 5]   "    }� Location$ 	Underline=�61   5^      5`      5a      5b      5c      �� 5f   
   $��3��6   $��3��6"   $��Center=�66   $��Center=�6S   ���#6B6B6B#��Z��6�   .+�5g      �� $��Center=�6   $	 Center=�65   $��15(�6L   $��Kanit)�6Z   
�������$��0,0,0,0q�6�   $	��805��6�   $��36��6�   �� 5h      $�©��6    �� 5i      $4�. 2023-2024 Agri-Products. All Rights Reserved.��6   5j      5k      5l      5m      