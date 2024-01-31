// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.TestFramework.Tests
{
    [ClientTestFixture(
        TestClientOptions.ServiceVersion.V0,
        TestClientOptions.ServiceVersion.V1,
        TestClientOptions.ServiceVersion.V2,
        TestClientOptions.ServiceVersion.V3,
        RecordingServiceVersion = TestClientOptions.ServiceVersion.V2,
        LiveServiceVersions = new object[] { TestClientOptions.ServiceVersion.V1, TestClientOptions.ServiceVersion.V0 })]
    public class ClientTestBaseMultiVersionTestsWithSpecificVersions : RecordedTestBase
    {
        private readonly TestClientOptions.ServiceVersion _version;

        public ClientTestBaseMultiVersionTestsWithSpecificVersions(bool isAsync, TestClientOptions.ServiceVersion version) : base(isAsync)
        {
            _version = version;
            TestDiagnostics = false;
        }

        [Test]
        [Ignore("Sparse checkout issue when running resource manager pipeline")]
        public async Task HasValidVersion()
        {
            var testClientOptions = new TestClientOptions(_version) { Transport = new MockTransport(new MockResponse(200))};
            var client = InstrumentClient(new TestClient(InstrumentClientOptions(testClientOptions)));
            await client.GetAsync(default);
            if (Mode == RecordedTestMode.Playback || Mode == RecordedTestMode.Record)
            {
                Assert.IsTrue(_version == TestClientOptions.ServiceVersion.V2);
            }
            else
            {
                Assert.IsTrue(_version == TestClientOptions.ServiceVersion.V1 || _version == TestClientOptions.ServiceVersion.V0);
            }
        }

        public class TestClientOptions: ClientOptions
        {
            public readonly ServiceVersion Version;

            public enum ServiceVersion
            {
                V0 = 0,
                V1 = 1,
                V2 = 2,
                V3 = 3
            }

            public TestClientOptions(ServiceVersion serviceVersion)
            {
                Version = serviceVersion;
            }
        }
        public class TestClient
        {
            private readonly TestClientOptions _options;
            private HttpPipeline _pipeline;

            protected TestClient(){}
            public TestClient(TestClientOptions options)
            {
                _options = options;
                _pipeline = HttpPipelineBuilder.Build(options);
            }

            public virtual Response Get(CancellationToken cancellationToken)
            {
                using var request = _pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("http://localhost"));
                request.Uri.AppendQuery("api", _options.Version.ToString());
                return _pipeline.SendRequest(request, cancellationToken);
            }

            public virtual async Task<Response> GetAsync(CancellationToken cancellationToken)
            {
                using var request = _pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("http://localhost"));
                request.Uri.AppendQuery("api", _options.Version.ToString());
                return await _pipeline.SendRequestAsync(request, cancellationToken);
            }
        }
    }
}
