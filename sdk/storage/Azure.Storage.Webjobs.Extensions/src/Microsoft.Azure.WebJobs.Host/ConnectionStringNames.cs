// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs
{
    /// <summary>Defines connection string names used by <see cref="IConnectionStringProvider"/>.</summary>
    public static class ConnectionStringNames
    {
        /// <summary>Gets the dashboard connection string name.</summary>
        public static readonly string Dashboard = "Dashboard";

        /// <summary>Gets the Azure Storage connection string name.</summary>
        public static readonly string Storage = "Storage";

        /// <summary>Gets an Azure Storage SAS connection for a blob container to use with internal operations.</summary>
        public static readonly string InternalSasStorage = "InternalSasBlobContainer";
    }
}
