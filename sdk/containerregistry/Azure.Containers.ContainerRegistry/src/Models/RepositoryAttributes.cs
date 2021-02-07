// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Models
{
    public partial class RepositoryAttributes
    {
        [CodeGenMember("ChangeableAttributes")]
        public ContentPermissions Permissions { get; }
    }
}
