// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.DataFactory.Models
{
    // MPG migration back-compat: generator omits public ctor that takes LogLocationSettings.
    // Restore so existing test/customer call sites of the form `new DataFactoryLogSettings(new LogLocationSettings(...))`
    // continue to compile.
    public partial class DataFactoryLogSettings
    {
        /// <summary> Initializes a new instance of <see cref="DataFactoryLogSettings"/>. </summary>
        /// <param name="logLocationSettings"> Log location settings customer needs to provide when enabling log. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="logLocationSettings"/> is null. </exception>
        public DataFactoryLogSettings(LogLocationSettings logLocationSettings)
        {
            if (logLocationSettings == null)
            {
                throw new ArgumentNullException(nameof(logLocationSettings));
            }
            LogLocationSettings = logLocationSettings;
        }
    }
}
