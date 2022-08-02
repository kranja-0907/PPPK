using System.Collections.Generic;
using Zadatak.Models;

namespace Zadatak.Dal
{
    public interface IRepository
    {
        void AddPerson(Person person);
        void DeletePerson(Person person);
        IList<Person> GetPeople();
        Person GetPerson(int idPerson);
        void UpdatePerson(Person person);



        void AddStudent(Student student);
        void DeleteStudent(Student student);
        IList<Student> GetStudents();
        Student GetStudent(int idStudent);
        void UpdateStudent(Student student);



        void AddSubjectt(Subject subject);
        void DeleteSubject(Subject subject);
        IList<Subject> GetSubjects();
        Subject GetSubject(int idSubject);
        void UpdateSubject(Subject subject);


    }
}