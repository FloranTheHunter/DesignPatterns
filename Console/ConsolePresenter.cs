using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DesignPatternLibrary;

namespace ConsoleProgramm
{
    class ConsolePresenter : IPresenter
    {
        public string DeleteData()
        {
            throw new NotImplementedException();
        }

        public string InsertData(string field, Data data)
        {
            throw new NotImplementedException();
        }

        #region Select Commands

        public string[] SelectAllData()
        {
            throw new NotImplementedException();
        }

        public string[] SelectDataBetween(string field, string val1, string val2)
        {
            throw new NotImplementedException();
        }

        public string[] SelectDataWhere(string field, string value)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
