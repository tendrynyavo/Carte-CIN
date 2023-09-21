package model;

import connection.BddObject;

public class Terrain extends BddObject {

    String adresse;
    boolean bornee;
    double longueur;
    double largeur;
    String longitude;
    String latitude;
    Personne personne;

    public String getLatitude() {
        return latitude;
    }

    public String getLongitude() {
        return longitude;
    }

    public String getAdresse() {
        return adresse;
    }

    public double getLargeur() {
        return largeur;
    }

    public double getLongueur() {
        return longueur;
    }

    public Personne getPersonne() {
        return personne;
    }

    public void setAdresse(String adresse) {
        this.adresse = adresse;
    }

    public void setBornee(boolean bornee) {
        this.bornee = bornee;
    }

    public void setLargeur(double largeur) {
        this.largeur = largeur;
    }

    public void setLatitude(String latitude) {
        this.latitude = latitude;
    }

    public void setLongitude(String longitude) {
        this.longitude = longitude;
    }

    public void setLongueur(double longueur) {
        this.longueur = longueur;
    }

    public Terrain setPersonne(Personne personne) {
        this.personne = personne;
        return this;
    }

    public double getSuperficie() {
        return this.getLargeur() * this.getLongueur();
    }

    public Terrain() throws Exception {
        super();
        this.setTable("terrain");
    }

    public static Terrain[] getTerrain(String id) throws Exception {
        Personne personne = Personne.getPersonne(id);
        return personne.getTerrains();
    }

}