// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#nullable disable
using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.IotOperations.Models
{
    /// <summary> AkriConnectorTemplateDiagnostics properties. </summary>
    internal partial class AkriConnectorTemplateDiagnostics
    {
        /// <summary> Initializes a new instance of <see cref="AkriConnectorTemplateDiagnostics"/>. </summary>
        /// <param name="logs"> The log settings for the Connector template. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="logs"/> is null. </exception>
        public AkriConnectorTemplateDiagnostics(string logs)
        {
            Argument.AssertNotNull(logs, nameof(logs));
        }
    }
}