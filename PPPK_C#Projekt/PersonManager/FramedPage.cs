using System.Windows.Controls;
using Zadatak.ViewModels;

namespace Zadatak
{

    public class FramedPage : Page
    {
        public FramedPage(PersonViewModel personViewModel)
        {
            PersonViewModel = personViewModel;
        }
        public PersonViewModel PersonViewModel { get; }

        public FramedPage(StudentViewModel studentViewModel)
        {
            StudentViewModel = studentViewModel;
        }
        public StudentViewModel StudentViewModel { get; }

        public FramedPage(SubjectViewModel subjectViewModel)
        {
            SubjectViewModel = subjectViewModel;
        }
        public SubjectViewModel SubjectViewModel { get; }



        public Frame Frame { get; set; }
    }
}
