// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// asd.
    /// </summary>
    public class TranslationFilterParameter
    {
        /// <summary>
        /// asd.
        /// </summary>
        public DateTimeOffset CreatedOnEnd { get; set; }
        /// <summary>
        /// asd.
        /// </summary>
        public DateTimeOffset CreatedOnStart { get; set; }
        /// <summary>
        /// asd.
        /// </summary>
        public IList<string> Ids { get; }
        /// <summary>
        /// asd.
        /// </summary>
        public IList<TranslationFilterOrderBy> OrderBy { get; }
        /// <summary>
        /// asd.
        /// </summary>
        public IList<DocumentTranslationStatus> Statuses { get; }
    }
}
