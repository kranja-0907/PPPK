/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.viewmodel;

import hr.algebra.model.Student;
import javafx.beans.property.IntegerProperty;
import javafx.beans.property.ObjectProperty;
import javafx.beans.property.SimpleIntegerProperty;
import javafx.beans.property.SimpleObjectProperty;
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

/**
 *
 * @author Leon Kranjcevic
 */
public class StudentViewModel {
    private final Student student;

    public StudentViewModel(Student student) {
        if (student == null) {
            student = new Student(0, "", "", 0, "", "", null);
        }
        this.student = student;
    }

    public Student getStudent() {
        return student;
    }
    
    public StringProperty getFirstNameProperty() {
        return new SimpleStringProperty(student.getFirstName());
    }
    
    public StringProperty getLastNameProperty() {
        return new SimpleStringProperty(student.getLastName());
    }
    
    public StringProperty getEmailProperty() {
        return new SimpleStringProperty(student.getEmail());
    }
    
    public StringProperty getStudentSubjectNameProperty() {
        return new SimpleStringProperty(student.getStudentSubjectName());
    }
    
    public IntegerProperty getIdProperty() {
        return new SimpleIntegerProperty(student.getIDStudent());
    }
    
    public IntegerProperty getAgeProperty() {
        return new SimpleIntegerProperty(student.getAge());
    }
    
    public ObjectProperty getSubjectIDProperty() {
        return new SimpleObjectProperty(student.getSubjectID());
    }
    
    public ObjectProperty<byte[]> getPictureProperty() {
        return new SimpleObjectProperty<>(student.getPicture());
    }
    
    public SubjectViewModel getSubjectViewModel() {
        return new SubjectViewModel(student.getSubjectID());
    }
}
