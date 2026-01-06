// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace Azure.Core
{
    /// <summary>
    /// .
    /// </summary>
    public abstract class AzureClientSettings : ClientSettingsBase
    {
        /// <summary>
        /// .
        /// </summary>
        public ClientOptions ClientOptions { get; set; } = ClientOptions.Default;
    }
}
