// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.IotHub.Models
{
    // Customization justification:
    // The service returns route compilation errors only as part of the test-route response. Older public
    // API listings exposed the flattened DetailsCompilationErrors property as IReadOnlyList, while the
    // latest generated model naturally emits IList after removing the response-only visibility decorator
    // that caused Swagger drift. This partial keeps the existing read-only public contract for ApiCompat
    // and customer source compatibility without reintroducing the TypeSpec decorator that changed the
    // generated swagger. The getter adapts the generated internal details model to the old public shape.
    public partial class IotHubTestRouteResult
    {
        /// <summary> JSON-serialized list of route compilation errors. </summary>
        public IReadOnlyList<RouteCompilationError> DetailsCompilationErrors
        {
            get
            {
                if (Details?.CompilationErrors is null)
                {
                    return default;
                }

                return Details.CompilationErrors is IReadOnlyList<RouteCompilationError> compilationErrors
                    ? compilationErrors
                    : new List<RouteCompilationError>(Details.CompilationErrors);
            }
        }
    }
}
