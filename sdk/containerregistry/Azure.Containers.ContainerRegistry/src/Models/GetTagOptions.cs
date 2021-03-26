// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// Options to override default GetTag() behavior.
    /// </summary>
    public class GetTagOptions
    {
        /// <summary>
        /// Construct an instance of GetTagOptions.
        /// </summary>
        /// <param name="orderBy"> Requested ordering for tags in the returned collection. </param>
        public GetTagOptions(TagOrderBy orderBy)
        {
            this.OrderBy = orderBy;
        }

        /// <summary>
        /// Get the option specified for ordering tags in the returned collection.
        /// </summary>
        public TagOrderBy OrderBy { get; }
    }
}
