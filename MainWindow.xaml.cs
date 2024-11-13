using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace FlowDoc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Файлы разметки (*.xaml)|*.xaml"
            };
            if (dlg.ShowDialog() == true)
            {
                using (FileStream fs = File.Open(dlg.FileName, FileMode.Open))
                {
                    docViewer.Document = XamlReader.Load(fs) as FlowDocument;
                }
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog
            {
                Filter = "Файлы разметки (*.xaml)|*.xaml"
            };
            if (dlg.ShowDialog() == true)
            {
                using (FileStream fs = File.Open(dlg.FileName, FileMode.Create))
                {
                    XamlWriter.Save(docViewer.Document, fs);
                }
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            docViewer.ClearValue(FlowDocumentScrollViewer.DocumentProperty);
        }
    }
}