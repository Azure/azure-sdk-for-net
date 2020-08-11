namespace HybridData.Tests.Tests
{
    using Microsoft.Azure.Management.HybridData;
    using Microsoft.Azure.Management.HybridData.Models;
    using System;
    using Xunit;
    using Xunit.Abstractions;

    public class JobsTest : HybridDataTestBase
    {
        string JobId;

        public JobsTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            JobDefinitionName = TestConstants.DefaultJobDefinitiontName;
            //JobId = "fd190bf4-9416-44ed-837d-3ab7fdfe5cf8";
        }

        //Jobs_Get
        [Fact]
        public void Jobs_Get()
        {
            try
            {
                JobId = "99ef93fe-36be-43e4-bebf-de6746730601";
                var job = Client.Jobs.Get(dataServiceName: DataServiceName,
                    jobDefinitionName: JobDefinitionName,
                    jobId: JobId,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                Assert.NotNull(job);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }
        //Jobs_Cancel
        [Fact]
        public void Jobs_Cancel()
        {
            try
            {
                JobId = "6eca9b3d-5ffe-4b44-9607-1ba838371ff7";
                Client.Jobs.BeginCancel(dataServiceName: DataServiceName,
                    jobDefinitionName: JobDefinitionName,
                    jobId: JobId,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                var job = Client.Jobs.Get(dataServiceName: DataServiceName,
                    jobDefinitionName: JobDefinitionName,
                    jobId: JobId,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                Assert.True(job.Status == JobStatus.Cancelled || job.Status == JobStatus.Cancelling);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //Jobs_Resume
        [Fact]
        public void Jobs_Resume()
        {
            JobId = "99ef93fe-36be-43e4-bebf-de6746730601";
            try
            {
                Client.Jobs.BeginResume(dataServiceName: DataServiceName,
                    jobDefinitionName: JobDefinitionName,
                    jobId: JobId,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                var job = Client.Jobs.Get(dataServiceName: DataServiceName,
                    jobDefinitionName: JobDefinitionName,
                    jobId: JobId,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                Assert.Equal(JobStatus.InProgress, job.Status);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }
        //Jobs_ListByJobDefinition
        [Fact]
        public void Jobs_ListByJobDefinition()
        {
            try
            {
                var jobList = Client.Jobs.ListByJobDefinition(
                    dataServiceName: DataServiceName,
                    jobDefinitionName: JobDefinitionName,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                Assert.NotNull(jobList);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //Jobs_ListByDataService
        [Fact]
        public void Jobs_ListByDataService()
        {
            try
            {
                var jobList = Client.Jobs.ListByDataService(
                    dataServiceName: DataServiceName,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                Assert.NotNull(jobList);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //Jobs_ListByDataManager
        [Fact]
        public void Jobs_ListByDataManager()
        {
            try
            {
                var jobList = Client.Jobs.ListByDataManager(
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                Assert.NotNull(jobList);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

    }
}

