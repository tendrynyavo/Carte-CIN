using MySqlConnector;

namespace sante_service.Models;

public class Maladie {

    public int Id { get; set; }

    public string Nom { get; set; }

    public DateTime Date { get; set; }

    public Maladie(int id, string nom) {
        Id = id;
        Nom = nom;
    }

    public Maladie(int id, string nom, DateTime date) : this(id, nom) {
        Date = date;
    }

    public static Maladie[] GetMaladie() {
        List<Maladie> maladies = new List<Maladie>();
        using (var connection = Connection.GetConnection()) {
            using (var cmd = new MySqlCommand("SELECT id, nom, date FROM maladie", connection)) {
                using (var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        maladies.Add(new Maladie(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2)));
                    }
                }
            }
        }
        return maladies.ToArray();
    }

}