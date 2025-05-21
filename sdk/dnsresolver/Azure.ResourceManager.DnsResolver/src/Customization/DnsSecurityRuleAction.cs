// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.DnsResolver.Models
{
	[CodeGenSerialization(nameof(BlockResponseCode), "blockResponseCode")]
	public partial class DnsSecurityRuleAction
	{
        /// <summary>
        /// The response code for block actions.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlockResponseCode? BlockResponseCode { get; set; }
	}
}
