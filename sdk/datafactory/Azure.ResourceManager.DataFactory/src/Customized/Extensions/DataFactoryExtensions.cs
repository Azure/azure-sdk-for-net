// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.DataFactory.Mocking;

namespace Azure.ResourceManager.DataFactory
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.DataFactory. </summary>
    public static partial class DataFactoryExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="DataFactoryManagedIdentityCredentialResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DataFactoryManagedIdentityCredentialResource.CreateResourceIdentifier" /> to create a <see cref="DataFactoryManagedIdentityCredentialResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableDataFactoryArmClient.GetDataFactoryManagedIdentityCredentialResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="DataFactoryManagedIdentityCredentialResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataFactoryManagedIdentityCredentialResource GetDataFactoryManagedIdentityCredentialResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableDataFactoryArmClient(client).GetDataFactoryManagedIdentityCredentialResource(id);
        }
    }
}
