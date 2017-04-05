// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class SqlWarehouseImpl
    {
        /// <summary>
        /// Pause an Azure SQL Data Warehouse database.
        /// </summary>
        void ISqlWarehouse.PauseDataWarehouse()
        {
            this.PauseDataWarehouse();
        }

        /// <summary>
        /// Pause an Azure SQL Data Warehouse database.
        /// </summary>
        async Task ISqlWarehouse.PauseDataWarehouseAsync(CancellationToken cancellationToken)
        {
            await this.PauseDataWarehouseAsync(cancellationToken);
        }

        /// <summary>
        /// Resume an Azure SQL Data Warehouse database.
        /// </summary>
        void ISqlWarehouse.ResumeDataWarehouse()
        {
            this.ResumeDataWarehouse();
        }

        /// <summary>
        /// Resume an Azure SQL Data Warehouse database.
        /// </summary>
        async Task ISqlWarehouse.ResumeDataWarehouseAsync(CancellationToken cancellationToken)
        {
            await this.ResumeDataWarehouseAsync(cancellationToken);
        }
    }
}