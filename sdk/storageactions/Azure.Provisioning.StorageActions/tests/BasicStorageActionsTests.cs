// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.StorageActions.Tests;

public class BasicStorageActionsTests
{
    internal static Trycep CreateStorageTaskTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:StorageActionsBasic
                Infrastructure infra = new();

                StorageTask task =
                    new(nameof(task), StorageTask.ResourceVersions.V2023_01_01)
                    {
                        Identity = new ManagedServiceIdentity
                        {
                            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned,
                        },
                        Properties = new StorageTaskProperties
                        {
                            Description = "Move cool-tier blobs to the hot tier",
                            IsEnabled = true,
                            Action = new StorageTaskAction
                            {
                                If = new StorageTaskIfCondition
                                {
                                    Condition = "[[equals(AccessTier, 'Cool')]]",
                                    Operations =
                                    {
                                        new StorageTaskOperationInfo
                                        {
                                            Name = StorageTaskOperationName.SetBlobTier,
                                            Parameters = { ["tier"] = "Hot" },
                                            OnSuccess = OnSuccessAction.Continue,
                                            OnFailure = OnFailureAction.Break,
                                        },
                                    },
                                },
                            },
                        },
                    };
                infra.Add(task);

                infra.Add(new ProvisioningOutput("taskId", typeof(string)) { Value = task.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateStorageTask()
    {
        await using Trycep test = CreateStorageTaskTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource task 'Microsoft.StorageActions/storageTasks@2023-01-01' = {
              name: take('task${uniqueString(resourceGroup().id)}', 18)
              location: location
              identity: {
                type: 'SystemAssigned'
              }
              properties: {
                action: {
                  if: {
                    condition: '[[equals(AccessTier, \'Cool\')]]'
                    operations: [
                      {
                        name: 'SetBlobTier'
                        onFailure: 'break'
                        onSuccess: 'continue'
                        parameters: {
                          tier: 'Hot'
                        }
                      }
                    ]
                  }
                }
                description: 'Move cool-tier blobs to the hot tier'
                enabled: true
              }
            }

            output taskId string = task.id
            """);
    }
}
