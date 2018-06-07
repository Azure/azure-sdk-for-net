using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class ElasticJobAgentScenarioTests
    {
        /// <summary>
        /// Test end to end agent
        /// </summary>
        [Fact]
        public void TestCreateUpdateDropAgent()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                try
                {
                    // Create database only required parameters
                    string dbName = SqlManagementTestUtilities.GenerateName();
                    var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                    {
                        Location = server.Location,
                    });
                    Assert.NotNull(db1);

                    // Create agent
                    string agentName = "agent1";
                    var agent1 = sqlClient.JobAgents.CreateOrUpdate(resourceGroup.Name, server.Name, agentName, new JobAgent
                    {
                        Location = server.Location,
                        DatabaseId = db1.Id
                    });

                    // Update agent tags
                    agent1 = sqlClient.JobAgents.CreateOrUpdate(resourceGroup.Name, server.Name, agentName, new JobAgent
                    {
                        Location = server.Location,
                        DatabaseId = db1.Id,
                        Tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    }
                    });

                    // Get agent
                    agent1 = sqlClient.JobAgents.Get(resourceGroup.Name, server.Name, agentName);

                    // List agents
                    var agents = sqlClient.JobAgents.ListByServer(resourceGroup.Name, server.Name);

                    // Delete agent
                    sqlClient.JobAgents.Delete(resourceGroup.Name, server.Name, agentName);
                }
                finally
                {
                    // Clean up
                    context.DeleteResourceGroup(resourceGroup.Name);
                }
            }
        }

        /// <summary>
        /// Tests end to end job credential
        /// </summary>
        [Fact]
        public void TestCreateUpdateDropJobCredential()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                try
                {
                    // Create database only required parameters
                    string dbName = SqlManagementTestUtilities.GenerateName();
                    var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                    {
                        Location = server.Location,
                    });
                    Assert.NotNull(db1);

                    // Create agent
                    string agentName = "agent";

                    JobAgent agent = sqlClient.JobAgents.CreateOrUpdate(resourceGroup.Name, server.Name, agentName, new JobAgent
                    {
                        Location = server.Location,
                        DatabaseId = db1.Id
                    });

                    // Create credential
                    JobCredential credential = sqlClient.JobCredentials.CreateOrUpdate(resourceGroup.Name, server.Name, agent.Name, SqlManagementTestUtilities.DefaultLogin, new JobCredential
                    {
                        Username = "a",
                        Password = "b!"
                    });


                    // Update credential
                    credential = sqlClient.JobCredentials.CreateOrUpdate(resourceGroup.Name, server.Name, agent.Name, SqlManagementTestUtilities.DefaultLogin, new JobCredential
                    {
                        Username = SqlManagementTestUtilities.DefaultLogin,
                        Password = SqlManagementTestUtilities.DefaultPassword
                    });

                    // List credentials
                    sqlClient.JobCredentials.ListByAgent(resourceGroup.Name, server.Name, agent.Name);

                    // Delete credential
                    sqlClient.JobCredentials.Delete(resourceGroup.Name, server.Name, agent.Name, credential.Name);
                }
                finally
                {
                    // Clean up resource group
                    context.DeleteResourceGroup(resourceGroup.Name);
                }
            }
        }

        /// <summary>
        /// Tests end to end target group
        /// </summary>
        [Fact]
        public void TestCreateUpdateDropTargetGroup()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                try
                {
                    // Create database only required parameters
                    string dbName = SqlManagementTestUtilities.GenerateName();
                    var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                    {
                        Location = server.Location,
                    });
                    Assert.NotNull(db1);

                    // Create agent
                    string agentName = "agent";

                    JobAgent agent = sqlClient.JobAgents.CreateOrUpdate(resourceGroup.Name, server.Name, agentName, new JobAgent
                    {
                        Location = server.Location,
                        DatabaseId = db1.Id
                    });

                    // Create credential
                    JobCredential credential = sqlClient.JobCredentials.CreateOrUpdate(resourceGroup.Name, server.Name, agent.Name, SqlManagementTestUtilities.DefaultLogin, new JobCredential
                    {
                        Username = SqlManagementTestUtilities.DefaultLogin,
                        Password = SqlManagementTestUtilities.DefaultPassword
                    });

                    // Create target group
                    JobTargetGroup targetGroup = sqlClient.JobTargetGroups.CreateOrUpdate(resourceGroup.Name, server.Name, agent.Name, "tg1", new JobTargetGroup
                    {
                        Members = new List<JobTarget>
                        {
                            // server target
                            new JobTarget
                            {
                                ServerName = "s1",
                                Type = JobTargetType.SqlServer,
                                RefreshCredential = credential.Id,
                                MembershipType = JobTargetGroupMembershipType.Include,
                            }
                        }
                    });

                    // Update target group with each type of target
                    targetGroup = sqlClient.JobTargetGroups.CreateOrUpdate(resourceGroup.Name, server.Name, agent.Name, "tg1", new JobTargetGroup
                    {
                        Members = new List<JobTarget>
                        {
                            // server target
                            new JobTarget
                            {
                                ServerName = "s1",
                                Type = JobTargetType.SqlServer,
                                RefreshCredential = credential.Id,
                                MembershipType = JobTargetGroupMembershipType.Include,
                            },
                            // db target
                            new JobTarget
                            {
                                DatabaseName = "db1",
                                ServerName = "s1",
                                Type = JobTargetType.SqlDatabase,
                                MembershipType = JobTargetGroupMembershipType.Include,
                            },
                            // shard map target
                            new JobTarget
                            {
                                ShardMapName = "sm1",
                                DatabaseName = "db1",
                                ServerName = "s1",
                                RefreshCredential = credential.Id,
                                Type = JobTargetType.SqlShardMap,
                                MembershipType = JobTargetGroupMembershipType.Exclude,
                            },
                            // elastic pool target
                            new JobTarget
                            {
                                ElasticPoolName = "ep1",
                                ServerName = "s1",
                                RefreshCredential = credential.Id,
                                Type = JobTargetType.SqlElasticPool,
                                MembershipType = JobTargetGroupMembershipType.Exclude,
                            },
                        }
                    });

                    // List target groups
                    sqlClient.JobTargetGroups.ListByAgent(resourceGroup.Name, server.Name, agent.Name);

                    // Delete target group
                    sqlClient.JobTargetGroups.Delete(resourceGroup.Name, server.Name, agent.Name, targetGroup.Name);
                }
                finally
                {
                    context.DeleteResourceGroup(resourceGroup.Name);
                }
            }
        }

        /// <summary>
        /// Tests end to end job
        /// </summary>
        [Fact]
        public void TestCreateUpdateDropJob()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                try
                {
                    // Create database only required parameters
                    string dbName = SqlManagementTestUtilities.GenerateName();
                    var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                    {
                        Location = server.Location,
                    });
                    Assert.NotNull(db1);

                    // Create agent
                    string agentName = "agent";

                    JobAgent agent = sqlClient.JobAgents.CreateOrUpdate(resourceGroup.Name, server.Name, agentName, new JobAgent
                    {
                        Location = server.Location,
                        DatabaseId = db1.Id
                    });

                    // Create job that repeats every 5 min from now. Starting now and ending in a day.
                    Job job1 = sqlClient.Jobs.CreateOrUpdate(resourceGroup.Name, server.Name, agent.Name, "job1", new Job
                    {
                        Description = "Test description",
                        Schedule = new JobSchedule
                        {
                            Enabled = false,
                            StartTime = new DateTime(),
                            EndTime = new DateTime().AddDays(1),
                            Type = JobScheduleType.Recurring,
                            Interval = "PT5M"
                        }
                    });

                    // Update job to run once
                    job1 = sqlClient.Jobs.CreateOrUpdate(resourceGroup.Name, server.Name, agent.Name, "job1", new Job
                    {
                        Description = "Test description",
                        Schedule = new JobSchedule
                        {
                            Enabled = true,
                            Type = JobScheduleType.Once,
                        }
                    });

                    // List job
                    sqlClient.Jobs.ListByAgent(resourceGroup.Name, server.Name, agent.Name);

                    // Delete job
                    sqlClient.Jobs.Delete(resourceGroup.Name, server.Name, agent.Name, job1.Name);
                }
                finally
                {
                    context.DeleteResourceGroup(resourceGroup.Name);
                }
            }
        }

        /// <summary>
        /// Tests end to end job step
        /// </summary>
        [Fact]
        public void TestCreateUpdateDropJobStep()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                try
                {
                    // Create database only required parameters
                    string dbName = SqlManagementTestUtilities.GenerateName();
                    var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                    {
                        Location = server.Location,
                    });
                    Assert.NotNull(db1);

                    // Create agent
                    string agentName = "agent";

                    JobAgent agent = sqlClient.JobAgents.CreateOrUpdate(resourceGroup.Name, server.Name, agentName, new JobAgent
                    {
                        Location = server.Location,
                        DatabaseId = db1.Id
                    });


                    // Create credential
                    JobCredential credential = sqlClient.JobCredentials.CreateOrUpdate(resourceGroup.Name, server.Name, agent.Name, SqlManagementTestUtilities.DefaultLogin, new JobCredential
                    {
                        Username = SqlManagementTestUtilities.DefaultLogin,
                        Password = SqlManagementTestUtilities.DefaultPassword
                    });

                    // Create target group
                    JobTargetGroup targetGroup = sqlClient.JobTargetGroups.CreateOrUpdate(resourceGroup.Name, server.Name, agent.Name, "tg1", new JobTargetGroup
                    {
                        Members = new List<JobTarget>
                        {
                            // server target
                            new JobTarget
                            {
                                ServerName = server.Name,
                                Type = JobTargetType.SqlServer,
                                RefreshCredential = credential.Id,
                                MembershipType = JobTargetGroupMembershipType.Include,
                            }
                        }
                    });

                    // Create job that runs once
                    Job job1 = sqlClient.Jobs.CreateOrUpdate(resourceGroup.Name, server.Name, agent.Name, "job1", new Job
                    {
                        Description = "Test description",
                        Schedule = new JobSchedule
                        {
                            Enabled = true,
                            Type = JobScheduleType.Once,
                        }
                    });

                    // Create step with min params
                    JobStep step1 = sqlClient.JobSteps.CreateOrUpdate(resourceGroup.Name, server.Name, agent.Name, job1.Name, "step1", new JobStep
                    {
                        Credential = credential.Id,
                        Action = new JobStepAction
                        {
                            Value = "SELECT 1"
                        },
                        TargetGroup = targetGroup.Id
                    });



                    // Update step with max params
                    step1 = sqlClient.JobSteps.CreateOrUpdate(resourceGroup.Name, server.Name, agent.Name, job1.Name, "step1", new JobStep
                    {
                        Credential = credential.Id,
                        Action = new JobStepAction
                        {
                            Value = "SELECT 1",
                            Source = "Inline",
                            Type = "TSql"
                        },
                        TargetGroup = targetGroup.Id,
                        ExecutionOptions = new JobStepExecutionOptions
                        {
                            InitialRetryIntervalSeconds = 100,
                            MaximumRetryIntervalSeconds = 1000,
                            RetryAttempts = 1000,
                            RetryIntervalBackoffMultiplier = 1.5,
                            TimeoutSeconds = 10000
                        },
                        Output = new JobStepOutput
                        {
                            ResourceGroupName = "rg1",
                            ServerName = "s1",
                            DatabaseName = "db1",
                            SchemaName = "dbo",
                            TableName = "tbl",
                            SubscriptionId = new Guid(),
                            Credential = credential.Id,
                            Type = JobTargetType.SqlDatabase
                        }
                    });


                    // List steps by job
                    sqlClient.JobSteps.ListByJob(resourceGroup.Name, server.Name, agent.Name, job1.Name);

                    // Delete job step
                    sqlClient.JobSteps.Delete(resourceGroup.Name, server.Name, agent.Name, job1.Name, step1.Name);
                }
                finally
                {
                    context.DeleteResourceGroup(resourceGroup.Name);
                }
            }
        }


        /// <summary>
        /// Tests end to end job execution
        /// </summary>
        [Fact]
        public void TestStartStopGetJobExecution()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);

                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                try
                {
                    // Allow all conenctions for test
                    sqlClient.FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, "allowAll", new FirewallRule
                    {
                        StartIpAddress = "0.0.0.0",
                        EndIpAddress = "255.255.255.255",
                    });

                    // Create database only required parameters
                    string dbName = SqlManagementTestUtilities.GenerateName();
                    var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                    {
                        Location = server.Location,
                    });
                    Assert.NotNull(db1);

                    // Create agent
                    string agentName = "agent";

                    JobAgent agent = sqlClient.JobAgents.CreateOrUpdate(resourceGroup.Name, server.Name, agentName, new JobAgent
                    {
                        Location = server.Location,
                        DatabaseId = db1.Id
                    });


                    // Create credential
                    JobCredential credential = sqlClient.JobCredentials.CreateOrUpdate(resourceGroup.Name, server.Name, agent.Name, SqlManagementTestUtilities.DefaultLogin, new JobCredential
                    {
                        Username = SqlManagementTestUtilities.DefaultLogin,
                        Password = SqlManagementTestUtilities.DefaultPassword
                    });


                    // Create target group
                    JobTargetGroup targetGroup = sqlClient.JobTargetGroups.CreateOrUpdate(resourceGroup.Name, server.Name, agent.Name, "tg1", new JobTargetGroup
                    {
                        Members = new List<JobTarget>
                        {
                            // server target
                            new JobTarget
                            {
                                ServerName = server.Name,
                                DatabaseName = db1.Name,
                                Type = JobTargetType.SqlDatabase,
                                MembershipType = JobTargetGroupMembershipType.Include,
                            }
                        }
                    });

                    // Create job that runs once
                    Job job1 = sqlClient.Jobs.CreateOrUpdate(resourceGroup.Name, server.Name, agent.Name, "job1", new Job
                    {
                        Description = "Test description",
                        Schedule = new JobSchedule
                        {
                            Enabled = true,
                            Type = JobScheduleType.Once,
                        }
                    });

                    // Create job step
                    JobStep step1 = sqlClient.JobSteps.CreateOrUpdate(resourceGroup.Name, server.Name, agent.Name, job1.Name, "step1", new JobStep
                    {
                        Credential = credential.Id,
                        Action = new JobStepAction
                        {
                            Value = "SELECT 1"
                        },
                        TargetGroup = targetGroup.Id
                    });


                    // Create job execution from job1 - do sync so we can be sure a step execution succeeds
                    JobExecution jobExecution = sqlClient.JobExecutions.Create(resourceGroup.Name, server.Name, agent.Name, job1.Name);

                    // List executions by agent
                    sqlClient.JobExecutions.ListByAgent(resourceGroup.Name, server.Name, agent.Name);

                    // List executions by job
                    sqlClient.JobExecutions.ListByJob(resourceGroup.Name, server.Name, agent.Name, job1.Name);

                    // Get root job execution
                    jobExecution = sqlClient.JobExecutions.Get(resourceGroup.Name, server.Name, agent.Name, job1.Name, jobExecution.JobExecutionId.Value);

                    // List step executions by root execution
                    sqlClient.JobStepExecutions.ListByJobExecution(resourceGroup.Name, server.Name, agent.Name, job1.Name, jobExecution.JobExecutionId.Value);

                    // Get step1 execution
                    sqlClient.JobStepExecutions.Get(resourceGroup.Name, server.Name, agent.Name, job1.Name, jobExecution.JobExecutionId.Value, step1.Name);

                    // List target executions by root job execution
                    sqlClient.JobTargetExecutions.ListByJobExecution(resourceGroup.Name, server.Name, agent.Name, job1.Name, jobExecution.JobExecutionId.Value);
                    
                    // List target executions by job step
                    IPage<JobExecution> targetStepExecutions = sqlClient.JobTargetExecutions.ListByStep(resourceGroup.Name, server.Name, agent.Name, job1.Name, jobExecution.JobExecutionId.Value, step1.Name);
                    Assert.Single(targetStepExecutions);

                    // Get target execution
                    sqlClient.JobTargetExecutions.Get(resourceGroup.Name, server.Name, agent.Name, job1.Name, jobExecution.JobExecutionId.Value, step1.Name, Guid.Parse(targetStepExecutions.FirstOrDefault().Name));

                    // Cancel the job execution
                    sqlClient.JobExecutions.Cancel(resourceGroup.Name, server.Name, agent.Name, job1.Name, jobExecution.JobExecutionId.Value);
                }
                finally
                {
                    context.DeleteResourceGroup(resourceGroup.Name);
                }
            }
        }
    }
}