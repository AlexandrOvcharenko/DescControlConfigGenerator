using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ConfigGenerator.Services;
using ConfigGenerator.infra;
using Microsoft.Win32;

namespace ConfigGenerator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private XmlGeneratorService _generator { get; set; }
        private string _iniFileContent { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _generator = new XmlGeneratorService();
            generateButton.IsEnabled = false;
        }

        public void GenerateConfigFiles(object sender, RoutedEventArgs e)
        {
            try
            {
                _generator.GenerateXmlDocument(_iniFileContent);
            }
            catch (Exception ex)
            {
                //TODO: add logic for handling errors: Logger, etc.
            }
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ini files (*.ini)|*.ini";

            if (openFileDialog.ShowDialog() == true)
            {
                openFileTextBox.Text = openFileDialog.FileName;
                _iniFileContent = openFileTextBox.Text;
                generateButton.IsEnabled = true;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void openFileTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

