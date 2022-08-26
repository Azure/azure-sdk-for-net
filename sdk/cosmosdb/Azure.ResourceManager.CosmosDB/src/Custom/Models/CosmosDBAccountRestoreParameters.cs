// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.CosmosDB.Models
{
    /// <summary> Parameters to indicate the information about the restore. </summary>
    public partial class CosmosDBAccountRestoreParameters
    {
        /// <summary> Describes the mode of the restore. </summary>
        public CosmosDBAccountRestoreMode? RestoreMode { get; set; }
        /// <summary> The id of the restorable database account from which the restore has to be initiated. For example: /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/{location}/restorableDatabaseAccounts/{restorableDatabaseAccountName}. </summary>
        public string RestoreSource { get; set; }
        /// <summary> Time to which the account has to be restored (ISO-8601 format). </summary>
        public DateTimeOffset? RestoreTimestampInUtc { get; set; }

        /// <summary> Initializes a new instance of CosmosDBAccountRestoreParameters. </summary>
        public CosmosDBAccountRestoreParameters()
        {
            DatabasesToRestoreV2 = new ChangeTrackingList<DatabaseRestoreResource>();
        }

        /// <summary> Initializes a new instance of CosmosDBAccountRestoreParameters. </summary>
        /// <param name="restoreMode"> Describes the mode of the restore. </param>
        /// <param name="restoreSource"> The id of the restorable database account from which the restore has to be initiated. For example: /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/{location}/restorableDatabaseAccounts/{restorableDatabaseAccountName}. </param>
        /// <param name="restoreTimestampInUtc"> Time to which the account has to be restored (ISO-8601 format). </param>
        /// <param name="databasesToRestore"> List of specific databases available for restore. </param>
        internal CosmosDBAccountRestoreParameters(CosmosDBAccountRestoreMode? restoreMode, string restoreSource, DateTimeOffset? restoreTimestampInUtc, IList<DatabaseRestoreResource> databasesToRestore)
        {
            RestoreMode = restoreMode;
            RestoreSource = restoreSource;
            RestoreTimestampInUtc = restoreTimestampInUtc;
            DatabasesToRestoreV2 = databasesToRestore;
        }

#pragma warning disable CS0618 // This type is obsolete and will be removed in a future release.
        // deprecated
        private IList<DatabaseRestoreResourceInfo> _databasesToRestore;

        [Obsolete("This property is obsolete and will be removed in a future release. Please use DatabasesToRestoreV2.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>")]
        public IList<DatabaseRestoreResourceInfo> DatabasesToRestore
        {
            get => _databasesToRestore;
            set
            {
                _databasesToRestore = value;
                _databasesToRestoreV2 = value.Select(x => ConvertFromDatabaseRestoreResourceInfo(x)).ToList(); // TODO
            }
        }

        private IList<DatabaseRestoreResource> _databasesToRestoreV2;

        /// <summary> List of specific databases available for restore. </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>")]
        public IList<DatabaseRestoreResource> DatabasesToRestoreV2
        {
            get => _databasesToRestoreV2;
            set
            {
                _databasesToRestoreV2 = value;
                if (value == null)
                {
                    _databasesToRestore = null;
                }
                else
                {
                    if (_databasesToRestore == null)
                    {
                        _databasesToRestore = new List<DatabaseRestoreResourceInfo>();
                    }
                    _databasesToRestore = value.Select(x => ConvertFromDatabaseRestoreResource(x)).ToList();
                }
            }
        }

        private static DatabaseRestoreResource ConvertFromDatabaseRestoreResourceInfo(DatabaseRestoreResourceInfo value)
        {
            return new DatabaseRestoreResource(value.DatabaseName, value.CollectionNames);
        }

        private static DatabaseRestoreResourceInfo ConvertFromDatabaseRestoreResource(DatabaseRestoreResource value)
        {
            return new DatabaseRestoreResourceInfo(value.DatabaseName, value.CollectionNames);
        }
#pragma warning restore CS0618 // This type is obsolete and will be removed in a future release.
    }
}
