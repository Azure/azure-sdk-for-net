// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SqlWarehouse and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxXYXJlaG91c2VJbXBs
    internal partial class SqlWarehouseImpl :
        SqlDatabaseImpl,
        ISqlWarehouse
    {
        ///GENMHASH:478F77EE25B1DAD41512D7810F424A78:E1ECD7008D29BB72B20EB2538850BB93
        internal  SqlWarehouseImpl(string name, DatabaseInner innerObject, ISqlManager manager)
            : base(name, innerObject, manager)
        {
        }

        ///GENMHASH:638E920B34EB7CDD894A8A261D1A3364:F65A55844E1B000D318C0439E7EDE006
        public void ResumeDataWarehouse()
        {
            Extensions.Synchronize(() => ResumeDataWarehouseAsync());
        }

        public async Task ResumeDataWarehouseAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Databases.ResumeDataWarehouseAsync(
                ResourceGroupName, 
                SqlServerName(), 
                Name,
                cancellationToken);
        }

        ///GENMHASH:CC45B434E5AD72F7D764B575FE4DBBB0:BA80FAB6E26489720ABD292F74B22257
        public void PauseDataWarehouse()
        {
            Extensions.Synchronize(() => PauseDataWarehouseAsync());
        }

        public async Task PauseDataWarehouseAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Databases.PauseDataWarehouseAsync(
                ResourceGroupName, 
                SqlServerName(), 
                Name,
                cancellationToken);
        }
    }
}
