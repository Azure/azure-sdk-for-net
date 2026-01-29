// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.Language.QuestionAnswering.Authoring
{
    /// <summary> Project assets that need to be imported. </summary>
    public partial class ImportJobOptions
    {
        /// <summary>
        /// Gets or sets the URI of the file associated with this instance.
        /// </summary>
        public Uri FileUri { get; set; }
    }
}
