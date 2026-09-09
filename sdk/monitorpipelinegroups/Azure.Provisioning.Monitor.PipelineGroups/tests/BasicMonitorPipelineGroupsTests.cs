// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Monitor.PipelineGroups.Tests;

public class BasicMonitorPipelineGroupsTests
{
    internal static Trycep CreatePipelineGroupTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:MonitorPipelineGroupBasic
                Infrastructure infra = new();

                PipelineGroup pipelineGroup =
                    new(nameof(pipelineGroup), PipelineGroup.ResourceVersions.V2024_10_01_PREVIEW)
                    {
                        Properties = new PipelineGroupProperties
                        {
                            Receivers = new BicepList<PipelineGroupReceiver>([]),
                            Processors = new BicepList<PipelineGroupProcessor>([]),
                            Exporters = new BicepList<PipelineGroupExporter>([]),
                            Service = new PipelineGroupService
                            {
                                Pipelines = new BicepList<PipelineGroupPipeline>([]),
                            },
                        },
                    };
                infra.Add(pipelineGroup);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/tree/master/quickstarts/microsoft.monitor")]
    public async Task CreatePipelineGroup()
    {
        await using Trycep test = CreatePipelineGroupTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource pipelineGroup 'Microsoft.Monitor/pipelineGroups@2024-10-01-preview' = {
              name: take('pipelineGroup-${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                exporters: []
                processors: []
                receivers: []
                service: {
                  pipelines: []
                }
              }
            }
            """);
    }
}
