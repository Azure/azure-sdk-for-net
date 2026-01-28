// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Batch.Models
{
    // Manually added back for completed compatibility
    public partial class BatchNameAvailabilityContent
    {
        /// <summary> Initializes a new instance of <see cref="BatchNameAvailabilityContent"/>. </summary>
        /// <param name="name"> The name to check for availability. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BatchNameAvailabilityContent(string name) : this(name, "Microsoft.Batch/batchAccounts")
        {}
    }
}
