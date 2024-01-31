// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using static Azure.AI.TextAnalytics.TextAnalyticsClientOptions;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Validates models support the specified <see cref="TextAnalyticsClientOptions.ServiceVersion"/>.
    /// </summary>
    internal interface IModelValidator
    {
        /// <summary>
        /// Checks that the specified <see cref="TextAnalyticsClientOptions.ServiceVersion"/> supports all properties set within a model.
        /// </summary>
        /// <param name="current">The current <see cref="TextAnalyticsClientOptions.ServiceVersion"/> used by the <see cref="TextAnalyticsClient"/>.</param>
        void CheckSupported(ServiceVersion current);
    }
}
