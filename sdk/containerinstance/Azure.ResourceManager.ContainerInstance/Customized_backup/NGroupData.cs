// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ContainerInstance.Models;

namespace Azure.ResourceManager.ContainerInstance
{
    public partial class NGroupData
    {
        /// <summary> Initializes a new instance of <see cref="NGroupData"/>. </summary>
        /// <param name="location"> The location. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NGroupData(AzureLocation location)
        {
            Location = location;
            Tags = new ChangeTrackingDictionary<string, string>();
            Zones = new ChangeTrackingList<string>();
        }

        // NOTE: Property type shims (ElasticProfile, Identity, UpdateProfile) cannot be added here
        // because NGroupData is a generated partial class and the generated file already defines
        // these properties with new types. C# does not allow redefining in the same partial class.
    }
}
