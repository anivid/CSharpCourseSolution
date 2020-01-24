﻿using System;
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

namespace ExampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.Title = "Hello To All";
            //this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void buttonMessageBox_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show(e.Handled.ToString());
        }

        private void GetInput_Click(object sender, RoutedEventArgs e)
        {
            string userInput = userInputField.Text;
            if (userInput != "") MessageBox.Show(userInput);
        }
    }
}