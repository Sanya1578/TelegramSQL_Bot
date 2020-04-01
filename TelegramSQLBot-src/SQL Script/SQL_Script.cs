using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBot2.SQL_Script
{
    public static class SQL_Script
    {
        static string description;
        static string examples;
        public static string GET(string command)
        {
            List<string> com = new List<string>();

            //TODO: work with sql
            description = "..";
            return description + "\n" + examples + "\n";
        }
    }
}