// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.WebPubSub;
using Azure.ResourceManager.WebPubSub.Models;

namespace Azure.Provisioning.WebPubSub
{
    /// <summary>
    /// Represents a hub setting for WebPubSub.
    /// </summary>
    public class WebPubSubHub : Resource<WebPubSubHubData>
    {
        // https://learn.microsoft.com/azure/templates/microsoft.signalrservice/2023-02-01/webPubSub/hubs?pivots=deployment-language-bicep
        private const string ResourceTypeName = "Microsoft.SignalRService/webPubSub/hubs";

        private static WebPubSubHubData Empty(string name) => ArmWebPubSubModelFactory.WebPubSubHubData();

        /// <summary>
        /// Creates a new instance of the <see cref="WebPubSubHub"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="properties">The properties of the hub settings.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        public WebPubSubHub(IConstruct scope,
            WebPubSubHubProperties properties,
            WebPubSubService? parent = null,
            string name = "Hub",
            string version = WebPubSubService.DefaultVersion)
            : this(scope, parent, name, version, false, (name) => ArmWebPubSubModelFactory.WebPubSubHubData(
                name: name,
                properties: properties))
        {
        }

        private WebPubSubHub(
            IConstruct scope,
            WebPubSubService? parent,
            string name,
            string version = WebPubSubService.DefaultVersion,
            bool isExisting = false,
            Func<string, WebPubSubHubData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="WebPubSubHub"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The WebPubSub service instance.</returns>
        public static WebPubSubHub FromExisting(IConstruct scope, string name, WebPubSubService? parent = null)
            => new WebPubSubHub(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<WebPubSubService>() ?? new WebPubSubService(scope);
        }
    }
}
