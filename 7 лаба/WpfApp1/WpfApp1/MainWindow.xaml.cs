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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        Window2ViewModel _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = new Window2ViewModel();
            this.DataContext = _vm;
        }
    }

    class Window2ViewModel : DependencyObject
    {
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static DependencyProperty NameProperty = DependencyProperty.Register(
            "Name",
            typeof(string),
            typeof(Window2ViewModel),
            null,
            new ValidateValueCallback(isNameValid));

        static Window2ViewModel()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);
        }

        private static object CorrectValue(DependencyObject d, object value)
        {
            string val = (string)value;

            if (!string.IsNullOrEmpty(val) &&
                System.Text.RegularExpressions.Regex.IsMatch(val, "[/!@#?/}[}{]"))
            {
                val = "gg";
                return val;
            }
            return value;
        }
        private static bool isNameValid(object value)
        {
            bool ret = true;
            string val = (string)value;

            if (!string.IsNullOrEmpty(val) &&
                System.Text.RegularExpressions.Regex.IsMatch(val, "[/!@#?/}[}{]"))
                ret = false;
            else
                ret = true;

            return ret;
        }

    }

}
