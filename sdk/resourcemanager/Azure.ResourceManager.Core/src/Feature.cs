// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a Subscription along with the instance operations that can be performed on it.
    /// </summary>
    public class Feature : FeatureOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Feature"/> class for mocking.
        /// </summary>
        protected Feature()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Feature"/> class.
        /// </summary>
        /// <param name="operations"> The operations object to copy the client parameters from. </param>
        /// <param name="featureData"> The data model representing the generic azure resource. </param>
        internal Feature(OperationsBase operations, FeatureData featureData)
            : base(operations, featureData.Id)
        {
            Data = featureData;
        }

        /// <summary>
        /// Gets the subscription data model.
        /// </summary>
        public virtual FeatureData Data { get; }

        /// <inheritdoc />
        protected override Feature GetFeature(CancellationToken cancellation = default)
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<Feature> GetFeatureAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(this);
        }
    }
}
