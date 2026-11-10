// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.Generator.MgmtTypeSpec.Tests
{
    internal class KnownManagementDeserializationTests
    {
        [TestCase("W", false)]
        [TestCase("J", false)]
        [TestCase("W", true)]
        [TestCase("J", true)]
        public void NestedManagementModelsPreserveUtf8AndOptions(string format, bool useJsonReader)
        {
            const string payload = """
                {
                  "name": "outer",
                  "location": "westus",
                  "systemData": {
                    "createdBy": "cr\u00e9ateur-\u4e2d",
                    "createdByType": "User"
                  },
                  "identity": {
                    "type": "SystemAssigned,UserAssigned",
                    "principalId": "11111111-1111-1111-1111-111111111111",
                    "tenantId": "22222222-2222-2222-2222-222222222222",
                    "userAssignedIdentities": {}
                  },
                  "plan": { "name": "plan", "publisher": "pub\u00e9", "product": "product" }
                }
                """;
            var options = new ModelReaderWriterOptions(format);
            var context = AzureGeneratorMgmtTypeSpecTestsContext.Default;
            var data = new BinaryData(payload.Replace("cr\\u00e9ateur-\\u4e2d", "cr\u00e9ateur-\u4e2d"));
            var model = ModelReaderWriter.Read<FooData>(data, options, context)!;
            if (useJsonReader)
            {
                var reader = new Utf8JsonReader(data.ToMemory().Span);
                model = ((IJsonModel<FooData>)model).Create(ref reader, options)!;
            }

            // Both generated Create paths have disposed their JsonDocument before these assertions.
            Assert.Multiple(() =>
            {
                Assert.That(model.Name, Is.EqualTo("outer"));
                Assert.That(model.SystemData.CreatedBy, Is.EqualTo("cr\u00e9ateur-\u4e2d"));
                Assert.That(model.Identity.ManagedServiceIdentityType,
                    Is.EqualTo(ManagedServiceIdentityType.SystemAssignedUserAssigned));
                Assert.That(model.Identity.PrincipalId, Is.EqualTo(Guid.Parse("11111111-1111-1111-1111-111111111111")));
                Assert.That(model.Identity.TenantId, Is.EqualTo(Guid.Parse("22222222-2222-2222-2222-222222222222")));
                Assert.That(model.Plan.Publisher, Is.EqualTo("pub\u00e9"));
            });

            using var systemData = JsonDocument.Parse(ModelReaderWriter.Write(model.SystemData, new ModelReaderWriterOptions("J"), context));
            Assert.That(systemData.RootElement.GetProperty("createdBy").GetString(), Is.EqualTo("cr\u00e9ateur-\u4e2d"));
        }
    }
}
