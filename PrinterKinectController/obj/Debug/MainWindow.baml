   M S B A M L   `   `   `  ����M  IControlsBasics-WPF, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Microsoft.Samples.Kinect.ControlsBasics'Microsoft.Samples.Kinect.ControlsBasics  5   	   6    0Microsoft.Samples.Kinect.ControlsBasics.Keyboard   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   \ XMicrosoft.Kinect.Toolkit.Controls, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullS OMicrosoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=null2k(http://schemas.microsoft.com/kinect/2013   5   	   <d2http://schemas.microsoft.com/expression/blend/2008   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   Clocal5clr-namespace:Microsoft.Samples.Kinect.ControlsBasics   5   	   -   5        $��ControlsBasicsWindow��5   	     � Title$  Controls Basics��5	   	   $	��500��5   	   $	��700��5   	   $��Segoe UI)�5   	    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterScreen=�6>   $
��Auto��6c   $
��Auto��6p    � 	Resources 5         ChevronGeometry  	ChevronUp �� Stretch
 �� Top �� FallbackValue �� Path �� RelativeSource	 �� AncestorType?  9Microsoft.Samples.Kinect.ControlsBasics.KinectHoverButton
 J� RenderTransformOrigin �� Angle  ChevronRight  ChevronDown  ChevronLeft  KinectHoverButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value " KinectHoverButtonScrollUpStyle �� BasedOn % !KinectHoverButtonScrollRightStyle $  KinectHoverButtonScrollDownStyle $	  KinectHoverButtonScrollLeftStyle��%�  &	       &	 �    7   &	 Y   7   &	 .   7   &	    7   &	 �    &	 �    7  7  &	 ?    7  7  &	 �    7  7  &		 �    7  7  B�5   
   miF1M150.001,146.9932L126.565,169.3822L126.565,153.5962L150.001,130.6182L173.435,153.5962L173.435,169.3822z�5      F� 5   
   $��48��6!   $��48��6-   $ Uniform=�68   $ 0��6J   8��  ��5      �� $ Black��$ 
Foreground� �� "	  $
 0.5,0.5&�5   M   z�5      �� 5      $ 0Q�6"   5      F� 5    
   $��48��6$   $��48��60   $ Uniform=�6;   $ 0��6M   8��  ��5"      �� $ Black��$ 
Foreground� �� "	  $
 0.5,0.5&�5#   M   z�5$      �� 5%      $ 90Q�6"   5'      F� 5)   
   $��48��6#   $��48��6/   $ Uniform=�6:   $ 0��6L   8��  ��5+      �� $ Black��$ 
Foreground� �� "	  $
 0.5,0.5&�5,   M   z�5-      �� 5.      $	 180Q�6"   50      F� 52   
   $��48��6#   $��48��6/   $ Uniform=�6:   $ 0��6L   8��  ��54      �� $ Black��$ 
Foreground� �� "	  $
 0.5,0.5&�55   M   z�56      �� 57      $	 270Q�6"   59      �� 5;   
   "  6/   .�5<      ��  � ��
 �����6+   �� 5=       � ��
 �����6,   �� 5>       � ��$ 0q�60   6<   �� 5?       � ��
 �����6;   �� 5@       � �� 5A      �� 5B      "  6&   .R�5C      � $��Stretch=�6   $��Stretch=�6=   #��z��6Y   #��z��6�   #��z��6�   .+�5D      �� #��z��6%   #��z��6Y   ._�5E   "   �� $��Stretch=�63   $��Stretch=�6Q   #��z��6m   6�   5F      5G      5H      5J       5K      P� 5L       � {� .  . �5M      ��  � ��
 �����63   �� 5N       � ��
 �����64   �� 5O       � ��
 ���� 6I   5P      P� 5Q       �@ IsHandPointerOver . . �5R      ��  � �� �#5A5B5B63   �� 5S       � ��
 �����63   5T      5V      �� 5X   
   "  67   8   .�5Y      ��  � ��8  6(   5Z      �� 5\   
   "  6:   8   .�5]      ��  � ��8  6(   5^      �� 5`   
   "  69   8   .�5a      ��  � ��8  6(   5b      �� 5d   
   "  69   8   .�5e      ��  � ��8  6(   5f      5g      .��5i      �  � RowDefinitions 5j   
   �� 5k      $
��Auto �6   �� 5l      $��* �6   .+�5o   
   �� $��0,0,-258.4,-84q�6   $��2��6(   $��Apples-Aqua-Blue.jpg��69   $
��Fill=�6W   $
��Left=�6f   $
��1600��6�   � 5q   
   $��0��6   $��
10 0 10 20q�6   .+�5r      8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  $	��100��6b   $��Center=�6o   $	��Top=�6�   4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion   KinectRegion 6!   ��  �� ElementName$ kinectRegion��6�   4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  5s      -   5          Name$ sensorChooserUi��5s   [   $��Center=�6&   $	��Top=�6C   6[   �� 5t      -   5         ��Name$ lblPrint��5t      $��Please wait, printing...��6&   $��Center=�6I   $��59,61,75.6,-6q�6f   $��Center=�6}   $
��1187��6�   $��45��6�   $
��Bold"�6�   $��Berlin Sans FB)�6�   $��22(�6�   ���	#FFF5CDAB$��Center=�6  5u        5w   
   -   5          Name$ kinectRegion��5w   &   $��1��6   $��0,0,-258.4,0q�6<   .��5x      � -   5         �Name$ kinectRegionGrid��5x      $��10,20,10,20q�6-    5y      �� 5z      �� 5{      $	��224 �6$   .+�5}      :  4Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer  -   5          Name$ scrollViewer��5}   '   $��Disabled=�6=   $��175,10,341,0q�6d   $
��1064��6z   }�. $��Visible=�6�   $��Center=�6�   $	��370��6�   $	��Top=�6�   .��5~      � -   5         �Name$ 	wrapPanel��5~   ;   $��Center=�6     � Orientation$ Vertical=�6N   $	��362��6�   .+�5      � -   5        $ 
wrapPanel1��5   1   $	��321��6$   $	��963��6E   $��Bottom=�6Q   $��Center=�6l   .+�5�      8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  $	��100��61   $	��100��6=      Label$ 1��6J      LabelBackground 5�   "   �� 5�   &     �� ImageSource$7  1/ControlsBasics-WPF;component/Images/IMAG0809.jpg��61   ! j� Stretch$! UniformToFill=�6q   " j� TileMode$
" None=�6�   5�        5�      $	��100��61   $	��100��6=   $ 2��6J     5�      $	��100��61   $	��100��6=   $ 3��6J     5�      $	��100��61   $	��100��6=   $ 4��6J     5�      $	��100��61   $	��100��6=   $ 5��6J   5�      5�      5�      � 5�      $��Stretch=�6   $��Stretch=�65   $��0,1,0,10q�6Q   $��1��6c   # � ColumnDefinitions# 5�      �� 5�      $��* �6+   �� 5�      $��10 �6+   �� 5�      $��* �6+   5�      � 5�      -	   5        $ wrapPanelNew��5�   7   $��Center=�6   $ 
Horizontal=�6M   $	��189��6�   $��175,19,0,16q�6�   $��LeftToRight=�6�   $
��Left=�6�   $
��1236��6�   $��1��6�   .+�5�        -
   5        $  Name$$ kinectTileButton1��5�   6   $	��119��6)   $��Keyboard��6Q   $	��612��6d   % J� Opacity$	% 0.7Q�6p   $��40(�6~   $��Berlin Sans FB Demi)�6�   
����������	#FFD8E0F9���	#FF515B7C& J� Effect& 5�      -  'System.Windows.Media.Effects.BlurEffect  5�      '   Radius$' 3Q�6)   5�        5�      -   5        $$ kinectTileButton2��5�   6   $	��119��6)   $��Give My Shirt Back !��6Q   $	��612��6p   $	% 0.7Q�6|   $��40(�6�   $��Berlin Sans FB Demi)�6�   
����������	#FFD8E0F9���	#FF515B7C& 5�        5�      $' 3Q�6)   5�      5�      5�      5�      G� 5�   
   -   5        ( G�Name$( passwordBox1��5�   `   $��1��6   $��23��6#   $
��Left=�6/   $��1726,291,0,0q�6J   $	��Top=�6v   $	��120��6�   �� 5�   
   -   5        ) ��Name$) resetShirtCarrier��5�      $��Reset Shirt Carrier��6,   $
��Left=�6J   $��
882,10,0,0q�6e   $	��Top=�6y   $	��150��6�   $��26��6�   
����������	#FFCBCBCB$��Berlin Sans FB)�6  $
��Bold"�6+  ��6�   Z� 6+  �� 5�   
   -   5        $) resetShirtCarrier_Copy��5�      $��Step Back Nozzle Carrier��61   $
��Left=�6T   $��1088,10,0,0q�6o   $	��Top=�6�   $	��150��6�   $��26��6�   
����������	#FFCBCBCB$��Berlin Sans FB)�6  $
��Bold"�6:  ��6�   Z� 6:  �� 5�   
   -   5        $) resetShirtCarrier_Copy1��5�      $��Reset Nozzle Carrier��62   $
��Left=�6Q   $��1296,10,-104.4,0q�6l   $	��Top=�6�   $	��150��6�   $��26��6�   
����������	#FFCBCBCB$��Berlin Sans FB)�6  $
��Bold"�69  ��6�   Z� 69  5�      5�      