   M S B A M L   `   `   `  ����@  <Chess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Chess.ViewModelsChess.ViewModels  5   	       Chess.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Chess.ViewModels     5   	   -   5          � Title$  Chess��5   	   $	��650��6   $	��900��6$   $	��650��60   $	��900��6@    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   66   �� 5       � ��
 �����6;   �� 5       �@��TextAlignment$ Center=�6.   6?   �� 5       � ��$ Center=�62   6C   5      5       � DataContext 5      $   Chess.ViewModels.PageViewModel  5   
   6    .��5      � -   5         �Name$ mainGrid��5       ���#47A992 � ColumnDefinitions 5   
   �� 5      $��2* �6   6,   �� 5      6!   .+�5   
   � -   5        $ winnerPanel��5   #   $��0��5       J� Opacity$ 1Q�6   ���	#A0000000	 K� ZIndex$	 1��6B   $y�Hidden=�5      .+�5      �� $��100, 200q�6   
 �� CornerRadius$
 20��6'   ���#7A3E3E._�5      �  � RowDefinitions 5      �� 5       $��2* �6(   66   �� 5!      6*   .+�5#      �� -   5         ��Name$ winImg��5$      $��0��5#      $��/Images/king.png��6)   $��15q�5$   ,   6:   �� 5%      -   5         ��Name$ winText��5%   -   $��1��6    $��18(�6>   6N   5&      5'      5)      �� 5*   
   -   5         ��Name$ 
tempCanvas��5*   :   $��0��6   
������ 5,   0   � 5-   
   -   5        $ gameboardGrid��5.      $��0��5-      $��30q�6   ���#4821215/       � 51   
   -   5          �Name$ 	mainFrame��51       $��1��6     � NavigationUIVisibility$ Hidden=�63   ��52      �� *CurrentPage+62   � 54   
   -	   5         �Name$ choicePopup��54       � AllowsTransparency . $��
MousePoint=�56       � 	StaysOpen . .��58      �� $
 10��6   ���#482121$��10q�6<   ._�59      � -
   5        $	��250��59      .+�5:      �� $��50��6   $��50��6$   $��5q�6/   $��/Images/knight.png��5;      66   �� 5<      $��50��6   $��50��6$   $��5q�6/   $��/Images/tower.png��5=      65   �� 5>      $��50��6   $��50��6$   $��5q�6/   $��/Images/bishop.png��5?      66   �� 5@      $��50��6   $��50��6$   $��5q�6/   $��/Images/queen.png��5A      65   5B      5C      5E      5F      5G      