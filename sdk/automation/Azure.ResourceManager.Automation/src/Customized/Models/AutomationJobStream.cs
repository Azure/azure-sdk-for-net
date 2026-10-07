// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Generated job stream values live under internal JobStreamProperties and are not exposed as the GA type.
    // Keep the GA read-only Value dictionary on AutomationJobStream.
    public partial class AutomationJobStream
    {
        /// <summary> Gets or sets the values of the job stream. </summary>
        public IReadOnlyDictionary<string, BinaryData> Value
        {
            get
            {
                return Properties?.Value is null ? default : new ReadOnlyDictionary<string, BinaryData>(Properties.Value);
            }
        }
    }
}
