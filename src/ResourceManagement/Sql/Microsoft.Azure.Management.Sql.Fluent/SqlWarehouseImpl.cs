// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Models;

    /// <summary>
    /// Implementation for SqlWarehouse and its parent interfaces.
    /// </summary>
    internal partial class SqlWarehouseImpl  :
        SqlDatabaseImpl,
        ISqlWarehouse
    {
        internal  SqlWarehouseImpl(string name, DatabaseInner innerObject, IDatabasesOperations innerCollection)
            : base(name, innerObject, innerCollection)
        {
        }

        public void ResumeDataWarehouse()
        {
            this.innerCollection.ResumeDataWarehouse(this.ResourceGroupName, this.SqlServerName(), this.Name);
        }

        public void PauseDataWarehouse()
        {
            this.innerCollection.PauseDataWarehouse(this.ResourceGroupName, this.SqlServerName(), this.Name);
        }
    }
}