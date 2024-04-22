// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.SignalR;
using Azure.ResourceManager.SignalR.Models;

namespace Azure.Provisioning.SignalR
{
    /// <summary>
    /// Represents a SignalR.
    /// </summary>
    public class SignalRService : Resource<SignalRData>
    {
        // https://learn.microsoft.com/azure/templates/microsoft.signalrservice/2022-02-01/signalr?pivots=deployment-language-bicep
        private const string ResourceTypeName = "Microsoft.SignalRService/signalR";
        // https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/signalr/Azure.ResourceManager.SignalR/src/Generated/RestOperations/SignalRRestOperations.cs#L36
        private const string DefaultVersion = "2022-02-01";

        private static SignalRData Empty(string name) => ArmSignalRModelFactory.SignalRData();

        /// <summary>
        /// Creates a new instance of the <see cref="SignalRService"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="sku">The SKU.</param>
        /// <param name="allowedOrigins">The allowed origins.</param>
        /// <param name="serviceMode">The service mode.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public SignalRService(
            IConstruct scope,
            SignalRResourceSku? sku = default,
            IEnumerable<string>? allowedOrigins = default,
            string serviceMode = "Default",
            ResourceGroup? parent = default,
            string name = "signalr",
            string version = DefaultVersion,
            AzureLocation? location = default)
            : this(scope, parent, name, version, false, (name) => ArmSignalRModelFactory.SignalRData(
                name: name,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                sku: sku ?? new SignalRResourceSku("Free_F1") { Capacity = 1 },
                corsAllowedOrigins: allowedOrigins ?? new string[] { "*" },
                features: new SignalRFeature[] { new SignalRFeature(SignalRFeatureFlag.ServiceMode, serviceMode) }))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
        }

        private SignalRService(
            IConstruct scope,
            ResourceGroup? parent,
            string name,
            string version = DefaultVersion,
            bool isExisting = false,
            Func<string, SignalRData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SignalRService"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static SignalRService FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new SignalRService(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => GetGloballyUniqueName(resourceName);
    }
}
