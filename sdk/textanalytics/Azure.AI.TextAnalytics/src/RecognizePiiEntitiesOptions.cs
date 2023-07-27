// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run. For example, set model version, whether to include statistics,
    /// filter the response entities by a given domain filter, and more.
    /// </summary>
    public class RecognizePiiEntitiesOptions : TextAnalyticsRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizePiiEntitiesOptions"/>
        /// class which allows callers to specify details about how the operation
        /// is run. For example, set model version, whether to include statistics,
        /// filter the response entities by a given domain filter, and more.
        /// </summary>
        public RecognizePiiEntitiesOptions()
        {
        }

        /// <summary>
        /// Filters the response entities to ones only included in the specified domain.
        /// For more information see <see href="https://aka.ms/azsdk/language/pii"/>.
        /// </summary>
        public PiiEntityDomain DomainFilter { get; set; }

        /// <summary>
        /// Filters the response entities to entities that match the <see cref="PiiEntityCategory"/> specified.
        /// </summary>
        public IList<PiiEntityCategory> CategoriesFilter { get; internal set; } = new List<PiiEntityCategory>();
    }
}
