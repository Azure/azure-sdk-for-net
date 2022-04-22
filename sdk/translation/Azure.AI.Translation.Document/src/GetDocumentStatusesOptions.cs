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
    public partial class GetDocumentStatusesOptions
    {
        /// <summary>
        /// Initializes and instance of <see cref="GetDocumentStatusesOptions"/>.
        /// </summary>
        public GetDocumentStatusesOptions()
        {
        }
        /// <summary>
        /// Filter results by <see cref="DocumentStatusResult.CreatedOn"/>.
        /// Get documents created after a certain date in UTC format.
        /// </summary>
        public DateTimeOffset ? CreatedAfter { get; set; }
        /// <summary>
        /// Filter results by <see cref="DocumentStatusResult.CreatedOn"/>.
        /// Get documents created before a certain date in UTC format.
        /// </summary>
        public DateTimeOffset ? CreatedBefore { get; set; }
        /// <summary>
        /// Filter results by <see cref="DocumentStatusResult.Id"/>.
        /// </summary>
        public IList<string> Ids { get; } = new List<string>();
        /// <summary>
        /// Defines sorting options for the result.
        /// See <see cref="DocumentFilterOrder"/> for more information on which sorting options to use.
        /// </summary>
        public IList<DocumentFilterOrder> OrderBy { get; } = new List<DocumentFilterOrder>();
        /// <summary>
        /// Filter results by <see cref="DocumentStatusResult.Status"/>.
        /// See <see cref="DocumentTranslationStatus"/> to know which statuses to use.
        /// </summary>
        public IList<DocumentTranslationStatus> Statuses { get; } = new List<DocumentTranslationStatus>();
    }
}
