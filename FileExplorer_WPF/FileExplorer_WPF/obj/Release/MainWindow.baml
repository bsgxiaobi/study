   M S B A M L   `   `   `  ���� K  GFileExplorer_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FileExplorer_WPFFileExplorer_WPF  !    FileExplorer_WPF.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:FileExplorer_WPF       � Title$  文件资源管理器_WPF��$	��720��$
��1200��$��Center=�$��Center=� � 	Resources ��%    .���  � RowDefinitions �� $	��18* ��� $��4* ��� $	��71* ��� $��5* � � ColumnDefinitions �� $	��20* ��� $	��80* �.+��� $��2���� -    ��Name$ 
tabControl��$��0��$��0��$��2��$
��Left=�$	��128��$	��Top=�$
��1194��$��
0,0,-0.4,0q�.@��� $��主 页��$��75��.��� ���	#FFE5E5E5�� $��查 看��$��75��.��� ���	#FFE5E5E5.+��� -    ��Name$ btn_datagrid_view��$��详细信息��$
��Left=�$	��Top=�$��	10,10,0,0q�$��60��$��37���� -   $ btn_listview_small��$��	小图标��$
��Left=�$��	75,10,0,0q�$	��Top=�$��60��$��37���� -   $ btn_listview_big��$��	大图标��$
��Left=�$��
140,10,0,0q�$	��Top=�$��60��$��37���� $��帮 助��$��75��.��� ���	#FFE5E5E5�� $��1��$��1�� �� Orientation$ 
Horizontal=�.+��� -   $ btn_last_path��$	��↑��$
��Left=�$	��Top=�$��15��$��23���� -    ��Name$ txt_Current_Path�� �� TextWrapping$ NoWrap=�	 �� AcceptsReturn	 . $��23��$	��680��$��10,0,0,0q�$��我的电脑��$	��Top=�$��Center=��� -   $ txt_Find��$
��Left=�$��23��$��5,0,0,0q�$
 Wrap=�$��搜索��$	��Top=�$	��210��$��Center=��� -   $ btn_Find_Files��$
��find��$
��Left=�$	��Top=�$��30��$��25��R� -	   
 R�Name$
 treeView_Dir��$��2��$��0��$
��Left=�$	��495��$��0,2,0,0q�$	��Top=�$	��238������  �� ItemsSource ��  �� Path$ Children�.R��� $ 
Horizontal=�$��20��.+��� $��Center=�$��16��$��16��$��0,0,5,0q����� *Icon+�� $��Center=����� *DisplayName+ � ToolTip �� $��Center=�$
��Wrap=�$	��200������ *Name+  �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%W   'Q�       �� " Q� P�  �@J�IsMouseOver . . ���  � �� �#CCE8FF� -
    �Name$ 	Grid_Info��$��2��$��1��.+�&   System.Windows.Controls.DataGrid  -     Name$ dataGrid_Info��$
��Left=�$	��Top=�   AutoGenerateColumns .  
�������   GridLinesVisibility$
 None=�
�������$	��492��$��5,1,0,0q�$	��944������    Columns 4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate �� .R��� $��3,0,3,0q�$��16��$��16������ *
IconPath+0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 名称��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 300    
Foreground
 �   �1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
FileName+  $ 日期�� . $	 150 
 ����� �� *
FileDate+  $ 类型�� . $	 100 
 ����� �� *
FileType+  $ 大小�� . $	 100 
 ����� �� *
FileSize+   RowStyle �� )  #System.Windows.Controls.DataGridRow"   P�  �@J�IsMouseOver . . ���  � �� �#FFF1FA    	CellStyle  �� *  $System.Windows.Controls.DataGridCell"   P�  �@ 
IsSelected . . ���  � �� �#CCE8FF��  � ��
 ���� P�  �@ 
IsSelected .  . ���  � ��
 ���� �� -   ! ��Name$! listView_Info��$��Disabled=�$
��Left=�$y�	Collapsed=�$	��490��$	��943��$��5,1,0,0q�$	��Top=����� ���� .R�� ���� .R�� " � Orientation$" Vertical=�$��3q�# � DataContext# �� .+��� $��	25,0,25,0q����� *
IconPath+���� *ImgHW+���� *ImgHW+�� $ �� TextAlignment$$ Center=�$	��100������ *
FileName+ �� $��Center=�$
��Wrap=�$	��200������ *
FileName+% � ContextMenu% �� -   $��dataGrid_Info_Menu��& �� 	StaysOpen& . .@�m� -   $��MenuItem_Open��$��打开��$
��Bold"�m� -   $��MenuItem_Refresh��$��刷新���� m� -   $��MenuItem_Uncheck��$��取消选中��m� -   $��MenuItem_MultiSelect��$��多选(按住Crtl键)��{�.  �� m� -   $��MenuItem_Copy��$��复制��m� -   $��MenuItem_Shear��$��剪切��m� -   $��MenuItem_Paste��$��粘贴���� m� -   $��MenuItem_Delete��$��删除��m� -   $��MenuItem_Rename��$��	重命名���� m� -   $��MenuItem_Attribute��$��属性���� -   $ textBox_test��$��3��$��2��$
��Left=�$��23��$
 Wrap=�$��选中行索引：��$	��Top=�$	��956��$��238,9.8,-0.4,0q�