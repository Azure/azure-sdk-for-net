// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.DataFactory.Mocking
{
    // Customization adds GetDataFactoryManagedIdentityCredentialResource to the mockable ArmClient
    // surface (see DataFactoryManagedIdentityCredentialResource for the dual-view rationale). The
    // spec only defines one credential resource (Microsoft.DataFactory/factories/credentials), so
    // the MPG generator does not emit a getter for the SDK-only DataFactoryManagedIdentityCredentialResource
    // view. This partial re-exposes the upstream mocking entry point with [EditorBrowsable(Never)]
    // so tests/mocks keep compiling without polluting IntelliSense.
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
