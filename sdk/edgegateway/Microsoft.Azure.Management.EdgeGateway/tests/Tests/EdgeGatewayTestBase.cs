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

    /// <summary>
    /// Base class for all tests
    /// </summary>
    public class EdgeGatewayTestBase : TestBase, IDisposable
    {
        /// <summary>
        /// The subscription id key
        /// </summary>
        protected const string SubIdKey = "SubId";

        /// <summary>
        /// The subscription id used for tests
        /// </summary>
        public string SubscriptionId { get; protected set; }

        /// <summary>
        /// The context in which the tests run
        /// </summary>
        protected MockContext Context { get; set; }

        /// <summary>
        /// The edge gateway client
        /// </summary>
        public DataBoxEdgeManagementClient Client { get; protected set; }


        /// <summary>
        /// Initializes common properties used across tests
        /// </summary>
        public EdgeGatewayTestBase(ITestOutputHelper testOutputHelper)
        {
            // Getting test method name here as we are not initializing context from each method
            var helper = (TestOutputHelper)testOutputHelper;
            ITest test = (ITest)helper.GetType().GetField("test", BindingFlags.NonPublic | BindingFlags.Instance)
                                  .GetValue(helper);
            this.Context = MockContext.Start(this.GetType(), test.TestCase.TestMethod.Method.Name);

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

        /// <summary>
        /// Disposes the client and context
        /// </summary>
        public void Dispose()
        {
            this.Client.Dispose();
           this.Context.Dispose();
        }

        /// <summary>
        /// Disposes the object
        /// </summary>
        ~EdgeGatewayTestBase()
        {
            Dispose();
        }

        ///// <summary>
        ///// Disposes the object
        ///// </summary>
        //protected static object GetResourceManagementClient(object context, object handler)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Disposes the object
        ///// </summary>
        //protected static Sku GetDefaultSku()
        //{
        //    return new Sku
        //    {
        //        Name = SkuName.Edge
        //    };
        //}

       

    }
}

