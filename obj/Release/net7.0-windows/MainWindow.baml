   M S B A M L   `   `   `  ����   BudgetSimulator     BudgetSimulator.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Icon$  assets/icon.png�� � Title$ Simulateur de Budget��$	��500��$
��1049�����#f4f4f4 � WindowStartupLocation$ CenterScreen=�.��]� $��20q�.+��� $��Bottom=� �� Orientation$ 
Horizontal=�$
��Left=�$��0,20,0,0q�.+��� -   $��Exporter Excel��$	��130��$��5q�$��5q����#388E3C
�������$
��Bold"��� $��Bottom=�$ 
Horizontal=�$
��Left=�$��0,20,0,0q�.+��� $��18(�
��� d �$��SemiBold"�
��� $�Solde : �� �� $
��Bold"���� *Solde+ �� Mode$ OneWay=� �� $
� €���� $	��Top=�$ 
Horizontal=�$
��Left=�$��0,0,0,20q�.+�(  "System.Windows.Controls.DatePicker  $	��130��$��5q�   SelectedDate �� *NouvelleDate+ �� UpdateSourceTrigger$ PropertyChanged=��� $	��150��$��5q�$��5q� � ToolTip$ Description������ *NouvelleDescription+$ PropertyChanged=��� $	��150��$��5q� �� StaysOpenOnEdit$
 True��	 �� 
IsEditable$
	 True������ *
Categories+
 �� Text
 �� *SelectedCategory+$ TwoWay=�$ PropertyChanged=��� $��80��$��5q�$��5q�$ Montant������ *NouveauMontant+$ PropertyChanged=��� $	��120��$��5q� �� SelectedValuePath$ Content�� �� SelectedValue �� *NouveauType+.@��� $��Revenu���� $��Depense���� -   $��Ajouter��$	��100��$��5q�$��5q����#0078D7
�������$
��Bold"��� -   $��	Supprimer��$	��100��$��5q�$��5q����#D32F2F
�������$
��Bold"��� -   $��Modifier��$��80��$��5q�&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��   AutoGenerateColumns$ False��   	RowHeight$ 30Q�   CanUserAddRows$ False��$��0,10,0,0q�$��14(�$��Normal"�   HeadersVisibility$ Column=�   GridLinesVisibility$ 
Horizontal=�$��Stretch=�
����������#ccc$��1q����� *Transactions+ �� SelectedItem �� *SelectedTransaction+$ TwoWay=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Date+ �� StringFormat$ {0:dd/MM/yyyy}��  $ Description��$ *  �� *Description+  $ 
Catégorie��$ *  �� *	Categorie+  $ Montant��$ *  �� *	Montant+  $
 Type��$ *  �� *Type+