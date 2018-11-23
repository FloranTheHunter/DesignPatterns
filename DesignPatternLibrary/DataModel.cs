﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace DesignPatternLibrary
{
    public class DataModel
    {
        OleDbConnection dbconnection;

        public DataModel()
        {
            var DBPath = System.Windows.Forms.Application.StartupPath + "\\Database11.mdb";
            dbconnection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + DBPath);
            dbconnection.Open();
        }


    }
}
