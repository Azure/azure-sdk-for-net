// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the a sub resource of ResourceIdentifier.
    /// </summary>
    [ReferenceType]
    public class SubResource : SubResource<ResourceIdentifier>
    {
        /// <summary>
        /// Initializes an empty instance of <see cref="SubResource"/> for mocking.
        /// </summary>
        [InitializationConstructor]
        public SubResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SubResource"/>. </summary>
        /// <param name="id"> ARM resource Id. </param>
        [SerializationConstructor]
        protected internal SubResource(string id) : base(id) { }
    }

    /// <summary>
    /// A class representing a sub-resource that contains only the ID.
    /// </summary>
    [ReferenceType(typeof(ResourceIdentifier))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Types differ by type argument only")]
    public partial class SubResource<TIdentifier>
        where TIdentifier : ResourceIdentifier
    {
        /// <summary>
        /// Initializes an empty instance of <see cref="SubResource{TIdentifier}"/> for mocking.
        /// </summary>
        [InitializationConstructor]
        public SubResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SubResource{TIdentifier}"/>. </summary>
        /// <param name="id"> ARM resource Id. </param>
        [SerializationConstructor]
        protected internal SubResource(string id)
        {
            Id = (TIdentifier)id;
        }

        /// <summary>
        /// Gets the ARM resource identifier.
        /// </summary>
        /// <value></value>
        public virtual TIdentifier Id { get; }
    }
}
