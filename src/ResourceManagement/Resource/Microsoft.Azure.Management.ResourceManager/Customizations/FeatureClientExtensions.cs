// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Rest.Azure
{
    public static class FeatureClientExtensions
    {
        /// <summary>
        /// Get the feature client for the given Azure context.  This provides operations to discover, enable, and disable the 
        /// custom resource manager features in the provided Azure context
        /// </summary>
        /// <param name="context">The context to target with the feature client</param>
        /// <returns>A feature client targeting the given context</returns>
        private static IFeatureClient GetFeatureClient(this IAzureContext context)
        {
           return FeatureClient.CreateClient(context);
        }

        /// <summary>
        /// Get Feature operations for the given context. These operations allow you to discover, 
        /// enable, and disable custom resource provider feature sin the given context.
        /// </summary>
        /// <param name="context">The context to target with the feature operations</param>
        /// <returns>The feature operations for this context</returns>
        public static IFeaturesOperations GetFeatureOperations(this IAzureContext context)
        {
            return context.GetFeatureClient().Features;
        }
    }
}
