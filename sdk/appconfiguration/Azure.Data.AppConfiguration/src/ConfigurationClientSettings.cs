// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

#nullable enable

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// Represents the settings used to configure a <see cref="ConfigurationClient"/> that can be loaded from an <see cref="IConfigurationSection"/>.
    /// </summary>
    public partial class ConfigurationClientSettings : ClientSettings
    {
        /// <summary>
        /// Gets or sets the <see cref="Uri"/> referencing the app configuration storage.
        /// </summary>
        public Uri? Endpoint { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ConfigurationClientOptions"/> used to configure requests sent to the App Configuration service.
        /// </summary>
        public ConfigurationClientOptions? Options { get; set; }
    }
}
