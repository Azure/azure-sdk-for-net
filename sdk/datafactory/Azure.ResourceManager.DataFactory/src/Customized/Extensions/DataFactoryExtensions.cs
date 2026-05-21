// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customization adds back-compat extension methods that the upstream SDK previously exposed.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.DataFactory.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DataFactory
{
    public static partial class DataFactoryExtensions
    {
        private static MockableDataFactoryArmClient GetMockableDataFactoryArmClientForManagedIdentityCredential(ArmClient client)
        {
            return client.GetCachedClient(c => new MockableDataFactoryArmClient(c, ResourceIdentifier.Root));
        }

        /// <summary>
        /// Gets an object representing a <see cref="DataFactoryManagedIdentityCredentialResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DataFactoryManagedIdentityCredentialResource.CreateResourceIdentifier"/> to create a <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DataFactoryManagedIdentityCredentialResource"/> object. </returns>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataFactoryManagedIdentityCredentialResource GetDataFactoryManagedIdentityCredentialResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableDataFactoryArmClientForManagedIdentityCredential(client).GetDataFactoryManagedIdentityCredentialResource(id);
        }

        /// <summary> Back-compat overload of GetDataFactory taking <paramref name="ifNoneMatch"/> as a string. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<DataFactoryResource> GetDataFactory(this ResourceGroupResource resourceGroupResource, string factoryName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetDataFactory(factoryName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Back-compat overload of GetDataFactoryAsync taking <paramref name="ifNoneMatch"/> as a string. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<DataFactoryResource>> GetDataFactoryAsync(this ResourceGroupResource resourceGroupResource, string factoryName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetDataFactoryAsync(factoryName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }
    }
}
