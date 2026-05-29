// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Azure.Generator.Mgmt.Tests
{
    internal class ResourceVisitorTests
    {
        [Test]
        public void OutputOnlyResourceCollectionPropertyUsesReadOnlyList()
        {
            var (client, inputModels) = InputResourceData.ClientWithResource(includeZonesList: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => inputModels, clients: () => [client]);

            var model = plugin.Object.TypeFactory.CreateModel(inputModels[0])!;
            var rendered = new TypeProviderWriter(model).Write().Content;

            Assert.That(model.Properties.Single(p => p.Name == "Zones").Type.FrameworkType, Is.EqualTo(typeof(IReadOnlyList<>)));
            Assert.That(rendered, Does.Contain("public global::System.Collections.Generic.IReadOnlyList<string> Zones"));
        }

        [Test]
        public void OutputOnlyResourceDictionaryPropertyUsesReadOnlyDictionary()
        {
            var (client, inputModels) = InputResourceData.ClientWithResource(isInputModel: true, isTagsReadOnly: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => inputModels, clients: () => [client]);

            var model = plugin.Object.TypeFactory.CreateModel(inputModels[0])!;
            var rendered = new TypeProviderWriter(model).Write().Content;

            Assert.That(model.Properties.Single(p => p.Name == "Tags").Type.FrameworkType, Is.EqualTo(typeof(IReadOnlyDictionary<,>)));
            Assert.That(rendered, Does.Contain("public global::System.Collections.Generic.IReadOnlyDictionary<string, string> Tags"));
        }

        [Test]
        public void ExistingReadOnlyResourceDictionaryPropertyKeepsReadOnlyDictionary()
        {
            var (client, inputModels) = InputResourceData.ClientWithResource(isInputModel: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => inputModels, clients: () => [client]);

            var model = plugin.Object.TypeFactory.CreateModel(inputModels[0])!;
            SetLastContractView(model, new LastContractModelView(model, new CSharpType(typeof(IReadOnlyDictionary<string, string>)), "Tags"));
            VisitType(model);
            var rendered = new TypeProviderWriter(model).Write().Content;

            Assert.That(model.Properties.Single(p => p.Name == "Tags").Type.FrameworkType, Is.EqualTo(typeof(IReadOnlyDictionary<,>)));
            Assert.That(rendered, Does.Contain("public global::System.Collections.Generic.IReadOnlyDictionary<string, string> Tags"));
        }

        private static void SetLastContractView(TypeProvider typeProvider, TypeProvider lastContractView)
        {
            typeof(TypeProvider).GetField(
                    "_lastContractView",
                    BindingFlags.NonPublic | BindingFlags.Instance)!
                .SetValue(typeProvider, new Lazy<TypeProvider?>(() => lastContractView));
        }

        private static void VisitType(TypeProvider typeProvider)
        {
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitTypeCore, Is.Not.Null);

            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visitTypeCore!.Invoke(visitor, [typeProvider]);
            }
        }

        private class LastContractModelView : TypeProvider
        {
            private readonly TypeProvider _enclosingType;
            private readonly CSharpType _propertyType;
            private readonly string _propertyName;

            public LastContractModelView(TypeProvider enclosingType, CSharpType propertyType, string propertyName)
            {
                _enclosingType = enclosingType;
                _propertyType = propertyType;
                _propertyName = propertyName;
            }

            protected override string BuildName() => _enclosingType.Name;
            protected override string BuildRelativeFilePath() => $"{Name}.cs";

            protected override PropertyProvider[] BuildProperties()
            {
                return
                [
                    new PropertyProvider(
                        null,
                        MethodSignatureModifiers.Public,
                        _propertyType,
                        _propertyName,
                        new AutoPropertyBody(true),
                        _enclosingType)
                ];
            }
        }
    }
}
