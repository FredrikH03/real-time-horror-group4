﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace real_time_horror_group4;

public class Get(HttpListenerRequest request, NpgsqlDataSource db)
{
    public string? path = request.Url.AbsolutePath;
    public string? Lastpath = request.Url.AbsolutePath.Split("/").Last();

    public string test()
    {

        string test = "test";

        return test;

    }
    public string getter()
    {
        if(path != null)
        {
            if (path.Contains("/test"))
            {
                return test(); 


            }
            if (path.Contains("/"))
            {


                //return nästa metod


            }



        }



        return "not found";

    }



}