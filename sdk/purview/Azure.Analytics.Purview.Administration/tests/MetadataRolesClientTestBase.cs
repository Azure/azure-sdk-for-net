// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Azure.Analytics.Purview.Tests;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using Castle.DynamicProxy;

namespace Azure.Analytics.Purview.Administration.Tests
{
    public class MetadataRolesClientTestBase : RecordedTestBase<PurviewCollectionTestEnvironment>
    {
        public MetadataRolesClientTestBase(bool isAsync, RecordedTestMode? mode = default) : base(isAsync, mode)
        {
            this.AddPurviewSanitizers();
        }
        public PurviewMetadataRolesClient GetMetadataPolicyClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewMetadataClientOptions { Transport = new HttpClientTransport(httpHandler) };
            var client = InstrumentClient(
                new PurviewMetadataRolesClient(TestEnvironment.Endpoint, TestEnvironment.Credential, InstrumentClientOptions(options)));
            return client;
        }
    }
}
