using LottieSharp;

using Prism.Commands;
using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Documents;

namespace WPF_LottieAnimation_Demo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public List<string> LottieFileList = new List<string>();


        private string _CurrentFile;
        /// <summary>
        /// 当前动画文件
        /// </summary>
        public string CurrentFile
        {
            get { return _CurrentFile; }
            set { _CurrentFile = value; RaisePropertyChanged(); }
        }

        public DelegateCommand<object> NextCommand { get; set; }

        public MainWindowViewModel()
        {
            foreach (var item in Directory.EnumerateFiles(@".\Resource"))
            {
                LottieFileList.Add(item);
            }

            NextCommand = new DelegateCommand<object>((obj) =>
            {
                CurrentFile = LottieFileList[new Random().Next(LottieFileList.Count)];
                (obj as LottieAnimationView).PlayAnimation();
            });
        }
    }
}
