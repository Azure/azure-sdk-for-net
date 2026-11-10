// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Visitors;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests
{
    internal class RestClientVisitorTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void RemovesSubClientCacheFieldsWhenRemovingAccessors(int childCount)
        {
            var root = InputFactory.Client("ServiceClient", decorators: []);
            var parent = InputFactory.Client("ParentClient", parent: root, decorators: []);
            for (int i = 0; i < childCount; i++)
            {
                InputFactory.Client($"ChildClient{i}", parent: parent, decorators: []);
            }
            var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [root]);
            var provider = plugin.Object.TypeFactory.CreateClient(parent)!;
            var childTypes = provider.SubClients.Select(child => child.Type).ToHashSet();
            var retainedFields = provider.Fields.Where(field => !childTypes.Contains(field.Type.WithNullable(false))).ToArray();

            Assert.That(provider.Fields.Count(field => childTypes.Contains(field.Type.WithNullable(false))), Is.EqualTo(childCount));
            Assert.That(retainedFields, Is.Not.Empty);

            var visitType = typeof(RestClientVisitor).GetMethod("VisitType", BindingFlags.Instance | BindingFlags.NonPublic)!;
            visitType.Invoke(new RestClientVisitor(), [provider]);

            Assert.That(provider.Fields, Is.EqualTo(retainedFields));
            Assert.That(provider.Methods, Is.EqualTo(provider.RestClient.Methods));
            Assert.That(provider.Methods.Any(method => method.Signature.Name.StartsWith("GetChildClient")), Is.False);
        }
    }
}
