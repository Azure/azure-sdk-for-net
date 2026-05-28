// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

using Azure.Storage.Blobs;
using Azure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Microsoft.Azure.Batch.Conventions.Files.IntegrationTests
{
    internal static class StorageConfiguration
    {
        private const string AccountNameEnvironmentVariable = "MABOM_StorageAccount";
        private const string AccountKeyEnvironmentVariable = "MABOM_StorageKey";
        private const string StorageAccountBlobEndpointVariable = "MABOM_BlobEndpoint";

        internal static BlobServiceClient GetAccount(ITestOutputHelper output)
        {
            var accountName = Environment.GetEnvironmentVariable(AccountNameEnvironmentVariable);
            var accountKey = Environment.GetEnvironmentVariable(AccountKeyEnvironmentVariable);
            var blobEndpoint = Environment.GetEnvironmentVariable(StorageAccountBlobEndpointVariable);

            var unset = new List<string>();

            if (String.IsNullOrEmpty(accountName))
            {
                unset.Add(AccountNameEnvironmentVariable);
            }

            if (String.IsNullOrEmpty(accountKey))
            {
                unset.Add(AccountKeyEnvironmentVariable);
            }

            if (unset.Any())
            {
                var error = $"Blob Service Client not configured for integration tests: environment variable(s) {string.Join(" and ", unset)} not set.";
                output?.WriteLine(error);
                throw new InvalidOperationException(error);
            }

            try
            {
                var credentials = new StorageSharedKeyCredential(accountName, accountKey);
                var blobClient = new BlobServiceClient(new Uri(blobEndpoint), credentials);
                return blobClient;
            }
            catch (Exception ex)
            {
                var error = $"Storage account incorrectly configured for integration tests: error creating account object '{ex.Message}'.";
                output?.WriteLine(error);
                throw new InvalidOperationException(error, ex);
            }
        }
    }
}
