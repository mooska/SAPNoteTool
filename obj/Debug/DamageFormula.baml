   M S B A M L   `   `   `  ����P  LWasserstrom Note Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Wasserstrom_Note_ToolWasserstrom_Note_Tool  5      )    #Wasserstrom_Note_Tool.DamageFormula   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Wasserstrom_Note_Tool     5        N� Title$  DamageFormula��5	      $	��326��6   $	��517��6*    N� 
Background �	#FFE5EAED.��5      � .+�5   
   �� -   5         ��Name$ Label��5      $��Damage Formula��6   $	��Top=�68   $��122,10,123,0q�6P   $��32(�6f   $
��Bold"�6t   $��Arial)�6�   �� 5   
   -   5        $ label��5      $��
Case Price��6   $
��Left=�64   $��
142,78,0,0q�6O   $	��Top=�6c   $��18.667(�6{   �� 5   
   -   5        $ 
label_Copy��5      $��Pieces Per Case��6$   $
��Left=�6>   $��
99,118,0,0q�6Y   $	��Top=�6m   $��18.667(�6�   �� 5   
   -   5        $ label_Copy1��5      $��Number of Cases��6%   $
��Left=�6?   $��
85,158,0,0q�6Z   $	��Top=�6n   $��18.667(�6�   �� 5   
   -   5        $ label_Copy2��5      $��Total Broken��6%   $
��Left=�6<   $��122,198,0,0q�6W   $	��Top=�6l   $��18.667(�6�   �� 5   
   -   5        $ label_Copy3��5      $��$��6%   $
��Left=�61   $��
264,78,0,0q�6L   $	��Top=�6`   $��18.667(�6x   �� 5   
   -   5         ��Name$ CasePriceTextBox��5      $
��Left=�6P   $��32��6k   $��
286,80,0,0q�6w    �� TextAlignment$ Right=�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��18.667(�6�    J� RenderTransformOrigin$ 0.315,-3.361&�6�   �� 5   
   -   5        $ CasePiecesTextBox��5      $
��Left=�6-   $��32��6H   $��286,120,0,0q�6T   $ Right=�6i   $
 Wrap=�6   $	��Top=�6�   $	��120��6�   $��18.667(�6�   $ 0.315,-3.361&�6�   6�   �� 5   
   -	   5        $ CasesTextBox��5      $
��Left=�6(   $��32��6C   $��286,160,0,0q�6O   $ Right=�6d   $
 Wrap=�6z   $	��Top=�6�   $	��120��6�   $��18.667(�6�   $ 0.315,-3.361&�6�   6�   �� 5   
   -
   5        $ BrokenPiecesTextBox��5      $
��Left=�6/   $��32��6J   $��286,200,0,0q�6V   $ Right=�6k   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��18.667(�6�   $ 0.315,-3.361&�6�   �� 5   
   -   5         ��Name$ SubmitButton��5      $��Submit��6'   $
��Left=�68   $��
10,254,0,0q�6S   $	��Top=�6g   $��75��6   $��62��6�   $��8��6�   ���	#FFDD7621
�������$��SemiBold"�6�   
���   �6�   �� 5   
   -   5        $ 
CopyButton��5      $
��Copy��6%   $
��Left=�64   $��
90,254,0,0q�6O   $	��Top=�6c   $��75��6{   $��28��6�   $��9��6�   {�.  ���	#FFDD7621
�������$��SemiBold"�6�   
���   �6  �� 5   
   -   5        $ ResetButton��5      $��Reset��6&   $
��Left=�66   $��
90,288,0,0q�6Q   $	��Top=�6e   $��75��6}   $ 1.295,1.736&�6�   $��28��6�   $��10��6�   {�.  ���	#FFDD7621
�������$��SemiBold"�6  
���   �6,  �� 5   
   -   5        $  DamageFormulaOutputTextBox��5      $
��Left=�66   $��62��6Q   $��170,254,0,0q�6]   $
 Wrap=�6r   $��
��6�   $	��Top=�6�   $	��337��6�   $��10(�6�   $��11��6�   {�.  6�   5      5      