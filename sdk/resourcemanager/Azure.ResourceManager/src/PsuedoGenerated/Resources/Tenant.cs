// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing a Tenant along with the instance operations that can be performed on it.
    /// </summary>
    public class Tenant : TenantOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tenant"/> class for mocking.
        /// </summary>
        protected Tenant()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tenant"/> class.
        /// </summary>
        /// <param name="operations"> The operations object to copy the client parameters from. </param>
        /// <param name="tenantData"> The data model representing the generic azure resource. </param>
        internal Tenant(ResourceOperations operations, TenantData tenantData)
            : base(operations.ClientOptions, operations.Credential, operations.BaseUri, operations.Pipeline)
        {
            Data = tenantData;
        }

        /// <summary>
        /// Gets the subscription data model.
        /// </summary>
        public virtual TenantData Data { get; }
    }
}
