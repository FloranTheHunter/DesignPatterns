using System;

namespace DesignPatternLibrary
{
    public interface IPresenter
    {
        string[] SelectAllData();

        string[] SelectDataBetween(string field, string val1, string val2);

        string[] SelectDataWhere(string field, string value);

        string InsertData(string field, Data data);

        string DeleteData();
    }
}
