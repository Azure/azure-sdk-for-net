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
        public TimeSpan Expiry { get; set; }

        /// <summary>
        /// Indicates whether models repository metadata processing should be enabled for the client.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets the default <see cref="TimeSpan"/> for <see cref="Expiry"/>.
        /// </summary>
        public static TimeSpan DefaultMetadataExpiry { get { return TimeSpan.MaxValue; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelsRepositoryClientMetadataOptions"/> class using the
        /// TimeSpan from <see cref="DefaultMetadataExpiry"/>.
        /// </summary>
        public ModelsRepositoryClientMetadataOptions():this(DefaultMetadataExpiry)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelsRepositoryClientMetadataOptions"/> class.
        /// </summary>
        /// <param name="expiry">
        /// The minimum <see cref="TimeSpan"/> for which the client considers fetched repository metadata stale.
        /// When metadata is stale, the next service operation that can make use of metadata will first attempt to
        /// fetch and refresh the client metadata state. The operation will then continue as normal.
        /// </param>
        public ModelsRepositoryClientMetadataOptions(TimeSpan expiry)
        {
            Expiry = expiry;
            Enabled = true;
        }
    }
}
