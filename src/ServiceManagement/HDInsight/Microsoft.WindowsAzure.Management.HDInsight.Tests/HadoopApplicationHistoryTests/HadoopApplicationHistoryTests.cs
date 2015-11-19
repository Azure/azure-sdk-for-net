using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Hadoop.Client;
using Microsoft.Hadoop.Client.ClientLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
using Moq;
using Moq.Language;

namespace Microsoft.WindowsAzure.Management.HDInsight.Tests
{
    [TestClass]
    public class HadoopApplicationHistoryTests
    {
        [TestMethod]
        public void ListApplications()
        {
            DateTime minTime = DateTime.MinValue;
            DateTime now = DateTime.UtcNow;

            RunMockedRestCall(
                m => m.ListCompletedApplicationsAsync(ConvertDateTimeToUnixEpoch(minTime).ToString(), ConvertDateTimeToUnixEpoch(now).ToString()),
                GetApplicationListResult(),
                c => c.ListCompletedApplicationsAsync(minTime, now));
        }

        [TestMethod]
        public void GetApplicationDetails()
        {
            string testAppId = "testAppId";
            ApplicationGetResult appResult = new ApplicationGetResult();
            appResult.ApplicationId = testAppId;

            ApplicationDetails app = RunMockedRestCall(
                                        m => m.GetApplicationDetailsAsync(testAppId),
                                        appResult,
                                        c => c.GetApplicationDetailsAsync(testAppId));

            Assert.IsTrue(app.ApplicationId == testAppId);
        }

        [TestMethod]
        public void ListApplicationAttempts()
        {
            string testAppId = "testAppId";
            ApplicationGetResult appResult = new ApplicationGetResult();
            appResult.ApplicationId = testAppId;

            ApplicationDetails app = new ApplicationDetails(appResult);

            var appAttempts = RunMockedRestCall(
                m => m.ListApplicationAttemptsAsync(testAppId),
                GetApplicationAttemptListResult(),
                c => c.ListApplicationAttemptsAsync(app));

            foreach (var appAttempt in appAttempts)
            {
                Assert.IsTrue(appAttempt.ParentApplication.ApplicationId == testAppId);
            }
        }

        [TestMethod]
        public void ListApplicationContainers()
        {
            string testAppId = "testAppId";
            string testAppAttemptId = "testAppAttemptId";
            ApplicationGetResult appResult = new ApplicationGetResult();
            appResult.ApplicationId = testAppId;

            ApplicationDetails app = new ApplicationDetails(appResult);

            ApplicationAttemptGetResult appAttemptResult = new ApplicationAttemptGetResult();
            appAttemptResult.ApplicationAttemptId = testAppAttemptId;

            ApplicationAttemptDetails appAttemptDetails = new ApplicationAttemptDetails(appAttemptResult, app);

            var containers = RunMockedRestCall(
                m => m.ListApplicationContainersAsync(testAppId, testAppAttemptId),
                GetContainerListResult(),
                c => c.ListApplicationContainersAsync(appAttemptDetails));

            foreach (var container in containers)
            {
                Assert.IsTrue(container.ParentApplicationAttempt.ApplicationAttemptId == testAppAttemptId);
                Assert.IsTrue(container.ParentApplicationAttempt.ParentApplication.ApplicationId == testAppId);
            }
        }

        [TestMethod]
        public void VerifyUnsupportedClusterType()
        {
            try
            {
                var cluster = GetClusterDetails(ClusterProvisioning.Data.ClusterType.HBase, "3.1.0.0");
                var appHistoryClient = cluster.CreateHDInsightApplicationHistoryClient();

                appHistoryClient.ListCompletedApplications();
                Assert.Fail("Expected to hit NotSupportedException");
            }
            catch (NotSupportedException)
            {
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void VerifyUnsupportedClusterVersion()
        {
            try
            {
                var cluster = GetClusterDetails(ClusterProvisioning.Data.ClusterType.Hadoop, "3.0.0.0");
                var appHistoryClient = cluster.CreateHDInsightApplicationHistoryClient();
                appHistoryClient.ListCompletedApplications();
                Assert.Fail("Expected to hit NotSupportedException");
            }
            catch (NotSupportedException)
            {
            }
        }

        private static TDetails RunMockedRestCall<TResult, TDetails>(
            Expression<Func<IHadoopApplicationHistoryRestReadClient, Task<TResult>>> mockCall,
            TResult mockCallResult,
            Func<HadoopApplicationHistoryRestClient, Task<TDetails>> testCall)
        {
            var mockClient = new Mock<IHadoopApplicationHistoryRestReadClient>(MockBehavior.Strict);

            mockClient
                .Setup<Task<TResult>>(mockCall)
                .Returns(Task.Run(() => mockCallResult))
                .Verifiable();

            var client = new HadoopApplicationHistoryRestClient(mockClient.Object);

            var details = testCall(client).WaitForResult();

            mockClient.Verify();
            Assert.IsNotNull(details);
            return details;
        }

        private static ApplicationListResult GetApplicationListResult()
        {
            ApplicationListResult appList = new ApplicationListResult();
            appList.Applications = GetObjects<ApplicationGetResult>(1);

            return appList;
        }

        private static ApplicationAttemptListResult GetApplicationAttemptListResult()
        {
            ApplicationAttemptListResult appAttemptList = new ApplicationAttemptListResult();
            appAttemptList.ApplicationAttempts = GetObjects<ApplicationAttemptGetResult>(1);

            return appAttemptList;
        }

        private static ApplicationContainerListResult GetContainerListResult()
        {
            ApplicationContainerListResult containerList = new ApplicationContainerListResult();
            containerList.Containers = GetObjects<ApplicationContainerGetResult>(1);

            return containerList;
        }

        private static List<T> GetObjects<T>(int count) where T : new()
        {
            List<T> objects = new List<T>();

            for (int i = 0; i < count; ++i)
            {
                objects.Add(new T());
            }

            return objects;
        }

        private static ClusterDetails GetClusterDetails(ClusterProvisioning.Data.ClusterType clusterType, string version)
        {
            ClusterDetails cluster = new ClusterDetails();

            cluster.Name = "fakeCluster";

            cluster.ConnectionUrl = "https://fakeCluster.azurehdinsight.net/";
            cluster.HttpUserName = "fakeUser";
            cluster.HttpPassword = "fakePassword";

            cluster.DefaultStorageAccount = new WabStorageAccountConfiguration("fakeAccount.blob.core.windows.net",
                "O92A/ccaUTRKmFMmypgT22fj2Oq3+zbwlZiHbZ4DiXxWaRrCSCgJcU2RTMaZQnxFwVIgj8Awz9NFA0kyKH0wtA==",
                "fakeCluster");

            cluster.ClusterType = clusterType;

            cluster.Version = version;

            return cluster;
        }

        private static long ConvertDateTimeToUnixEpoch(DateTime dateTime)
        {
            long epoch = Convert.ToInt64((dateTime - new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds);

            if (epoch < 0)
            {
                epoch = 0;
            }

            return epoch;
        }
    }
}
