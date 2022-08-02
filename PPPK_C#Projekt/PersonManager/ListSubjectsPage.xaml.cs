using System.Windows;
using System.Windows.Controls;
using Zadatak.Models;
using Zadatak.ViewModels;

namespace Zadatak
{
    /// <summary>
    /// Interaction logic for ListSubjectsPage.xaml
    /// </summary>
    public partial class ListSubjectsPage : FramedPage
    {
        public ListSubjectsPage(SubjectViewModel subjectViewModel) : base(subjectViewModel)
        {
            InitializeComponent();
            LvSubjects.ItemsSource = subjectViewModel.Subjects;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new EditSubjectPage(SubjectViewModel) { Frame = Frame });

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvSubjects.SelectedItem != null)
            {
                Frame.Navigate(new EditSubjectPage(SubjectViewModel, LvSubjects.SelectedItem as Subject) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvSubjects.SelectedItem != null)
            {
                SubjectViewModel.Subjects.Remove(LvSubjects.SelectedItem as Subject);
            }
        }

        private void BtnListOfStudents_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ListStudentsPage(new StudentViewModel()) { Frame = Frame });
        }
    }
}
