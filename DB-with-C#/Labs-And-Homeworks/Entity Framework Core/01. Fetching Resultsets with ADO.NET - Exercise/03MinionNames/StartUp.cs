﻿namespace _03MinionNames
{
    using System;
    using System.Data.SqlClient;
    using _01InitialSetup;

    public class StartUp
    {
        private const string DbName = "MinionsDB";

        public static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnectionString, DbName));

            connection.Open();

            using (connection)
            {
                using SqlCommand idCommand = new SqlCommand(Queries.VillainsIdQuery, connection);

                idCommand.Parameters.AddWithValue("@Id", villainId);

                string villainName = (string)idCommand.ExecuteScalar();

                if (villainName == null)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                    return;
                }

                using SqlCommand minionsCommand = new SqlCommand(Queries.MinionsQuery, connection);

                minionsCommand.Parameters.AddWithValue("@Id", villainId);

                SqlDataReader sqlDataReader = minionsCommand.ExecuteReader();

                using (sqlDataReader)
                {
                    Console.WriteLine($"Villain: {villainName}");

                    int counter = 1;
                    while (sqlDataReader.Read())
                    {
                        string minionName = (string)sqlDataReader["MinionName"];

                        if (sqlDataReader.HasRows)
                        {
                            int minionAge = (int)sqlDataReader["MinionAge"];

                            Console.WriteLine($"{counter}. {minionName} {minionAge}");
                            counter++;
                        }
                        else
                        {
                            Console.WriteLine("(no minions)");
                        }
                    }
                }
            }
        }
    }
}
