using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FirstMVVM.Annotations;
using FirstMVVM.Utilities;

namespace FirstMVVM.Models
{
    public class MyModel : BaseINPC
    {
        private string _text1;
        private string _text2;
        private string _text3;

        public string Text1
        {
            get => _text1;
            set
            {
                _text1 = value;
                OnPropertyChanged();
            }
        }
        public string Text2
        {
            get => _text2;
            set
            {
                _text2 = value;
                OnPropertyChanged();
            }
        }
        public string Text3
        {
            get => _text3;
            set
            {
                _text3 = value;
                OnPropertyChanged();
            }
        }

    }
}
