   M S B A M L   `   `   `  ���� K  GFileExplorer_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FileExplorer_WPFFileExplorer_WPF  '    !FileExplorer_WPF.Window_Attribute   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:FileExplorer_WPF       � Title$  Window_Attribute��$	��520��$	��400��.��� -   $��	Grid_main�� � RowDefinitions �� $��5* ��� $	��15* ��� $	��15* ��� $	��20* ��� $	��20* ��� $	��25* � � ColumnDefinitions �� $��3* ��� $	��25* ��� $	��69* ��� $��3* �.+��� $��0��$��0��$��6�����#F0F0F0�� $��0��$��3��$��6�����#F0F0F0�� $��0��$��1��$��2�����#F0F0F0�� -    ��Name$ 
image_icon��$��1��$��1��$
��Left=�$��5,2,0,0q�$��70��$	��top=�$��70���� -    ��Name$ txt_name��$��1��$��2��$��5,20,0,0q�$
��Left=�$
��Wrap=�$��	TextBlock��$	��Top=�$��2��$��34��$	��262���� $��2��$��2��.+��� -    ��Name$ lb_type��$��Label��$
��Left=�$	��Top=��� -   $ lb_file_system��$��Label��$
��Left=�$	��Top=��� $��3��$��2��.+��� -   $ lb_dir��$��Label��$
��Left=�$	��Top=��� -   $ lb_size��$��3��$��1��$��Label��$
��Left=�$	��Top=��� -   $ 
lb_include��$��Lable��$
��Left=�$	��Top=��� -	   $��StackPanel_time��$��4��$��2��.+��� -
   $ lb_create_time��$��Label��$
��Left=�$	��Top=��� -   $ lb_modify_time��$��Label��$
��Left=�$	��Top=��� -   $ lb_access_time��$��Label��$
��Left=�$	��Top=��� $��2��$��1��.+��� -   $ lb_type_title��$��文件类型：��$
��Left=�$	��Top=��� -   $ lb_file_system_title��$��文件系统：��$
��Left=�$	��Top=��� $��3��$��1��.+��� -   $ lb_dir_title��$��文件路径：��$
��Left=�$	��Top=��� -   $ lb_size_title��$��文件大小：��$
��Left=�$	��Top=��� -   $ lb_include_title��$��包含数量：��$
��Left=�$	��Top=��� -   $��StackPanel_time_title��$��4��$��1��.+��� -   $ lb_create_time_title��$��创建时间：��$
��Left=�$	��Top=��� -   $ lb_modify_time_title��$��修改时间：��$
��Left=�$	��Top=��� -   $ lb_access_time_title��$��访问时间：��$
��Left=�$	��Top=�� -   $��GridPie��$��5��$��2��$��120,0,0,0.4q�$
��Left=�