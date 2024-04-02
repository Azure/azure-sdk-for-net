// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;

namespace Azure.Provisioning.ResourceManager
{
    /// <summary>
    /// Subscription resource.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public class Subscription : Resource<SubscriptionData>
#pragma warning restore AZC0012 // Avoid single word type names
    {
        internal static readonly ResourceType ResourceType = "Microsoft.Resources/subscriptions";

        /// <summary>
        /// Initializes a new instance of the <see cref="Subscription"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="guid">The <see cref="Guid"/>.</param>
        public Subscription(IConstruct scope, Guid? guid = default)
            : base(
                  scope,
                  scope.Root,
                  guid?.ToString()!,
                  ResourceType,
                  "2022-12-01",
                  (name) => ResourceManagerModelFactory.SubscriptionData(
                      id: SubscriptionResource.CreateResourceIdentifier(name),
                      subscriptionId: name,
                      tenantId: scope.Root.Properties.TenantId))
        {
        }

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string? resourceName)
        {
            if (scope.Configuration?.UseInteractiveMode == true)
            {
                return "subscription()";
            }
            return resourceName ?? Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID") ?? throw new InvalidOperationException("No environment variable named 'AZURE_SUBSCRIPTION_ID' found");
        }
    }
}
