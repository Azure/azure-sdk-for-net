// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Qumulo.Models
{
    public partial class QumuloUserDetails
    {
        /// <summary> Initializes a new instance of <see cref="QumuloUserDetails"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public QumuloUserDetails() : this(string.Empty)
        {
        }
    }
}
