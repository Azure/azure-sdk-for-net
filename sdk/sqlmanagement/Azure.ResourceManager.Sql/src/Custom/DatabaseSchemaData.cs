// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Sql
{
    // Make the default ctor public to keep backwards compatibility.
    public partial class DatabaseSchemaData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="DatabaseSchemaData"/>. </summary>
        public DatabaseSchemaData()
        {
        }
    }
}
