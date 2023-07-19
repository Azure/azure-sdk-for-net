// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Linq;

    /// <summary>
    /// Defines how the Suggest API should apply to a group of fields in the
    /// index.
    /// </summary>
    public partial class Suggester
    {
        /// <summary>
        /// Initializes a new instance of the Suggester class with required
        /// arguments.
        /// </summary>
        /// <param name="name">The name of the suggester.</param>
        /// <param name="sourceFields">The list of field names to which the suggester applies; Each field must be
        /// searchable.</param>
        public Suggester(string name, params string[] sourceFields) : this(name, sourceFields.ToList())
        {
            // Do nothing.
        }
    }
}
