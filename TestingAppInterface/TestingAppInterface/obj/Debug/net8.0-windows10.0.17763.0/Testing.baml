   M S B A M L   `   `   `  ����N  JTestingAppInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TestingAppInterfaceTestingAppInterface  5   	   !    TestingAppInterface.Testing   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:TestingAppInterface     5   	     � Title$  Тестирование��5   	   $	��500��6   $	��800��6+   
 J� Uid$
 win1��67    � 	Resources 5	       �� Source�� 5
   
   $ StyleResources.xaml?�6   %    .��5      (�  (� Stretch$ Uniform=�6   .��5   
   �� 
�������$	��500��6$   $	��800��61   .+�5      �� $��/3.png��6   $
��Left=�6$   $��Center=�6?   $	��500��6Z   $
��1000��6g    J� RenderTransformOrigin$ 0.5,0.5&�6t   $��2��6�   $��2��6�    �� Left$	 -27��6�   �� 5      -   5         ��Name$ ExerciseTestTextBlock��5      $�� ��67      ExerciseTextBlockStyle#��[  6?   $ 76��5      
 �� Top$ 40��6%   	 �� Right$		 104��65   
 �� Bottom$	
 178��6H   $	��210��6\   $	��648��6i   �� 5      -   5         ��Name$ YourAnswerTestTextBox��5      $�� ��65     AnswerTextBoxStyle#��[ 6=   $ 76��5      $	 277��6#   $		 406��64   $	
 116��6G   $��38��6[   $	��324��6g   6s   �� 5      -   5         ��Name$ NextTaskTest��5   1   $'��!Следующее задание��6     NextButtonStyle#��[ 6G   $	 308��5      $	 405��6#   64   �� 5      -   5        $ LastTaskTest��5   2   $)��#Предыдущее задание��6     PreviousButtonStyle#��[ 6H   $ 12��5       $	 407��6"   63   �� 5#      -   5        $ 
FinishTest��5#   .   $!��Завершить тест��6     FinishButtonStyle#��[ 6B   $	 596��5$      $	 407��6#   64   �� 5'      -   5        $ TaskCounterTextBlock��5'      $
��1/20��66     TaskCounterTextBlockStyle#��[ 6B   $	 729��5(      $ 13��6&   $��39��66   $��70��6B   5*      5+      5,      