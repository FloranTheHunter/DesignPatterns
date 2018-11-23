using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using static System.Reflection.Assembly;

namespace DesignPatternLibrary
{
    public class DataModel
    {
        OleDbConnection dbconnection;

        public DataModel()
        {
            var DBPath = System.IO.Path.GetDirectoryName(GetExecutingAssembly().Location) + "\\Database.mdb";
            dbconnection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + DBPath);
            dbconnection.Open();
        }


    }
}
