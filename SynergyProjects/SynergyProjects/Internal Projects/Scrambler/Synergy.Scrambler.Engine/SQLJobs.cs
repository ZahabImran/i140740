using System;
using System.Collections.Generic;
using System.Linq;
using Synergy.Scrambler.Model.Configuration;
using Synergy.Scrambler.Model;

namespace Synergy.Scrambler.Engine
{
    public class SqlScramblingJobs : IScramblerJobDistributer
    {
        IScramblerEngine ISE;
        List<Table> Tables = new List<Table>();
     
        public SqlScramblingJobs(String ConnectionString)
        {
            ISE = new MsSqlBusinessLogic(ConnectionString);
            Tables = ISE.FetchSchema();
        }

        public ProjectConfig GetScrambledConfig(ProjectConfig PC)
        {
            ProjectConfig ForScrambling = new ProjectConfig();

            foreach (var configTable in PC.TableConfigs)
            {
                TableCofig ForScramblingTable = new TableCofig();

                var cols = new List<ColumnConfig>();
                foreach (var configColumn in configTable.ColumnConfigs)
                {
                    cols = configTable.ColumnConfigs.Where(t => t.MappingConfig.Name == "Data Scramble").ToList();

                }

                if (cols.Count != 0)
                {
                    ForScramblingTable.ColumnConfigs = cols;
                    ForScramblingTable.TableName = configTable.TableName;
                    ForScrambling.TableConfigs.Add(ForScramblingTable);
                }
            }
            /*  for (int i = 0; i < PC.TableConfigs.Count; i++)
              {
                  ColumnConfig ForScramblingCols = new ColumnConfig();

                  for (int j = 0; j < PC.TableConfigs[i].ColumnConfigs.Count; j++)
                  {
                      if (PC.TableConfigs[i].ColumnConfigs[j].MappingConfig.Name == "Data Scramble")
                      {
                          ForScramblingTable.ColumnConfigs.Add(PC.TableConfigs[i].ColumnConfigs[j]);
                          ForScramblingTable.TableName = PC.TableConfigs[i].TableName;
                      }
                      //list.Add(PC.TableConfigs[i].TableName.ToString() + " " + PC.TableConfigs[i].ColumnConfigs[j].Name + " " + PC.TableConfigs[i].ColumnConfigs[j].MappingConfig.Name);
                  }
                  if(ForScramblingTable.ColumnConfigs!=null)
                  {
                      ForScrambling.TableConfigs.Add(ForScramblingTable);
                  }

              }*/
            ForScrambling.ConnectionString = PC.ConnectionString;
            return ForScrambling;
        }

        public ProjectConfig GetMaskingConfig(ProjectConfig PC)
        {
            ProjectConfig ForScrambling = new ProjectConfig();

            foreach (var configTable in PC.TableConfigs)
            {
                TableCofig ForScramblingTable = new TableCofig();

                var cols = new List<ColumnConfig>();
                foreach (var configColumn in configTable.ColumnConfigs)
                {
                    cols = configTable.ColumnConfigs.Where(t => t.MappingConfig.Name == "Data Mask").ToList();

                }

                if (cols.Count != 0)
                {
                    ForScramblingTable.ColumnConfigs = cols;
                    ForScramblingTable.TableName = configTable.TableName;
                    ForScrambling.TableConfigs.Add(ForScramblingTable);
                }
            }
            ForScrambling.ConnectionString = PC.ConnectionString;
            return ForScrambling;
        }
        public ProjectConfig GetParagraphConfig(ProjectConfig PC)
        {
            ProjectConfig ForScrambling = new ProjectConfig();

            foreach (var configTable in PC.TableConfigs)
            {
                TableCofig ForScramblingTable = new TableCofig();

                var cols = new List<ColumnConfig>();
                foreach (var configColumn in configTable.ColumnConfigs)
                {
                    cols = configTable.ColumnConfigs.Where(t => t.MappingConfig.Name == "ParagraphMask").ToList();

                }

                if (cols.Count != 0)
                {
                    ForScramblingTable.ColumnConfigs = cols;
                    ForScramblingTable.TableName = configTable.TableName;
                    ForScrambling.TableConfigs.Add(ForScramblingTable);
                }
            }
            ForScrambling.ConnectionString = PC.ConnectionString;
            return ForScrambling;
        }
        public ProjectConfig GetReplaceConfig(ProjectConfig PC)
        {
            ProjectConfig ForScrambling = new ProjectConfig();

            foreach (var configTable in PC.TableConfigs)
            {
                TableCofig ForScramblingTable = new TableCofig();

                var cols = new List<ColumnConfig>();
                foreach (var configColumn in configTable.ColumnConfigs)
                {
                    cols = configTable.ColumnConfigs.Where(t => t.MappingConfig.Name == "Data Replacement").ToList();

                }

                if (cols.Count != 0)
                {
                    ForScramblingTable.ColumnConfigs = cols;
                    ForScramblingTable.TableName = configTable.TableName;
                    ForScrambling.TableConfigs.Add(ForScramblingTable);
                }
            }
            ForScrambling.ConnectionString = PC.ConnectionString;
            return ForScrambling;
        }
        public ProjectConfig GetHashConfig(ProjectConfig PC)
        {
            ProjectConfig ForScrambling = new ProjectConfig();

            foreach (var configTable in PC.TableConfigs)
            {
                TableCofig ForScramblingTable = new TableCofig();

                var cols = new List<ColumnConfig>();
                foreach (var configColumn in configTable.ColumnConfigs)
                {
                    cols = configTable.ColumnConfigs.Where(t => t.MappingConfig.Name == "Data Hash").ToList();

                }

                if (cols.Count != 0)
                {
                    ForScramblingTable.ColumnConfigs = cols;
                    ForScramblingTable.TableName = configTable.TableName;
                    ForScrambling.TableConfigs.Add(ForScramblingTable);
                }
            }
            ForScrambling.ConnectionString = PC.ConnectionString;
            return ForScrambling;
        }


        public bool ValidateConfig(ProjectConfig PC)
        {
            foreach(var configTable in PC.TableConfigs)
              {
                  var table = Tables.Where(t => t.TableName == configTable.TableName).ToList();

                  if (table.Count() == 0)
                      return false;

                  foreach(var configColumn in configTable.ColumnConfigs)
                  {
                      if (table.First().ColumnsList.Where(c => c.Name == configColumn.Name).Count() == 0)
                          return false;
                  }
              }

              return true;

   

        }

    }
}
