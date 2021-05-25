// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a Subscription along with the instance operations that can be performed on it.
    /// </summary>
    public class FeatureResult : FeaturesOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureResult"/> class for mocking.
        /// </summary>
        protected FeatureResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureResult"/> class.
        /// </summary>
        /// <param name="operations"> The operations object to copy the client parameters from. </param>
        /// <param name="featureResultData"> The data model representing the generic azure resource. </param>
        internal FeatureResult(OperationsBase operations, FeatureResultData featureResultData)
            : base(operations, featureResultData.Id)
        {
            Data = featureResultData;
        }

        /// <summary>
        /// Gets the subscription data model.
        /// </summary>
        public virtual FeatureResultData Data { get; }

        /// <inheritdoc />
        protected override FeatureResult GetFeatureResult(CancellationToken cancellation = default)
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<FeatureResult> GetFeatureResultAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(this);
        }
    }
}
