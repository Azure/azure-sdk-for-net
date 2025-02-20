// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    /// <summary> Policy Info in backupInstance. </summary>
    public partial class BackupInstancePolicyInfo
    {
        /// <summary>
        /// Gets or sets the DataStore Parameters
        /// Please note <see cref="DataStoreSettings"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="OperationalDataStoreSettings"/>.
        /// Please note <see cref="DataStoreSettings"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="OperationalDataStoreSettings"/>.
        /// </summary>
        [Obsolete("DataStoreParametersList is obsolete and will be removed in a future release. Please do not use it any longer.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<DataStoreSettings> DataStoreParametersList
        {
            get
            {
                if (PolicyParameters is null)
                    PolicyParameters = new BackupInstancePolicySettings();
                return PolicyParameters.DataStoreParametersList;
            }
        }
    }
}
