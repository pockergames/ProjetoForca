   M S B A M L   `   `   `  ����C  ?ForcaWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ForcaWPFForcaWPF  5   	       ForcaWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ForcaWPF     5   	     � Title$  
MainWindow��5   	   $��673.517��6   $��1090.775��6-   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��124* �6   �� 5      $
��147* �6   .+�5   
   o� -   5         o�Name$
 menu��5      $
��Left=�6   $	��643��68   $	��Top=�6E   $	��221��6]   �� 5   
   -   5         ��Name$ txt_nome��5      $
��Left=�6$   $��22��6?   $��	45,38,0,0q�6K    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��120��6�    �� TextAlignment$ Center=�6�   6�   �� 5   
   -   5         ��Name$ btn_addJogador��5      $��Adicionar Jogador��6)   $
��Left=�6E   $��	45,91,0,0q�6`   $	��Top=�6s   $	��120��6�   $��37��6�   6�   �� 5   
   -   5        $ btn_novaPartida��5      $��Nova Partida��6*   $
��Left=�6A   $��
45,194,0,0q�6\   $	��Top=�6p   $	��120��6�   $��38��6�   6�   �� 5   
   $��Nome do Jogador
��6   $
��Left=�64   $��	52,10,0,0q�6O   $	��Top=�6b   $��28��6z   �� 5   
   -   5         ��Name$ scroll_pontuacao��5      $
��Left=�61   $	��233��6L   $��
10,353,0,0q�6Y   $	��Top=�6m   $	��201��6�   #��� ��6�   �� 5   
   -   5         ��Name$ lbl_tema��5      $�� ��6"   $��Center=�6-   $��404,38,125,0q�6J   $	��Top=�6`   $��36(�6x   $	��554��6�   $��2��6�   �� 5   
   ���	#FFF0F0F0$
��Left=�6%   $	��180��6@   $��221,463,0,0q�6M   $	��Top=�6b   $	��862��6z   $��2��6�   �� 5   
   -   5        $ 	txt_chute��5      $
��Left=�6%   $��25��6@   $��404,497,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��433��6�   $��2��6�   6�   �� 5   
   -   5        $ lbl_escrevaSeuChuteAqui��5      $��Escreva seu chute aqui:��61   $
��Left=�6S   $��38��6n   $��226,492,0,0q�6z   $	��Top=�6�   $��16(�6�   �� 5   
   -	   5        $ 	btn_chute��5      $��Chuta!��6$   $��1��65   $
��Left=�6E   $��356,497,0,0q�6`   $	��Top=�6u   $	��106��6�   $��25��6�   6�   �� 5   
   -
   5        $ lbl_jogadorAtual��5      $�� ��6*   $
��Left=�65   $��
10,322,0,0q�6P   $	��Top=�6d   $	��182��6|   $
��Bold"�6�   �� 5   
   -   5        	 ��Name$	 txt_palavra��5      $
��Left=�6)   $��282,194,0,0q�6D   $
��Wrap=�6Y   $��O jogo já vai começar!��6m   $	��Top=�6�   $��72(�6�   $��2��6�   $	��728��6�   
 �� TextAlignment$
 Center=�6�   �� 5   
   -   5        $ btn_sair��5      $
��Sair��6#   $
��Left=�62   $��20��6M   $��
59,606,0,0q�6Y   $	��Top=�6m   $��76��6�   6�   5      5      