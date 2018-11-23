using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLibrary
{
    public class Data
    {
        public Data(string date, string text, int value)
        {
            this.Date = date;
            this.Text = text;
            this.Value = value;
        }

        string Id { get; set; }
        string Date { get; set; }
        string Text { get; set; }
        int Value { get; set; }        
    }
}
