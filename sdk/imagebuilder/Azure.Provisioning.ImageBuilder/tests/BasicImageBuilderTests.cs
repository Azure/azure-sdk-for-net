// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ImageBuilder.Tests;

public class BasicImageBuilderTests
{
    internal static Trycep CreateImageTemplateTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:ImageBuilderBasic
                Infrastructure infra = new();

                ImageTemplate template =
                    new(nameof(template), ImageTemplate.ResourceVersions.V2025_10_01)
                    {
                        Identity = new ImageTemplateIdentity
                        {
                            Type = ImageBuilderIdentityType.None,
                        },
                        Source = new ImageTemplateManagedImageSource
                        {
                            ImageId = new ResourceIdentifier(
                                "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/source-rg/providers/Microsoft.Compute/images/source-image")
                        },
                        Tags = { ["environment"] = "test" },
                    };
                template.Distribute.Add(
                    new ImageTemplateManagedImageDistributor
                    {
                        ImageId = new ResourceIdentifier(
                            "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/output-rg/providers/Microsoft.Compute/images/output-image"),
                        Location = new AzureLocation("westus2"),
                        RunOutputName = "managed-image",
                    });
                infra.Add(template);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateImageTemplate()
    {
        await using Trycep test = CreateImageTemplateTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource template 'Microsoft.VirtualMachineImages/imageTemplates@2025-10-01' = {
              name: take('template-${uniqueString(resourceGroup().id)}', 24)
              location: location
              identity: {
                type: 'None'
              }
              properties: {
                distribute: [
                  {
                    imageId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/output-rg/providers/Microsoft.Compute/images/output-image'
                    location: 'westus2'
                    runOutputName: 'managed-image'
                    type: 'ManagedImage'
                  }
                ]
                source: {
                  imageId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/source-rg/providers/Microsoft.Compute/images/source-image'
                  type: 'ManagedImage'
                }
              }
              tags: {
                environment: 'test'
              }
            }
            """);
    }
}
