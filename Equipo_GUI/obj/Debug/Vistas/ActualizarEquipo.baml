   M S B A M L   `   `   `  ����E  AEquipo_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Equipo_GUI.VistasEquipo_GUI.Vistas  5   	   (    "Equipo_GUI.Vistas.ActualizarEquipo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Equipo_GUI.Vistas     5   	     � Title$  ActualizarEquipo��5   	   $	��450��6"   $	��800��6/   .��5	      � .+�5
   
   �� -   5         ��Name$ lblAgregarEquipo��5
      $��Actualizar Equipo��6*   $
��Left=�6F   $��
249,81,0,0q�6a   $	��Top=�6u   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ 	txtNombre��5      $
��Left=�6%   $��357,139,0,0q�6@    �� TextWrapping$ NoWrap=�6U   $	��Top=�6k   $	��125��6�   �� 5   
   -   5        $ 	lblNombre��5      $��Nombre del Equipo :��6#   $
��Left=�6A   $��217,135,0,0q�6\   $	��Top=�6q   $	��138��6�   �� 5   
   -   5        $ txtCantidad��5      $
��Left=�6'   $��357,167,0,0q�6B   $ NoWrap=�6W   $	��Top=�6m   $	��125��6�   �� 5   
   -   5        $ lblCantidad��5      $��Cantidad de Jugadores :��6%   $
��Left=�6G   $��217,163,0,0q�6b   $	��Top=�6w   $	��140��6�   �� 5   
   -   5        $ lblNomDT��5      $��Nombre del DT :��6"   $
��Left=�6<   $��217,192,0,0q�6W   $	��Top=�6l   �� 5   
   -   5        $ txtNomDT��5      $
��Left=�6$   $��357,196,0,0q�6?   $ NoWrap=�6T   $	��Top=�6j   $	��125��6�   �� 5   
   -   5        $ lblTipo��5      $��Tipo  Equipo :��6!   $
��Left=�6:   $��217,223,0,0q�6U   $	��Top=�6j   �� 5   
   -	   5         ��Name$ cmbTipoEquipo��5      $
��Left=�6*   $��356,227,0,0q�6E   $	��Top=�6Z   $	��126��6r   .@�5      �� $��Seleccionar��6    �� 
IsSelected . {�.  6C   �� 5      $��Femenino��6   �� 5      $��	Masculino��6   �� 5      $��Infantil��6   �� 5      $
��Otro��6   5      �� 5   
   -
   5        $ txtNomCapitan��5      $
��Left=�6)   $��357,261,0,0q�6D   $ NoWrap=�6Y   $	��Top=�6o   $	��125��6�   �� 5   
   -   5        $ lblNomCapitan��5      $��Capitan del Equipo :��6'   $
��Left=�6F   $��217,257,0,0q�6a   $	��Top=�6v   �� 5   
   -   5        $ lblTieneSub21��5      $��Tiene Sub 21 :��6'   $
��Left=�6@   $��217,288,0,0q�6[   $	��Top=�6p   �� 5   
   -   5         ��Name$ chkTieneSub21��5      $��Tiene Sub21��6*   $��Center=�6@   $��	0,294,0,0q�6]   $	��Top=�6p   �� 5   
   -   5         ��Name$ btnActualizarEquipo��5      $��Actualizar Equipo��6.   $
��Left=�6l   $��337,325,0,0q�6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.48,-0.749&�6�   {�6J   �� *IsFormValid+6�   5      5      