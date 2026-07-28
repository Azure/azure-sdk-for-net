// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using Azure;
using Azure.ResourceManager.ApiManagement.Mocking;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class CompatibilityTests
    {
        [Test]
        public void OptionalListCallsUseGeneratedOverloads()
        {
            Func<ApiGatewayCollection, Pageable<ApiGatewayResource>> collectionCall = collection => collection.GetAll();
            Func<SubscriptionResource, Pageable<ApiGatewayResource>> extensionCall = subscription => subscription.GetApiGateways();

            Assert.That(collectionCall, Is.Not.Null);
            Assert.That(extensionCall, Is.Not.Null);
        }

        [Test]
        public void LegacyListOverloadsRetainBinarySignaturesWithoutOptionalDefaults()
        {
            var collectionMethod = typeof(ApiGatewayCollection).GetMethod(nameof(ApiGatewayCollection.GetAll), [typeof(CancellationToken)]);
            var mockableMethod = typeof(MockableApiManagementSubscriptionResource).GetMethod(
                nameof(MockableApiManagementSubscriptionResource.GetApiGateways),
                [typeof(CancellationToken)]);
            var extensionMethod = typeof(ApiManagementExtensions).GetMethods()
                .Single(method => method.Name == nameof(ApiManagementExtensions.GetApiGateways) &&
                    method.GetParameters().Length == 2);

            Assert.That(collectionMethod, Is.Not.Null);
            Assert.That(mockableMethod, Is.Not.Null);
            Assert.That(collectionMethod.GetParameters()[0].IsOptional, Is.False);
            Assert.That(mockableMethod.GetParameters()[0].IsOptional, Is.False);
            Assert.That(extensionMethod.GetParameters()[1].IsOptional, Is.False);
        }

        [Test]
        public void LegacyTlsPropertiesForwardToCorrectedProperties()
        {
            var data = new ApiManagementGatewayHostnameConfigurationData
            {
                IsTls1_0Enabled = true,
                IsTls1_1Enabled = false
            };

            Assert.That(data.IsTls10Enabled, Is.True);
            Assert.That(data.IsTls11Enabled, Is.False);
        }
    }
}
