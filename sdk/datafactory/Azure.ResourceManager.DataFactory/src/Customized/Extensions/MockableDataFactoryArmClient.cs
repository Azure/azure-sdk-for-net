// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customization adds the GetDataFactoryManagedIdentityCredentialResource extension method
// that the upstream SDK previously exposed. The underlying resource type is restored as a
// hidden ([EditorBrowsable(Never)]) SDK customization for back-compat only.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.DataFactory;

namespace Azure.ResourceManager.DataFactory.Mocking
{
    public partial class MockableDataFactoryArmClient
    {
        /// <summary>
        /// Gets an object representing a <see cref="DataFactoryManagedIdentityCredentialResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DataFactoryManagedIdentityCredentialResource.CreateResourceIdentifier"/> to create a <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DataFactoryManagedIdentityCredentialResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DataFactoryManagedIdentityCredentialResource GetDataFactoryManagedIdentityCredentialResource(ResourceIdentifier id)
        {
            DataFactoryManagedIdentityCredentialResource.ValidateResourceId(id);
            return new DataFactoryManagedIdentityCredentialResource(Client, id);
        }
    }
}
