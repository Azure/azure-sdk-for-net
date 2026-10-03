// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.DataBox.Tests;

public class BasicDataBoxTests
{
    internal static Trycep CreateDataBoxJobTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:DataBoxJobBasic
                Infrastructure infra = new();

                DataBoxJob dataBoxJob = new(nameof(dataBoxJob), DataBoxJob.ResourceVersions.V2025_07_01)
                {
                    Name = "databox-job",
                    Location = new AzureLocation("eastus"),
                    Details = new DataBoxBasicJobDetails(),
                    Sku = new DataBoxSku()
                };
                infra.Add(dataBoxJob);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateDataBoxJob()
    {
        await using Trycep test = CreateDataBoxJobTest();

        test.Compare(
            """
            resource dataBoxJob 'Microsoft.DataBox/jobs@2025-07-01' = {
              name: 'databox-job'
              location: 'eastus'
            }
            """);
    }
}
