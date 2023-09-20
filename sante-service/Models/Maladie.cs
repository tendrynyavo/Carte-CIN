namespace sante_service.Models;

public class Maladie {

    public int Id { get; set; }

    public string Nom { get; set; }

    public DateTime Date { get; set; }

    public Personne Personne { set; get; }

    public Maladie(int id, string nom) {
        Id = id;
        Nom = nom;
    }

    public Maladie(int id, string nom, DateTime date) : this(id, nom) {
        Date = date;
    }

    public static Maladie[] GetMaladie(string cin) {
        Maladie[] maladies = new Maladie[0];
        using (var connection = Connection.GetConnection()) {
            Personne? personne = Personne.GetByCIN(connection, cin);
            if (personne == null) throw new Exception("Numero de CIN n'existe pas");
            maladies = personne.GetMaladie(connection);
        }
        return maladies;
    }

}