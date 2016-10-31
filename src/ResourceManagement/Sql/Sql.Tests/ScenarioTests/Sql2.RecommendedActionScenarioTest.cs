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
using Microsoft.Data.Edm;
using Xunit;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for Server, Elastic Pool and Database RecommendedActions
    /// </summary>
    public class Sql2RecommendedActionScenarioTests : TestBase
    {
        private const string ResourceGroupName = "WIRunnersProd";
        private const string ServerName = "wi-runner-australia-east";
        private const string DatabaseName = "WIRunner";
        private const string ElasticPoolName = "WIRunnerPool";
        private const string AdvisorName = "CreateIndex";
        private const string RecommendedActionName = "IR_[test_schema]_[test_table_0.0361551]_6C7AE8CC9C87E7FD5893";

        private const string ServerRecommendedActionType = "Microsoft.Sql/servers/advisors/recommendedActions";
        private const string DatabaseRecommendedActionType = "Microsoft.Sql/servers/databases/advisors/recommendedActions";
        private const string ElasticPoolRecommendedActionType = "Microsoft.Sql/servers/elasticPools/advisors/recommendedActions";

        /// <summary>
        /// Test for list server recommended actions request
        /// </summary>
        [Fact]
        public void ListRecommendedActionsForServerAdvisor()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.ServerRecommendedActions.List(ResourceGroupName, ServerName, AdvisorName);

                ValidateRecommendedActionList(response.RecommendedActions, ServerRecommendedActionType);
            }
        }

        /// <summary>
        /// Test for get server recommended action request
        /// </summary>
        [Fact]
        public void GetSingleRecommendedActionForServerAdvisor()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.ServerRecommendedActions.Get(ResourceGroupName, ServerName, AdvisorName, RecommendedActionName);

                ValidateSingleRecommendedAction(response.RecommendedAction, ServerRecommendedActionType);
            }
        }

        /// <summary>
        /// Test for update state of server recommended action
        /// </summary>
        [Fact]
        public void UpdateServerRecommendedActionState()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                RecommendedActionUpdateParameters updateParameters = new RecommendedActionUpdateParameters()
                {
                    Properties = new RecommendedActionUpdateProperties()
                    {
                        State = new RecommendedActionUpdateStateInfo()
                        {
                            CurrentValue = "Pending"
                        }
                    }
                };

                var response = sqlClient.ServerRecommendedActions.Update(ResourceGroupName, ServerName, AdvisorName, RecommendedActionName, updateParameters);
                ValidateSingleRecommendedAction(response.RecommendedAction, ServerRecommendedActionType, expectedState: "Pending");
            }
        }

        /// <summary>
        /// Test for list database recommended actions request
        /// </summary>
        [Fact]
        public void ListRecommendedActionsForDatabaseAdvisor()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.DatabaseRecommendedActions.List(ResourceGroupName, ServerName, DatabaseName, AdvisorName);

                ValidateRecommendedActionList(response.RecommendedActions, DatabaseRecommendedActionType);
            }
        }

        /// <summary>
        /// Test for get database recommended action request
        /// </summary>
        [Fact]
        public void GetSingleRecommendedActionForDatabaseAdvisor()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.DatabaseRecommendedActions.Get(ResourceGroupName, ServerName, DatabaseName, AdvisorName, RecommendedActionName);

                ValidateSingleRecommendedAction(response.RecommendedAction, DatabaseRecommendedActionType);
            }
        }

        /// <summary>
        /// Test for update state of database recommended action
        /// </summary>
        [Fact]
        public void UpdateDatabaseRecommendedActionState()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                RecommendedActionUpdateParameters updateParameters = new RecommendedActionUpdateParameters()
                {
                    Properties = new RecommendedActionUpdateProperties()
                    {
                        State = new RecommendedActionUpdateStateInfo()
                        {
                            CurrentValue = "Pending"
                        }
                    }
                };

                var response = sqlClient.DatabaseRecommendedActions.Update(ResourceGroupName, ServerName, DatabaseName, AdvisorName, RecommendedActionName, updateParameters);
                ValidateSingleRecommendedAction(response.RecommendedAction, DatabaseRecommendedActionType, expectedState: "Pending");
            }
        }

        /// <summary>
        /// Test for list elastic pool recommended actions request
        /// </summary>
        [Fact]
        public void ListRecommendedActionsForElasticPoolAdvisor()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.ElasticPoolRecommendedActions.List(ResourceGroupName, ServerName, ElasticPoolName, AdvisorName);

                ValidateRecommendedActionList(response.RecommendedActions, ElasticPoolRecommendedActionType);
            }
        }

        /// <summary>
        /// Test for get elastic pool recommended action request
        /// </summary>
        [Fact]
        public void GetSingleRecommendedActionForElasticPoolAdvisor()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var response = sqlClient.ElasticPoolRecommendedActions.Get(ResourceGroupName, ServerName, ElasticPoolName, AdvisorName, RecommendedActionName);

                ValidateSingleRecommendedAction(response.RecommendedAction, ElasticPoolRecommendedActionType);
            }
        }

        /// <summary>
        /// Test for update state of elastic pool recommended action
        /// </summary>
        [Fact]
        public void UpdateElasticPoolRecommendedActionState()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var handler = new BasicDelegatingHandler();
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                RecommendedActionUpdateParameters updateParameters = new RecommendedActionUpdateParameters()
                {
                    Properties = new RecommendedActionUpdateProperties()
                    {
                        State = new RecommendedActionUpdateStateInfo()
                        {
                            CurrentValue = "Pending"
                        }
                    }
                };

                var response = sqlClient.ElasticPoolRecommendedActions.Update(ResourceGroupName, ServerName, ElasticPoolName, AdvisorName, RecommendedActionName, updateParameters);
                ValidateSingleRecommendedAction(response.RecommendedAction, ElasticPoolRecommendedActionType, expectedState: "Pending");
            }
        }

        /// <summary>
        /// Validates list of recommended actions
        /// </summary>
        private static void ValidateRecommendedActionList(IList<RecommendedAction> responseList, string expectedResponseType)
        {
            Assert.NotNull(responseList);
            IList<RecommendedAction> expectedList = CreateRecommendedActionListForValidation();

            Assert.Equal(expectedList.Count, responseList.Count);
            foreach (var response in responseList)
            {
                ValidateSingleRecommendedAction(response, expectedResponseType);
            }
        }

        /// <summary>
        /// Validates single recommended action object
        /// </summary>
        private static void ValidateSingleRecommendedAction(RecommendedAction response, string expectedResponseType, string expectedState = null)
        {
            Assert.NotNull(response);

            RecommendedAction expected = CreateRecommendedActionListForValidation().SingleOrDefault(a => a.Name.Equals(response.Name));
            Assert.NotNull(expected);

            Assert.Equal(expectedResponseType, response.Type);
            CompareRecommendedActionProperties(expected, response, expectedState);
        }

        /// <summary>
        /// Creates a list of Recommended Action objects for validating responses.
        /// </summary>
        private static List<RecommendedAction> CreateRecommendedActionListForValidation()
        {
            return new List<RecommendedAction>()
            {
                new RecommendedAction()
                {
                    Name = "IR_[test_schema]_[test_table_0.0361551]_6C7AE8CC9C87E7FD5893",
                    Properties = new RecommendedActionProperties()
                    {
                        RecommendationReason = "",
                        ValidSince = DateTime.Parse("2016-04-21T15:24:47Z").ToUniversalTime(),
                        LastRefresh = DateTime.Parse("2016-04-21T15:24:47Z").ToUniversalTime(),
                        State = new RecommendedActionStateInfo()
                        {
                            CurrentValue = "Success",
                            ActionInitiatedBy = "User",
                            LastModified = DateTime.Parse("2016-04-21T15:24:47Z").ToUniversalTime()
                        },
                        IsExecutableAction = true,
                        IsRevertableAction = true,
                        IsArchivedAction = false,
                        ExecuteActionStartTime = DateTime.Parse("2016-04-21T15:24:47Z").ToUniversalTime(),
                        ExecuteActionDuration = "PT1M",
                        ExecuteActionInitiatedBy = "User",
                        ExecuteActionInitiatedTime = DateTime.Parse("2016-04-21T15:24:47Z").ToUniversalTime(),
                        Score = 2,
                        ImplementationDetails = new RecommendedActionImplementationInfo()
                        {
                            Method = "TSql",
                            Script = "CREATE NONCLUSTERED INDEX [nci_wi_test_table_0.0361551_6C7AE8CC9C87E7FD5893] ON [test_schema].[test_table_0.0361551] ([index_1],[index_2],[index_3]) INCLUDE ([included_1]) WITH (ONLINE = ON)"
                        },
                        ErrorDetails = new RecommendedActionErrorInfo(),
                        EstimatedImpact = new[]
                        {
                            new RecommendedActionImpactInfo()
                            {
                                DimensionName = "ActionDuration",
                                Unit = "Seconds",
                                AbsoluteValue = 343
                            },
                            new RecommendedActionImpactInfo()
                            {
                                DimensionName = "SpaceChange",
                                Unit = "Megabytes",
                                AbsoluteValue = 0.05578900124594545
                            }
                        },
                        ObservedImpact = new[]
                        {
                            new RecommendedActionImpactInfo()
                            {
                                DimensionName = "CpuUtilization",
                                Unit = "CpuCores",
                                ChangeValueAbsolute = 0.5,
                                ChangeValueRelative = 0.1
                            }
                        },
                        TimeSeries = new RecommendedActionMetricInfo[] {},
                        Details = new Dictionary<string, object>()
                        {
                            {"indexName", "nci_wi_test_table_0.0361551_6C7AE8CC9C87E7FD5893"},
                            {"indexType", "NONCLUSTERED"},
                            {"schema", "[test_schema]"},
                            {"table", "[test_table_0.0361551]"},
                            {"indexColumns", "[index_1],[index_2],[index_3]"},
                            {"benefit", 2},
                            {"includedColumns", "[included_1]"},
                            {"indexActionStartTime", "2016-04-21T15:24:47.583"},
                            {"indexActionDuration", "00:01:00"}
                        }
                    },
                },
                new RecommendedAction()
                {
                    Name = "IR_[test_schema]_[test_table_0.756532]_6C7AE8CC9C87E7FD5893",
                    Properties = new RecommendedActionProperties()
                    {
                        RecommendationReason = "",
                        ValidSince = DateTime.Parse("2016-04-21T15:24:47Z").ToUniversalTime(),
                        LastRefresh = DateTime.Parse("2016-04-21T15:24:47Z").ToUniversalTime(),
                        State = new RecommendedActionStateInfo()
                        {
                            CurrentValue = "Error",
                            ActionInitiatedBy = "User",
                            LastModified = DateTime.Parse("2016-04-21T15:24:47Z").ToUniversalTime()
                        },
                        IsExecutableAction = true,
                        IsRevertableAction = true,
                        IsArchivedAction = false,
                        ExecuteActionStartTime = DateTime.Parse("2016-04-21T15:24:47Z").ToUniversalTime(),
                        ExecuteActionDuration = "PT1M",
                        ExecuteActionInitiatedBy = "User",
                        ExecuteActionInitiatedTime = DateTime.Parse("2016-04-21T15:24:47Z").ToUniversalTime(),
                        Score = 2,
                        ImplementationDetails = new RecommendedActionImplementationInfo()
                        {
                            Method = "TSql",
                            Script = "CREATE NONCLUSTERED INDEX [nci_wi_test_table_0.756532_6C7AE8CC9C87E7FD5893] ON [test_schema].[test_table_0.756532] ([index_1],[index_2],[index_3]) INCLUDE ([included_1]) WITH (ONLINE = ON)"
                        },
                        ErrorDetails = new RecommendedActionErrorInfo()
                        {
                            ErrorCode = "UnknownInfraError",
                            IsRetryable = "No"
                        },
                        EstimatedImpact = new[]
                        {
                            new RecommendedActionImpactInfo()
                            {
                                DimensionName = "ActionDuration",
                                Unit = "Seconds",
                                AbsoluteValue = 599
                            },
                            new RecommendedActionImpactInfo()
                            {
                                DimensionName = "SpaceChange",
                                Unit = "Megabytes",
                                AbsoluteValue = 0.09490018314321796
                            }
                        },
                        ObservedImpact = new[]
                        {
                            new RecommendedActionImpactInfo()
                            {
                                DimensionName = "SpaceChange",
                                Unit = "Megabytes",
                                AbsoluteValue = 4.882812
                            }
                        },
                        TimeSeries = new RecommendedActionMetricInfo[] {},
                        Details = new Dictionary<string, object>()
                        {
                            {"indexName", "nci_wi_test_table_0.756532_6C7AE8CC9C87E7FD5893"},
                            {"indexType", "NONCLUSTERED"},
                            {"schema", "[test_schema]"},
                            {"table", "[test_table_0.756532]"},
                            {"indexColumns", "[index_1],[index_2],[index_3]"},
                            {"benefit", 2},
                            {"includedColumns", "[included_1]"},
                            {"indexActionStartTime", "2016-04-21T15:24:47.583"},
                            {"indexActionDuration", "00:01:00"}
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Compares properties of expected and response
        /// </summary>
        private static void CompareRecommendedActionProperties(RecommendedAction expected, RecommendedAction response, string expectedState = null)
        {
            Assert.Equal(expected.Properties.RecommendationReason, response.Properties.RecommendationReason);
            Assert.Equal(expected.Properties.ValidSince, response.Properties.ValidSince);
            Assert.Equal(expected.Properties.LastRefresh, response.Properties.LastRefresh);
            Assert.Equal(expected.Properties.State.ActionInitiatedBy, response.Properties.State.ActionInitiatedBy);
            Assert.Equal(expectedState ?? expected.Properties.State.CurrentValue, response.Properties.State.CurrentValue);
            Assert.Equal(expected.Properties.State.LastModified, response.Properties.State.LastModified);

            Assert.Equal(expected.Properties.IsExecutableAction, response.Properties.IsExecutableAction);
            Assert.Equal(expected.Properties.IsRevertableAction, response.Properties.IsRevertableAction);
            Assert.Equal(expected.Properties.IsArchivedAction, response.Properties.IsArchivedAction);

            Assert.Equal(expected.Properties.ExecuteActionStartTime, response.Properties.ExecuteActionStartTime);
            Assert.Equal(expected.Properties.ExecuteActionDuration, response.Properties.ExecuteActionDuration);
            Assert.Equal(expected.Properties.RevertActionStartTime, response.Properties.RevertActionStartTime);
            Assert.Equal(expected.Properties.RevertActionDuration, response.Properties.RevertActionDuration);

            Assert.Equal(expected.Properties.ExecuteActionInitiatedBy, response.Properties.ExecuteActionInitiatedBy);
            Assert.Equal(expected.Properties.ExecuteActionInitiatedTime, response.Properties.ExecuteActionInitiatedTime);
            Assert.Equal(expected.Properties.RevertActionInitiatedBy, response.Properties.RevertActionInitiatedBy);
            Assert.Equal(expected.Properties.RevertActionInitiatedTime, response.Properties.RevertActionInitiatedTime);
            Assert.Equal(expected.Properties.Score, response.Properties.Score);

            CompareRecommendedActionImplementationInfo(expected.Properties.ImplementationDetails, response.Properties.ImplementationDetails);
            CompareRecommendedActionErrorInfo(expected.Properties.ErrorDetails, response.Properties.ErrorDetails);
            CompareRecommendedActionImpactInfo(expected.Properties.EstimatedImpact, response.Properties.EstimatedImpact);
            CompareRecommendedActionImpactInfo(expected.Properties.ObservedImpact, response.Properties.ObservedImpact);
            CompareRecommendedActionMetricInfo(expected.Properties.TimeSeries, response.Properties.TimeSeries);
            CompareRecommendedActionLinkedObjects(expected.Properties.LinkedObjects, response.Properties.LinkedObjects);
            CompareRecommendedActionDetails(expected.Properties.Details, response.Properties.Details);
        }

        /// <summary>
        /// Compares ErrorInfo details of recommendation action entity
        /// </summary>
        private static void CompareRecommendedActionErrorInfo(RecommendedActionErrorInfo expected, RecommendedActionErrorInfo response)
        {
            Assert.False(expected != null ^ response != null);

            if (response != null)
            {
                Assert.Equal(expected.ErrorCode, response.ErrorCode);
                Assert.Equal(expected.IsRetryable, response.IsRetryable);
            }
        }

        /// <summary>
        /// Compare Implementation details of recommendation action entity
        /// </summary>
        private static void CompareRecommendedActionImplementationInfo(RecommendedActionImplementationInfo expected, RecommendedActionImplementationInfo response)
        {
            Assert.False(expected != null ^ response != null);

            if (response != null)
            {
                Assert.Equal(expected.Script, response.Script);
                Assert.Equal(expected.Method, response.Method);
            }
        }

        /// <summary>
        /// Compare Impact details of recommendation action entity
        /// </summary>
        private static void CompareRecommendedActionImpactInfo(IList<RecommendedActionImpactInfo> expected, IList<RecommendedActionImpactInfo> response)
        {
            Assert.False(expected != null ^ response != null);

            if (response != null)
            {
                Assert.Equal(expected.Count, response.Count());

                foreach (RecommendedActionImpactInfo expectedImpact in expected)
                {
                    RecommendedActionImpactInfo responseImpact = response.FirstOrDefault(r => r.DimensionName == expectedImpact.DimensionName);
                    Assert.NotNull(responseImpact);
                    Assert.Equal(expectedImpact.DimensionName, responseImpact.DimensionName);
                    Assert.Equal(expectedImpact.Unit, responseImpact.Unit);
                    Assert.Equal(expectedImpact.AbsoluteValue, responseImpact.AbsoluteValue);
                    Assert.Equal(expectedImpact.ChangeValueAbsolute, responseImpact.ChangeValueAbsolute);
                    Assert.Equal(expectedImpact.ChangeValueRelative, responseImpact.ChangeValueRelative);
                }
            }
        }

        /// <summary>
        /// Comapre Time series details of recommendation action entity
        /// </summary>
        private static void CompareRecommendedActionMetricInfo(IList<RecommendedActionMetricInfo> expected, IList<RecommendedActionMetricInfo> response)
        {
            Assert.False(expected != null ^ response != null);

            if (response != null)
            {
                Assert.Equal(expected.Count, response.Count());

                foreach (RecommendedActionMetricInfo expectedMetric in expected)
                {
                    RecommendedActionMetricInfo responseMetric = response.FirstOrDefault(r => r.MetricName == expectedMetric.MetricName);
                    Assert.NotNull(responseMetric);
                    Assert.Equal(expectedMetric.MetricName, responseMetric.MetricName);
                    Assert.Equal(expectedMetric.Unit, responseMetric.Unit);
                    Assert.Equal(expectedMetric.StartTime, responseMetric.StartTime);
                    Assert.Equal(expectedMetric.TimeGrain.ToString(), responseMetric.TimeGrain);
                    Assert.Equal(expectedMetric.Value, responseMetric.Value);
                }
            }
        }

        /// <summary>
        /// Comapres linked Objects details of recommendation action entity
        /// </summary>
        private static void CompareRecommendedActionLinkedObjects(IList<string> expected, IEnumerable<string> response)
        {
            Assert.False(expected != null ^ response != null);

            if (response != null)
            {
                Assert.True(expected.SequenceEqual(response));
            }
        }

        /// <summary>
        /// Compares Additional details of recommendation action entity
        /// </summary>
        private static void CompareRecommendedActionDetails(IDictionary<string, object> expected, IDictionary<string, object> response)
        {
            Assert.False(expected != null ^ response != null);

            if (response != null)
            {
                Assert.Equal(expected.Keys.Count, response.Keys.Count);
                foreach (string key in expected.Keys)
                {
                    Assert.NotNull(key);
                }
            }
        }
    }
}

