   M S B A M L   `   `   `  ���� K  GFileExplorer_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FileExplorer_WPFFileExplorer_WPF  $    FileExplorer_WPF.Window_Delete   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:FileExplorer_WPF       � Title$/  )Window_Delete_数据无价，谨慎操作��$��Center=�$	��500��$	��210��$	��500��$	��230��$��Center=�.��� ���#F0F0F0.+��� -    ��Name$ btn_yes��$	��是��$
��Left=�$��310,140,0,0q�$	��Top=�   Btn_YesOrNo#��[  
����  ��� -   $ btn_no��$	��否��$
��Left=�$��399,140,0,0q�$	��Top=�$��75��#��[  �� -    ��Name$ textBlock_Info��$
��Left=�$��
170,48,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�$��80��$	��280�� �� 
LineHeight$ 10��$��13(��� -    ��Name$ 
image_icon��$
��Left=�$��80��$��80��$��	53,48,0,0q�$	��Top=��� -   $ textBlock_prompt��$
��Left=�$��	36,10,0,0q�$
��Wrap=�$-��'您是否将选中文件永久删除？��$	��Top=�$	��317��$��14(��� -   $ button��$��移入回收站��$
��Left=�$��222,140,0,0q�$	��Top=�#��[  