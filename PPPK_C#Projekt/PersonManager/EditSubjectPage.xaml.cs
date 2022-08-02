using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Zadatak.Models;
using Zadatak.Utils;
using Zadatak.ViewModels;

namespace Zadatak
{
    /// <summary>
    /// Interaction logic for EditSubjectPage.xaml
    /// </summary>
    public partial class EditSubjectPage : FramedPage
    {
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
        private readonly Subject subject;
        public EditSubjectPage(SubjectViewModel subjectViewModel, Subject subject = null) : base(subjectViewModel)
        {
            InitializeComponent();
            this.subject = subject ?? new Subject();
            DataContext = subject;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                subject.SubjectName = TbName.Text.Trim();
                subject.ECTS = int.Parse(TbECTS.Text.Trim());
                //subject.Picture = ImageUtils.BitmapImageToByteArray(Picture.Source as BitmapImage);
                if (subject.IDSubject == 0)
                {
                    SubjectViewModel.Subjects.Add(subject);
                }
                else
                {
                    SubjectViewModel.Update(subject);
                }
                Frame.NavigationService.GoBack();
            }
        }

        private bool FormValid()
        {
            bool valid = true;
            GridContainter.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim())
                    || ("Int".Equals(e.Tag) && !int.TryParse(e.Text, out int age)))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });
            //if (Picture.Source == null)
            //{
            //    PictureBorder.BorderBrush = Brushes.LightCoral;
            //    valid = false;
            //}
            //else
            //{
            //    PictureBorder.BorderBrush = Brushes.WhiteSmoke;
            //}
            return valid;
        }

        //private void BtnUpload_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog()
        //    {
        //        Filter = Filter
        //    };
        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        Picture.Source = new BitmapImage(new Uri(openFileDialog.FileName));
        //    }
        //}



    }
}
