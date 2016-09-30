// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent.Resource.Authentication;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using Microsoft.Azure.Management.Fluent.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fluent.Tests
{
    public class StorageUsagesTests
    {
        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanListUsages()
        {
            var storageManger = CreateStorageManager();
            var usages = storageManger.Usages.List();
        }

        private IStorageManager CreateStorageManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(@"C:\my.azureauth");
            return StorageManager
                .Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }
    }
}
