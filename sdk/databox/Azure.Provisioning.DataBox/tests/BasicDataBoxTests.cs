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
                    Details = new DataBoxJobDetails
                    {
                        ContactDetails = new DataBoxContactDetails
                        {
                            ContactName = "Data Box User",
                            Phone = "1234567890",
                            EmailList = ["user@example.com"]
                        }
                    },
                    TransferType = DataBoxJobTransferType.ImportToAzure,
                    Sku = new DataBoxSku
                    {
                        Name = DataBoxSkuName.DataBox
                    }
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
              properties: {
                details: {
                  contactDetails: {
                    contactName: 'Data Box User'
                    emailList: [
                      'user@example.com'
                    ]
                    phone: '1234567890'
                  }
                  jobDetailsType: 'DataBox'
                }
                transferType: 'ImportToAzure'
              }
              sku: {
                name: 'DataBox'
              }
            }
            """);
    }
}
