/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.viewmodel;

import hr.algebra.model.Subjectt;
import javafx.beans.property.IntegerProperty;
import javafx.beans.property.SimpleIntegerProperty;
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

/**
 *
 * @author Leon Kranjcevic
 */
public class SubjectViewModel {
    private final Subjectt subject;

    public SubjectViewModel(Subjectt subject) {
        if (subject == null) {
            subject = new Subjectt(0, "", 0);
        }
        this.subject = subject;
    }

    public Subjectt getSubject() {
        return subject;
    }
    
    public StringProperty getSubjectNameProperty() {
        return new SimpleStringProperty(subject.getSubjectName());
    }
    
    public IntegerProperty getIdProperty() {
        return new SimpleIntegerProperty(subject.getIDSubject());
    }
    
    public IntegerProperty getECTSProperty() {
        return new SimpleIntegerProperty(subject.getEcts());
    }

    @Override
    public String toString() {
        return subject.getSubjectName();
    }
    

}
