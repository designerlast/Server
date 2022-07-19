using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        StringAnimationUsingKeyFrames StringAnimationUsingKeyFrames = new StringAnimationUsingKeyFrames();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 6; i >=0; i--)
            {
                StringAnimationUsingKeyFrames.KeyFrames.
                    Add(new DiscreteStringKeyFrame
                    (
                     $"请{i}秒之后重新获取"
                    ,TimeSpan.FromSeconds(6-i)
                    ));
            }
            StringAnimationUsingKeyFrames.FillBehavior = FillBehavior.Stop;
            StringAnimationUsingKeyFrames.Completed += (s, e) =>
            {
                mybtn.IsEnabled = true;
                mybtn.Foreground = Brushes.Black;
            };
        }

        private void myslider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           // mytranform.Y =200- ( e.NewValue/100)*200;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mybtn.IsEnabled = false;
            mybtn.Foreground = Brushes.YellowGreen;
            mybtn.BeginAnimation(ContentProperty, StringAnimationUsingKeyFrames);
        }
    }
}
