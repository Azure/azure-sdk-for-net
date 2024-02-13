// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Provisioning
{
    /// <summary>
    /// Represents a <see cref="Resource"/> with a strongly typed properties object.
    /// </summary>
    /// <typeparam name="T">The type from Azure ResourceManager Sdk that represents the properties for the resource.</typeparam>
#pragma warning disable SA1649 // File name should match first type name
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Resource<T> : Resource
#pragma warning restore AZC0012 // Avoid single word type names
#pragma warning restore SA1649 // File name should match first type name
        where T : notnull
    {
        /// <summary>
        /// Gets the properties of the resource.
        /// </summary>
        public T Properties { get; }

        /// <inheritdoc/>
        protected Resource(IConstruct scope, Resource? parent, string resourceName, ResourceType resourceType, string version, T properties)
            : base(scope, parent, resourceName, resourceType, version, properties)
        {
            Properties = properties;
        }
    }
}
