using System;
using System.Data.SQLite;
using System.Windows.Forms;

public class crud_op
{
    private SQLiteConnection connection;

    public crud_op()
    {
        string connectionString = "Data Source=C:/Users/ASUS/Desktop/personeldatabase/databases/personel.db";
;

        connection = new SQLiteConnection(connectionString);
    }

    public void OpenConnection()
    {
        if (connection.State != System.Data.ConnectionState.Open)
        {
            connection.Open();
        }
    }

    public void CloseConnection()
    {
        if (connection.State != System.Data.ConnectionState.Closed)
        {
            connection.Close();
        }
    }

    public void CreateTable()
    {
        OpenConnection();

        string createTableQuery = @"CREATE TABLE IF NOT EXISTS personel (
                                        personel_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        personel_name TEXT NOT NULL,
                                        personel_surname TEXT NOT NULL,
                                        personel_yevmiye INTEGER NOT NULL,
                                        personel_mesai INTEGER NOT NULL,
                                        personel_telno INTEGER NOT NULL,
                                        personel_eposta TEXT NOT NULL,
                                        personel_alan TEXT NOT NULL
                                    )"
        ;
        SQLiteCommand command = new SQLiteCommand(createTableQuery, connection);
        command.ExecuteNonQuery();

        CloseConnection();
    }

    public void Add(string name, string surname, int yevmiye, int mesai, string telno, string eposta, string alan)
    {
        OpenConnection();

        string insertDataQuery = @"INSERT INTO personel (personel_name, personel_surname, personel_yevmiye, personel_mesai, personel_telno, personel_eposta, personel_alan)
                                   VALUES (@Name, @Surname, @Yevmiye, @Mesai, @TelNo, @Eposta, @Alan)";
        SQLiteCommand command = new SQLiteCommand(insertDataQuery, connection);
        command.Parameters.AddWithValue("@Name", name);
        command.Parameters.AddWithValue("@Surname", surname);
        command.Parameters.AddWithValue("@Yevmiye", yevmiye);
        command.Parameters.AddWithValue("@Mesai", mesai);
        command.Parameters.AddWithValue("@TelNo", telno);
        command.Parameters.AddWithValue("@Eposta", eposta);
        command.Parameters.AddWithValue("@Alan", alan);
        command.ExecuteNonQuery();

        CloseConnection();
    }

    public void Update(int id, string name, string surname, int yevmiye, int mesai, string telno, string eposta, string alan)
    {
        OpenConnection();

        string updateDataQuery = @"UPDATE personel SET personel_name = @Name, personel_surname = @Surname,
                                    personel_yevmiye = @Yevmiye, personel_mesai = @Mesai, personel_telno = @TelNo,
                                    personel_eposta = @Eposta, personel_alan = @Alan WHERE personel_id = @Id";
        SQLiteCommand command = new SQLiteCommand(updateDataQuery, connection);
        command.Parameters.AddWithValue("@Name", name);
        command.Parameters.AddWithValue("@Surname", surname);
        command.Parameters.AddWithValue("@Yevmiye", yevmiye);
        command.Parameters.AddWithValue("@Mesai", mesai);
        command.Parameters.AddWithValue("@TelNo", telno);
        command.Parameters.AddWithValue("@Eposta", eposta);
        command.Parameters.AddWithValue("@Alan", alan);
        command.Parameters.AddWithValue("@Id", id);
        command.ExecuteNonQuery();

        CloseConnection();
    }

    public void Delete(int id)
    {
        OpenConnection();
        string deleteDataQuery = "DELETE FROM personel WHERE personel_id = @Id";
        SQLiteCommand command = new SQLiteCommand(deleteDataQuery, connection);
        command.Parameters.AddWithValue("@Id", id);
        command.ExecuteNonQuery();

        CloseConnection();
    }

    public void List(DataGridView dataGridView)
    {
        OpenConnection();

        string readDataQuery = "SELECT * FROM personel";
        SQLiteCommand command = new SQLiteCommand(readDataQuery, connection);
        SQLiteDataReader reader = command.ExecuteReader();

        dataGridView.Rows.Clear();

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader["personel_id"]);
            string name = reader["personel_name"].ToString();
            string surname = reader["personel_surname"].ToString();
            int yevmiye = Convert.ToInt32(reader["personel_yevmiye"]);
            int mesai = Convert.ToInt32(reader["personel_mesai"]);
            string telno = reader["personel_telno"].ToString();
            string eposta = reader["personel_eposta"].ToString();
            string alan = reader["personel_alan"].ToString();

            dataGridView.Rows.Add(id, name, surname, yevmiye, mesai, telno, eposta, alan);
        }

        reader.Close();

        CloseConnection();
    }
}



