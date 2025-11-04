// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Translation.Text
{
    /// <summary> Dictionary Example element. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    public class DictionaryExampleItem
    {
        /// <summary>
        /// A string giving the normalized form of the source term. Generally, this should be identical
        /// to the value of the Text field at the matching list index in the body of the request.
        /// </summary>
        public string NormalizedSource { get; }
        /// <summary>
        /// A string giving the normalized form of the target term. Generally, this should be identical
        /// to the value of the Translation field at the matching list index in the body of the request.
        /// </summary>
        public string NormalizedTarget { get; }
        /// <summary> A list of examples for the (source term, target term) pair. </summary>
        public IReadOnlyList<DictionaryExample> Examples { get; }
    }
}
