namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ClientAbstractionTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using System.Xml;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.DynamicXml.Writer;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    [TestClass]
    public class HttpRetryTests : IntegrationTestBase
    {
        internal class Response
        {
            public IHttpResponseMessageAbstraction ResponseMessage { get; set; }
            public Exception Exception { get; set; }
        }

        private int attempts;
        private TimeSpan timeout = TimeSpan.FromSeconds(1);
        private TimeSpan pollInterval = TimeSpan.FromMilliseconds(100);

        private Queue<Response> responses = new Queue<Response>();
            
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.EnableHttpSpy();
            this.responses.Clear();
            this.EnableHttpMock(this.ReturnNextResponse);
            this.timeout = TimeSpan.FromSeconds(1);
            this.pollInterval = TimeSpan.FromMilliseconds(100);
            this.attempts = 0;
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            this.responses.Clear();
            base.TestCleanup();
        }

        internal void AddHttpResponse(IHttpResponseMessageAbstraction responseMessage, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                var response = new Response() { ResponseMessage = responseMessage };
                this.responses.Add(response);
            }
        }

        internal void AddHttpException(Exception ex, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                var response = new Response() { Exception = ex };
                this.responses.Add(response);
            }
        }

        internal IHttpResponseMessageAbstraction ReturnNextResponse(IHttpClientAbstraction client)
        {
            this.attempts++;
            var response = this.responses.Remove();
            if (response.Exception.IsNotNull())
            {
                throw response.Exception;
            }
            return response.ResponseMessage;
        }

        internal async Task<IHttpResponseMessageAbstraction> PerformRequest()
        {
            using (CancellationTokenSource source = new CancellationTokenSource())
            {
                var factory = ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>();
                OperationExecutionResult<IHttpResponseMessageAbstraction> result = await
                        OperationExecutor.ExecuteOperationWithRetry(
                            () => this.DoClientSend(factory.Create()),
                            this.GetRetryPolicy(),
                            new HDInsightSubscriptionAbstractionContext(GetValidCredentials(), source.Token),
                            new Logger());

                if (result.ExecutionOutput.StatusCode != HttpStatusCode.Accepted && result.ExecutionOutput.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpLayerException(result.ExecutionOutput.StatusCode, result.ExecutionOutput.Content, result.Attempts, result.TotalTime);
                }

                return result.ExecutionOutput;
            }
        }

        internal async Task<IHttpResponseMessageAbstraction> DoClientSend(IHttpClientAbstraction client)
        {
            client.ContentType = "text/HTML";
            client.Method = HttpMethod.Get;
            client.RequestHeaders.Add("test", "value");
            client.RequestUri = new Uri("http://www.microsoft.com");
            client.Timeout = new TimeSpan(0, 5, 0);
            var ret = await client.SendAsync();
            if (ret.StatusCode != HttpStatusCode.Accepted && ret.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpLayerException(ret.StatusCode, ret.Content);
            }
            return ret;
        }

        internal IRetryPolicy GetRetryPolicy()
        {
            return RetryPolicyFactory.CreateExponentialRetryPolicy(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(100), 3, 0.2);
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public async Task WhenAnHttpMethodFailsARetryIsPerformed()
        {
            this.AddHttpResponse(new HttpResponseMessageAbstraction(HttpStatusCode.BadGateway, new HttpResponseHeadersAbstraction(), "Transient Failure"));
            this.AddHttpResponse(new HttpResponseMessageAbstraction(HttpStatusCode.Accepted, new HttpResponseHeadersAbstraction(), "<Okay />"));
            var response = await this.PerformRequest();
            Assert.AreEqual(2, this.attempts);
            Assert.AreEqual(0, this.responses.Count);
            Assert.AreEqual(HttpStatusCode.Accepted, response.StatusCode);
            Assert.AreEqual("<Okay />", response.Content);
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public async Task TimeOutExceptionOnTheHttpCallShouldRetry()
        {
            var factory = ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>();
            OperationExecutionResult<IHttpResponseMessageAbstraction> response;

            using (CancellationTokenSource source = new CancellationTokenSource())
            {
                this.AddHttpException(new TimeoutException("The Operation Timed Out"));
                this.AddHttpResponse(new HttpResponseMessageAbstraction(HttpStatusCode.Accepted, new HttpResponseHeadersAbstraction(), "<Okay />"));
                response =
                    await
                    OperationExecutor.ExecuteOperationWithRetry(
                        () => this.DoClientSend(factory.Create()),
                        this.GetRetryPolicy(),
                        new HDInsightSubscriptionAbstractionContext(GetValidCredentials(), source.Token),
                        new Logger());
            }
            Assert.AreEqual(2, this.attempts);
            Assert.AreEqual(0, this.responses.Count);
            Assert.AreEqual(HttpStatusCode.Accepted, response.ExecutionOutput.StatusCode);
            Assert.AreEqual("<Okay />", response.ExecutionOutput.Content);
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public async Task TaskCanceledByUserShouldNotRetry()
        {
            try
            {
                this.AddHttpResponse(new HttpResponseMessageAbstraction(HttpStatusCode.Accepted, new HttpResponseHeadersAbstraction(), "<Okay />"));
                var factory = ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>();
                using (CancellationTokenSource source = new CancellationTokenSource())
                {
                    var context = new HDInsightSubscriptionAbstractionContext(GetValidCredentials(), source.Token);
                    source.Cancel();
                    var val = await
                    OperationExecutor.ExecuteOperationWithRetry(
                        () => this.DoClientSend(factory.Create()),
                        this.GetRetryPolicy(),
                        context,
                        new Logger());
                    Assert.IsNotNull(val.ExecutionOutput);
                }
                Assert.Fail("Should have thrown an operation cancelled exception");
            }
            catch (OperationCanceledException tex)
            {
                Assert.IsNotNull(tex.CancellationToken);
                Assert.IsTrue(tex.CancellationToken.IsCancellationRequested);
            }
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public async Task WhenAnHttpExceptionOccursARetryIsPerformed()
        {
            this.AddHttpException(new WebException("Unable to connect to server"));
            this.AddHttpResponse(new HttpResponseMessageAbstraction(HttpStatusCode.Accepted, new HttpResponseHeadersAbstraction(), "<Okay />"));
            var response = await this.PerformRequest();
            Assert.AreEqual(2, this.attempts);
            Assert.AreEqual(0, this.responses.Count);
            Assert.AreEqual(HttpStatusCode.Accepted, response.StatusCode);
            Assert.AreEqual("<Okay />", response.Content);
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public async Task WhenMultipleHttpRequestsFailAndAndTheTimeoutIsReachedTheResultIsAFailure()
        {
            this.pollInterval = TimeSpan.FromMilliseconds(10);
            this.timeout = TimeSpan.FromMilliseconds(100);
            this.AddHttpResponse(new HttpResponseMessageAbstraction(HttpStatusCode.BadGateway, new HttpResponseHeadersAbstraction(), "Transient Failure"), 11);
            IHttpResponseMessageAbstraction response;
            try
            {
                response = await this.PerformRequest();
                Assert.Fail("Should have failed.");
            }
            catch (HttpLayerException ex)
            {
                Assert.IsTrue(this.attempts > 1);
                Assert.IsTrue(this.responses.Count < 10);
                Assert.AreEqual(HttpStatusCode.BadGateway, ex.RequestStatusCode);
                Assert.AreEqual("Transient Failure", ex.RequestContent);
            }
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public async Task WhenMultipleHttpRequestsProduceExceptionsAndAndTheTimeoutIsReachedTheResultIsAnException()
        {
            try
            {
                this.pollInterval = TimeSpan.FromMilliseconds(10);
                this.timeout = TimeSpan.FromMilliseconds(100);
                this.AddHttpException(new WebException("Unable to connect to server"), 11);
                var response = await this.PerformRequest();
                Assert.Fail("The test failed to raise the expected exception");
            }
            catch (WebException wex)
            {
                Assert.AreEqual("Unable to connect to server", wex.Message);
            }
            Assert.IsTrue(this.attempts > 1);
            Assert.IsTrue(this.responses.Count < 10);
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public async Task ListClustersPerformesARetryWhenAnAttemptDoesNotSucceed()
        {
            var credentails = IntegrationTestBase.GetValidCredentials();
            var restLayer = ServiceLocator.Instance.Locate<IHDInsightManagementRestClientFactory>().Create(credentails, GetAbstractionContext(), false);
            var goodResponse = await restLayer.ListCloudServices();

            var manager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>().MockingLevel = ServiceLocationMockingLevel.ApplyIndividualTestMockingOnly;
            var individual = ServiceLocator.Instance.Locate<IServiceLocationIndividualTestManager>();

            var client = ServiceLocator.Instance.Locate<IHDInsightClientFactory>().Create(credentails);

            this.AddHttpResponse(new HttpResponseMessageAbstraction(HttpStatusCode.InternalServerError, new HttpResponseHeadersAbstraction(), "Server Problem"));
            this.AddHttpResponse(goodResponse);

            //The fist list containers on an HdInsightClient performs a get resource provider properties call.
            //so let us add the response for that into the set of responses for the restclient.
            dynamic xml = DynaXmlBuilder.Create(false, Formatting.None);
            xml.xmlns("http://schemas.microsoft.com/windowsazure")
               .Root
               .b
                 .ResourceProviderProperty
                 .b
                   .Key("Test")
                   .Value("Value")
                 .d
               .d
               .End();

            this.AddHttpResponse(new HttpResponseMessageAbstraction(HttpStatusCode.OK, new HttpResponseHeadersAbstraction(), xml.ToString()));
            var results = client.ListClusters();
            Assert.AreEqual(3, this.attempts);
            Assert.AreEqual(0, this.responses.Count);
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public async Task TaskDoesNotRetryOn401Error()
        {
            var credentails = IntegrationTestBase.GetValidCredentials();
            var restLayer = ServiceLocator.Instance.Locate<IHDInsightManagementRestClientFactory>().Create(credentails, GetAbstractionContext(), false);
            var goodResponse = await restLayer.ListCloudServices();

            var manager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>().MockingLevel = ServiceLocationMockingLevel.ApplyIndividualTestMockingOnly;
            var individual = ServiceLocator.Instance.Locate<IServiceLocationIndividualTestManager>();

            var client = ServiceLocator.Instance.Locate<IHDInsightClientFactory>().Create(credentails);

            this.AddHttpResponse(new HttpResponseMessageAbstraction(HttpStatusCode.Unauthorized, new HttpResponseHeadersAbstraction(), "401 Unauthorized"));
            this.AddHttpResponse(goodResponse);
            var results = this.PerformRequest();
            Assert.AreEqual(1, this.attempts);
            Assert.IsNotNull(results.Exception);
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public async Task GetProviderPropertiesPerformsARetryWhenAnAttemptDoesNotSucced()
        {
            var manager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>().MockingLevel = ServiceLocationMockingLevel.ApplyIndividualTestMockingOnly;
            var individual = ServiceLocator.Instance.Locate<IServiceLocationIndividualTestManager>();

            dynamic xml = DynaXmlBuilder.Create(false, Formatting.None);
            xml.xmlns("http://schemas.microsoft.com/windowsazure")
               .Root
               .b
                 .ResourceProviderProperty
                 .b
                   .Key("Test")
                   .Value("Value")
                 .d
               .d
               .End();
            var content = xml.ToString();
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = ServiceLocator.Instance.Locate<IRdfeServiceRestClientFactory>().Create(credentials, GetAbstractionContext(), false);

            this.AddHttpResponse(new HttpResponseMessageAbstraction(HttpStatusCode.InternalServerError, new HttpResponseHeadersAbstraction(), "Server Problem"));
            this.AddHttpResponse(new HttpResponseMessageAbstraction(HttpStatusCode.OK, new HttpResponseHeadersAbstraction(), content));

            var properties = await client.GetResourceProviderProperties();
            Assert.AreEqual(2, this.attempts);
            Assert.AreEqual(0, this.responses.Count);
            Assert.AreEqual("Test", properties.First().Key);
            Assert.AreEqual("Value", properties.First().Value);
            Assert.AreEqual(1, properties.Count());
        }
    }
}
