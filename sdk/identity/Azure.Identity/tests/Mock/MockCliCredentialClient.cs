// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Identity.Tests.Mock
{
    internal class MockCliCredentialClient : CliCredentialClient
    {
        private readonly (string, int) _resultGenerator;

        public MockCliCredentialClient((string, int) resultGenerator)
        {
            _resultGenerator = resultGenerator;
        }

        public override (string, int) CreateProcess(string extendCommand)
        {
            return _resultGenerator;
        }
    }
}
