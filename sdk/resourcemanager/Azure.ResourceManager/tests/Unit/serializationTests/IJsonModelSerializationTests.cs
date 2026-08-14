// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    /// <summary>
    /// Verifies that all IJsonModel types in Azure.ResourceManager can be deserialized
    /// using AzureResourceManagerContext without throwing exceptions.
    /// This catches issues like https://github.com/Azure/azure-sdk-for-net/issues/53528
    /// where a referenced type (e.g. ResponseError) was missing from the context.
    /// </summary>
    [Parallelizable]
    public class IJsonModelSerializationTests
    {
        private static readonly ModelReaderWriterOptions WireOptions = ModelSerializationExtensions.WireOptions;

        /// <summary>
        /// Discovers all types (public and internal) in the Azure.ResourceManager assembly
        /// that implement IJsonModel&lt;T&gt; and returns test cases using the model type T
        /// for deserialization. Internal types are included because they may be deserialized
        /// as nested types within public models.
        /// Resource types (e.g. TenantResource) implement IJsonModel&lt;TenantData&gt;, so we
        /// extract T from the interface and use it as the deserialization target.
        /// </summary>
        public static IEnumerable<TestCaseData> AllIJsonModelTypes()
        {
            var assembly = typeof(AzureResourceManagerContext).Assembly;
            var jsonModelOpenType = typeof(IJsonModel<>);
            var seen = new HashSet<Type>();

            foreach (var type in assembly.GetTypes()
                .Where(t => !t.IsAbstract && t.IsClass)
                .OrderBy(t => t.FullName))
            {
                var jsonModelInterface = type.GetInterfaces()
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == jsonModelOpenType);

                if (jsonModelInterface != null)
                {
                    // Use the model type T from IJsonModel<T>, not the implementing class
                    var modelType = jsonModelInterface.GetGenericArguments()[0];
                    if (seen.Add(modelType))
                    {
                        yield return new TestCaseData(modelType).SetName($"Deserialize_{modelType.Name}_FromEmptyJson");
                    }
                }
            }
        }

        [TestCaseSource(nameof(AllIJsonModelTypes))]
        public void DeserializeFromEmptyJsonDoesNotThrow(Type modelType)
        {
            var json = new BinaryData(Encoding.UTF8.GetBytes("{}"));

            // This verifies the AzureResourceManagerContext has a builder for the type.
            // Some models throw ArgumentNullException or similar when given empty JSON
            // due to required properties - those are acceptable. We only fail on
            // InvalidOperationException indicating a missing ModelReaderWriterTypeBuilder,
            // which is the issue from https://github.com/Azure/azure-sdk-for-net/issues/53528.
            try
            {
                ModelReaderWriter.Read(json, modelType, WireOptions, AzureResourceManagerContext.Default);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("ModelReaderWriterTypeBuilder"))
            {
                Assert.Fail($"Missing ModelReaderWriterTypeBuilder for {modelType.FullName}: {ex.Message}");
            }
            catch (Exception)
            {
                // Other exceptions (e.g. ArgumentNullException for required properties)
                // are acceptable - they indicate the builder was found but the empty JSON
                // didn't satisfy the model's requirements.
            }
        }

        /// <summary>
        /// Test cases for models that contain nested types deserialized via
        /// ModelReaderWriter.Read with AzureResourceManagerContext.Default.
        /// These require richer JSON to exercise the nested deserialization paths.
        /// </summary>
        public static IEnumerable<TestCaseData> ModelsWithNestedTypes()
        {
            // ResourceGroupExportResult references ResponseError
            yield return new TestCaseData(
                typeof(Azure.ResourceManager.Resources.Models.ResourceGroupExportResult),
                @"{
                    ""template"": { ""$schema"": ""https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#"" },
                    ""error"": {
                        ""code"": ""ExportTemplateCompletedWithErrors"",
                        ""message"": ""Export template operation completed with errors.""
                    }
                }"
            ).SetName("Deserialize_ResourceGroupExportResult_WithResponseError");

            // OperationStatusResult references ResponseError and self-references (children)
            yield return new TestCaseData(
                typeof(Azure.ResourceManager.Models.OperationStatusResult),
                @"{
                    ""id"": ""/subscriptions/00000000-0000-0000-0000-000000000000/operations/op1"",
                    ""status"": ""Failed"",
                    ""error"": {
                        ""code"": ""InternalError"",
                        ""message"": ""An internal error occurred.""
                    }
                }"
            ).SetName("Deserialize_OperationStatusResult_WithResponseError");

            // GenericResourceData references ArmPlan, ManagedServiceIdentity, ExtendedLocation, SystemData
            yield return new TestCaseData(
                typeof(Azure.ResourceManager.Resources.GenericResourceData),
                @"{
                    ""id"": ""/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Compute/virtualMachines/vm1"",
                    ""name"": ""vm1"",
                    ""type"": ""Microsoft.Compute/virtualMachines"",
                    ""location"": ""eastus"",
                    ""plan"": {
                        ""name"": ""plan1"",
                        ""publisher"": ""pub1"",
                        ""product"": ""prod1""
                    },
                    ""identity"": {
                        ""type"": ""SystemAssigned""
                    },
                    ""extendedLocation"": {
                        ""name"": ""extended1"",
                        ""type"": ""EdgeZone""
                    },
                    ""systemData"": {
                        ""createdBy"": ""user@example.com"",
                        ""createdByType"": ""User"",
                        ""createdAt"": ""2023-01-01T00:00:00Z""
                    }
                }"
            ).SetName("Deserialize_GenericResourceData_WithNestedTypes");

            // PolicyAssignmentData references ManagedServiceIdentity, SystemData
            yield return new TestCaseData(
                typeof(Azure.ResourceManager.Resources.PolicyAssignmentData),
                @"{
                    ""id"": ""/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.Authorization/policyAssignments/pa1"",
                    ""name"": ""pa1"",
                    ""type"": ""Microsoft.Authorization/policyAssignments"",
                    ""identity"": {
                        ""type"": ""SystemAssigned""
                    },
                    ""systemData"": {
                        ""createdBy"": ""user@example.com"",
                        ""createdByType"": ""User"",
                        ""createdAt"": ""2023-01-01T00:00:00Z""
                    },
                    ""properties"": {}
                }"
            ).SetName("Deserialize_PolicyAssignmentData_WithNestedTypes");

            // TrackedResourceExtendedData references ExtendedLocation, SystemData
            yield return new TestCaseData(
                typeof(Azure.ResourceManager.Resources.Models.TrackedResourceExtendedData),
                @"{
                    ""id"": ""/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Test/resources/r1"",
                    ""name"": ""r1"",
                    ""type"": ""Microsoft.Test/resources"",
                    ""location"": ""eastus"",
                    ""extendedLocation"": {
                        ""name"": ""extended1"",
                        ""type"": ""EdgeZone""
                    },
                    ""systemData"": {
                        ""createdBy"": ""user@example.com"",
                        ""createdByType"": ""User"",
                        ""createdAt"": ""2023-01-01T00:00:00Z""
                    }
                }"
            ).SetName("Deserialize_TrackedResourceExtendedData_WithNestedTypes");

            // ManagedServiceIdentity references UserAssignedIdentity
            yield return new TestCaseData(
                typeof(Azure.ResourceManager.Models.ManagedServiceIdentity),
                @"{
                    ""type"": ""UserAssigned"",
                    ""userAssignedIdentities"": {
                        ""/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.ManagedIdentity/userAssignedIdentities/id1"": {}
                    }
                }"
            ).SetName("Deserialize_ManagedServiceIdentity_WithUserAssignedIdentity");
        }

        [TestCaseSource(nameof(ModelsWithNestedTypes))]
        public void DeserializeWithNestedTypesDoesNotThrow(Type modelType, string json)
        {
            var data = new BinaryData(Encoding.UTF8.GetBytes(json));

            Assert.DoesNotThrow(() =>
            {
                ModelReaderWriter.Read(data, modelType, WireOptions, AzureResourceManagerContext.Default);
            }, $"ModelReaderWriter.Read failed for {modelType.FullName} with nested types using AzureResourceManagerContext.");
        }
    }
}
