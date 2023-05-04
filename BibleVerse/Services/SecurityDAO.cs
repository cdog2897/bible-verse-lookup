using System;
using BibleVerse.Models;
using MySqlConnector;

namespace BibleVerse.Services
{
	public class SecurityDAO
	{
        String connectionString = "datasource=localhost;port=8889;username=root;password=root;database=bible_verses";

        /// <summary>
        /// Return all the verses that have the included search term:
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public List<VerseModel> GetVerseBySearchTerm(string st)
        {
            List<VerseModel> verses = new List<VerseModel>();

            // open conneciton
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string searchTerm = "%" + st + "%";
            string sqlStatement = "SELECT * FROM `t_asv` WHERE t LIKE @searchTerm";

            MySqlCommand command = new MySqlCommand(sqlStatement, connection);
            command.Parameters.AddWithValue("@searchTerm", searchTerm);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int bookId = reader.GetInt32(1);
                    int chapterId = reader.GetInt32(2);
                    int verseId = reader.GetInt32(3);
                    string text = reader.GetString(4);

                    VerseModel v = new VerseModel(bookId, chapterId, verseId, text);
                    verses.Add(v);
                }
            }
            connection.Close();
            return verses;
        }



    }
}

