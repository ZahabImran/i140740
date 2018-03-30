using Synergy.Scrambler.Model;
using System;
using System.Collections.Generic;

namespace Synergy.Scrambler.Engine
{
    public interface IScramblerEngine
    {
        List<Table> FetchSchema();
        List<String> GetDatabases(String ConnectionString);

        Boolean TestCon();

        List<Columns> FetchColumns(String TableName);

        List<String> FetchData(String TableName,String ColName,int Rows);
        int FetchTotal(String TableName, String ColName);

        string GetType(String ColumnName,String TableName);

        void Processing( String Table);
        Boolean UpdateDataBase(List<String> list);

        

    }
}
