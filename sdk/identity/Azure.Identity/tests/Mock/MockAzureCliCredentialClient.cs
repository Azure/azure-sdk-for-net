// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Identity.Tests.Mock
{
    internal class MockAzureCliCredentialClient : AzureCliCredentialClient
    {
        private readonly (string, int) _resultGenerator;

        public MockAzureCliCredentialClient((string, int) resultGenerator)
        {
            _resultGenerator = resultGenerator;
        }

        public override (string, int) GetAzureCliAccesToken(string resource)
        {
            return _resultGenerator;
        }
    }
}
