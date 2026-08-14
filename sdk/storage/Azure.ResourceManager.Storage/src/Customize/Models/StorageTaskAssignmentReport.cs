// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat (Compile Remove replacement): Restores older public constructor shape.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The storage task assignment report. </summary>
    public partial class StorageTaskAssignmentReport
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="StorageTaskAssignmentReport"/>. </summary>
        /// <param name="prefix"> The container prefix for the location of storage task assignment report. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="prefix"/> is null. </exception>
        public StorageTaskAssignmentReport(string prefix)
        {
            Argument.AssertNotNull(prefix, nameof(prefix));

            Prefix = prefix;
        }

        /// <summary> Initializes a new instance of <see cref="StorageTaskAssignmentReport"/>. </summary>
        /// <param name="prefix"> The container prefix for the location of storage task assignment report. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal StorageTaskAssignmentReport(string prefix, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Prefix = prefix;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The container prefix for the location of storage task assignment report. </summary>
        [WirePath("prefix")]
        public string Prefix { get; set; }
    }
}
