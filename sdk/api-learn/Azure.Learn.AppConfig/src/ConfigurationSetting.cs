// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Learn.AppConfig
{
    /// <summary>
    /// A setting, defined by a unique combination of a key and label.
    /// </summary>
    [CodeGenModel("KeyValue")]
    public partial class ConfigurationSetting
    {
        /// <summary>
        /// An ETag indicating the state of a configuration setting within a configuration store.
        /// </summary>
        [CodeGenMember("Etag")]
        public ETag ETag { get; }
    }
}
