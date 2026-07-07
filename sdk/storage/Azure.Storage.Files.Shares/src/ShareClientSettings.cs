// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Files.Shares
{
    public partial class ShareClientSettings
    {
        internal string ConnectionString { get; set; }
        internal string ShareName { get; set; }

        /// <summary>
        /// A <see cref="Uri"/> referencing the share that includes the
        /// name of the account and the name of the share.
        /// </summary>
        [CodeGenMember("Url")]
        public Uri ShareUri { get; set; }
    }
}
