// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Warehouse.
    /// </summary>
    public interface ISqlWarehouse  :
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase
    {
        /// <summary>
        /// Pause an Azure SQL Data Warehouse database asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task PauseDataWarehouseAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Resume an Azure SQL Data Warehouse database.
        /// </summary>
        void ResumeDataWarehouse();

        /// <summary>
        /// Pause an Azure SQL Data Warehouse database.
        /// </summary>
        void PauseDataWarehouse();

        /// <summary>
        /// Resume an Azure SQL Data Warehouse database asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task ResumeDataWarehouseAsync(CancellationToken cancellationToken = default(CancellationToken));

    }
}