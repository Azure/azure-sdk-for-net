// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Customization adds an ArmDataFactoryModelFactory factory method for the SDK-only
    // DataFactoryManagedIdentityCredentialData type (see DataFactoryManagedIdentityCredentialResource
    // for the dual-view rationale). Because the spec does not define a separate ManagedIdentityCredential
    // resource, the MPG generator emits only DataFactoryServiceCredentialData on the model factory;
    // this partial keeps the upstream factory signature available for mocking/back-compat consumers.
    public static partial class ArmDataFactoryModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="DataFactoryManagedIdentityCredentialData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> Managed identity credential properties. </param>
        /// <param name="eTag"> Etag identifies change in the resource. </param>
        /// <returns> A new <see cref="DataFactoryManagedIdentityCredentialData"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete. Use ArmDataFactoryModelFactory.DataFactoryServiceCredentialData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataFactoryManagedIdentityCredentialData DataFactoryManagedIdentityCredentialData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, DataFactoryManagedIdentityCredentialProperties properties = default, ETag? eTag = default)
        {
            return new DataFactoryManagedIdentityCredentialData(DataFactoryServiceCredentialData(id, name, resourceType, systemData, properties, eTag));
        }
    }
}
