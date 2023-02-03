// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.GraphServices.Tests.Helpers
{
    /// <summary>
    /// A helper class used to retrieve information to be used for tests.
    /// </summary>
    public class AccountTestEnvironment: TestEnvironment
    {
        public string ApplicationIDClient => GetRecordedVariable("AZURE_CLIENT_ID");
    }
}
