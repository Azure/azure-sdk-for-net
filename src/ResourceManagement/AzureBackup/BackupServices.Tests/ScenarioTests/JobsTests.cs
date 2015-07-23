using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;
using System.Configuration;
using System;

namespace BackupServices.Tests
{
    public class JobsTests : BackupServicesTestsBase
    {
        [Fact]
        public void ListGetJobsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetServiceClient<BackupServicesManagementClient>();
                var queryParams = new CSMJobQueryObject()
                {
                    StartTime = DateTime.UtcNow.AddDays(-50).ToString("yyyy-MM-dd hh:mm:ss tt"),
                    EndTime = DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss tt"),
                    Operation = "Register"
                };

                // TODO: Trigger a backup and test the job created.
                var response = client.Job.ListAsync(queryParams, GetCustomRequestHeaders()).Result.List.Value;

                Assert.NotNull(response);
                foreach(var job in response)
                {
                    ValidateJobResponse(job);
                }
            }
        }

        [Fact]
        public void GetJobDetailsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetServiceClient<BackupServicesManagementClient>();
                var queryParams = new CSMJobQueryObject()
                {
                    StartTime = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-dd hh:mm:ss tt"),
                    EndTime = DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss tt")
                };

                var jobResponse = client.Job.ListAsync(queryParams, GetCustomRequestHeaders()).Result.List.Value;
                var response = client.Job.GetAsync(jobResponse[0].Name, GetCustomRequestHeaders()).Result.Value;

                Assert.NotNull(response);
                ValidateJobDetailsResponse(response);
            }
        }

        //[Fact]
        //public void CancelJobTest()
        //{
        //    using (UndoContext context = UndoContext.Current)
        //    {
        //        context.Start();
        //        var client = GetServiceClient<BackupServicesManagementClient>();

        //        string containerName = ConfigurationManager.AppSettings["ContainerName"];
        //        string dataSourceType = ConfigurationManager.AppSettings["DataSourceType"];
        //        string dataSourceId = ConfigurationManager.AppSettings["DataSourceId"];

        //        var backupResponse = client.BackUp.TriggerBackUpAsync(GetCustomRequestHeaders(), containerName, dataSourceType, dataSourceId).Result;

        //        var opStatus = client.OperationStatus.GetAsync(backupResponse.OperationId.ToString(), GetCustomRequestHeaders()).Result;
        //        while (opStatus.OperationStatus != "Completed")
        //        {
        //            opStatus = client.OperationStatus.GetAsync(backupResponse.OperationId.ToString(), GetCustomRequestHeaders()).Result;
        //        }

        //        var queryParams = new CSMJobQueryObject()
        //        {
        //            StartTime = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-dd hh:mm:ss tt"),
        //            EndTime = DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss tt"),
        //            Status = "InProgress",
        //            Operation = "Backup"
        //        };

        //        var jobResponse = client.Job.ListAsync(queryParams, GetCustomRequestHeaders()).Result.List.Value;
        //        var opId = client.Job.StopAsync(jobResponse[0].Name, GetCustomRequestHeaders()).Result;

        //        // TODO: Wait till the WF completes
        //        opStatus = client.OperationStatus.GetAsync(opId.OperationId.ToString(), GetCustomRequestHeaders()).Result;
        //        while(opStatus.OperationStatus != "Completed")
        //        {
        //            opStatus = client.OperationStatus.GetAsync(opId.OperationId.ToString(), GetCustomRequestHeaders()).Result;
        //        }
        //        var response = client.Job.GetAsync(jobResponse[0].Name, GetCustomRequestHeaders()).Result.Value;
        //        // TODO: Remove this hack once backend is upgraded.
        //        while(response.JobDetailedProperties.Status.CompareTo("InProgress") == 0)
        //        {
        //            response = client.Job.GetAsync(jobResponse[0].Name, GetCustomRequestHeaders()).Result.Value;
        //        }
        //        Assert.True((response.JobDetailedProperties.Status.CompareTo("Cancelled") == 0) || (response.JobDetailedProperties.Status.CompareTo("Cancelling") == 0));
        //    }
        //}

        private void ValidateJobResponse(CSMJobResponse response)
        {
            Assert.True(response.Name != null, "JobID cannot be null");
        }

        private void ValidateJobProperties(CSMJobProperties props)
        {
            Assert.True(props.Duration != TimeSpan.Zero, "Duration should be > 0");
            Assert.True(props.EntityFriendlyName != null, "Entity friendly name shouldn't be null");
            Assert.True(props.Operation != null, "Operation of the job can't be null");
            Assert.True(props.Status != null, "Status can't be null");
            Assert.True(props.WorkloadType != null, "WorkloadType can't be null");
            Assert.True(props.StartTimestamp != DateTime.MinValue, "StartTime can't be DateTime.MinValue");
        }

        private void ValidateJobDetailsResponse(CSMJobDetailsResponse response)
        {
            ValidateJobProperties(response.JobDetailedProperties);
            Assert.True(response.Name != null, "JobID cannot be null");
            Assert.True(response.JobDetailedProperties.PropertyBag != null, "Property bag can't be null");
            Assert.True(response.JobDetailedProperties.TasksList != null, "Subtasks can't be null");
        }
    }
}
