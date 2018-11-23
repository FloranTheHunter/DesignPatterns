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


        /// <summary>
        /// Open DataBase connection and create DataModel
        /// </summary>
        public DataModel()
        {
            var DBPath = System.IO.Path.GetDirectoryName(GetExecutingAssembly().Location) + "\\Database.mdb";
            dbconnection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + DBPath);
            dbconnection.Open();
        }

        /// <summary>
        /// Perform Select command by command text
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public List<Data> Select(string command)
        {
            OleDbCommand cmmnd = dbconnection.CreateCommand();
            cmmnd.CommandText = command;
            List<Data> DataList;
            using (OleDbDataReader dataReader = cmmnd.ExecuteReader())
            {
                if (dataReader.FieldCount != 4)
                    new MissingFieldException("Количество столбцов базы данных не совпадает с количеством полей Data");

                DataList = new List<Data>();
                while (dataReader.Read())
                {
                    Data datamember = new Data
                    {
                        Id = dataReader.GetFieldValue<string>(0),
                        Date = dataReader.GetFieldValue<string>(1),
                        Text = dataReader.GetFieldValue<string>(2),
                        Value = dataReader.GetFieldValue<int>(3)
                    };
                    DataList.Add(datamember);
                }
            }
            return DataList;
        }


        /// <summary>
        /// Insert values into Data Base into fields specified by array
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="values"></param>
        public void Insert(string[] fields, string[] values)
        {
            if (fields.Length == 0)
                new ArgumentException("Количество полей не может быть меньше единицы.", "fields");

            if (fields.Length != values.Length)
                new ArgumentException("Количество полей и значений должно совпадать.", "values");

            if (fields.Length > 4)
                new ArgumentException("Количество полей слишком велико.", "fields");

            string fieldList = $"({fields[0]}";
            string valueList = $"(@f0";

            for (int i = 1; i < fieldList.Length; i++)
            {
                fieldList += $", {fields[i]}";
                valueList += $", @f{i}";
            }


            OleDbCommand cmmnd = new OleDbCommand("INSERT INTO Data (Data_Date, Data_Text) VALUES (@f1, @f2)", dbconnection);

            //cmmnd.Parameters.AddWithValue("@f1", SqlDbType.Date).Value = time;
            //cmmnd.Parameters.AddWithValue("@f2", SqlDbType.VarChar).Value = text;
            cmmnd.ExecuteNonQuery();
        }

    }
}
