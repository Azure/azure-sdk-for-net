// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Storage;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.ReadmeSnippets;

internal class ToBicepExpressionMethodSnippets
{
    [Test]
    [Ignore("Ignore this since this is a snippet instead of a test")]
    public void ToBicepExpression_CommonUseCases()
    {
        #region Snippet:CommonUseCases
        // Create a storage account
        StorageAccount storage = new(nameof(storage), StorageAccount.ResourceVersions.V2023_01_01)
        {
            Name = "mystorageaccount",
            Kind = StorageKind.StorageV2
        };

        // Reference the storage account name in a connection string
        BicepValue<string> connectionString = BicepFunction.Interpolate(
            $"AccountName={storage.Name.ToBicepExpression()};EndpointSuffix=core.windows.net"
        );
        // this would produce: 'AccountName=${storage.name};EndpointSuffix=core.windows.net'
        // If we do not call ToBicepExpression()
        BicepValue<string> nonExpressionConnectionString =
            BicepFunction.Interpolate(
                $"AccountName={storage.Name};EndpointSuffix=core.windows.net"
            );
        // this would produce: 'AccountName=mystorageaccount;EndpointSuffix=core.windows.net'
        #endregion
    }
}
