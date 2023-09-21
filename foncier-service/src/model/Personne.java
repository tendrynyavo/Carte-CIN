package model;

import java.io.IOException;
import java.net.MalformedURLException;
import java.net.URL;
import com.json.JsonObject;

public class Personne {
    
    String id;
    String nom;
    String prenom;
    String cin;

    public String getCin() {
        return cin;
    }

    public String getId() {
        return id;
    }

    public String getNom() {
        return nom;
    }

    public String getPrenom() {
        return prenom;
    }

    public void setCin(String cin) {
        this.cin = cin;
    }

    public void setId(String id) {
        this.id = id;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }

    public void setPrenom(String prenom) {
        this.prenom = prenom;
    }

    public static boolean exist(String cin) throws IOException {
        return (boolean) JsonObject.createJsonObject(new URL("http://localhost:5114/Sante/Verifier/" + cin), Boolean.class).toObject();
    }
    
    public static Personne getPersonne(String id) throws IOException, IllegalArgumentException {
        if (Personne.exist(id)) throw new IllegalArgumentException("CIN n'existe pas");
        return (Personne) JsonObject.createJsonObject(new URL("http://localhost:5114/Sante/GetPersonne/" + id), Personne.class).toObject();
    }

    public Terrain[] getTerrains() throws Exception {
        return (Terrain[]) new Terrain().setPersonne(this).findAll(null);
    }

}