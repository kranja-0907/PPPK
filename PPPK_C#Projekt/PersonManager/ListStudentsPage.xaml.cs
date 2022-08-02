using System.Windows;
using System.Windows.Controls;
using Zadatak.Models;
using Zadatak.ViewModels;

namespace Zadatak
{
    /// <summary>
    /// Interaction logic for ListStudentsPage.xaml
    /// </summary>
    public partial class ListStudentsPage : FramedPage
    {
        public ListStudentsPage(StudentViewModel studentViewModel) : base(studentViewModel)
        {
            InitializeComponent();
            LvStudents.ItemsSource = studentViewModel.Students;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new EditStudenttPage(StudentViewModel) { Frame = Frame });

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvStudents.SelectedItem != null)
            {
                Frame.Navigate(new EditStudenttPage(StudentViewModel, LvStudents.SelectedItem as Student) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvStudents.SelectedItem != null)
            {
                StudentViewModel.Students.Remove(LvStudents.SelectedItem as Student);
            }
        }

        private void BtnListOfSubjects_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ListSubjectsPage(new SubjectViewModel()) { Frame = Frame });
        }


    }
}
