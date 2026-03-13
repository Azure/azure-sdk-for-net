// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class BlobInventoryPolicyData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.policy")]
        public BlobInventoryPolicySchema PolicySchema
        {
            get => Properties is null ? default : Properties.PolicySchema;
            set
            {
                if (Properties is null)
                {
                    Properties = new BlobInventoryPolicyProperties();
                }
                Properties.PolicySchema = value;
            }
        }
    }
}
