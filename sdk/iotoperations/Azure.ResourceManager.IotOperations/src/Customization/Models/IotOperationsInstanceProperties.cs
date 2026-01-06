// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.IotOperations.Models
{
    public partial class IotOperationsInstanceProperties
    {
        /// <summary> Initializes a new instance of <see cref="IotOperationsInstanceProperties"/>. </summary>
        /// <param name="schemaRegistryRef"> The reference to the Schema Registry for this AIO Instance. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="schemaRegistryRef"/> is null. </exception>
        public IotOperationsInstanceProperties(SchemaRegistryRef schemaRegistryRef)
        {
            Argument.AssertNotNull(schemaRegistryRef, nameof(schemaRegistryRef));

            SchemaRegistryRef = schemaRegistryRef;
            Features = new ChangeTrackingDictionary<string, IotOperationsInstanceFeature>();
        }
    }
}
