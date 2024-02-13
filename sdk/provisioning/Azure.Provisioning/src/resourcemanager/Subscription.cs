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

        private static string GetName(Guid? guid) => guid.HasValue ? guid.Value.ToString() : Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID") ?? throw new InvalidOperationException("No environment variable named 'AZURE_SUBSCRIPTION_ID' found");

        /// <summary>
        /// Initializes a new instance of the <see cref="Subscription"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="guid">The <see cref="Guid"/>.</param>
        public Subscription(IConstruct scope, Guid? guid = default)
            : base(
                  scope,
                  scope.Root,
                  GetName(guid),
                  ResourceType,
                  "2022-12-01",
                  ResourceManagerModelFactory.SubscriptionData(
                      id: SubscriptionResource.CreateResourceIdentifier(GetName(guid)),
                      subscriptionId: GetName(guid),
                      tenantId: scope.Root.Properties.TenantId))
        {
        }
    }
}
