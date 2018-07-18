//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Test.HttpRecorder;

namespace Microsoft.Azure.KeyVault.Internal
{
    public class TestKeyVaultCredential : KeyVaultCredential
    {
        public TestKeyVaultCredential(KeyVaultClient.AuthenticationCallback authenticationCallback) : base(authenticationCallback)
        {
        }

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                return base.ProcessHttpRequestAsync(request, cancellationToken);
            }
            else
            {
                return Task.Run(() => { return; });
            }
        }
    }
}
