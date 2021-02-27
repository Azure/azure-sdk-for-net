// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a generic tracked resource in Azure.
    /// </summary>
    /// <typeparam name="TModel"> The type of the underlying model this class wraps </typeparam>
    public abstract class TrackedResource<TModel> : TrackedResource
        where TModel : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackedResource{TModel}"/> class.
        /// </summary>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        /// <param name="location"> The location of the resource. </param>
        /// <param name="data"> The model to copy from. </param>
        protected TrackedResource(ResourceIdentifier id, LocationData location, TModel data)
        {
            Id = id;
            Location = location;
            Model = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrackedResource{TModel}"/> class.
        /// </summary>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        /// <param name="location"> The location of the resource. </param>
        /// <param name="data"> The model to copy from. </param>
        protected TrackedResource(string id, LocationData location, TModel data)
        {
            if (ReferenceEquals(id, null))
            {
                Id = null;
            }
            else
            {
                Id = id;
            }

            Location = location;
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
        public static implicit operator TModel(TrackedResource<TModel> other)
        {
            return other.Model;
        }
    }
}
