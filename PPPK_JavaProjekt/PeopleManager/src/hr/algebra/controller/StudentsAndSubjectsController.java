/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.controller;

import hr.algebra.dao.RepositoryFactory;
import hr.algebra.utilities.FileUtils;
import hr.algebra.utilities.ImageUtils;
import hr.algebra.utilities.ValidationUtils;
import hr.algebra.viewmodel.StudentViewModel;
import hr.algebra.viewmodel.SubjectViewModel;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.IOException;
import java.net.URL;
import java.util.AbstractMap;
import java.util.Map;
import java.util.ResourceBundle;
import java.util.concurrent.atomic.AtomicBoolean;
import java.util.function.UnaryOperator;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.stream.Collectors;
import java.util.stream.Stream;
import javafx.collections.FXCollections;
import javafx.collections.ListChangeListener;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.Tab;
import javafx.scene.control.TabPane;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.TextFormatter;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.util.converter.IntegerStringConverter;

/**
 * FXML Controller class
 *
 * @author Leon Kranjcevic
 */
public class StudentsAndSubjectsController implements Initializable {

    private Map<TextField, Label> validationMapSubjects;
    private Map<TextField, Label> validationMapStudents;
    
    private final ObservableList<SubjectViewModel> listSubjects = FXCollections.observableArrayList();
    
    private SubjectViewModel selectedSubjectViewModel;
    
    private final ObservableList<StudentViewModel> listStudents = FXCollections.observableArrayList();
    
    private StudentViewModel selectedStudentViewModel;
    
    @FXML
    private TabPane tpContent;
    @FXML
    private Tab tabListSubjects;
    @FXML
    private TableView<SubjectViewModel> tvSubjects;
    @FXML
    private TableColumn<SubjectViewModel, String> tcSubjectName;
    @FXML
    private TableColumn<SubjectViewModel, Integer> tcECTS;
    @FXML
    private Tab tabEditSubject;
    @FXML
    private TextField tfSubjectName;
    @FXML
    private Label lbSubjectName;
    @FXML
    private TextField tfECTS;
    @FXML
    private Label lbECTS;
    
    
    
    @FXML
    private Tab tabListStudents;
    @FXML
    private TableView<StudentViewModel> tvStudents;
    @FXML
    private TableColumn<StudentViewModel, String> tcFirstName,tcLastName,tcEmail,tcStudentSubjectName;
    @FXML
    private TableColumn<StudentViewModel, Integer> tcAge;
    @FXML
    private Tab tabEditStudent;
    @FXML
    private ImageView ivStudent;
    @FXML
    private TextField tfFirstName;
    @FXML
    private Label lbFirstName;
    @FXML
    private Label lbLastName;
    @FXML
    private TextField tfAge;
    @FXML
    private Label lbAge;
    @FXML
    private TextField tfEmail;
    @FXML
    private Label lbEmail;
    @FXML
    private Label lbStudentSubjectName;
    @FXML
    private Label lbIcon;
    @FXML
    private ComboBox<SubjectViewModel> cbSubject;
    @FXML
    private TextField tfLastName;


    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
       initSubjectValidation();
       initStudentValidation();
       initSubjects();
       initStudents();
       initTableSubjects();
       initTableStudents();
       addIntegerMask(tfECTS);
       addIntegerMask(tfAge);
       setStudentSubjectListeners();
    }    

    @FXML
    private void editSubject(ActionEvent event) {
        if (tvSubjects.getSelectionModel().getSelectedItem() != null) {
            bindSubject(tvSubjects.getSelectionModel().getSelectedItem());
            tpContent.getSelectionModel().select(tabEditSubject);
        } 
    }

    @FXML
    private void deleteSubject(ActionEvent event) {
        if (tvSubjects.getSelectionModel().getSelectedItem() != null) {
            listSubjects.remove(tvSubjects.getSelectionModel().getSelectedItem());
            listStudents.removeIf(student -> student.getStudentSubjectNameProperty().equals(tvSubjects.getSelectionModel().getSelectedItem().getSubjectNameProperty()));
            cbSubject.setItems(listSubjects);
        } 
    }

    @FXML
    private void commitSubject(ActionEvent event) {
        if (subjectFormValid()) {
            
            selectedSubjectViewModel.getSubject().setSubjectName(tfSubjectName.getText().trim());
            selectedSubjectViewModel.getSubject().setEcts(Integer.valueOf(tfECTS.getText().trim()));
            if (selectedSubjectViewModel.getSubject().getIDSubject()== 0) {
                listSubjects.add(selectedSubjectViewModel);
                cbSubject.setItems(listSubjects);
            } else{
                try {
                    listStudents.removeIf(student -> student.getStudentSubjectNameProperty().equals(tvSubjects.getSelectionModel().getSelectedItem().getSubjectNameProperty()));
                    RepositoryFactory.getRepository().updateSubjectt(selectedSubjectViewModel.getSubject());
                    
                    tvSubjects.refresh();
                    tvStudents.refresh();
                } catch (Exception ex) {
                    Logger.getLogger(StudentsAndSubjectsController.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
            selectedSubjectViewModel = null;
            tpContent.getSelectionModel().select(tabListSubjects);
            resetSubjectForm();
        }
    }
    
    private boolean subjectFormValid() {
        final AtomicBoolean ok = new AtomicBoolean(true);
        validationMapSubjects.keySet().forEach(tf ->{
            if (tf.getText().trim().isEmpty()) {
                ok.set(false);
                validationMapSubjects.get(tf).setVisible(true);
            } else{
                validationMapSubjects.get(tf).setVisible(false);
            }        
        });
        return ok.get();
    }



    private void initSubjectValidation() {
        validationMapSubjects = Stream.of(
                new AbstractMap.SimpleImmutableEntry<>(tfSubjectName,lbSubjectName),
                new AbstractMap.SimpleImmutableEntry<>(tfECTS,lbECTS)
        ).collect(Collectors.toMap(Map.Entry::getKey, Map.Entry::getValue));
    }

    private void initTableSubjects() {
        tcSubjectName.setCellValueFactory(subject -> subject.getValue().getSubjectNameProperty());
        tcECTS.setCellValueFactory(subject -> subject.getValue().getECTSProperty().asObject());
        tvSubjects.setItems(listSubjects);
    }

    private void addIntegerMask(TextField tf) {
        UnaryOperator<TextFormatter.Change> filter = change -> {
            String input = change.getText();
            if (input.matches("\\d*")) {
                return change;
            }
            return null;
        };
        tf.setTextFormatter(new TextFormatter<>(new IntegerStringConverter(), 0, filter));
    }

    private void setStudentSubjectListeners() {
        tpContent.setOnMouseClicked(event ->{
            if (tpContent.getSelectionModel().getSelectedItem().equals(tabEditSubject)) { 
                bindSubject(null);
            }
            if (tpContent.getSelectionModel().getSelectedItem().equals(tabEditStudent)) { 
                bindStudent(null);
                cbSubject.getSelectionModel().select(0);
            }
        });       
        listSubjects.addListener(new ListChangeListener<SubjectViewModel>() {
            @Override
            public void onChanged(ListChangeListener.Change<? extends SubjectViewModel> change) {
                if (change.next()) { //provjeri i udi u cursor koji radi promjenu
                    if (change.wasRemoved()) {
                        change.getRemoved().forEach(suvm -> {
                            try {
                                RepositoryFactory.getRepository().deleteSubjectt(suvm.getSubject());
                                tvStudents.refresh();
                            } catch (Exception ex) {
                                Logger.getLogger(StudentsAndSubjectsController.class.getName()).log(Level.SEVERE, null, ex);
                            }
                        });
                    } else if (change.wasAdded()) {
                        change.getAddedSubList().forEach(suvm ->{
                            try {
                                int idSubject = RepositoryFactory.getRepository().addSubjectt(suvm.getSubject());
                                suvm.getSubject().setIDSubject(idSubject);
                            } catch (Exception ex) {
                                Logger.getLogger(StudentsAndSubjectsController.class.getName()).log(Level.SEVERE, null, ex);
                            }
                        });
                    }
                }                
            }
        });
        listStudents.addListener(new ListChangeListener<StudentViewModel>() {
            @Override
            public void onChanged(ListChangeListener.Change<? extends StudentViewModel> change) {
                if (change.next()) { //provjeri i udi u cursor koji radi promjenu
                    if (change.wasRemoved()) {
                        change.getRemoved().forEach(stvm -> {
                            try {
                                RepositoryFactory.getRepository().deleteStudent(stvm.getStudent());
                                tvStudents.refresh();
                            } catch (Exception ex) {
                                Logger.getLogger(StudentsAndSubjectsController.class.getName()).log(Level.SEVERE, null, ex);
                            }
                        });
                    } else if (change.wasAdded()) {
                        change.getAddedSubList().forEach(stvm ->{
                            try {
                                int idStudent = RepositoryFactory.getRepository().addStudent(stvm.getStudent());
                                stvm.getStudent().setIDStudent(idStudent);
                            } catch (Exception ex) {
                                Logger.getLogger(StudentsAndSubjectsController.class.getName()).log(Level.SEVERE, null, ex);
                            }
                        });
                    }
                }
                
            }
        });
    }
    
    private void bindStudent(StudentViewModel studentViewModel) {
        resetStudentForm();
        
        selectedStudentViewModel = studentViewModel != null ? studentViewModel : new StudentViewModel(null);
        tfFirstName.setText(selectedStudentViewModel.getFirstNameProperty().get());
        tfLastName.setText(selectedStudentViewModel.getLastNameProperty().get());
        tfAge.setText(String.valueOf(selectedStudentViewModel.getAgeProperty().get()));
        tfEmail.setText(selectedStudentViewModel.getEmailProperty().get());
        cbSubject.getSelectionModel().select(selectedStudentViewModel.getSubjectViewModel());
        
        ivStudent.setImage(
                selectedStudentViewModel.getPictureProperty().get() != null
                ? new Image(new ByteArrayInputStream(selectedStudentViewModel.getPictureProperty().get()))
                : new Image(new File("src/assets/no_image.png").toURI().toString())
        );    
    }
    
    private void bindSubject(SubjectViewModel subjectViewModel) {
        resetSubjectForm();
        
        selectedSubjectViewModel = subjectViewModel != null ? subjectViewModel : new SubjectViewModel(null);
        tfSubjectName.setText(selectedSubjectViewModel.getSubjectNameProperty().get());
        tfECTS.setText(String.valueOf(selectedSubjectViewModel.getECTSProperty().get()));
    }
    
    private void resetSubjectForm() {
        validationMapSubjects.values().forEach(l -> l.setVisible(false));
    }
    
    private void resetStudentForm() {
        validationMapStudents.values().forEach(l -> l.setVisible(false));
        lbIcon.setVisible(false); 
    }

    private void initSubjects() {
        try {
            RepositoryFactory.getRepository().getSubjects().forEach(subject -> listSubjects.add(new SubjectViewModel(subject)));
            cbSubject.getItems().addAll(listSubjects);
            cbSubject.getSelectionModel().select(0);
        } catch (Exception ex) {
            Logger.getLogger(StudentsAndSubjectsController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    
    
    
    
    
    
    @FXML
    private void editStudent(ActionEvent event) {
        if (tvStudents.getSelectionModel().getSelectedItem() != null) {
            bindStudent(tvStudents.getSelectionModel().getSelectedItem());
            tpContent.getSelectionModel().select(tabEditStudent);
            cbSubject.setItems(listSubjects);
        }
    }

    @FXML
    private void deleteStudent(ActionEvent event) {
        if (tvStudents.getSelectionModel().getSelectedItem() != null) {
            listStudents.remove(tvStudents.getSelectionModel().getSelectedItem());
        } 
    }

    @FXML
    private void commitStudent(ActionEvent event) {
        if (studentFormValid()) {
            
            selectedStudentViewModel.getStudent().setFirstName(tfFirstName.getText().trim());
            selectedStudentViewModel.getStudent().setLastName(tfLastName.getText().trim());
            selectedStudentViewModel.getStudent().setAge(Integer.valueOf(tfAge.getText().trim()));
            selectedStudentViewModel.getStudent().setEmail(tfEmail.getText().trim());
            selectedStudentViewModel.getStudent().setStudentSubjectName(cbSubject.getSelectionModel().getSelectedItem().toString());
            selectedStudentViewModel.getStudent().setSubjectID(cbSubject.getSelectionModel().getSelectedItem().getSubject());
            
            if (selectedStudentViewModel.getStudent().getIDStudent()== 0) {
                listStudents.add(selectedStudentViewModel);
            } else{
                try {
                    RepositoryFactory.getRepository().updateStudent(selectedStudentViewModel.getStudent());
                    tvStudents.refresh();
                } catch (Exception ex) {
                    Logger.getLogger(StudentsAndSubjectsController.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
            selectedStudentViewModel = null;
            tpContent.getSelectionModel().select(tabListStudents);
            resetStudentForm();
        }
    }
    
    private boolean studentFormValid() {
        final AtomicBoolean ok = new AtomicBoolean(true);
        validationMapStudents.keySet().forEach(tf ->{
            if (tf.getText().trim().isEmpty()
                    || tf.getId().contains("Email") && !ValidationUtils.isValidEmail(tf.getText().trim())) {
                ok.set(false);
                validationMapStudents.get(tf).setVisible(true);
            } else{
                validationMapStudents.get(tf).setVisible(false);
            }        
        });
        if (selectedStudentViewModel.getPictureProperty().get() == null) {
            lbIcon.setVisible(true);
            ok.set(false);            
        } else {
            lbIcon.setVisible(false);
        }
                
        
        return ok.get();
    }

    @FXML
    private void uploadStudent(ActionEvent event) {
        File file = FileUtils.uploadFileDialog(tfAge.getScene().getWindow(), "jpg", "jpeg", "png");
        if (file != null) {
            Image image = new Image(file.toURI().toString());
            String ext = file.getName().substring(file.getName().lastIndexOf(".") + 1);
            try {
                selectedStudentViewModel.getStudent().setPicture(ImageUtils.imageToByteArray(image, ext));
                ivStudent.setImage(image);
            } catch (IOException ex) {
                Logger.getLogger(StudentsAndSubjectsController.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }

    private void initStudentValidation() {
        validationMapStudents = Stream.of(
                new AbstractMap.SimpleImmutableEntry<>(tfFirstName,lbFirstName),
                new AbstractMap.SimpleImmutableEntry<>(tfLastName,lbLastName),
                new AbstractMap.SimpleImmutableEntry<>(tfAge,lbAge),
                new AbstractMap.SimpleImmutableEntry<>(tfEmail,lbEmail)
        ).collect(Collectors.toMap(Map.Entry::getKey, Map.Entry::getValue));
    }

    private void initStudents() {
        try {
            RepositoryFactory.getRepository().getStudents().forEach(student -> listStudents.add(new StudentViewModel(student)));
        } catch (Exception ex) {
            Logger.getLogger(StudentsAndSubjectsController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    private void initTableStudents() {
        tcFirstName.setCellValueFactory(person -> person.getValue().getFirstNameProperty());
        tcLastName.setCellValueFactory(person -> person.getValue().getLastNameProperty());
        tcAge.setCellValueFactory(person -> person.getValue().getAgeProperty().asObject());
        tcEmail.setCellValueFactory(person -> person.getValue().getEmailProperty());
        tcStudentSubjectName.setCellValueFactory(person -> person.getValue().getStudentSubjectNameProperty());
        tvStudents.setItems(listStudents);
    }






       
}
