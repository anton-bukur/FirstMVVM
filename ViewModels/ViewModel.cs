using System;
using System.IO;
using System.Windows.Input;
using FirstMVVM.Models;
using FirstMVVM.Utilities;

namespace FirstMVVM
{
    public class ViewModel:BaseINPC
    {
        public ViewModel()
        {
            LoadData();
        }

        private MyModel _modelForFields;

        public MyModel ModelForFields
        {
            get => _modelForFields ?? (_modelForFields = new MyModel());
            set
            {
                _modelForFields = value;
                OnPropertyChanged();
            }
        }

        private ICommand _saveDataCommand;

        public ICommand SaveDataCommand => _saveDataCommand ?? (_saveDataCommand = new Command(a =>
          {
             
              string writePath = "data.txt";
              try
              {
                  File.WriteAllText(writePath, ModelForFields.Text1 + Environment.NewLine + ModelForFields.Text2 + Environment.NewLine + ModelForFields.Text3);
                  string text1 = "Successful";
              }
              //потом сделать -убить процесс, если файл занят
              catch (Exception e)
              {
                  string text1 = e.Message;
              }
          }));


        public  void LoadData()
        {
            string Path = "data.txt";
            string[] lines = null;
            if (File.Exists(Path))
            {
                lines = File.ReadAllLines(Path);
                if(lines.Length !=3)
                    return;
                ModelForFields.Text1 = lines[0];
                ModelForFields.Text2 = lines[1];
                ModelForFields.Text3 = lines[2];
            }
        }
    }
}
