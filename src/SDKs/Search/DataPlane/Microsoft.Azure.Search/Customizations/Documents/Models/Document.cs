// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a document as a property bag. This is useful for scenarios where the index schema is only known
    /// at run-time.
    /// </summary>
    public class Document : Dictionary<string, object>
    {
        /// <summary>
        /// Initializes a new instance of the Document class.
        /// </summary>
        public Document() { }
    }
}
