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
import hr.algebra.viewmodel.PersonViewModel;
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
public class PeopleController implements Initializable {

    private Map<TextField, Label> validationMap;
    
    private final ObservableList<PersonViewModel> list = FXCollections.observableArrayList();
    
    private PersonViewModel selectedPersonViewModel;
    
    @FXML
    private TabPane tpContent;
    @FXML
    private Tab tabList;
    @FXML
    private TableColumn<PersonViewModel, String> tcFirstName, tcLastName, tcEmail;
    @FXML
    private TableColumn<PersonViewModel, Integer> tcAge;
    @FXML
    private Tab tabEdit;
    @FXML
    private ImageView ivPerson;
    @FXML
    private TextField tfFirstName;
    @FXML
    private Label lbFirstName;
    @FXML
    private TextField tfLastName;
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
    private Label lbIcon;
    @FXML
    private TableView<PersonViewModel> tvPeople;

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
       initValidation();
       initPeople();
       initTable();
       addIntegerMask(tfAge);
       setListeners();
    }    

    @FXML
    private void edit() {
        if (tvPeople.getSelectionModel().getSelectedItem() != null) {
            bindPerson(tvPeople.getSelectionModel().getSelectedItem());
            tpContent.getSelectionModel().select(tabEdit);
        }       
    }

    @FXML
    private void delete() {
        if (tvPeople.getSelectionModel().getSelectedItem() != null) {
            list.remove(tvPeople.getSelectionModel().getSelectedItem());
            //mozda tu ide da remova sve ljude koji imaju taj predmet koji se brise ak funk ne radi
        } 
    }

    @FXML
    private void upload(ActionEvent event) {
        File file = FileUtils.uploadFileDialog(tfAge.getScene().getWindow(), "jpg", "jpeg", "png");
        if (file != null) {
            Image image = new Image(file.toURI().toString());
            String ext = file.getName().substring(file.getName().lastIndexOf(".") + 1);
            try {
                selectedPersonViewModel.getPerson().setPicture(ImageUtils.imageToByteArray(image, ext));
                ivPerson.setImage(image);
            } catch (IOException ex) {
                Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }

    @FXML
    private void commit(ActionEvent event) {
        if (formValid()) {
            
            selectedPersonViewModel.getPerson().setFirstName(tfFirstName.getText().trim());
            selectedPersonViewModel.getPerson().setLastName(tfLastName.getText().trim());
            selectedPersonViewModel.getPerson().setAge(Integer.valueOf(tfAge.getText().trim()));
            selectedPersonViewModel.getPerson().setEmail(tfEmail.getText().trim());
            if (selectedPersonViewModel.getPerson().getIDPerson() == 0) {
                list.add(selectedPersonViewModel);
            } else{
                try {
                    RepositoryFactory.getRepository().updatePerson(selectedPersonViewModel.getPerson());
                    tvPeople.refresh();
                } catch (Exception ex) {
                    Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
            selectedPersonViewModel = null;
            tpContent.getSelectionModel().select(tabList);
            resetForm();
        }
    }

    private void initValidation() {
        validationMap = Stream.of(
                new AbstractMap.SimpleImmutableEntry<>(tfFirstName,lbFirstName),
                new AbstractMap.SimpleImmutableEntry<>(tfLastName,lbLastName),
                new AbstractMap.SimpleImmutableEntry<>(tfAge,lbAge),
                new AbstractMap.SimpleImmutableEntry<>(tfEmail,lbEmail)
        ).collect(Collectors.toMap(Map.Entry::getKey, Map.Entry::getValue));
    }

    private void initPeople() {
        try {
            RepositoryFactory.getRepository().getPeople().forEach(person -> list.add(new PersonViewModel(person)));
        } catch (Exception ex) {
            Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    private void initTable() {
        tcFirstName.setCellValueFactory(person -> person.getValue().getFirstNameProperty());
        tcLastName.setCellValueFactory(person -> person.getValue().getLastNameProperty());
        tcAge.setCellValueFactory(person -> person.getValue().getAgeProperty().asObject());
        tcEmail.setCellValueFactory(person -> person.getValue().getEmailProperty());
        tvPeople.setItems(list);
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
    private Tab priorTab;
    private void setListeners() {
        tpContent.setOnMouseClicked(event ->{
            if (tpContent.getSelectionModel().getSelectedItem().equals(tabEdit) && !tabEdit.equals(priorTab)) {
                bindPerson(null);
            }      
            priorTab = tpContent.getSelectionModel().getSelectedItem();
        });       
        list.addListener(new ListChangeListener<PersonViewModel>() {
            @Override
            public void onChanged(ListChangeListener.Change<? extends PersonViewModel> change) {
                if (change.next()) { //provjeri i udi u cursor koji radi promjenu
                    if (change.wasRemoved()) {
                        change.getRemoved().forEach(pvm -> {
                            try {
                                RepositoryFactory.getRepository().deletePerson(pvm.getPerson());
                            } catch (Exception ex) {
                                Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
                            }
                        });
                    } else if (change.wasAdded()) {
                        change.getAddedSubList().forEach(pvm ->{
                            try {
                                int idPerson = RepositoryFactory.getRepository().addPerson(pvm.getPerson());
                                pvm.getPerson().setIDPerson(idPerson);
                            } catch (Exception ex) {
                                Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
                            }
                        });
                    }
                }
                
            }
        });
    }

    private void bindPerson(PersonViewModel personViewModel) {
        
        resetForm();
        
        selectedPersonViewModel = personViewModel != null ? personViewModel : new PersonViewModel(null);
        tfFirstName.setText(selectedPersonViewModel.getFirstNameProperty().get());
        tfLastName.setText(selectedPersonViewModel.getLastNameProperty().get());
        tfAge.setText(String.valueOf(selectedPersonViewModel.getAgeProperty().get()));
        tfEmail.setText(selectedPersonViewModel.getEmailProperty().get());
        
        ivPerson.setImage(
                selectedPersonViewModel.getPictureProperty().get() != null
                ? new Image(new ByteArrayInputStream(selectedPersonViewModel.getPictureProperty().get()))
                : new Image(new File("src/assets/no_image.png").toURI().toString())
        );
    }

    private void resetForm() {
        validationMap.values().forEach(l -> l.setVisible(false));
        lbIcon.setVisible(false);
    }


    private boolean formValid() {
        final AtomicBoolean ok = new AtomicBoolean(true);
        validationMap.keySet().forEach(tf ->{
            if (tf.getText().trim().isEmpty()
                    || tf.getId().contains("Email") && !ValidationUtils.isValidEmail(tf.getText().trim())) {
                ok.set(false);
                validationMap.get(tf).setVisible(true);
            } else{
                validationMap.get(tf).setVisible(false);
            }        
        });
        if (selectedPersonViewModel.getPictureProperty().get() == null) {
            lbIcon.setVisible(true);
            ok.set(false);            
        } else {
            lbIcon.setVisible(false);
        }
                
        
        return ok.get();
        
    }
}

















