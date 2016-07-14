using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Contains tests for Server, Elastic Pool and Database Advisors
    /// </summary>
    public class Sql2AdvisorScenarioTests : TestBase
    {
        private const string ResourceGroupName = "WIRunnersProd";
        private const string ServerName = "wi-runner-australia-east";
        private const string DatabaseName = "WIRunner";
        private const string ElasticPoolName = "WIRunnerPool";
        private const string AdvisorName = "CreateIndex";
        private const string ExpandKey = "recommendedActions";

        private const string ServerAdvisorType = "Microsoft.Sql/servers/advisors";
        private const string DatabaseAdvisorType = "Microsoft.Sql/servers/databases/advisors";
        private const string ElasticPoolAdvisorType = "Microsoft.Sql/servers/elasticPools/advisors";

        /// <summary>
        /// Test for list server advisors request
        /// </summary>
        [Fact]
        public void ListAdvisorsForServer()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.ServerAdvisors.List(ResourceGroupName, ServerName, expand: null);

                ValidateAdvisorList(response.Advisors, ServerAdvisorType);
            }
        }

        /// <summary>
        /// Test for list server advisors request expanded for recommended actions
        /// </summary>
        [Fact]
        public void ListAdvisorsForServerExpandedWithRecommendedActions()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.ServerAdvisors.List(ResourceGroupName, ServerName, expand: ExpandKey);

                ValidateAdvisorList(response.Advisors, ServerAdvisorType);
                ValidatePresenceOfRecommendedActions(response);
            }
        }

        /// <summary>
        /// Test for get server advisor request
        /// </summary>
        [Fact]
        public void GetSingleAdvisorForServer()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.ServerAdvisors.Get(ResourceGroupName, ServerName, AdvisorName, expand: null);

                ValidateSingleAdvisor(response.Advisor, ServerAdvisorType);
            }
        }

        /// <summary>
        /// Test for update status of server advisor request
        /// </summary>
        [Fact]
        public void UpdateStatusOfServerAdvisor()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                AdvisorUpdateParameters updateParameters = new AdvisorUpdateParameters()
                {
                    Properties = new AdvisorUpdateProperties()
                    {
                        AutoExecuteStatus = "Disabled"
                    }
                };

                var response = sqlClient.ServerAdvisors.Update(ResourceGroupName, ServerName, AdvisorName, updateParameters);
                ValidateSingleAdvisor(response.Advisor, ServerAdvisorType, expectedAutoExecuteStatus: "Disabled");
            }
        }

        /// <summary>
        /// Test for list database advisors request
        /// </summary>
        [Fact]
        public void ListAdvisorsForDatabase()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.DatabaseAdvisors.List(ResourceGroupName, ServerName, DatabaseName, expand: null);

                ValidateAdvisorList(response.Advisors, DatabaseAdvisorType);
            }
        }

        /// <summary>
        /// Test for list database advisors request expanded for recommended actions
        /// </summary>
        [Fact]
        public void ListAdvisorsForDatabaseExpandedWithRecommendedActions()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.DatabaseAdvisors.List(ResourceGroupName, ServerName, DatabaseName, expand: ExpandKey);

                ValidateAdvisorList(response.Advisors, DatabaseAdvisorType);
                ValidatePresenceOfRecommendedActions(response);
            }
        }

        /// <summary>
        /// Test for get database advisor request
        /// </summary>
        [Fact]
        public void GetSingleAdvisorForDatabase()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.DatabaseAdvisors.Get(ResourceGroupName, ServerName, DatabaseName, AdvisorName, expand: null);

                ValidateSingleAdvisor(response.Advisor, DatabaseAdvisorType);
            }
        }

        /// <summary>
        /// Test for update status of database advisor request
        /// </summary>
        [Fact]
        public void UpdateStatusOfDatabaseAdvisor()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                AdvisorUpdateParameters updateParameters = new AdvisorUpdateParameters()
                {
                    Properties = new AdvisorUpdateProperties()
                    {
                        AutoExecuteStatus = "Disabled"
                    }
                };

                var response = sqlClient.DatabaseAdvisors.Update(ResourceGroupName, ServerName, DatabaseName, AdvisorName, updateParameters);
                ValidateSingleAdvisor(response.Advisor, DatabaseAdvisorType, expectedAutoExecuteStatus: "Disabled");
            }
        }

        /// <summary>
        /// Test for list elastic pool advisors request
        /// </summary>
        [Fact]
        public void ListAdvisorsForElasticPool()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.ElasticPoolAdvisors.List(ResourceGroupName, ServerName, ElasticPoolName, expand: null);

                ValidateAdvisorList(response.Advisors, ElasticPoolAdvisorType);
            }
        }

        /// <summary>
        /// Test for list elastic pool advisors request expanded for recommended actions
        /// </summary>
        [Fact]
        public void ListAdvisorsForElasticPoolExpandedWithRecommendedActions()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.ElasticPoolAdvisors.List(ResourceGroupName, ServerName, ElasticPoolName, expand: ExpandKey);

                ValidateAdvisorList(response.Advisors, ElasticPoolAdvisorType);
                ValidatePresenceOfRecommendedActions(response);
            }
        }

        /// <summary>
        /// Test for get elastic pool advisor request
        /// </summary>
        [Fact]
        public void GetSingleAdvisorForElasticPool()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.ElasticPoolAdvisors.Get(ResourceGroupName, ServerName, ElasticPoolName, AdvisorName, expand: null);

                ValidateSingleAdvisor(response.Advisor, ElasticPoolAdvisorType);
            }
        }

        /// <summary>
        /// Test for update status of elastic pool advisor request
        /// </summary>
        [Fact]
        public void UpdateStatusOfElasticPoolAdvisor()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                AdvisorUpdateParameters updateParameters = new AdvisorUpdateParameters()
                {
                    Properties = new AdvisorUpdateProperties()
                    {
                        AutoExecuteStatus = "Disabled"
                    }
                };

                var response = sqlClient.ElasticPoolAdvisors.Update(ResourceGroupName, ServerName, ElasticPoolName, AdvisorName, updateParameters);
                ValidateSingleAdvisor(response.Advisor, ElasticPoolAdvisorType, expectedAutoExecuteStatus: "Disabled");
            }
        }

        /// <summary>
        /// Validates list of advisors
        /// </summary>
        private static void ValidateAdvisorList(IList<Advisor> responseList, string expectedResponseType)
        {
            Assert.NotNull(responseList);
            IList<Advisor> expectedList = CreateAdvisorListForValidation();

            Assert.Equal(expectedList.Count, responseList.Count);
            foreach (var response in responseList)
            {
                ValidateSingleAdvisor(response, expectedResponseType);
            }
        }

        /// <summary>
        /// Validates single advisor object
        /// </summary>
        private static void ValidateSingleAdvisor(Advisor response, string expectedAdvisorType, string expectedAutoExecuteStatus = null)
        {
            Assert.NotNull(response);

            Advisor expected = CreateAdvisorListForValidation().SingleOrDefault(a => a.Name.Equals(response.Name));
            Assert.NotNull(expected);

            Assert.Equal(expectedAdvisorType, response.Type);
            CompareAdvisorProperties(expected, response, expectedAutoExecuteStatus);
        }

        /// <summary>
        /// Validates presence of recommended actions inside advisor objects, when expand call was made.
        /// </summary>
        private static void ValidatePresenceOfRecommendedActions(AdvisorListResponse response)
        {
            Assert.Equal(10, response.Advisors.Single(a => a.Name.Equals("CreateIndex")).Properties.RecommendedActions.Count);
            Assert.Equal(10, response.Advisors.Single(a => a.Name.Equals("DropIndex")).Properties.RecommendedActions.Count);
            Assert.Equal(0, response.Advisors.Single(a => a.Name.Equals("DbParameterization")).Properties.RecommendedActions.Count);
            Assert.Equal(0, response.Advisors.Single(a => a.Name.Equals("SchemaIssue")).Properties.RecommendedActions.Count);
        }

        private static void CompareAdvisorProperties(Advisor expected, Advisor response, string expectedAutoExecuteStatus = null)
        {
            Assert.Equal(expected.Properties.AdvisorStatus, response.Properties.AdvisorStatus);
            Assert.Equal(expectedAutoExecuteStatus ?? expected.Properties.AutoExecuteStatus, response.Properties.AutoExecuteStatus);
            Assert.Equal(expected.Properties.AutoExecuteStatusInheritedFrom, response.Properties.AutoExecuteStatusInheritedFrom);
            Assert.Equal(expected.Properties.RecommendationsStatus, response.Properties.RecommendationsStatus);
            Assert.Equal(expected.Properties.LastChecked, response.Properties.LastChecked);
        }

        /// <summary>
        /// Creates a list of Advisor objects for validating responses.
        /// </summary>
        private static List<Advisor> CreateAdvisorListForValidation()
        {
            return new List<Advisor>()
            {
                new Advisor()
                {
                    Name = "CreateIndex",
                    Properties = new AdvisorProperties()
                    {
                        AdvisorStatus = "GA",
                        AutoExecuteStatus = "Disabled",
                        AutoExecuteStatusInheritedFrom = "Database",
                        RecommendationsStatus = "Ok",
                        LastChecked = DateTime.Parse("2016-06-23T03:57:09Z").ToUniversalTime()
                    }
                },
                new Advisor()
                {
                    Name = "DropIndex",
                    Properties = new AdvisorProperties()
                    {
                        AdvisorStatus = "PublicPreview",
                        AutoExecuteStatus = "Disabled",
                        AutoExecuteStatusInheritedFrom = "Database",
                        RecommendationsStatus = "Ok",
                        LastChecked = DateTime.Parse("2016-06-22T18:34:42Z").ToUniversalTime()
                    }
                },
                new Advisor()
                {
                    Name = "DbParameterization",
                    Properties = new AdvisorProperties()
                    {
                        AdvisorStatus = "PublicPreview",
                        AutoExecuteStatus = "Disabled",
                        AutoExecuteStatusInheritedFrom = "Subscription",
                        RecommendationsStatus = "NoDbParameterizationIssue",
                        LastChecked = DateTime.Parse("2016-06-21T22:04:57Z").ToUniversalTime()
                    }
                },
                new Advisor()
                {
                    Name = "SchemaIssue",
                    Properties = new AdvisorProperties()
                    {
                        AdvisorStatus = "PublicPreview",
                        AutoExecuteStatus = "Disabled",
                        AutoExecuteStatusInheritedFrom = "Subscription",
                        RecommendationsStatus = "SchemaIsConsistent",
                        LastChecked = DateTime.Parse("2016-06-23T10:20:59Z").ToUniversalTime()
                    }
                },
            };
        }
    }
}

