﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegexLaba.ViewModels;

namespace RegexLaba.Views
{
    public partial class RegexSetWindow : Window
    {
        public RegexSetWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("OK").Click += delegate
            {
                var context = this.Owner.DataContext as MainWindowViewModel;
                var inputField = this.FindControl<TextBox>("RegexInputField");
                try
                {
                    Regex rg = new Regex(inputField.Text);
                    context.Regex = inputField.Text;
                    this.CloseWindow();
                }
                catch (Exception ex)
                {
                    inputField.Text = "INVALID REGEX";
                }


            };
            this.FindControl<Button>("Close").Click += delegate
            {
                CloseWindow();
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void CloseWindow()
        {
            this.Close();
        }

    }
}