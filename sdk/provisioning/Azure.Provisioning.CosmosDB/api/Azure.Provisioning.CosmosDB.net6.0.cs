namespace Azure.Provisioning.CosmosDB
{
    public partial class CosmosDBAccount : Azure.Provisioning.Resource<Azure.ResourceManager.CosmosDB.CosmosDBAccountData>
    {
        public CosmosDBAccount(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind? kind = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind?), Azure.ResourceManager.CosmosDB.Models.ConsistencyPolicy? consistencyPolicy = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType? accountOfferType = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountLocation>? accountLocations = null, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "cosmosDB", string version = "2023-04-15", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.CosmosDB.CosmosDBAccountData>), default(bool)) { }
        public static Azure.Provisioning.CosmosDB.CosmosDBAccount FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
        public Azure.Provisioning.CosmosDB.CosmosDBAccountConnectionString GetConnectionString(Azure.Provisioning.CosmosDB.CosmosDBKey? key = default(Azure.Provisioning.CosmosDB.CosmosDBKey?)) { throw null; }
    }
    public partial class CosmosDBAccountConnectionString : Azure.Provisioning.ConnectionString
    {
        internal CosmosDBAccountConnectionString() : base (default(string)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBKey : System.IEquatable<Azure.Provisioning.CosmosDB.CosmosDBKey>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBKey(string value) { throw null; }
        public static Azure.Provisioning.CosmosDB.CosmosDBKey PrimaryKey { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBKey PrimaryReadonlyMasterKey { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBKey SecondaryKey { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBKey SecondaryReadonlyMasterKey { get { throw null; } }
        public bool Equals(Azure.Provisioning.CosmosDB.CosmosDBKey other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static implicit operator Azure.Provisioning.CosmosDB.CosmosDBKey (string value) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBSqlDatabase : Azure.Provisioning.Resource<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseData>
    {
        public CosmosDBSqlDatabase(Azure.Provisioning.IConstruct scope, Azure.Provisioning.CosmosDB.CosmosDBAccount? parent = null, Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlDatabaseResourceInfo? databaseResourceInfo = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabasePropertiesConfig? propertiesConfig = null, string name = "db", string version = "2023-04-15", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.CosmosDB.CosmosDBSqlDatabase FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.CosmosDB.CosmosDBAccount parent) { throw null; }
    }
}
