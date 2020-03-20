// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class DataLakeSasBuilderTests
    {
        private readonly DataLakeSasPermissions _sasPermissions = DataLakeSasPermissions.All;

        [Test]
        public void EnsureStateTests()
        {
            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder();

            // No Identifier, Permissions and ExpiresOn not present.
            TestHelper.AssertExpectedException(
                () => sasBuilder.EnsureState(),
                new InvalidOperationException("SAS is missing required parameter: Permissions"));

            sasBuilder.SetPermissions(_sasPermissions);

            // No Identifier, ExpiresOn not present.
            TestHelper.AssertExpectedException(
                () => sasBuilder.EnsureState(),
                new InvalidOperationException("SAS is missing required parameter: ExpiresOn"));
        }
    }
}
