﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the execution of a <see cref="RecognizeEntitiesAction"/> on the input documents.
    /// </summary>
    public class RecognizeEntitiesActionResult : TextAnalyticsActionResult
    {
        private readonly RecognizeEntitiesResultCollection _documentsResults;

        internal RecognizeEntitiesActionResult(RecognizeEntitiesResultCollection result, DateTimeOffset completedOn, TextAnalyticsErrorInternal error)
            : base(completedOn, error)
        {
            _documentsResults = result;
        }

        /// <summary>
        /// Intended for mocking purposes only.
        /// </summary>
        internal RecognizeEntitiesActionResult(
            RecognizeEntitiesResultCollection result,
            DateTimeOffset completedOn) : base(completedOn)
        {
            _documentsResults = result;
        }

        /// <summary>
        /// Intended for mocking purposes only.
        /// </summary>
        internal RecognizeEntitiesActionResult(
            TextAnalyticsErrorInternal error) : base(error)
        {
        }

        /// <summary>
        /// Gets the result of the execution of a <see cref="RecognizeEntitiesAction"/> per each input document.
        /// </summary>
        public RecognizeEntitiesResultCollection DocumentsResults
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
