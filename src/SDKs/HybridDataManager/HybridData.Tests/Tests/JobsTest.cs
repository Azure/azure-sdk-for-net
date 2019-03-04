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
                JobId = "af59807d-f32b-4f1f-b797-83c551af1348";
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
                JobId = "26fbcf29-53fc-45c1-b33f-c0d587330cea";
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
            JobId = "af59807d-f32b-4f1f-b797-83c551af1348";
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
