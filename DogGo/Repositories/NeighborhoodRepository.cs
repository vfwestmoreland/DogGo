﻿using DogGo.Models;
using DogGo.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.Identity.Client;


namespace DogGo.Repositories
{
    namespace DogGo.Repositories
    {
        public class NeighborhoodRepository : INeighborhoodRepository
        {
            private readonly IConfiguration _config;

            public NeighborhoodRepository(IConfiguration config)
            {
                _config = config;
            }

            public SqlConnection Connection
            {
                get
                {
                    return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                }
            }

            public List<Neighborhood> GetAll()
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"SELECT Id, [Name] 
                                          FROM Neighborhood";

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            List<Neighborhood> neighborhoods = new List<Neighborhood>();

                            while (reader.Read())
                            {
                                Neighborhood neighborhood = new Neighborhood
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name"))
                                };
                                neighborhoods.Add(neighborhood);
                            }

                            return neighborhoods;
                        }
                    }
                }
            }

            public Neighborhood GetNeighborhoodById(int id)
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"SELECT Id, [Name] 
                                            FROM Neighborhood
                                            Where Id = @id
                                            ";
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                Neighborhood neighborhood = new Neighborhood
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name"))
                                };
                                return neighborhood;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }   
            }

            public List<Neighborhood> GetNeighborhoodByOwnerId(int id)
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"SELECT o.NeighborhoodId AS Id, n.[Name] 
                                            FROM Owner o
                                            INNER JOIN Neighborhood n ON n.Id = o.NeighborhoodId
                                            WHERE o.NeighborhoodId = @id
                                            ";
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            List<Neighborhood> neighborhoods = new List<Neighborhood>();

                            while (reader.Read())
                            {
                                Neighborhood neighborhood = new Neighborhood
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name"))
                                };
                                neighborhoods.Add(neighborhood);
                            }

                            return neighborhoods;
                        }
                    }
                }
            }
        }
    }
}
        