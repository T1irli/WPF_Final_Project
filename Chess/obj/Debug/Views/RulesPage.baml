   M S B A M L   `   `   `  ����@  <Chess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Chess.ViewsChess.Views  5          Chess.Views.RulesPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Chess.Views     5      -   5          N�Name$  	rulesPage��5	       N� 
Background �#482121 � 	Resources 5
       �� 
TargetType �� Property �� Value 
  Header��%`  '��       &	  ?    �� 5   
   " ��6   .�5      ��  � ��
 �����6;   �� 5       � ��$ Italic$�6*   6;   �� 5       � ��$ 20(�6)   66   �� 5       � ��$ 10, 5q�6'   67   �� 5       � ��$ WrapWithOverflow=�6-   6H   �� 5       �@��TextAlignment$ Justify=�6.   6@   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6;   �� 5       � ��$ 34(�6)   66   �� 5       � ��$ 10, 10, 0, 12q�6'   6?   �� 5       � ��$ DemiBold"�6+   6>   �� 5       � ��$ WrapWithOverflow=�6-   6H   5      5      .��5      �� $��Disabled=�6   $
��Auto=�5      .��5   
   �� -   5        .+�5      � .+�5      �� -   5         ��Name$ 	backArrow��5    3   $��50��5      $��50��6$   $��10q�6/   $
��Fill=�6;   $
��Left=�6J   $��/Images/arrow.png��5        K� ZIndex$ 1��6F   6Y   �� 5!      -   5         ��Name$ rulesHeader��5"   /   $��1��5!      
��� ���$��42(�6>   	 �� TextAlignment$	 Center=�5"      RULES6K   5#      �� 5%      -   5        
 ��Name$
 pawnSP��5%   6   .+�5&      �� #��[  6   Pawn6B   �� 5'      ��Pawns move one square forward and cannot move back. A pawn may advance two squares on its first move. Pawns can only capture one square diagonally ahead.6�   5(      �� 5*      -   5        $
 rookSP��5*   6   .+�5+      �� #��[  6   Rook6B   �� 5,      53The rook can move forwards, backward, and sideways.6Q   5-      �� 5/      -   5        $
 bishopSP��5/   8   .+�50      �� #��[  6   Bishop6D   �� 51      ��The bishop can move diagonally like a queen, but not forward, backward, or sideways. Each side starts with two bishops, one on a light square and one on a dark square.6�   52      �� 54      -   5        $
 knightSP��54   8   .+�55      �� #��[  6   Knight6D   �� 56      ��The knight is the only chess piece that doesn't go in a straight line. The knight moves two squares in one direction and then turns and goes one square to the side.6�   57      �� 59      -	   5        $
 queenSP��59   7   .+�5:      �� #��[  6   Queen6C   �� 5;      ��The queen can move forwards, backward, sideways, and diagonally like a king. However, unlike the king, the queen can move as far as it wants to in each of these directions.6�   5<      �� 5>      -
   5        $
 kingSP��5>   6   .+�5?      �� #��[  6   King6B   �� 5@      ��Chess is won by checkmating - trapping - the opponent’s king. The king can move to any square that’s directly next to it: up, down, sideways, or diagonal.6�   5A      �� 5C      -   5        $
 
pawnPromSP��5C   <   .+�5D      �� #��[  6   Pawn Promotion6L   �� 5E      ��When a pawn reaches the end of the board it “promotes”, it turns into another piece. Most of the time players promote to a queen, but a rook, knight, or bishop is also possible.6�   5F      5G      5H      5J      