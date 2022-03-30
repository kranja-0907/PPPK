/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra;

import hr.algebra.dao.RepositoryFactory;
import java.io.IOException;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

/**
 *
 * @author Leon Kranjcevic
 */
public class PeopleApplication extends Application {
    
    @Override
    public void start(Stage primaryStage) throws IOException {
        
        Parent root = FXMLLoader.load(getClass().getResource("view/StudentsAndSubjects.fxml")); //StudentsAndSubjects People
        
        Scene scene = new Scene(root, 600, 400);
        
        primaryStage.setTitle("Subject manager");
        primaryStage.setScene(scene);
        primaryStage.show();
    }
    
    
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void stop() throws Exception {
        RepositoryFactory.getRepository().release();
        super.stop(); //To change body of generated methods, choose Tools | Templates.
    }
    
    
    
}
