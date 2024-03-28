// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.WebPubSub;
using Azure.ResourceManager.WebPubSub.Models;

namespace Azure.Provisioning.WebPubSub
{
    /// <summary>
    /// Represents a WebPubSub.
    /// </summary>
    public class WebPubSubService : Resource<WebPubSubData>
    {
        // https://learn.microsoft.com/azure/templates/microsoft.signalrservice/2023-02-01/webPubSub?pivots=deployment-language-bicep
        private const string ResourceTypeName = "Microsoft.SignalRService/webPubSub";
        // https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.ResourceManager.WebPubSub/src/Generated/RestOperations/WebPubSubRestOperations.cs#L36
        internal const string DefaultVersion = "2021-10-01";

        private static WebPubSubData Empty(string name) => ArmWebPubSubModelFactory.WebPubSubData();

        /// <summary>
        /// Creates a new instance of the <see cref="WebPubSubService"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="sku">The SKU.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public WebPubSubService(
            IConstruct scope,
            BillingInfoSku? sku = default,
            ResourceGroup? parent = default,
            string name = "WebPubSub",
            string version = DefaultVersion,
            AzureLocation? location = default)
            : this(scope, parent, name, version, false, (name) => ArmWebPubSubModelFactory.WebPubSubData(
                name: name,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                sku: sku ?? new BillingInfoSku("Free_F1") { Capacity = 1 }))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
        }

        private WebPubSubService(
            IConstruct scope,
            ResourceGroup? parent,
            string name,
            string version = DefaultVersion,
            bool isExisting = false,
            Func<string, WebPubSubData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="WebPubSubService"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The WebPubSub service instance.</returns>
        public static WebPubSubService FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new WebPubSubService(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => GetGloballyUniqueName(resourceName);
    }
}
