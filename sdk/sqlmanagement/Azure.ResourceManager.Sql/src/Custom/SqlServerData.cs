// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A Class representing a SqlServerData
    /// </summary>
	public partial class SqlServerData
	{
		/// <summary>
        /// Gets minimal tls version for a server.
        /// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string SqlMinimalTlsVersion
		{
			get {
				return MinTlsVersion.ToString();
			}
			set {
				MinTlsVersion = value != null ? value : null;
			}
		}
	}
}