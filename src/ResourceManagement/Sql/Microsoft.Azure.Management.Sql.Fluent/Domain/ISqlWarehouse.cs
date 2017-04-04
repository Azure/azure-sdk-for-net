// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Sql.Fluent
{
    /// <summary>
    /// An immutable client-side representation of an Azure SQL Warehouse.
    /// </summary>
    public interface ISqlWarehouse  :
        ISqlDatabase
    {
        /// <summary>
        /// Resume an Azure SQL Data Warehouse database.
        /// </summary>
        void ResumeDataWarehouse();

        /// <summary>
        /// Resume an Azure SQL Data Warehouse database.
        /// </summary>
        Task ResumeDataWarehouseAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Pause an Azure SQL Data Warehouse database.
        /// </summary>
        void PauseDataWarehouse();

        /// <summary>
        /// Pause an Azure SQL Data Warehouse database.
        /// </summary>
        Task PauseDataWarehouseAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}