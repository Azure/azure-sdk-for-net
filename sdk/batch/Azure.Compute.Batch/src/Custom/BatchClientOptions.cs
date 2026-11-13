// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Compute.Batch
{
    public partial class BatchClientOptions
    {
        /// <summary>
        /// Gets or sets the Microsoft Entra audience used for token authentication.
        /// If null, <see cref="BatchAudience.AzurePublicCloud"/> is used.
        /// This option is ignored when authenticating with a shared key.
        /// </summary>
        /// <remarks> Configure the credential's authority host separately when using a sovereign cloud. </remarks>
        public BatchAudience? Audience { get; set; }
    }
}
