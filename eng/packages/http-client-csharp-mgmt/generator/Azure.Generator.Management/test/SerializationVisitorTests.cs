// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;
using System.Reflection;

namespace Azure.Generator.Mgmt.Tests
{
    public class SerializationVisitorTests
    {
        [Test]
        public void ResourceSerializationRetainsManagementHelpersAfterAllVisitors(
            [Values] bool isDynamicModel,
            [Values] bool rebuildMethods)
        {
            var (client, models) = InputResourceData.ClientWithResource(
                isInputModel: true,
                isDynamicModel: isDynamicModel);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [client]);
            var model = plugin.Object.TypeFactory.CreateModel(models.Single())!;
            var visit = typeof(LibraryVisitor).GetMethod("VisitLibrary", BindingFlags.NonPublic | BindingFlags.Instance)!;

            foreach (var visitor in plugin.Object.Visitors)
            {
                visit.Invoke(visitor, [plugin.Object.OutputLibrary]);
            }

            var serialization = model.SerializationProviders.OfType<MrwSerializationTypeDefinition>().Single();
            if (rebuildMethods)
            {
                serialization.ResetMethods();
            }

            var content = plugin.Object.GetWriter(serialization).Write().Content;
            Assert.That(serialization.Methods.Select(m => m.Signature.Name), Does.Contain("FromResponse"));
            Assert.That(serialization.Methods.Select(m => m.Signature.Name), Does.Contain("ToRequestContent"));
            Assert.That(serialization.Methods.Any(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator)), Is.False);
            Assert.That(content, Does.Contain("FromResponse("));
            Assert.That(content, Does.Contain("ToRequestContent("));
            Assert.That(content, Does.Not.Contain(" operator "));
            Assert.That(plugin.Object.GetWriter(serialization).Write().Content, Is.EqualTo(content));
        }
    }
}
