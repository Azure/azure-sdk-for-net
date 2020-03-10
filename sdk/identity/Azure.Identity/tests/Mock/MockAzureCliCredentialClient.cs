// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity.Tests.Mock
{
    internal class MockAzureCliCredentialClient : AzureCliCredentialClient
    {
        private readonly (string, int) _resultGenerator;

        public MockAzureCliCredentialClient((string, int) resultGenerator)
        {
            _resultGenerator = resultGenerator;
        }

        protected override ValueTask<(string, int)> GetAzureCliAccesToken(bool isAsync, string resource, CancellationToken cancellationToken)
        {
            return new ValueTask<(string, int)>(_resultGenerator);
        }
    }
}
