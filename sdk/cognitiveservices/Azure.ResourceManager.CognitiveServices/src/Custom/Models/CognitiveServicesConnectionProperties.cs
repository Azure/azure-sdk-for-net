// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.CognitiveServices;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices.Models
{
    public abstract partial class CognitiveServicesConnectionProperties
    {
        /// <summary> Initializes a new instance of <see cref="CognitiveServicesConnectionProperties"/>. </summary>
        protected CognitiveServicesConnectionProperties()
        {
            Metadata = new ChangeTrackingDictionary<string, string>();
            SharedUserList = new ChangeTrackingList<string>();
        }
    }
}
