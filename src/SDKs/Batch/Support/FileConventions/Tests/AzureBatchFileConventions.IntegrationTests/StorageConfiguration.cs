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

﻿using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
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
        private const string AccountNameEnvironmentVariable = "MABFC_StorageAccount";
        private const string AccountKeyEnvironmentVariable = "MABFC_StorageKey";

        internal static CloudStorageAccount GetAccount(ITestOutputHelper output)
        {
            var accountName = Environment.GetEnvironmentVariable(AccountNameEnvironmentVariable);
            var accountKey = Environment.GetEnvironmentVariable(AccountKeyEnvironmentVariable);

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
                var error = $"Storage account not configured for integration tests: environment variable(s) {string.Join(" and ", unset)} not set.";
                output?.WriteLine(error);
                throw new InvalidOperationException(error);
            }

            try
            {
                var credentials = new StorageCredentials(accountName, accountKey);
                var account = new CloudStorageAccount(credentials, true);
                return account;
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
