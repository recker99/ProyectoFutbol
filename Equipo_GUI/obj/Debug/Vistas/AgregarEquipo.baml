   M S B A M L   `   `   `  ����E  AEquipo_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Equipo_GUI.VistasEquipo_GUI.Vistas  5   	   %    Equipo_GUI.Vistas.AgregarEquipo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Equipo_GUI.Vistas     5   	     � Title$  AgregarEquipo��5   	   $	��450��6   $	��800��6,   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��23* �6   �� 5      $
��377* �6   .+�5   
   �� -   5         ��Name$ lblAgregarEquipo��5      $��Formulario Agregar Equipo��6*   $
��Left=�6N   $��
203,81,0,0q�6i   $	��Top=�6}   $��16(�6�   $
��Bold"�6�   $��1��6�   �� 5   
   -   5        $ 	lblNombre��5      $��Nombre del Equipo :��6#   $
��Left=�6A   $��171,135,0,0q�6\   $	��Top=�6q   $	��138��6�   $��1��6�   �� 5   
   -   5        $ lblCantidad��5      $��Cantidad de Jugadores :��6%   $
��Left=�6G   $��171,163,0,0q�6b   $	��Top=�6w   $	��140��6�   $��1��6�   �� 5   
   -   5        $ lblNomDT��5      $��Nombre del DT :��6"   $
��Left=�6<   $��171,192,0,0q�6W   $	��Top=�6l   $��1��6�   �� 5   
   -   5        $ lblTipo��5      $��Tipo  Equipo :��6!   $
��Left=�6:   $��171,223,0,0q�6U   $	��Top=�6j   $��1��6�   �� 5   
   -   5        $ lblNomCapitan��5      $��Capitan del Equipo :��6'   $
��Left=�6F   $��171,257,0,0q�6a   $	��Top=�6v   $��1��6�   �� 5   
   -   5        $ lblTieneSub21��5      $��Tiene Sub 21 :��6'   $
��Left=�6@   $��171,288,0,0q�6[   $	��Top=�6p   $��1��6�   �� 5   
   -   5         ��Name$ 	txtNombre��5      $
��Left=�6%   $��311,139,0,0q�6@    �� TextWrapping$
 Wrap=�6U   $	��Top=�6i   $	��125��6�   $��1��6�    �� 	MaxLength$ 25��5   
   ��5   
   �� *Nombre+ �� ValidatesOnExceptions .  �� UpdateSourceTrigger$ PropertyChanged=�5   
   �� 5   
   -	   5        $ txtCantidad��5      $
��Left=�6'   $��311,167,0,0q�6B   $
 Wrap=�6W   $	��Top=�6k   $	��125��6�   $��1��6�   $ 25��5   
   ��5   
   �� *
Cantidad+ . $ PropertyChanged=�5   
   �� 5    
   -
   5        $ txtNomDT��5       $
��Left=�6$   $��311,196,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $	��125��6�   $��1��6�   $ 25��5"   
   ��5!   
   �� *NomDT+ . $ PropertyChanged=�5"   
   �� 5%   
   -   5         ��Name$ cmbTipoEquipo��5%      $
��Left=�6*   $��310,227,0,0q�6E   $	��Top=�6Z   $	��126��6r   $��1��6~   ��5&      �� *
TipoEquipo+	 �� SelectedItem	 66   �� *TipoEquipoSeleccionado+
 �� ValidatesOnDataErrors
 . $ PropertyChanged=�.@�5'      �� $��Seleccionar��6    �� 
IsSelected . {�.  6C   �� 5(      $��Femenino��6   �� 5)      -   5        $��	Masculino��5)      6/   5*      �� 5,   
   -   5        $ txtNomCapitan��5,      $
��Left=�6)   $��311,261,0,0q�6D   $
 Wrap=�6Y   $	��Top=�6m   $	��125��6�   $��1��6�   $ 25��5.      ��5-      �� *
NomCapitan+ . $ PropertyChanged=�5.      �� 51   
   -   5         ��Name$ chkTieneSub21��51      $��Tiene Sub21��6*   $
��Left=�6@   $��311,294,0,0q�6[   $	��Top=�6p   $��1��6�   �� 52   
   -   5         ��Name$ btnAgregarEquipo��52      $��1��6+   $��AGREGAR��6;   $
��Left=�6o   $��291,325,0,0q�6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.48,-0.749&�6�   {�6M   �� *IsFormValid+6�   53      54      