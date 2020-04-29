// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Base type for results of text analytics operations corresponding to a
    /// document.  If the operation is unsuccessful, the Id and
    /// Error properties will be populated, but not others.
    /// </summary>
    public class TextAnalyticsResult
    {
        internal TextAnalyticsResult(string id, TextDocumentStatistics statistics, IList<TextAnalyticsWarning> warnings)
        {
            Id = id;
            Statistics = statistics;
            Warnings = new ReadOnlyCollection<TextAnalyticsWarning>(warnings);
        }

        internal TextAnalyticsResult(string id, TextAnalyticsError error)
        {
            Id = id;
            Error = error;
        }

        /// <summary>
        /// Gets the unique identifier for the document that generated
        /// the result.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets statistics about the document and how it was processed by
        /// the service.  This property will have a value when IncludeStatistics
        /// is set to true in the client call.
        /// </summary>
        public TextDocumentStatistics Statistics { get; }

        /// <summary>
        /// Gets the error explaining why the operation failed on this
        /// document. This property will have a value only when the document
        /// cannot be processed.
        /// </summary>
        public TextAnalyticsError Error { get; }

        /// <summary>
        /// Gets the error explaining why the operation failed on this
        /// document. This property will have a value only when the document
        /// cannot be processed.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        /// <summary>
        /// Indicates that the document was not successfully processed and an error was returned for this document.
        /// </summary>
        public bool HasError => Error.Code != default;

        /// <summary>
        /// Indicates that the document was not successfully processed and an error was returned for this document.
        /// </summary>
        public bool HasWarnings => Warnings != default && Warnings.Count > 0;
    }
}
