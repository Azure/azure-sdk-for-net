// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// A class which defines filtering and ordering options
    /// for listing all document statuses for a certain translation operation.
    /// </summary>
    public partial class DocumentFilter
    {
        /// <summary>
        /// Filter results by <see cref="DocumentStatus.CreatedOn"/>.
        /// Get documents created AFTER a certain datetime.
        /// </summary>
        public DateTimeOffset CreatedAfter { get; set; }
        /// <summary>
        /// Filter results by <see cref="DocumentStatus.CreatedOn"/>.
        /// Get documents created BEFORE a certain datetime.
        /// </summary>
        public DateTimeOffset CreatedBefore { get; set; }
        /// <summary>
        /// Filter results by <see cref="DocumentStatus.Id"/>.
        /// Get documents with certain IDs.
        /// </summary>
        public IList<string> Ids { get; }
        /// <summary>
        /// Defines sorting options for the result.
        /// <see cref="DocumentFilterOrder"/> for more info on which sorting options to use.
        /// </summary>
        public IList<DocumentFilterOrder> OrderBy { get; }
        /// <summary>
        /// Filter results by <see cref="DocumentStatus.Status"/>.
        /// <see cref="DocumentTranslationStatus"/> to know which statuses to use.
        /// </summary>
        public IList<DocumentTranslationStatus> Statuses { get; }
    }
}
