// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5EYXRhYmFzZXNJbXBs
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using SqlDatabase.Definition;
    using SqlDatabases.SqlDatabaseCreatable;
    using SqlServer.Databases;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation of SqlServer.Databases, which enables the creating the database from the SQLServer directly.
    /// </summary>
    internal partial class DatabasesImpl :
        IDatabases
    {
        private string resourceGroupName;
        private string sqlServerName;
        private ISqlDatabaseCreatable databases;
        private Region region;

        ///GENMHASH:DF46C62E0E8998CD0340B3F8A136F135:714B63AADC1377917C498035051A9621
        internal ISqlDatabases Databases
        {
            get
            {
                return this.databases;
            }
        }

        ///GENMHASH:206E829E50B031B66F6EA9C7402231F9:A57FA8C118C2E54E51F065015161FD4E
        public ISqlDatabase Get(string databaseName)
        {
            return this.databases.GetBySqlServer(this.resourceGroupName, this.sqlServerName, databaseName);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:2BD35BB14527027C8AC45AC2175017F2
        public IBlank Define(string databaseName)
        {
            return this.databases.DefinedWithSqlServer(this.resourceGroupName, this.sqlServerName, databaseName, this.region);
        }

        ///GENMHASH:BEDEF34E57C25BFA34A4AB1C8430428E:0F072877D2FFAB73046D32E384962CF0
        public async Task DeleteAsync(string databaseName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.databases.DeleteByParentAsync(this.resourceGroupName, this.sqlServerName, databaseName, cancellationToken);
        }

        internal DatabasesImpl(IDatabasesOperations innerCollection, ISqlManager manager, string resourceGroupName, string sqlServerName, Region region)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.region = region;
            this.databases = new SqlDatabasesImpl(innerCollection, manager);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:DDC88190329C40E33404F24D728694C7
        public IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> List()
        {
            return this.databases.ListBySqlServer(this.resourceGroupName, this.sqlServerName);
        }

        ///GENMHASH:184FEA122A400D19B34517FEF358ED78:A91AF20B1A37CBAE69A12237E610BDF2
        public void Delete(string databaseName)
        {
            this.databases.DeleteByParent(this.resourceGroupName, this.sqlServerName, databaseName);
        }
    }
}
