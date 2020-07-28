using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace FirstMVVM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string _text1;
        private string _text2;
        private string _text3;

        public string text1
        {
            get => _text1;
            set
            {
                _text1 = value;
                OnPropertyChanged();
            }
        }
        public string text2
        {
            get => _text2;
            set
            {
                _text2 = value;
                OnPropertyChanged();
            }
        }
        public string text3
        {
            get => _text3;
            set
            {
                _text3 = value;
                OnPropertyChanged();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.SaveData(text1, text2, text3);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            string[] lines = Model.LoadData();
            if (lines.Length > 1)
            {
                text1 = lines[0];
                text2 = lines[1];
                text3 = lines[2];
            }
        }
    }
}
