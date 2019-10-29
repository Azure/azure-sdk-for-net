using Microsoft.Azure.Management.HybridData;
using Microsoft.Azure.Management.HybridData.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace HybridData.Tests.Tests
{
    public class CustomLoginCredentials : Microsoft.Rest.ServiceClientCredentials
    {
        public override async Task ProcessHttpRequestAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            await base.ProcessHttpRequestAsync(request, cancellationToken);
        }
        
    }

    public abstract class HybridDataTestBase : TestBase, IDisposable
    {
        protected const string SubIdKey = "SubId";

        protected const int DefaultWaitingTimeInMs = 60000;

        public string ResourceGroupName { get; protected set; }

        public string DataManagerName { get; protected set; }

        public string DataServiceName { get; protected set; }

        public string JobDefinitionName { get; protected set; }

        public string SubscriptionId { get; protected set; }

        protected MockContext Context { get; set; }

        public HybridDataManagementClient Client { get; protected set; }

        public string StorSimpleDeviceServiceEncryptionKey { get; protected set; }

        public string AzureStorageAccountAccessKey { get; protected set; }

        public HybridDataTestBase(ITestOutputHelper testOutputHelper)
        {
            // Getting test method name here as we are not initializing context from each method
            var helper = (TestOutputHelper)testOutputHelper;
            ITest test = (ITest)helper.GetType().GetField("test", BindingFlags.NonPublic | BindingFlags.Instance)
                                  .GetValue(helper);
            this.Context = MockContext.Start(this.GetType(), test.TestCase.TestMethod.Method.Name);
            var testEnv = TestEnvironmentFactory.GetTestEnvironment();
            this.ResourceGroupName = TestConstants.DefaultResourceGroupName;
            this.DataManagerName = TestConstants.DefaultDataManagerName;
            this.DataServiceName = TestConstants.DefaultDataServiceName;
            this.JobDefinitionName= TestConstants.DefaultJobDefinitiontName;
            this.Client = this.Context.GetServiceClient<HybridDataManagementClient>();
            //this.Client.BaseUri = new Uri("http://localhost:81");
            this.SubscriptionId = testEnv.SubscriptionId;
            StorSimpleDeviceServiceEncryptionKey = Environment.GetEnvironmentVariable("ServiceEncryptionKey") ?? "Placeholder";
            AzureStorageAccountAccessKey = Environment.GetEnvironmentVariable("StorageAccountKey") ?? "Placeholder";

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables[SubIdKey] = testEnv.SubscriptionId;
            }
        }

        #region Helper Methods

        public Job TrackLongRunningJob(string jobDefinitionName, string jobId)
        {
            Job job = null;
            do
            {
                Thread.Sleep(DefaultWaitingTimeInMs);
                job = Client.Jobs.Get(DataServiceName, jobDefinitionName, jobId, this.ResourceGroupName, this.DataManagerName);
            }
            while (job != null && job.Status == JobStatus.InProgress);

            return job;
        }

        #endregion

        // Dispose all disposable objects
        public virtual void Dispose()
        {
            this.Client.Dispose();
            this.Context.Dispose();
        }

        ~HybridDataTestBase()
        {
            this.Dispose();
        }

    }
}

