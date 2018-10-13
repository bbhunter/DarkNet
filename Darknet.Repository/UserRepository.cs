﻿using System;
using System.Data;
using System.Data.SqlClient;
using Darknet.Models;

namespace Darknet.Repository
{
    public class UserRepository: IUserRepository
    {
        private string _connectionString;
        public UserRepository(string connectionString) {
            _connectionString = connectionString;
        }
        public string RegisterUser(UserRegistrationModel userRegistrationModel) {
            string result = "";
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString)) {

                SqlCommand sqlCommand = new SqlCommand("uspRegisterUser", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@username", userRegistrationModel.Username);
                sqlCommand.Parameters.AddWithValue("@password", userRegistrationModel.Password);
                sqlCommand.Parameters.AddWithValue("@firstName", userRegistrationModel.FirstName);
                sqlCommand.Parameters.AddWithValue("@lastName", userRegistrationModel.LastName);

                sqlConnection.Open();
                result = sqlCommand.ExecuteScalar().ToString();
                sqlConnection.Close();
                return result;
            }
        }

        public string AuthenticateUser(UserCredentials userCredentials)
        {
            string result = "";
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {

                SqlCommand sqlCommand = new SqlCommand("uspAuthenticateUser", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@username", userCredentials.Username);
                sqlCommand.Parameters.AddWithValue("@password", userCredentials.Password);

                sqlConnection.Open();
                result = sqlCommand.ExecuteScalar().ToString();
                sqlConnection.Close();
                return result;
            }
        }
    }
}
