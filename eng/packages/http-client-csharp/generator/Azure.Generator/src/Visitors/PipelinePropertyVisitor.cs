// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Makes the Pipeline property virtual for consistency and backwards compatibility with existing
    /// Azure libraries.
    /// </summary>
    internal class PipelinePropertyVisitor : ScmLibraryVisitor
    {
        protected override PropertyProvider? VisitProperty(PropertyProvider property)
        {
            if (property.Type.Equals(typeof(HttpPipeline)))
            {
                // Add the virtual modifier for the HttpPipeline property for backwards compatibility.
                property.Update(modifiers: property.Modifiers | MethodSignatureModifiers.Virtual);
            }

            return property;
        }
    }
}