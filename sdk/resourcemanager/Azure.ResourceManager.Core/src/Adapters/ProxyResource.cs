// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a generic proxy resource in Azure
    /// </summary>
    /// <typeparam name="TModel"> The type of the underlying model this class wraps </typeparam>
    /// <typeparam name="TIdentifier"> The type of the underlying modelresource Id </typeparam>
    public abstract class ProxyResource<TIdentifier, TModel> : Resource<TIdentifier>
        where TModel : class 
        where TIdentifier : TenantResourceIdentifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyResource{TModel, TIdentifier}"/> class.
        /// </summary>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        /// <param name="data"> The model to copy from. </param>
        protected ProxyResource(TIdentifier id, TModel data)
        {
            Id = id;
            Model = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyResource{TModel, TIdentifier}"/> class.
        /// </summary>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        /// <param name="data"> The model to copy from. </param>
        protected ProxyResource(string id, TModel data)
        {
            if (ReferenceEquals(id, null))
            {
                Id = null;
            }
            else
            {
                Id = ResourceIdentifier.Create(id) as TIdentifier;
            }

            Model = data;
        }

        /// <summary>
        /// Gets or sets the identifier for the resource.
        /// </summary>
        public override TIdentifier Id { get; protected set; }

        /// <summary>
        /// Gets or sets the Model this resource is based off.
        /// </summary>
        public virtual TModel Model { get; set; }

        /// <summary>
        /// Converts from a <see cref="ProxyResource{TModel, TIdentifier}"/> into the TModel.
        /// </summary>
        /// <param name="other"> The tracked resource convert from. </param>
        public static implicit operator TModel(ProxyResource<TIdentifier, TModel> other)
        {
            return other.Model;
        }
    }
}
