   M S B A M L   `   `   `  ����K  GFileExplorer_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FileExplorer_WPFFileExplorer_WPF  5   	   $    FileExplorer_WPF.Window_Delete   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:FileExplorer_WPF     5   	     � Title$/  )Window_Delete_数据无价，谨慎操作��5   	   $��Center=�6)   $	��500��6F   $	��210��6R   $	��500��6_   $	��230��6n   $��Center=�6~   .��5	      � ���#F0F0F0.+�5
   
   �� -   5         ��Name$ btn_yes��5
      $	��是��6"   $
��Left=�6.   $��310,140,0,0q�6I   $	��Top=�6^      Btn_YesOrNo#��[  6v   
����  �6�   �� 5   
   -   5        $ btn_no��5      $	��否��6!   $
��Left=�6-   $��399,140,0,0q�6H   $	��Top=�6]   $��75��6u   #��[  6�   6�   �� 5   
   -   5         ��Name$ textBlock_Info��5      $
��Left=�6,   $��
170,48,0,0q�6G   $
��Wrap=�6[   $��	TextBlock��6o   $	��Top=�6�   $��80��6�   $	��280��6�    �� 
LineHeight$ 10��6�   $��13(�6�   �� 5   
   -   5         ��Name$ 
image_icon��5      $
��Left=�6$   $��80��6?   $��80��6K   $��	53,48,0,0q�6V   $	��Top=�6i   �� 5   
   -   5        $ textBlock_prompt��5      $
��Left=�6.   $��	36,10,0,0q�6I   $
��Wrap=�6\   $-��'您是否将选中文件永久删除？��6p   $	��Top=�6�   $	��317��6�   $��14(�6�   �� 5   
   -   5        $ button��5      $��移入回收站��6!   $
��Left=�61   $��222,140,0,0q�6L   $	��Top=�6a   #��[  6z   5      5      