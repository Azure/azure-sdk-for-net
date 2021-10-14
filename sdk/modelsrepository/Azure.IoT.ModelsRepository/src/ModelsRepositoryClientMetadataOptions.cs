// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.IoT.ModelsRepository
{
    /// <summary>
    /// Options that configure how the client uses models repository metadata.
    /// </summary>
    public class ModelsRepositoryClientMetadataOptions
    {
        /// <summary>
        /// Gets or sets the <see cref="TimeSpan"/> for which the client considers repository metadata stale.
        /// </summary>
        public TimeSpan Expiration { get; set; }

        /// <summary>
        /// Indicates if models repository metadata processing should be enabled for the client.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets the default <see cref="TimeSpan"/> of <see cref="TimeSpan.MaxValue"/> for <see cref="Expiration"/>.
        /// </summary>
        public static TimeSpan DefaultMetadataExpiration { get { return TimeSpan.MaxValue; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelsRepositoryClientMetadataOptions"/> class using the
        /// <see cref="TimeSpan"/> value from <see cref="DefaultMetadataExpiration"/>.
        /// </summary>
        public ModelsRepositoryClientMetadataOptions():this(DefaultMetadataExpiration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelsRepositoryClientMetadataOptions"/> class.
        /// </summary>
        /// <param name="expiration">
        /// The minimum <see cref="TimeSpan"/> for which the client considers fetched repository metadata stale.
        /// When metadata is stale, the next service operation that can make use of metadata will first attempt to
        /// fetch and refresh the client metadata state. The operation will then continue as normal.
        /// </param>
        public ModelsRepositoryClientMetadataOptions(TimeSpan expiration)
        {
            Expiration = expiration;
            Enabled = true;
        }
    }
}
