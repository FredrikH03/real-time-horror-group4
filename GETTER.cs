﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace real_time_horror_group4;

public class Get(HttpListenerRequest request, NpgsqlDataSource db)
{

    public string? path = request.Url.AbsolutePath;
    public string? Lastpath = request.Url.AbsolutePath.Split("/").Last();

    public string menu()
    {
        return "Welcome Contestants!\r\n" +
               "What would you like to do:\r\n" +
               "Register or Log in\r\n";


    }

    public string ShowQuestions() // behöver fixas
    {
        string qShow = @"SELECT questions, A, B, C
                     FROM questions
                     JOIN options ON optionsid = optionsid";

        string result = string.Empty;

        using (var reader = db.CreateCommand(qShow).ExecuteReader())
        {
            if (reader.Read())
            {
                result += reader.GetString(0) + "\nA) ";
                result += reader.GetString(1) + "\nB) ";
                result += reader.GetString(2) + "\nC) ";
                result += reader.GetString(3) + "\n\n ";

            }
        }

        return result;
    }


    public string Getter()
    {
        if (path != null)
        {
            if (path.Contains("/menu"))
            {
                return menu();
            }
            if (path.Contains("/questions"))
            {
                return ShowQuestions();
            }
            //if (path.Contains("/"))
            //{
            //    return Leaderboard();
            //}

        }
        return "Not Found";
    }

}

// user register och login och när man registrear det ska in db
// sen curl loginmenu. som ska vara 1. join game 2. see leaderboard
// 1. join game gör curl get på questions
// curl post på answer och då jämför vi med det rätta svaret i correctanswers table
// om rätt +1 / om fel inget
//förberredda svaret visas med understreck
// post svar och jämför med correct answer table 

