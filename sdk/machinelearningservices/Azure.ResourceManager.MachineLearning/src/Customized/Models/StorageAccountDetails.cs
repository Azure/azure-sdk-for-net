// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy property names over generated TypeSpec-normalized names.
    public partial class StorageAccountDetails
    {
        /// <summary> ARM resource ID of the generated storage account. </summary>
        [WirePath("userCreatedStorageAccount.armResourceId.resourceId")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ArmResourceId
        {
            get => SystemCreatedStorageAccount?.ArmResourceId;
            set
            {
                SystemCreatedStorageAccount ??= new SystemCreatedStorageAccount();
                SystemCreatedStorageAccount.ArmResourceId = value;
            }
        }
    }
}
