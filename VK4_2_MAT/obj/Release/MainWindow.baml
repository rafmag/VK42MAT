   M S B A M L   `   `   `  ���� D  @VK4_2_MAT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:VK4_2_MAT	VK4_2_MAT  %clr-namespace:VK4_2_MAT	VK4_2_MAT      VK4_2_MAT.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'srcclr-namespace:VK4_2_MAT     )localclr-namespace:VK4_2_MAT       � Title$!  VK4 2 Matlab Batch Exporter��$	��440��$	��680�����	#FF343434 � Icon$ 	Icon1.ico�� � 
ResizeMode$ CanMinimize=� � WindowStyle$ 
ToolWindow=�.��� -    �Name$ mainGRID�� � RowDefinitions �� $
��366* ��� $	��43* � � ColumnDefinitions �� $
��155* ��� $
��181* �.+��� -    ��Name$ lstFileList�� �� SelectionMode$ Extended=�$��5q�$��0��]� ��.  $��1��.+��� -   	 ��Name$	 btnAdd��$	��Add�����	#FF13587A$��13.333(�$
��Bold"����	#FFD1D1D1���	#FF3E3E3E$
��Left=�$	��130��$��5q��� -   $	 	btnRemove��$��Remove�����	#FF13587A$��13.333(�$
��Bold"����	#FFD1D1D1���	#FF3E3E3E$��Right=�$	��130��$��5q�]� $��1����.  .+��� -   
 ��Name$
 groupBox��$��Export Options��$
��Bold"�$��Italic$����	#FFD1D1D1$	��Top=�$	��122��$��5q�.���  �� $
��149* ��� $
��190* �.+�]� $��0����.  .+��� -    ��Name$ chkColor_Light��$��Full Color Light�����	#FFD1D1D1$	��Top=�$��5q��� -   $ chkColor_Peak��$��Full Color Peak�����	#FFD1D1D1$	��Top=�$��5q��� -   $ 	chkHeight��$��Height Data�����	#FFD1D1D1$	��Top=�$��5q��� -	   $ chkLaser��$��
Laser Data�����	#FFD1D1D1$	��Top=�$��5q�]� $��1����.  .+��� -
   $ chkMeas_Cond��$��Measurement Conditions�����	#FFD1D1D1$	��Top=�$��5q��� -   $ 
chkInc_pal��$!��Include Palette Information�����	#FFD1D1D1$	��Top=�$��5q��� -   $ 
chkAddTime��$��Add Time Stamp�����	#FFD1D1D1$	��Top=�$��5q��� -   $ chkSaveToNewLoc��$��Save to New Location�����	#FFD1D1D1$	��Top=�$��5q��� -    ��Name$ label��$��Save to location:��$��Italic$�$
��Bold"����	#FFD1D1D1$	��Top=�$��5,0,5,5q�]� $��23����. $	��Top=�.+��� -    ��Name$ fileTxt��$
��Left=�$	��288��$	��5,0q�{��� *	IsChecked+ �� ElementName$ chkSaveToNewLoc���� -   $	 	btnBrowse��$��Browse�����	#FF13587A$��13.333(�$
��Bold"����	#FFD1D1D1���	#FF3E3E3E$��Right=�$��0,0,5,0q�{��� *	IsChecked+$ chkSaveToNewLoc��� -    �Name$
 Pbar�� � Value$ 0Q�$	��Top=�$��24��$��5,5,5,0q��� -    ��Name$ imgPrev1��$��dis.png��$��
10,10,5,10q�$	��165��$
��Left=��� -   $ imgPrev2��$��dis.png��$��
5,10,10,10q�$��Right=�$	��165��]� $��1��$��1����.  .+��� -   $ chkprev��$��Preview�����	#FFD1D1D1$
��Left=�$��75��$��Center=�$
��5,14q�$��Center=��� -   $	 	btnExport��$��Export!��$
��Bold"�$��14.667(����	#FF197050���	#FFD1D1D1���	#FF3E3E3E{�.  $��Right=�$	��271��$��5q�