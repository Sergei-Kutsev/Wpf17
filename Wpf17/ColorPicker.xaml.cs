using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf17
{
    /// <summary>
    /// Логика взаимодействия для ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
       

        public static readonly DependencyProperty ColorProperty;
        public static readonly DependencyProperty RedProperty;
        public static readonly DependencyProperty GreenProperty;
        public static readonly DependencyProperty BlueProperty;

        static ColorPicker()
        {
            ColorProperty = DependencyProperty.Register(
          nameof(Color),
          typeof(Color),
          typeof(ColorPicker),
          new FrameworkPropertyMetadata(
              Colors.Black,
               new PropertyChangedCallback(OnColorChanged)));

            RedProperty = DependencyProperty.Register(
                nameof(Red),
                    typeof(byte),
                    typeof(ColorPicker),
                    new FrameworkPropertyMetadata(
                        new PropertyChangedCallback(OnColorRGBChanged)));

            GreenProperty = DependencyProperty.Register(
                nameof(Green),
                typeof(byte),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnColorRGBChanged)));

            BlueProperty = DependencyProperty.Register(
                nameof(Blue),
                typeof(byte),
                typeof(ColorPicker),
                 new FrameworkPropertyMetadata(
                     new PropertyChangedCallback(OnColorRGBChanged)));
        }

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public byte Red
        {
            get => (byte)GetValue(RedProperty);
            set => SetValue(RedProperty, value);
        }

        public byte Green
        {
            get => (byte)GetValue(GreenProperty);
            set => SetValue(GreenProperty, value);
        }

        public byte Blue
        {
            get => (byte)GetValue(BlueProperty);
            set => SetValue(BlueProperty, value);
        }


        private static void OnColorRGBChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            Color color = colorPicker.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            colorPicker.Color = color;
        }

        private static void OnColorChanged(DependencyObject sender,
      DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            ColorPicker colorpicker = (ColorPicker)sender;
            colorpicker.Red = newColor.R;
            colorpicker.Green = newColor.G;
            colorpicker.Blue = newColor.B;
        }

        public static readonly RoutedEvent ColorChangedEvent =
            EventManager.RegisterRoutedEvent(
            nameof(ColorChanged),
            RoutingStrategy.Bubble,
    typeof(RoutedPropertyChangedEventHandler<Color>),
    typeof(ColorPicker));

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }
         public ColorPicker()
        {
            InitializeComponent();
        }
    }
}