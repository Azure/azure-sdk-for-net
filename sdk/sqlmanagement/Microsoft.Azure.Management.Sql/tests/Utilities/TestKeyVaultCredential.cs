// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Test.HttpRecorder;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sql.Tests.Utilities
{
    public class TestKeyVaultCredential : KeyVaultCredential
    {
        public TestKeyVaultCredential(KeyVaultClient.AuthenticationCallback authenticationCallback) : base(authenticationCallback)
        {
        }

        public override Task ProcessHttpRequestAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                return base.ProcessHttpRequestAsync(request, cancellationToken);
            }
            else
            {
                return Task.CompletedTask;
            }
        }
    }
}
