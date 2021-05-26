// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// The properties that enable an account to host a static website.
    /// </summary>
    public class DataLakeStaticWebsite
    {
        /// <summary>
        /// Indicates whether this account is hosting a static website.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The default name of the index page under each directory.
        /// </summary>
        public string IndexDocument { get; set; }

        /// <summary>
        /// The absolute path of the custom 404 page.
        /// </summary>
        public string ErrorDocument404Path { get; set; }

        /// <summary>
        /// Absolute path of the default index page.
        /// </summary>
        public string DefaultIndexDocumentPath { get; set; }
    }
}
