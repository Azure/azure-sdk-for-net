// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.ModelsRepository
{
    /// <summary>
    /// Options that configure interaction with Azure IoT models repository metadata.
    /// </summary>
    public class ModelsRepositoryClientMetadataOptions
    {
        /// <summary>
        /// Indicates if models repository metadata processing should be enabled for the client.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelsRepositoryClientMetadataOptions"/> class with
        /// default options.
        /// </summary>
        public ModelsRepositoryClientMetadataOptions()
        {
            Enabled = true;
        }
    }
}
