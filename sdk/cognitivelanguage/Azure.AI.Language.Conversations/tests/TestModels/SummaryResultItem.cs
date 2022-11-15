// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The SummaryResultItem. </summary>
    public partial class SummaryResultItem
    {
        /// <summary> Initializes a new instance of SummaryResultItem. </summary>
        /// <param name="aspect"></param>
        /// <param name="text"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="aspect"/> or <paramref name="text"/> is null. </exception>
        public SummaryResultItem(string aspect, string text)
        {
            Argument.AssertNotNull(aspect, nameof(aspect));
            Argument.AssertNotNull(text, nameof(text));

            Aspect = aspect;
            Text = text;
            Contexts = new ChangeTrackingList<ItemizedSummaryContext>();
        }

        /// <summary> Initializes a new instance of SummaryResultItem. </summary>
        /// <param name="aspect"></param>
        /// <param name="text"></param>
        /// <param name="contexts"> The context list of the summary. </param>
        internal SummaryResultItem(string aspect, string text, IList<ItemizedSummaryContext> contexts)
        {
            Aspect = aspect;
            Text = text;
            Contexts = contexts;
        }

        /// <summary> Gets or sets the aspect. </summary>
        public string Aspect { get; set; }
        /// <summary> Gets or sets the text. </summary>
        public string Text { get; set; }
        /// <summary> The context list of the summary. </summary>
        public IList<ItemizedSummaryContext> Contexts { get; }
    }
}
