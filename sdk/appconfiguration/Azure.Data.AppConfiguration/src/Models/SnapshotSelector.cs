// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// <see cref="SnapshotSelector"/> is a set of options that allows selecting a filtered set of <see cref="ConfigurationSnapshot"/> entities.
    /// </summary>
    public class SnapshotSelector
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SnapshotSelector"/>.
        /// </summary>
        /// <param name="name">A filter for the name of the returned snapshots.</param>
        /// <param name="fields">A list of fields used to specify which fields are included in the returned resource(s).</param>
        /// <param name="status">A list of snapshot status used to filter the returned snapshots based on their status property.</param>
        public SnapshotSelector(string name = null, IEnumerable<SnapshotFields> fields = null, IEnumerable<ConfigurationSnapshotStatus> status = null)
        {
            Name = name;
            Fields = fields?.ToList();
            Status = status?.ToList();
        }

        /// <summary>
        /// A filter for the name of the returned snapshots.
        /// </summary>
        public string Name { get;  }

        /// <summary>
        /// A list of fields used to specify which fields are included in the returned resource(s).
        /// </summary>
        public IList<SnapshotFields> Fields { get; }

        /// <summary>
        /// A list of snapshot status used to filter the returned snapshots based on their status property.
        /// </summary>
        public IList<ConfigurationSnapshotStatus> Status { get; }
    }
}
