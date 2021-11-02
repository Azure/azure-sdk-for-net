﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the execution of a <see cref="RecognizeLinkedEntitiesAction"/> on the input documents.
    /// </summary>
    public class RecognizeLinkedEntitiesActionResult : TextAnalyticsActionResult
    {
        private readonly RecognizeLinkedEntitiesResultCollection _documentsResults;

        /// <summary>
        /// Successful action.
        /// </summary>
        internal RecognizeLinkedEntitiesActionResult(RecognizeLinkedEntitiesResultCollection result, DateTimeOffset completedOn)
            : base(completedOn)
        {
            _documentsResults = result;
        }

        /// <summary>
        /// Action with an error.
        /// </summary>
        internal RecognizeLinkedEntitiesActionResult(DateTimeOffset completedOn, TextAnalyticsErrorInternal error)
            : base(completedOn, error) { }

        /// <summary>
        /// Gets the result of the execution of a <see cref="RecognizeLinkedEntitiesAction"/> per each input document.
        /// </summary>
        public RecognizeLinkedEntitiesResultCollection DocumentsResults
        {
            get
            {
                if (HasError)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException($"Cannot access the results of this action, due to error {Error.ErrorCode}: {Error.Message}");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                return _documentsResults;
            }
        }
    }
}
