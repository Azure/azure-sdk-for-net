// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class RecoverableDatabaseData : ResourceData
    {
        // Make the default ctor public to keep backwards compatibility.
        /// <summary> Initializes a new instance of <see cref="RecoverableDatabaseData"/>. </summary>
        public RecoverableDatabaseData()
        {
        }
    }
}
