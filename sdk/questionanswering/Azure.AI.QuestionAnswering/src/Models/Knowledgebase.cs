// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;

namespace Azure.AI.QuestionAnswering.Models
{
    [SuppressMessage("Usage", "AZC0012:Avoid single word type names", Justification = "(Pending) Should be unique enough within Cognitive Services")]
    public partial class Knowledgebase
    {
        /// <summary>
        /// Gets the host <see cref="Uri"/> where the knowledgebase is hosted.
        /// </summary>
        public Uri Endpoint { get; }

        /// <summary>
        /// Gets a list of <see cref="Uri"/>s to files to add to the knowledgebase.
        /// </summary>
        [CodeGenMember("Urls")]
        public IReadOnlyList<Uri> Uris { get; }
    }
}
