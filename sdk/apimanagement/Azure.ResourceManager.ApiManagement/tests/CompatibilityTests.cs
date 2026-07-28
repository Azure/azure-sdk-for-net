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
            Func<ApiGatewayCollection, CancellationToken, Pageable<ApiGatewayResource>> gatewayCollectionCall =
                (collection, token) => collection.GetAll(cancellationToken: token);
            Func<ApiGatewayCollection, CancellationToken, AsyncPageable<ApiGatewayResource>> gatewayCollectionAsyncCall =
                (collection, token) => collection.GetAllAsync(cancellationToken: token);
            Func<ApiGatewayConfigConnectionCollection, CancellationToken, Pageable<ApiGatewayConfigConnectionResource>> configConnectionCollectionCall =
                (collection, token) => collection.GetAll(cancellationToken: token);
            Func<ApiGatewayConfigConnectionCollection, CancellationToken, AsyncPageable<ApiGatewayConfigConnectionResource>> configConnectionCollectionAsyncCall =
                (collection, token) => collection.GetAllAsync(cancellationToken: token);
            Func<ApiManagementServiceCollection, CancellationToken, Pageable<ApiManagementServiceResource>> serviceCollectionCall =
                (collection, token) => collection.GetAll(cancellationToken: token);
            Func<ApiManagementServiceCollection, CancellationToken, AsyncPageable<ApiManagementServiceResource>> serviceCollectionAsyncCall =
                (collection, token) => collection.GetAllAsync(cancellationToken: token);
            Func<ApiManagementWorkspaceLinksCollection, CancellationToken, Pageable<ApiManagementWorkspaceLinksResource>> workspaceLinksCollectionCall =
                (collection, token) => collection.GetAll(cancellationToken: token);
            Func<ApiManagementWorkspaceLinksCollection, CancellationToken, AsyncPageable<ApiManagementWorkspaceLinksResource>> workspaceLinksCollectionAsyncCall =
                (collection, token) => collection.GetAllAsync(cancellationToken: token);
            Func<SubscriptionResource, CancellationToken, Pageable<ApiGatewayResource>> gatewayExtensionCall =
                (subscription, token) => subscription.GetApiGateways(cancellationToken: token);
            Func<SubscriptionResource, CancellationToken, AsyncPageable<ApiGatewayResource>> gatewayExtensionAsyncCall =
                (subscription, token) => subscription.GetApiGatewaysAsync(cancellationToken: token);
            Func<SubscriptionResource, CancellationToken, Pageable<ApiManagementServiceResource>> serviceExtensionCall =
                (subscription, token) => subscription.GetApiManagementServices(cancellationToken: token);
            Func<SubscriptionResource, CancellationToken, AsyncPageable<ApiManagementServiceResource>> serviceExtensionAsyncCall =
                (subscription, token) => subscription.GetApiManagementServicesAsync(cancellationToken: token);
            Func<MockableApiManagementSubscriptionResource, CancellationToken, Pageable<ApiGatewayResource>> mockableGatewayCall =
                (resource, token) => resource.GetApiGateways(cancellationToken: token);
            Func<MockableApiManagementSubscriptionResource, CancellationToken, AsyncPageable<ApiGatewayResource>> mockableGatewayAsyncCall =
                (resource, token) => resource.GetApiGatewaysAsync(cancellationToken: token);
            Func<MockableApiManagementSubscriptionResource, CancellationToken, Pageable<ApiManagementServiceResource>> mockableServiceCall =
                (resource, token) => resource.GetApiManagementServices(cancellationToken: token);
            Func<MockableApiManagementSubscriptionResource, CancellationToken, AsyncPageable<ApiManagementServiceResource>> mockableServiceAsyncCall =
                (resource, token) => resource.GetApiManagementServicesAsync(cancellationToken: token);

            Assert.That(collectionCall, Is.Not.Null);
            Assert.That(extensionCall, Is.Not.Null);
            Assert.That(
                new Delegate[]
                {
                    gatewayCollectionCall,
                    gatewayCollectionAsyncCall,
                    configConnectionCollectionCall,
                    configConnectionCollectionAsyncCall,
                    serviceCollectionCall,
                    serviceCollectionAsyncCall,
                    workspaceLinksCollectionCall,
                    workspaceLinksCollectionAsyncCall,
                    gatewayExtensionCall,
                    gatewayExtensionAsyncCall,
                    serviceExtensionCall,
                    serviceExtensionAsyncCall,
                    mockableGatewayCall,
                    mockableGatewayAsyncCall,
                    mockableServiceCall,
                    mockableServiceAsyncCall
                },
                Has.All.Not.Null);
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
