namespace EdgeGateway.Tests
{
    using Microsoft.Azure.Management.EdgeGateway;
    using Microsoft.Azure.Management.EdgeGateway.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Reflection;
    using System.Threading;
    using Xunit.Abstractions;
    using Xunit.Sdk;


    public class EdgeGatewayTestBase : TestBase, IDisposable
    {
        protected const string SubIdKey = "SubId";

        protected const int DefaultWaitingTimeInMs = 60000;

        public string ResourceGroupName { get; protected set; }

        public string ManagerName { get; protected set; }

        public string SubscriptionId { get; protected set; }

        protected MockContext Context { get; set; }

        public DataBoxEdgeManagementClient Client { get; protected set; }


        public EdgeGatewayTestBase(ITestOutputHelper testOutputHelper)
        {
            // Getting test method name here as we are not initializing context from each method
            var helper = (TestOutputHelper)testOutputHelper;
            ITest test = (ITest)helper.GetType().GetField("test", BindingFlags.NonPublic | BindingFlags.Instance)
                                  .GetValue(helper);
            this.Context = MockContext.Start(this.GetType().FullName, test.TestCase.TestMethod.Method.Name);

            this.ResourceGroupName = TestConstants.DefaultResourceGroupName;
            this.Client = this.Context.GetServiceClient<DataBoxEdgeManagementClient>();
            var testEnv = TestEnvironmentFactory.GetTestEnvironment();
            this.SubscriptionId = testEnv.SubscriptionId;

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables[SubIdKey] = testEnv.SubscriptionId;
            }
        }

        /// <summary>
        /// Wait for the specified span unless we are in mock playback mode
        /// </summary>
        /// <param name="timeout">The span of time to wait for</param>
        public static void Wait(TimeSpan timeout)
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                Thread.Sleep(timeout);
            }
        }

        public void Dispose()
        {
            this.Client.Dispose();
            // this.Context.Dispose();
        }

        ~EdgeGatewayTestBase()
        {
            Dispose();
        }

        protected static object GetResourceManagementClient(object context, object handler)
        {
            throw new NotImplementedException();
        }

        protected static Sku GetDefaultSku()
        {
            return new Sku
            {
                Name = SkuName.Edge
            };
        }

       

    }
}
