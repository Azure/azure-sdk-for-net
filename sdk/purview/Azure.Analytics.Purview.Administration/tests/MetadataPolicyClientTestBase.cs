// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using Azure.Analytics.Purview.Tests;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Administration.Tests
{
    public class MetadataPolicyClientTestBase : RecordedTestBase<PurviewCollectionTestEnvironment>
    {
        public MetadataPolicyClientTestBase(bool isAsync, RecordedTestMode? mode = default) : base(isAsync, mode)
        {
            this.AddPurviewSanitizers();
        }
        public PurviewMetadataPolicyClient GetMetadataPolicyClient(string collectionName)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewMetadataClientOptions { Transport = new HttpClientTransport(httpHandler) };
            var client = InstrumentClient(
                new PurviewMetadataPolicyClient(TestEnvironment.Endpoint, collectionName, TestEnvironment.Credential, InstrumentClientOptions(options)));
            return client;
        }
    }
}
