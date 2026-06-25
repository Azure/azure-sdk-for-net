// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Sql;

namespace Azure.ResourceManager.Sql.Models
{
    // Make all properties settable to ensure backward compatibility with the previous version of the SDK, the code will be removed once https://github.com/Azure/azure-sdk-for-net/issues/60037 is resolved.
    internal partial class SensitivityLabelUpdateProperties
    {
        /// <summary> Gets the Op. </summary>
        [WirePath("op")]
        public SensitivityLabelUpdateKind Op { get; set; }

        /// <summary> Schema name of the column to update. </summary>
        [WirePath("schema")]
        public string Schema { get; set; }

        /// <summary> Table name of the column to update. </summary>
        [WirePath("table")]
        public string Table { get; set; }

        /// <summary> Column name to update. </summary>
        [WirePath("column")]
        public string Column { get; set; }
    }
}
