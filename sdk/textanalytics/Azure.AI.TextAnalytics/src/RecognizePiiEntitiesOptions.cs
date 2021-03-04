// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run. For example set model version, whether to include statistics,
    /// and filter the response entities by a given domain filter.
    /// </summary>
    public class RecognizePiiEntitiesOptions : TextAnalyticsRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizePiiEntitiesOptions"/>
        /// class which allows callers to specify details about how the operation
        /// is run. For example set model version, whether to include statistics,
        /// and filter the response entities by a given domain filter.
        /// </summary>
        public RecognizePiiEntitiesOptions()
        {
        }

        /// <summary>
        /// Filters the response entities to ones only included in the specified domain.
        /// For more information see <a href="https://aka.ms/tanerpii"/>.
        /// </summary>
        public PiiEntityDomainType? DomainFilter { get; set; }

        /// <summary>
        /// Filters the response entities to entities that match the <see cref="PiiEntityCategory"/> specified.
        /// </summary>
        public IList<PiiEntityCategory> CategoriesFilter { get; internal set; } = new List<PiiEntityCategory>();
    }
}
