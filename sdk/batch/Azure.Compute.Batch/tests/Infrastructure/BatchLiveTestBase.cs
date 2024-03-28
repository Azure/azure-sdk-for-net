// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

namespace Azure.Compute.Batch.Tests.Infrastructure
{
    public class BatchLiveTestBase : RecordedTestBase<BatchLiveTestEnvironment>
    {
        public BatchLiveTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
            UseDefaultGuidFormatForClientRequestId = true;
        }

        public BatchLiveTestBase(bool isAsync) : base(isAsync)
        {
            UseDefaultGuidFormatForClientRequestId = true;
        }

        /// <summary>
        /// Creates a <see cref="BatchClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="skipInstrumenting">Whether or not instrumenting should be skipped. Avoid skipping it as much as possible.</param>
        /// <returns>The instrumented <see cref="BatchClient" />.</returns>
        public BatchClient CreateBatchClient(bool useTokenCredential = true, bool skipInstrumenting = false)
        {
            var options = InstrumentClientOptions(new BatchClientOptions());
            BatchClient client;
            Uri uri = new Uri("https://" + TestEnvironment.BatchAccountURI);

            var authorityHost = TestEnvironment.AuthorityHostUrl;
            if (useTokenCredential)
            {
                var credential = new ClientSecretCredential(
                    TestEnvironment.TenantId,
                    TestEnvironment.ClientId,
                    TestEnvironment.ClientSecret,
                    new ClientSecretCredentialOptions()
                    {
                        AuthorityHost = new Uri(authorityHost)
                    });

                client = new BatchClient(uri,credential, options);
            }
            else
            {
                var credential = new AzureNamedKeyCredential(TestEnvironment.BatchAccountName, TestEnvironment.BatchAccountKey);
                client = new BatchClient(uri, credential, options);
            }

            return skipInstrumenting ? client : InstrumentClient(client);
        }
    }
}
