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
        /// Initializes and instance of <see cref="DocumentFilter"/>.
        /// </summary>
        /// <param name="createdAfter">Filter documents by <see cref="DocumentStatus.CreatedOn"/>. Get documents created after a certain datetime.</param>
        /// <param name="createdBefore">Filter documents by <see cref="DocumentStatus.CreatedOn"/>. Get documents created before a certain datetime.</param>
        /// <param name="ids">Filter results by <see cref="DocumentStatus.Id"/>. Get documents with certain IDs.</param>
        /// <param name="orderBy">Defines sorting options for the result. See <see cref="DocumentFilterOrder"/> for more info on which sorting options to use.</param>
        /// <param name="statuses">Filter results by <see cref="DocumentStatus.Status"/>.</param>
        public DocumentFilter(
            DateTimeOffset createdAfter = default,
            DateTimeOffset createdBefore = default,
            IList<string> ids = null,
            IList<DocumentFilterOrder> orderBy = null,
            IList<DocumentTranslationStatus> statuses = null)
        {
            CreatedAfter = createdAfter;
            CreatedBefore = createdBefore;
            Ids = ids;
            OrderBy = orderBy;
            Statuses = statuses;
        }
        /// <summary>
        /// Filter results by <see cref="DocumentStatus.CreatedOn"/>.
        /// Get documents created after a certain datetime.
        /// </summary>
        public DateTimeOffset CreatedAfter { get; set; }
        /// <summary>
        /// Filter results by <see cref="DocumentStatus.CreatedOn"/>.
        /// Get documents created before a certain datetime.
        /// </summary>
        public DateTimeOffset CreatedBefore { get; set; }
        /// <summary>
        /// Filter results by <see cref="DocumentStatus.Id"/>.
        /// Get documents with certain IDs.
        /// </summary>
        public IList<string> Ids { get; }
        /// <summary>
        /// Defines sorting options for the result.
        /// See <see cref="DocumentFilterOrder"/> for more info on which sorting options to use.
        /// </summary>
        public IList<DocumentFilterOrder> OrderBy { get; }
        /// <summary>
        /// Filter results by <see cref="DocumentStatus.Status"/>.
        /// See <see cref="DocumentTranslationStatus"/> to know which statuses to use.
        /// </summary>
        public IList<DocumentTranslationStatus> Statuses { get; }
    }
}
