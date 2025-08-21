// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    public partial class OracleDBSystemShapeProperties
    {
        /// <summary> Initializes a new instance of <see cref="OracleDBSystemShapeProperties"/>. </summary>
        /// <param name="availableCoreCount"> The maximum number of CPU cores that can be enabled on the DB system for this shape. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OracleDBSystemShapeProperties(int availableCoreCount) : this(default, availableCoreCount)
        { }
    }
}
