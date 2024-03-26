// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.ManagedServiceIdentities;
using Azure.ResourceManager.ManagedServiceIdentities.Models;

namespace Azure.Provisioning.ManagedServiceIdentities
{
    /// <summary>
    /// Represents a user assigned identity.
    /// </summary>
    public class UserAssignedIdentity : Resource<UserAssignedIdentityData>
    {
        // https://learn.microsoft.com/azure/templates/microsoft.insights/2020-02-02/components?pivots=deployment-language-bicep
        private const string ResourceTypeName = "Microsoft.ManagedIdentity/userAssignedIdentities";
        // https://learn.microsoft.com/azure/templates/microsoft.managedidentity/2023-01-31/userassignedidentities?pivots=deployment-language-bicep
        internal const string DefaultVersion = "2023-01-31";

        private static UserAssignedIdentityData Empty(string name) => ArmManagedServiceIdentitiesModelFactory.UserAssignedIdentityData();

        /// <summary>
        /// Creates a new instance of the <see cref="UserAssignedIdentity"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public UserAssignedIdentity(
            IConstruct scope,
            ResourceGroup? parent = default,
            string name = "useridentity",
            string version = DefaultVersion,
            AzureLocation? location = default)
            : this(scope, parent, name, version, location, false, (name) => ArmManagedServiceIdentitiesModelFactory.UserAssignedIdentityData(
                name: name,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
        }

        private UserAssignedIdentity(
            IConstruct scope,
            ResourceGroup? parent,
            string name,
            string version = DefaultVersion,
            AzureLocation? location = default,
            bool isExisting = false,
            Func<string, UserAssignedIdentityData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="UserAssignedIdentity"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The UserAssignedIdentity instance.</returns>
        public static UserAssignedIdentity FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new UserAssignedIdentity(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => GetGloballyUniqueName(resourceName);
    }
}
