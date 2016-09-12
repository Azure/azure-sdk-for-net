using System;
using Microsoft.Azure;

namespace Microsoft.AzureStack.AzureConsistentStorage.Tests
{
    public class TestBase
    {
        protected StorageAdminManagementClient GetClient(RecordedDelegatingHandler handler, TokenCloudCredentials token)
        {
            handler.IsPassThrough = false;
            var client = new StorageAdminManagementClient(token, new Uri(Constants.BaseUri)).WithHandler(handler);
            return client;
        }
    }
}