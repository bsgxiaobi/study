   M S B A M L   `   `   `  ����K  GFileExplorer_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FileExplorer_WPFFileExplorer_WPF  5   	   $    FileExplorer_WPF.Window_Rename   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:FileExplorer_WPF     5   	     � Title$  Window_Rename��5   	   $	��130��6   $	��410��6,   .��5	      � .+�5
   
   �� -   5         ��Name$ 
button_yes��5
      $��确 定��6%   $
��Left=�63   $��
350,43,0,0q�6N   $	��Top=�6b   $��45��6z   $��25��6�    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 3��65   �� 5       � �� �#66666664   5      5      5      �� 5   
   -   5         ��Name$ label��5      $-��'重命名，请勿包含以下符号：��6   $
��Left=�67   $��10,0,0,0q�6R   $	��Top=�6d   $	��158��6|   �� 5   
   -   5        $ label_symbol��5      $�� ��6&   $
��Left=�61   $��	168,0,0,0q�6L   $	��Top=�6_   $��99��6w   �� 5   
   -   5         ��Name$ textBox_name��5      $��2q�6(   $
��Left=�6<   $��23��6W    �� TextWrapping$
 Wrap=�6c   $��TextBox��6w   $	��Top=�6�   $	��330��6�   $��	10,43,0,0q�6�   5      5      