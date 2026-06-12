// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public partial class SqlServerPatch
    {
        /// <summary> Gets or sets minimal TLS version. </summary>
        [WirePath("properties.minimalTlsVersion")]
        public SqlMinimalTlsVersion? MinTlsVersion
        {
            get => Properties?.MinimalTlsVersion;
            set
            {
                if (Properties == null)
                    Properties = new ServerProperties();
                Properties.MinimalTlsVersion = value;
            }
        }

        /// <summary>
        /// Gets minimal tls version for a server.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MinimalTlsVersion
        {
            get => MinTlsVersion?.ToString();
            set => MinTlsVersion = value;
        }
    }
}
