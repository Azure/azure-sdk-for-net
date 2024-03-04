// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
	public partial class SqlServerPatch
    {
        /// <summary>
        /// Gets minimal tls version for a server.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MinimalTlsVersion
        {
            get
            {
                return MinTlsVersion.ToString();
            }
            set
            {
                MinTlsVersion = value ?? null;
            }
        }
    }
}
