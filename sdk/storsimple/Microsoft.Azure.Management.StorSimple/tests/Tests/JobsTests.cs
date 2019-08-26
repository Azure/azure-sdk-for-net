namespace StorSimple1200Series.Tests
{
    using System;
    using System.Linq;
    using Xunit;
    using Xunit.Abstractions;

    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using System.Linq.Expressions;
    using Microsoft.Rest.Azure.OData;

    /// <summary>
    /// Class represents tests for jobs
    /// </summary>
    public class JobTests : StorSimpleTestBase
    {
        #region Constructor
        public JobTests(ITestOutputHelper testOutputHelper) :
            base(testOutputHelper)
        { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Test method for create manual backup and get the job
        /// </summary>
        [Fact]
        public void TestBackupJob()
        {
            try
            {
                var fileServers = TestUtilities.GetFileServers(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                Assert.True(fileServers != null && fileServers.Count() > 0,
                    "No fileserver found in the given manager:" + this.ManagerName);

                var fileServer = fileServers.FirstOrDefault();

                var fileShares = fileServer.GetFileShares(fileServer.Name);
                var fileShare = fileShares.First();

                DateTime backupStartTime = DateTime.Parse(TestConstants.DefaultBackupJobStartTime);
                fileServer.BackupNowAsync();

                var device = TestUtilities.GetDeviceByFileServer(
                    fileServer.Name,
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                // Get jobs for a given job type
                var deviceJobs = device.GetJobs(JobType.Backup);

                Assert.True(deviceJobs != null && deviceJobs.Any(),
                    "No backup jobs found for device:" + device.Name);

                // Get Job for a given manager
                DateTime startTime = DateTime.Parse(TestConstants.BackupsCreatedTime);
                DateTime endTime = DateTime.Parse(TestConstants.BackupsEndTime);

                Expression<Func<JobFilter, bool>> filterExp = filter =>
                    (filter.JobType == JobType.Backup &&
                    filter.StartTime >= startTime && 
                    filter.StartTime <= endTime);

                var jobsFilter = new ODataQuery<JobFilter>(filterExp);

                var managerJobs = TestUtilities.GetJobsByManager(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName,
                    null);

                Assert.True(managerJobs != null && managerJobs.Any(), "No jobs by manager found");

                var job = TestUtilities.GetJob(
                    managerJobs.First().Name,
                    fileServer.Name,
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                Assert.True(
                    job.Name.Equals(managerJobs.First().Name, StringComparison.CurrentCultureIgnoreCase),
                    "Mismatch of job name");
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        #endregion Test Methods
    }
}

