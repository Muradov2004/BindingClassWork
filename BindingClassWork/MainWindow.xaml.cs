using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace BindingClassWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Stretch ImageStretch
        {
            get { return (Stretch)GetValue(ImageStretchProperty); }
            set { SetValue(ImageStretchProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ImageStretch.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageStretchProperty =
            DependencyProperty.Register("ImageStretch", typeof(Stretch), typeof(MainWindow));

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ImageStretch = Stretch.Fill;
        }

        private void chkBox_Clicked(object sender, RoutedEventArgs e)
        {
            if (chkBox.IsChecked == true)
            {
                ImageStretch = Stretch.Uniform;
                HeightSlider.SetBinding(Slider.ValueProperty, new Binding("Value") { ElementName = "WidthSlider", Mode = BindingMode.TwoWay });
            }
            else
            {
                ImageStretch = Stretch.Fill;
                HeightSlider.SetBinding(Slider.ValueProperty, new Binding("Value") { ElementName = "WidthSlider", Mode = BindingMode.OneTime });
            }
        }
    }
}
