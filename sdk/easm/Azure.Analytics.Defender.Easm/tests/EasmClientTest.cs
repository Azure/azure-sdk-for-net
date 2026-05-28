// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests
{
    public class EasmClientTest: RecordedTestBase<EasmClientTestEnvironment>
    {
        protected Regex UUID_REGEX = new Regex(@"[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}");
        protected EasmClient client { get; private set; }
        public EasmClientTest(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void SetUp()
        {
            client = InstrumentClient(new EasmClient(new System.Uri(TestEnvironment.Endpoint),
                // TODO https://github.com/Azure/azure-sdk-for-net/issues/53199
                TestEnvironment.Credential, InstrumentClientOptions(new EasmClientOptions(EasmClientOptions.ServiceVersion.V2023_03_01_Preview))));
        }
        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */

        [RecordedTest]
        public void TestOperation()
        {
            Assert.IsTrue(true);
        }

        #region Helpers

        private static BinaryData GetContentFromResponse(Response r)
        {
            // Workaround azure/azure-sdk-for-net#21048, which prevents .Content from working when dealing with responses
            // from the playback system.

            MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }
        #endregion
    }
}
