// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.RecoveryServicesBackup.Tests;

public class BasicRecoveryServicesBackupTests
{
    internal static Trycep CreateVmBackupPolicyTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:RecoveryServicesBackupBasic
                Infrastructure infra = new();
                DateTimeOffset backupTime = DateTimeOffset.Parse("2026-01-01T02:00:00Z");

                BackupProtectionPolicy policy =
                    new(nameof(policy), BackupProtectionPolicy.ResourceVersions.V2026_01_01)
                    {
                        Name = "example-vault/daily-vm-policy",
                        Properties = new IaasVmProtectionPolicy
                        {
                            SchedulePolicy = new SimpleSchedulePolicy
                            {
                                ScheduleRunFrequency = ScheduleRunType.Daily,
                                ScheduleRunTimes = { backupTime },
                            },
                            RetentionPolicy = new LongTermRetentionPolicy
                            {
                                DailySchedule = new DailyRetentionSchedule
                                {
                                    RetentionTimes = { backupTime },
                                    RetentionDuration = new RetentionDuration
                                    {
                                        Count = 7,
                                        DurationType = RetentionDurationType.Days,
                                    },
                                },
                            },
                            TimeZone = "UTC",
                        },
                    };
                infra.Add(policy);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.recoveryservices/vaults/backuppolicies")]
    public async Task CreateVmBackupPolicy()
    {
        await using Trycep test = CreateVmBackupPolicyTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource policy 'Microsoft.RecoveryServices/vaults/backupPolicies@2026-01-01' = {
              name: 'example-vault/daily-vm-policy'
              location: location
              properties: {
                backupManagementType: 'AzureIaasVM'
                retentionPolicy: {
                  dailySchedule: {
                    retentionDuration: {
                      count: 7
                      durationType: 'Days'
                    }
                    retentionTimes: [
                      '2026-01-01T02:00:00.0000000Z'
                    ]
                  }
                  retentionPolicyType: 'LongTermRetentionPolicy'
                }
                schedulePolicy: {
                  schedulePolicyType: 'SimpleSchedulePolicy'
                  scheduleRunFrequency: 'Daily'
                  scheduleRunTimes: [
                    '2026-01-01T02:00:00.0000000Z'
                  ]
                }
                timeZone: 'UTC'
              }
            }
            """);
    }
}
