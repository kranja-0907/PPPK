/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.model;

import java.io.Serializable;
import java.util.Collection;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author Leon Kranjcevic
 */
@Entity
@Table(name = "Subjectt")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Subjectt.findAll", query = "SELECT s FROM Subjectt s")
    , @NamedQuery(name = "Subjectt.findByIDSubject", query = "SELECT s FROM Subjectt s WHERE s.iDSubject = :iDSubject")
    , @NamedQuery(name = "Subjectt.findBySubjectName", query = "SELECT s FROM Subjectt s WHERE s.subjectName = :subjectName")
    , @NamedQuery(name = "Subjectt.findByEcts", query = "SELECT s FROM Subjectt s WHERE s.ects = :ects")})
public class Subjectt implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "IDSubject")
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer iDSubject;
    @Basic(optional = false)
    @Column(name = "SubjectName")
    private String subjectName;
    @Basic(optional = false)
    @Column(name = "ECTS")
    private int ects;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "subjectID")
    private Collection<Student> studentCollection;

    public Subjectt() {
    }
    
    public Subjectt(Subjectt data) {
        updateDetails(data);
    }

    public Subjectt(Integer iDSubject) {
        this.iDSubject = iDSubject;
    }

    public Subjectt(Integer iDSubject, String subjectName, int ects) {
        this.iDSubject = iDSubject;
        this.subjectName = subjectName;
        this.ects = ects;
    }

    public Integer getIDSubject() {
        return iDSubject;
    }

    public void setIDSubject(Integer iDSubject) {
        this.iDSubject = iDSubject;
    }

    public String getSubjectName() {
        return subjectName;
    }

    public void setSubjectName(String subjectName) {
        this.subjectName = subjectName;
    }

    public int getEcts() {
        return ects;
    }

    public void setEcts(int ects) {
        this.ects = ects;
    }

    @XmlTransient
    public Collection<Student> getStudentCollection() {
        return studentCollection;
    }

    public void setStudentCollection(Collection<Student> studentCollection) {
        this.studentCollection = studentCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (iDSubject != null ? iDSubject.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Subjectt)) {
            return false;
        }
        Subjectt other = (Subjectt) object;
        if ((this.iDSubject == null && other.iDSubject != null) || (this.iDSubject != null && !this.iDSubject.equals(other.iDSubject))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "hr.algebra.model.Subjectt[ iDSubject=" + iDSubject + " ]";
    }

    public void updateDetails(Subjectt data) {
        this.subjectName = data.getSubjectName();
        this.ects = data.getEcts();
    }
    
}
