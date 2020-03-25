namespace StorSimple1200Series.Tests
{
    using System;
    using System.Reflection;
    using System.Threading;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public abstract class StorSimpleTestBase : TestBase, IDisposable
    {
        protected const string SubIdKey = "SubId";

        protected const int DefaultWaitingTimeInMs = 60000;

        public string ResourceGroupName { get; protected set; }

        public string ManagerName { get; protected set; }

        public string SubscriptionId { get; protected set; }

        protected MockContext Context { get; set; }

        public StorSimpleManagementClient Client { get; protected set; }

        public StorSimpleTestBase(ITestOutputHelper testOutputHelper)
        {
            // Getting test method name here as we are not initializing context from each method
            var helper = (TestOutputHelper)testOutputHelper;
            ITest test = (ITest)helper.GetType().GetField("test", BindingFlags.NonPublic | BindingFlags.Instance)
                                  .GetValue(helper);
            this.Context = MockContext.Start(this.GetType(), test.TestCase.TestMethod.Method.Name);

            this.ResourceGroupName = TestConstants.DefaultResourceGroupName;
            this.ManagerName = TestConstants.DefaultManagerName;
            this.Client = this.Context.GetServiceClient<StorSimpleManagementClient>();
            var testEnv = TestEnvironmentFactory.GetTestEnvironment();
            this.SubscriptionId = testEnv.SubscriptionId;

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables[SubIdKey] = testEnv.SubscriptionId;
            }
        }

        #region Helper Methods

        public Job TrackLongRunningJob(string deviceName, string jobName)
        {
            Job job = null;
            do
            {
                Thread.Sleep(DefaultWaitingTimeInMs);
                job = this.Client.Jobs.Get(deviceName, jobName, this.ResourceGroupName, this.ManagerName);
            }
            while (job != null && job.Status == JobStatus.Running);

            return job;
        }

        #endregion

        // Dispose all disposable objects
        public virtual void Dispose()
        {
            this.Client.Dispose();
            this.Context.Dispose();
        }

        ~StorSimpleTestBase()
        {
            this.Dispose();
        }
    }
}
