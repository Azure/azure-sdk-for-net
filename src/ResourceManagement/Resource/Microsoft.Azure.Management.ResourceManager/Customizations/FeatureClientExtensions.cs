// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Rest.Azure
{
    public static class FeatureClientExtensions
    {
        public static IFeatureClient GetFeatureClient(this IAzureContext context)
        {
           return FeatureClient.CreateClient(context);
        }

        public static IFeaturesOperations GetFeatureOperations(this IAzureContext context)
        {
            return context.GetFeatureClient().Features;
        }
    }
}
