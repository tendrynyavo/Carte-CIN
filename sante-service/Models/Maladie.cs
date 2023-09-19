namespace sante_service.Models;

public class Maladie {
    
    public string Id { get; set; }

    public string Nom { get; set; }

    public DateTime Date { get; set; }

    public Maladie(string id, string nom) {
        Id = id;
        Nom = nom;
    }

    public Maladie(string id, string nom, DateTime date) : this(id, nom) {
        Date = date;
    }

}