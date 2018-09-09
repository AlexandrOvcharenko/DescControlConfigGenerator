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

namespace ConfigGenerator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly XmlGeneratorService generator;

        public MainWindow(/*Generator generator*/)
        {
            InitializeComponent();
            ReaderService reader = new ReaderService();
            ParserService parser = new ParserService();
            generator = new XmlGeneratorService(reader, parser);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                generator.GenerateXmlDocument();
            }

            catch
            {
                //TODO: add logic for handling errors: Logger, etc.
            }
        }
    }
}

