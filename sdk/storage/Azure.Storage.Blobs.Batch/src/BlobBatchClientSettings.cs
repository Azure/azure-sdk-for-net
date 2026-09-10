// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Extensions.Configuration;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Blobs.Batch
{
    [CodeGenType("BlobBatchClientSettings")]
    // CUSTOM:
    // - Make internal.
    internal partial class BlobBatchClientSettings
    {
        /// <summary> Gets or sets the Client. </summary>
        public BlobServiceClient Client { get; set; }

        /// <summary> Binds configuration values from the given section. </summary>
        /// <param name="section"> The configuration section. </param>
        protected override void BindCore(IConfigurationSection section)
        {
            if (Uri.TryCreate(section["Url"], UriKind.Absolute, out Uri url))
            {
                Url = url;
            }
            IConfigurationSection optionsSection = section.GetSection("Options");
            if (optionsSection.Exists())
            {
                Options = new BlobBatchClientOptions(optionsSection);
            }
        }
    }
}
