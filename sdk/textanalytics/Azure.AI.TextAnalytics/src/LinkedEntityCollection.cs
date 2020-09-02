// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="LinkedEntity"/> objects in a document.
    /// </summary>
    public class LinkedEntityCollection : ReadOnlyCollection<LinkedEntity>
    {
        internal LinkedEntityCollection(IList<LinkedEntity> entities, IList<TextAnalyticsWarning> warnings)
       : base(entities)
        {
            Warnings = new ReadOnlyCollection<TextAnalyticsWarning>(warnings);
        }

        /// <summary>
        /// Gets the warnings encountered while processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }
    }
}
