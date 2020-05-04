// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class CategorizedEntityCollection : ReadOnlyCollection<CategorizedEntity>
    {
        internal CategorizedEntityCollection(IList<CategorizedEntity> entities, IList<TextAnalyticsWarning> warnings)
            : base(entities)
        {
            Warnings = new ReadOnlyCollection<TextAnalyticsWarning>(warnings);
        }

        /// <summary>
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }
    }
}
