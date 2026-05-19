// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.CostManagement.Tests;

public class BasicCostManagementTests
{
    internal static Trycep CreateCostManagementExportTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:CostManagementExportBasic
                Infrastructure infra = new();

                CostManagementExport export =
                    new(nameof(export))
                    {
                        Definition = new ExportDefinition
                        {
                            ExportType = ExportType.ActualCost,
                            Timeframe = TimeframeType.MonthToDate,
                        },
                        DeliveryInfoDestination = new ExportDeliveryDestination
                        {
                            Container = "exports",
                            RootFolderPath = "cost-data",
                        },
                        Schedule = new ExportSchedule
                        {
                            Status = ExportScheduleStatusType.Active,
                            Recurrence = ExportScheduleRecurrenceType.Weekly,
                        },
                    };
                infra.Add(export);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/en-us/azure/templates/microsoft.costmanagement/exports")]
    public async Task CreateCostManagementExport()
    {
        await using Trycep test = CreateCostManagementExportTest();
        test.Compare(
            """
            resource export 'Microsoft.CostManagement/exports@2023-03-01' = {
              name: take('export${uniqueString(resourceGroup().id)}', 24)
              properties: {
                definition: {
                  type: 'ActualCost'
                  timeframe: 'MonthToDate'
                }
                deliveryInfo: {
                  destination: {
                    container: 'exports'
                    rootFolderPath: 'cost-data'
                  }
                }
                schedule: {
                  status: 'Active'
                  recurrence: 'Weekly'
                }
              }
            }
            """);
    }
}
