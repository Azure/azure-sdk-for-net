﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core.Adapters
{
    /// <summary>
    /// A class representing a generic tracked resource in Azure.
    /// </summary>
    /// <typeparam name="TIdentifier"> The type of the underlying resource id </typeparam>
    /// <typeparam name="TModel"> The type of the underlying model this class wraps </typeparam>
    public abstract class TrackedResource<TIdentifier, TModel> : TrackedResource<TIdentifier> 
        where TIdentifier : TenantResourceIdentifier
        where TModel : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackedResource{TModel, TIdentifier}"/> class.
        /// </summary>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        /// <param name="location"> The location of the resource. </param>
        /// <param name="data"> The model to copy from. </param>
        protected TrackedResource(TIdentifier id, LocationData location, TModel data)
            :base(id, id?.Name, id?.ResourceType, location, null)
        {
            Model = data;
        }

        /// <summary>
        /// Gets or sets the Model this resource is based off.
        /// </summary>
        public virtual TModel Model { get; set; }

        /// <summary>
        /// Converts from a <see cref="TrackedResource{TModel}"/> into the TModel.
        /// </summary>
        /// <param name="other"> The tracked resource convert from. </param>
        public static implicit operator TModel(TrackedResource<TIdentifier, TModel> other)
        {
            return other.Model;
        }
    }
}
