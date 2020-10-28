// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="DocumentHealthcareEntities"/> objects in a document.
    /// </summary>
    public class DocumentHealthcareEntitiesCollection : ReadOnlyCollection<DocumentHealthcareEntities>
    {
        internal DocumentHealthcareEntitiesCollection(IList<DocumentHealthcareEntities> entities, IList<TextAnalyticsWarning> warnings)
            : base(entities)
        {
            Warnings = new ReadOnlyCollection<TextAnalyticsWarning>(warnings);
        }

        /// <summary>
        /// Warnings encountered while processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }
    }
}
