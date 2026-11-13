// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests
{
    public class NetworkFabricFactoryCompatibilityTests
    {
        [Test]
        public void HistoricalAccessControlListFactoriesPreserveFlattenedValues()
        {
            var uri = new Uri("https://example.com/acls");
            var withAction = ArmManagedNetworkFabricModelFactory.NetworkFabricAccessControlListData(
                default, default, default, default, default, AzureLocation.EastUS,
                "annotation", NetworkFabricConfigurationType.File, uri, CommunityActionType.Permit,
                default, default, default, default, default, default);
            Assert.That(withAction.Annotation, Is.EqualTo("annotation"));
            Assert.That(withAction.ConfigurationType, Is.EqualTo(NetworkFabricConfigurationType.File));
            Assert.That(withAction.AclsUri, Is.EqualTo(uri));
            Assert.That(withAction.DefaultAction, Is.EqualTo(CommunityActionType.Permit));

            var withoutAction = ArmManagedNetworkFabricModelFactory.NetworkFabricAccessControlListData(
                default, default, default, default, default, AzureLocation.EastUS,
                "annotation", NetworkFabricConfigurationType.File, uri,
                default, default, default, default, default, default);
            Assert.That(withoutAction.ConfigurationType, Is.EqualTo(NetworkFabricConfigurationType.File));
            Assert.That(withoutAction.AclsUri, Is.EqualTo(uri));
        }
    }
}
