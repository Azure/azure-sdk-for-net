// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class ResourceGroupExportResultTests
    {
        private const string ExportResultWithError = @"{
            ""template"": {
                ""$schema"": ""https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#"",
                ""contentVersion"": ""1.0.0.0"",
                ""resources"": []
            },
            ""error"": {
                ""code"": ""ExportTemplateCompletedWithErrors"",
                ""message"": ""Export template operation completed with errors."",
                ""details"": [
                    {
                        ""code"": ""ExportTemplateProviderError"",
                        ""message"": ""The resource type is not supported for template export.""
                    }
                ]
            }
        }";

        [Test]
        public void DeserializeResourceGroupExportResultWithError()
        {
            // This reproduces https://github.com/Azure/azure-sdk-for-net/issues/53528
            // ResponseError is not in AzureResourceManagerContext, so ModelReaderWriter.Read<ResponseError>()
            // throws InvalidOperationException: "No ModelReaderWriterTypeBuilder found for ResponseError."
            using JsonDocument document = JsonDocument.Parse(ExportResultWithError);
            ResourceGroupExportResult result = ResourceGroupExportResult.DeserializeResourceGroupExportResult(document.RootElement);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Template);
            Assert.IsNotNull(result.Error);
            Assert.AreEqual("ExportTemplateCompletedWithErrors", result.Error.Code);
            Assert.AreEqual("Export template operation completed with errors.", result.Error.Message);
        }

        [Test]
        public void DeserializeResourceGroupExportResultWithoutError()
        {
            string json = @"{
                ""template"": {
                    ""$schema"": ""https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#"",
                    ""contentVersion"": ""1.0.0.0"",
                    ""resources"": []
                }
            }";

            using JsonDocument document = JsonDocument.Parse(json);
            ResourceGroupExportResult result = ResourceGroupExportResult.DeserializeResourceGroupExportResult(document.RootElement);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Template);
            Assert.IsNull(result.Error);
        }
    }
}
