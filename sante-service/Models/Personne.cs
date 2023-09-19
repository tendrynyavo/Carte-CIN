using MySqlConnector;

namespace sante_service.Models;

public class Personne {

    public int Id { get; set; }

    public string? Nom { get; set; }
    
    public string? Prenom { get; set; }
    
    public string? Cin { get; set; }

    public Personne(int id, string nom, string prenom, string cin) {
        Id = id;
        Nom = nom;
        Prenom = prenom;
        Cin = cin;
    }

    public Maladie[] GetMaladie(MySqlConnection connection) {
        List<Maladie> maladies = new List<Maladie>();
        using (var cmd = new MySqlCommand("SELECT id, nom, date FROM maladie WHERE cin = @numero", connection)) {
            cmd.Parameters.AddWithValue("@numero", Cin);
            using (var reader = cmd.ExecuteReader()) {
                while(reader.Read()) {
                    Maladie maladie = new Maladie(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2));
                    maladies.Add(maladie);
                    maladie.Personne = this;
                }
            }
        }
        return maladies.ToArray();
    }

    public static Personne? GetByCIN(string cin) {
        Personne? personne = null;
        using (var connection = Connection.GetConnection()) {
            personne = GetByCIN(connection, cin);
        }
        return personne;
    }

    public static Personne? GetByCIN(MySqlConnection connection, string cin) {
        Personne? personne = null;
        using (var cmd = new MySqlCommand("SELECT id, nom, prenom, num_cin FROM personne WHERE num_cin = @numero", connection)) {
            cmd.Parameters.AddWithValue("@numero", cin);
            using (var reader = cmd.ExecuteReader()) {
                if (reader.Read()) {
                    personne = new Personne(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                }
            }
        }
        return personne;
    }

    public static bool Verifier(string cin) {
        bool check = false;
        using (var connection = Connection.GetConnection()) {
            check = GetByCIN(connection, cin) != null;
        }
        return check;
    }


}