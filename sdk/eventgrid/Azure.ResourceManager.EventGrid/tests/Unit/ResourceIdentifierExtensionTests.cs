// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests.Unit
{
    public class ResourceIdentifierExtensionTests
    {
        [TestCase("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgName/providers/Microsoft.EventGrid/parents/parentName", "Microsoft.EventGrid", "parents", "parentName")]
        [TestCase("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgName/providers/Microsoft.EventGrid/parents/parentName/children/childName", "Microsoft.EventGrid", "parents/parentName/children", "childName")]
        public void ValidateSplitResourceIdentifierIntoParts(string rawId, string ns, string parentName, string name)
        {
            var scope = new ResourceIdentifier(rawId);
            var parentPart = scope.Parent.SubstringAfterProviderNamespace();
            var actualParentName = (string.IsNullOrEmpty(parentPart) ? string.Empty : $"{parentPart}/") + scope.ResourceType.GetLastType();
            Assert.AreEqual(ns, scope.ResourceType.Namespace);
            Assert.AreEqual(parentName, actualParentName);
            Assert.AreEqual(name, scope.Name);
        }
    }
}
