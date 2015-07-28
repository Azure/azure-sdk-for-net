using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for recommended elastic pools
    /// </summary>
    public class Sql2RecommendedIndexScenarioTests : TestBase
    {
        private const string ResourceGroupName = "Group-1";
        private const string ServerName = "demo-ne";
        private const string Expand = "schemas/tables/recommendedIndexes";
        private const string DatabaseName = "index-demo";
        private const string Schema = "[dbo]";
        private const string TableName = "[Person]";
        private const string IndexName = "nci_wi_Person_25F9812A-26A3-4ECA-B078-B2982817D12C";

        [Fact]
        public void ListAllIndexesForServer()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.Databases.ListExpanded(ResourceGroupName, ServerName, Expand);

                var index =
                    response.Databases[1].Properties.Schemas[0].Properties.Tables[0].Properties.RecommendedIndexes[0];
                ValidateRecommendedIndex(index, "Active");
            }
        }

        [Fact]
        public void GetSingleRecommendation()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.RecommendedIndexes.Get(ResourceGroupName, ServerName, DatabaseName, Schema,
                    TableName, IndexName);

                var index = response.RecommendedIndex;
                ValidateRecommendedIndex(index, "Active");
            }
        }

        [Fact]
        public void UpdateState()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);

                var updateParams = new RecommendedIndexUpdateParameters
                {
                    Properties = new RecommendedIndexUpdateProperties
                    {
                        State = "Pending"
                    }
                };
                var response = sqlClient.RecommendedIndexes.Update(ResourceGroupName, ServerName, DatabaseName, Schema,
                    TableName, IndexName, updateParams);

                var index = response.RecommendedIndex;
                ValidateRecommendedIndex(index, "Pending");

                updateParams.Properties.State = "Active";
                sqlClient.RecommendedIndexes.Update(ResourceGroupName, ServerName, DatabaseName, Schema, TableName,
                    IndexName, updateParams);
            }
        }

        private void ValidateRecommendedIndex(RecommendedIndex index, string state)
        {
            Assert.Equal(index.Name, "nci_wi_Person_25F9812A-26A3-4ECA-B078-B2982817D12C");
            Assert.Equal(index.Properties.Action, "Create");
            Assert.Equal(index.Properties.State, state);
            Assert.Equal(index.Properties.Created, DateTime.Parse("2015-06-22T13:18:00"));
            Assert.Equal(index.Properties.LastModified, DateTime.Parse("2015-06-22T13:18:00"));
            Assert.Equal(index.Properties.IndexType, "NONCLUSTERED");
            Assert.Equal(index.Properties.Schema, "[dbo]");
            Assert.Equal(index.Properties.Table, "[Person]");
            Assert.Equal(index.Properties.Columns[0], "[FirstName]");
            Assert.Equal(index.Properties.Columns[1], "[LastName]");
            Assert.Equal(index.Properties.IncludedColumns[0], "[MiddleName]");
            Assert.Equal(index.Properties.IncludedColumns[1], "[Suffix]");
            Assert.Equal(index.Properties.IndexScript, "create nonclustered index [nci_wi_Person_25F9812A-26A3-4ECA-B078-B2982817D12C] on [dbo].[Person] ([FirstName], [LastName]) include ([MiddleName], [Suffix]) with (online = on)");
            Assert.Equal(index.Properties.EstimatedImpact[0].Name, "benefit");
            Assert.Equal(index.Properties.EstimatedImpact[0].Unit, "unitless");
            Assert.Equal(index.Properties.EstimatedImpact[0].ChangeValueAbsolute, 3);
            Assert.Equal(index.Properties.EstimatedImpact[0].ChangeValueRelative, null);
            Assert.Equal(index.Properties.ReportedImpact[0].Name, "space_change");
            Assert.Equal(index.Properties.ReportedImpact[0].Unit, "megabytes");
            Assert.Equal(index.Properties.ReportedImpact[0].ChangeValueAbsolute, null);
            Assert.Equal(index.Properties.ReportedImpact[0].ChangeValueRelative, null);
        }
    }
}

