// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public abstract partial class DataProtectionBackupPolicyPropertiesBase
    {
        /// <summary> Initializes a new instance of <see cref="DataProtectionBackupPolicyPropertiesBase"/>. </summary>
        /// <param name="dataSourceTypes"> Type of datasource for the backup management. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dataSourceTypes"/> is null. </exception>
        protected DataProtectionBackupPolicyPropertiesBase(IEnumerable<string> dataSourceTypes)     // This constructor is intentionally retained for backward compatibility.
        {
            Argument.AssertNotNull(dataSourceTypes, nameof(dataSourceTypes));
            DataSourceTypes = dataSourceTypes.ToList();
        }
    }
}
