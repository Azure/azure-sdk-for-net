// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// A class which defines filtering and ordering options
    /// for listing all submitted translation operations.
    /// </summary>
    public class GetTranslationStatusesOptions
    {
        /// <summary>
        /// Initializes and instance of <see cref="GetTranslationStatusesOptions"/>.
        /// </summary>
        public GetTranslationStatusesOptions()
        {
        }
        /// <summary>
        /// Filter results by <see cref="TranslationStatusResult.CreatedOn"/>.
        /// Get translations created after a certain date in UTC format.
        /// </summary>
        public DateTimeOffset? CreatedAfter { get; set; }
        /// <summary>
        /// Filter results by <see cref="TranslationStatusResult.CreatedOn"/>.
        /// Get translations created before a certain date in UTC format.
        /// </summary>
        public DateTimeOffset? CreatedBefore { get; set; }
        /// <summary>
        /// Filter results by <see cref="TranslationStatusResult.Id"/>.
        /// </summary>
        public IList<string> Ids { get; } = new List<string>();
        /// <summary>
        /// Defines sorting options for the result.
        /// See <see cref="TranslationFilterOrder"/> for more information on which sorting options to use.
        /// </summary>
        public IList<TranslationFilterOrder> OrderBy { get; } = new List<TranslationFilterOrder>();
        /// <summary>
        /// Filter results by <see cref="TranslationStatusResult.Status"/>.
        /// See <see cref="DocumentTranslationStatus"/> to know which statuses to use.
        /// </summary>
        public IList<DocumentTranslationStatus> Statuses { get; } = new List<DocumentTranslationStatus>();
    }
}
