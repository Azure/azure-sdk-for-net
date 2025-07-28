namespace Azure.Analytics.Purview.DataMap
{
    public static partial class AnalyticsPurviewDataMapModelFactory
    {
        public static Azure.Analytics.Purview.DataMap.AtlasClassifications AtlasClassifications(System.Collections.Generic.IEnumerable<System.BinaryData> list = null, int? pageSize = default(int?), string sortBy = null, Azure.Analytics.Purview.DataMap.AtlasSortType? sortType = default(Azure.Analytics.Purview.DataMap.AtlasSortType?), int? startIndex = default(int?), int? totalCount = default(int?)) { throw null; }
        public static Azure.Analytics.Purview.DataMap.AtlasEntity AtlasEntity(System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, string typeName = null, string lastModifiedTS = null, System.Collections.Generic.IDictionary<string, System.BinaryData> businessAttributes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasClassification> classifications = null, long? createTime = default(long?), string createdBy = null, System.Collections.Generic.IDictionary<string, string> customAttributes = null, string guid = null, string homeId = null, string collectionId = null, bool? isIncomplete = default(bool?), System.Collections.Generic.IEnumerable<string> labels = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasTermAssignmentHeader> meanings = null, int? provenanceType = default(int?), bool? proxy = default(bool?), System.Collections.Generic.IDictionary<string, System.BinaryData> relationshipAttributes = null, Azure.Analytics.Purview.DataMap.EntityStatus? status = default(Azure.Analytics.Purview.DataMap.EntityStatus?), long? updateTime = default(long?), string updatedBy = null, long? version = default(long?), System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.ContactInfo>> contacts = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.AtlasGlossaryExtInfo AtlasGlossaryExtInfo(string guid = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasClassification> classifications = null, string longDescription = null, string name = null, string qualifiedName = null, string shortDescription = null, string lastModifiedTS = null, long? createTime = default(long?), string createdBy = null, long? updateTime = default(long?), string updatedBy = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader> categories = null, string language = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> terms = null, string usage = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory> categoryInfo = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm> termInfo = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.AtlasLineageInfo AtlasLineageInfo(string baseEntityGuid = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.Analytics.Purview.DataMap.AtlasEntityHeader> guidEntityMap = null, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IDictionary<string, System.BinaryData>> widthCounts = null, int? lineageDepth = default(int?), int? lineageWidth = default(int?), int? childrenCount = default(int?), Azure.Analytics.Purview.DataMap.LineageDirection? lineageDirection = default(Azure.Analytics.Purview.DataMap.LineageDirection?), System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.ParentRelation> parentRelations = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.LineageRelation> relations = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.AtlasRelationshipWithExtInfo AtlasRelationshipWithExtInfo(System.Collections.Generic.IReadOnlyDictionary<string, Azure.Analytics.Purview.DataMap.AtlasEntityHeader> referredEntities = null, Azure.Analytics.Purview.DataMap.AtlasRelationship relationship = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.AtlasTypeDef AtlasTypeDef(Azure.Analytics.Purview.DataMap.TypeCategory? category = default(Azure.Analytics.Purview.DataMap.TypeCategory?), long? createTime = default(long?), string createdBy = null, Azure.Analytics.Purview.DataMap.AtlasDateFormat dateFormatter = null, string description = null, string guid = null, string name = null, System.Collections.Generic.IReadOnlyDictionary<string, string> options = null, string serviceType = null, string typeVersion = null, long? updateTime = default(long?), string updatedBy = null, long? version = default(long?), string lastModifiedTS = null, System.Collections.Generic.IEnumerable<string> entityTypes = null, System.Collections.Generic.IEnumerable<string> subTypes = null, System.Collections.Generic.IEnumerable<string> superTypes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasRelationshipAttributeDef> relationshipAttributeDefs = null, string defaultValue = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasEnumElementDef> elementDefs = null, Azure.Analytics.Purview.DataMap.AtlasRelationshipEndDef endDef1 = null, Azure.Analytics.Purview.DataMap.AtlasRelationshipEndDef endDef2 = null, Azure.Analytics.Purview.DataMap.RelationshipCategory? relationshipCategory = default(Azure.Analytics.Purview.DataMap.RelationshipCategory?), string relationshipLabel = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasAttributeDef> attributeDefs = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.AtlasTypeDefHeader AtlasTypeDefHeader(Azure.Analytics.Purview.DataMap.TypeCategory? category = default(Azure.Analytics.Purview.DataMap.TypeCategory?), string guid = null, string name = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.AutoCompleteResult AutoCompleteResult(System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AutoCompleteResultValue> value = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.AutoCompleteResultValue AutoCompleteResultValue(string text = null, string queryPlusText = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.BulkImportResult BulkImportResult(System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.ImportInfo> failedImportInfoList = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.ImportInfo> successImportInfoList = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.ContactSearchResultValue ContactSearchResultValue(string id = null, string info = null, string contactType = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.EntityMutationResult EntityMutationResult(System.Collections.Generic.IReadOnlyDictionary<string, string> guidAssignments = null, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasEntityHeader>> mutatedEntities = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasEntityHeader> partialUpdatedEntities = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.ImportInfo ImportInfo(string childObjectName = null, Azure.Analytics.Purview.DataMap.ImportStatus? importStatus = default(Azure.Analytics.Purview.DataMap.ImportStatus?), string parentObjectName = null, string remarks = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.LineageRelation LineageRelation(string fromEntityId = null, string relationshipId = null, string toEntityId = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.ParentRelation ParentRelation(string childEntityId = null, string relationshipId = null, string parentEntityId = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.QueryResult QueryResult(int? searchCount = default(int?), bool? searchCountApproximate = default(bool?), string continuationToken = null, Azure.Analytics.Purview.DataMap.SearchFacetResultValue searchFacets = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.SearchResultValue> value = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.SearchFacetItemValue SearchFacetItemValue(int? count = default(int?), string value = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.SearchFacetResultValue SearchFacetResultValue(System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> entityType = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> assetType = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> classification = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> term = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> contactId = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> contactType = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> label = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> glossaryType = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> termStatus = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> termTemplate = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.SearchHighlights SearchHighlights(System.Collections.Generic.IEnumerable<string> id = null, System.Collections.Generic.IEnumerable<string> qualifiedName = null, System.Collections.Generic.IEnumerable<string> name = null, System.Collections.Generic.IEnumerable<string> description = null, System.Collections.Generic.IEnumerable<string> entityType = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.SearchResultValue SearchResultValue(float? searchScore = default(float?), Azure.Analytics.Purview.DataMap.SearchHighlights searchHighlights = null, string objectType = null, long? createTime = default(long?), long? updateTime = default(long?), string id = null, string name = null, string qualifiedName = null, string entityType = null, string description = null, System.Collections.Generic.IEnumerable<string> endorsement = null, string owner = null, System.Collections.Generic.IEnumerable<string> classification = null, System.Collections.Generic.IEnumerable<string> label = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.TermSearchResultValue> term = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.ContactSearchResultValue> contact = null, System.Collections.Generic.IEnumerable<string> assetType = null, string glossaryType = null, string glossary = null, string termStatus = null, System.Collections.Generic.IEnumerable<string> termTemplate = null, string longDescription = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.SuggestResult SuggestResult(System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.SuggestResultValue> value = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.SuggestResultValue SuggestResultValue(float? searchScore = default(float?), string searchText = null, string objectType = null, long? createTime = default(long?), long? updateTime = default(long?), string id = null, string name = null, string qualifiedName = null, string entityType = null, string description = null, System.Collections.Generic.IEnumerable<string> endorsement = null, string owner = null, System.Collections.Generic.IEnumerable<string> classification = null, System.Collections.Generic.IEnumerable<string> label = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.TermSearchResultValue> term = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.ContactSearchResultValue> contact = null, System.Collections.Generic.IEnumerable<string> assetType = null, string glossaryType = null, string glossary = null, string termStatus = null, System.Collections.Generic.IEnumerable<string> termTemplate = null, string longDescription = null) { throw null; }
        public static Azure.Analytics.Purview.DataMap.TermSearchResultValue TermSearchResultValue(string name = null, string glossaryName = null, string guid = null) { throw null; }
    }
    public partial class AtlasAttributeDef : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasAttributeDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasAttributeDef>
    {
        public AtlasAttributeDef() { }
        public Azure.Analytics.Purview.DataMap.CardinalityValue? Cardinality { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasConstraintDef> Constraints { get { throw null; } }
        public string DefaultValue { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IncludeInNotification { get { throw null; } set { } }
        public bool? IsIndexable { get { throw null; } set { } }
        public bool? IsOptional { get { throw null; } set { } }
        public bool? IsUnique { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Options { get { throw null; } }
        public string TypeName { get { throw null; } set { } }
        public int? ValuesMaxCount { get { throw null; } set { } }
        public int? ValuesMinCount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasAttributeDef System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasAttributeDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasAttributeDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasAttributeDef System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasAttributeDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasAttributeDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasAttributeDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasBusinessMetadataDef : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasBusinessMetadataDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasBusinessMetadataDef>
    {
        public AtlasBusinessMetadataDef() { }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasAttributeDef> AttributeDefs { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.TypeCategory? Category { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public long? CreateTime { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasDateFormat DateFormatter { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Guid { get { throw null; } set { } }
        public string LastModifiedTS { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Options { get { throw null; } }
        public string ServiceType { get { throw null; } set { } }
        public string TypeVersion { get { throw null; } set { } }
        public string UpdatedBy { get { throw null; } set { } }
        public long? UpdateTime { get { throw null; } set { } }
        public long? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasBusinessMetadataDef System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasBusinessMetadataDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasBusinessMetadataDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasBusinessMetadataDef System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasBusinessMetadataDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasBusinessMetadataDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasBusinessMetadataDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasClassification : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasClassification>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasClassification>
    {
        public AtlasClassification() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public string EntityGuid { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.EntityStatus? EntityStatus { get { throw null; } set { } }
        public string LastModifiedTS { get { throw null; } set { } }
        public bool? RemovePropagationsOnEntityDelete { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.TimeBoundary> ValidityPeriods { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasClassification System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasClassification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasClassification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasClassification System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasClassification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasClassification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasClassification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasClassificationDef : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasClassificationDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasClassificationDef>
    {
        public AtlasClassificationDef() { }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasAttributeDef> AttributeDefs { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.TypeCategory? Category { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public long? CreateTime { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasDateFormat DateFormatter { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EntityTypes { get { throw null; } }
        public string Guid { get { throw null; } set { } }
        public string LastModifiedTS { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Options { get { throw null; } }
        public string ServiceType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SubTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> SuperTypes { get { throw null; } }
        public string TypeVersion { get { throw null; } set { } }
        public string UpdatedBy { get { throw null; } set { } }
        public long? UpdateTime { get { throw null; } set { } }
        public long? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasClassificationDef System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasClassificationDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasClassificationDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasClassificationDef System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasClassificationDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasClassificationDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasClassificationDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasClassifications : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasClassifications>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasClassifications>
    {
        internal AtlasClassifications() { }
        public System.Collections.Generic.IReadOnlyList<System.BinaryData> List { get { throw null; } }
        public int? PageSize { get { throw null; } }
        public string SortBy { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.AtlasSortType? SortType { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public int? TotalCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasClassifications System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasClassifications>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasClassifications>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasClassifications System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasClassifications>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasClassifications>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasClassifications>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasConstraintDef : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasConstraintDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasConstraintDef>
    {
        public AtlasConstraintDef() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Params { get { throw null; } }
        public string Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasConstraintDef System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasConstraintDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasConstraintDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasConstraintDef System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasConstraintDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasConstraintDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasConstraintDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasDateFormat : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasDateFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasDateFormat>
    {
        public AtlasDateFormat() { }
        public System.Collections.Generic.IList<string> AvailableLocales { get { throw null; } }
        public float? Calendar { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasDateFormat DateInstance { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasDateFormat DateTimeInstance { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasDateFormat Instance { get { throw null; } set { } }
        public bool? Lenient { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasNumberFormat NumberFormat { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasDateFormat TimeInstance { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasTimeZone TimeZone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasDateFormat System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasDateFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasDateFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasDateFormat System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasDateFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasDateFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasDateFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasEntitiesWithExtInfo : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntitiesWithExtInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntitiesWithExtInfo>
    {
        public AtlasEntitiesWithExtInfo() { }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasEntity> Entities { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.Purview.DataMap.AtlasEntity> ReferredEntities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasEntitiesWithExtInfo System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntitiesWithExtInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntitiesWithExtInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasEntitiesWithExtInfo System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntitiesWithExtInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntitiesWithExtInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntitiesWithExtInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasEntity : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntity>
    {
        public AtlasEntity() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> BusinessAttributes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasClassification> Classifications { get { throw null; } }
        public string CollectionId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.ContactInfo>> Contacts { get { throw null; } }
        public string CreatedBy { get { throw null; } set { } }
        public long? CreateTime { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> CustomAttributes { get { throw null; } }
        public string Guid { get { throw null; } set { } }
        public string HomeId { get { throw null; } set { } }
        public bool? IsIncomplete { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public string LastModifiedTS { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasTermAssignmentHeader> Meanings { get { throw null; } }
        public int? ProvenanceType { get { throw null; } set { } }
        public bool? Proxy { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> RelationshipAttributes { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.EntityStatus? Status { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
        public string UpdatedBy { get { throw null; } set { } }
        public long? UpdateTime { get { throw null; } set { } }
        public long? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasEntity System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasEntity System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasEntityDef : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntityDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntityDef>
    {
        public AtlasEntityDef() { }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasAttributeDef> AttributeDefs { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.TypeCategory? Category { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public long? CreateTime { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasDateFormat DateFormatter { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Guid { get { throw null; } set { } }
        public string LastModifiedTS { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Options { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelationshipAttributeDef> RelationshipAttributeDefs { get { throw null; } }
        public string ServiceType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SubTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> SuperTypes { get { throw null; } }
        public string TypeVersion { get { throw null; } set { } }
        public string UpdatedBy { get { throw null; } set { } }
        public long? UpdateTime { get { throw null; } set { } }
        public long? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasEntityDef System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntityDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntityDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasEntityDef System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntityDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntityDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntityDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasEntityHeader : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntityHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntityHeader>
    {
        public AtlasEntityHeader() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public System.Collections.Generic.IList<string> ClassificationNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasClassification> Classifications { get { throw null; } }
        public string DisplayText { get { throw null; } set { } }
        public string Guid { get { throw null; } set { } }
        public bool? IsIncomplete { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public string LastModifiedTS { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MeaningNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasTermAssignmentHeader> Meanings { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.EntityStatus? Status { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasEntityHeader System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntityHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntityHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasEntityHeader System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntityHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntityHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntityHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasEntityHeaders : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntityHeaders>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntityHeaders>
    {
        public AtlasEntityHeaders() { }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.Purview.DataMap.AtlasEntityHeader> GuidHeaderMap { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasEntityHeaders System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntityHeaders>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntityHeaders>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasEntityHeaders System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntityHeaders>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntityHeaders>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntityHeaders>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasEntityWithExtInfo : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo>
    {
        public AtlasEntityWithExtInfo() { }
        public Azure.Analytics.Purview.DataMap.AtlasEntity Entity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.Purview.DataMap.AtlasEntity> ReferredEntities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasEnumDef : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEnumDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEnumDef>
    {
        public AtlasEnumDef() { }
        public Azure.Analytics.Purview.DataMap.TypeCategory? Category { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public long? CreateTime { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasDateFormat DateFormatter { get { throw null; } set { } }
        public string DefaultValue { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasEnumElementDef> ElementDefs { get { throw null; } }
        public string Guid { get { throw null; } set { } }
        public string LastModifiedTS { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Options { get { throw null; } }
        public string ServiceType { get { throw null; } set { } }
        public string TypeVersion { get { throw null; } set { } }
        public string UpdatedBy { get { throw null; } set { } }
        public long? UpdateTime { get { throw null; } set { } }
        public long? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasEnumDef System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEnumDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEnumDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasEnumDef System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEnumDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEnumDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEnumDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasEnumElementDef : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEnumElementDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEnumElementDef>
    {
        public AtlasEnumElementDef() { }
        public string Description { get { throw null; } set { } }
        public int? Ordinal { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasEnumElementDef System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEnumElementDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasEnumElementDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasEnumElementDef System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEnumElementDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEnumElementDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasEnumElementDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasGlossary : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasGlossary>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossary>
    {
        public AtlasGlossary() { }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader> Categories { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasClassification> Classifications { get { throw null; } }
        public string CreatedBy { get { throw null; } set { } }
        public long? CreateTime { get { throw null; } set { } }
        public string Guid { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string LastModifiedTS { get { throw null; } set { } }
        public string LongDescription { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string QualifiedName { get { throw null; } set { } }
        public string ShortDescription { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> Terms { get { throw null; } }
        public string UpdatedBy { get { throw null; } set { } }
        public long? UpdateTime { get { throw null; } set { } }
        public string Usage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasGlossary System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasGlossary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasGlossary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasGlossary System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasGlossaryCategory : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory>
    {
        public AtlasGlossaryCategory() { }
        public Azure.Analytics.Purview.DataMap.AtlasGlossaryHeader Anchor { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader> ChildrenCategories { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasClassification> Classifications { get { throw null; } }
        public string CreatedBy { get { throw null; } set { } }
        public long? CreateTime { get { throw null; } set { } }
        public string Guid { get { throw null; } set { } }
        public string LastModifiedTS { get { throw null; } set { } }
        public string LongDescription { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader ParentCategory { get { throw null; } set { } }
        public string QualifiedName { get { throw null; } set { } }
        public string ShortDescription { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> Terms { get { throw null; } }
        public string UpdatedBy { get { throw null; } set { } }
        public long? UpdateTime { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasGlossaryExtInfo : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryExtInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryExtInfo>
    {
        internal AtlasGlossaryExtInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader> Categories { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory> CategoryInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasClassification> Classifications { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public long? CreateTime { get { throw null; } }
        public string Guid { get { throw null; } }
        public string Language { get { throw null; } }
        public string LastModifiedTS { get { throw null; } }
        public string LongDescription { get { throw null; } }
        public string Name { get { throw null; } }
        public string QualifiedName { get { throw null; } }
        public string ShortDescription { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm> TermInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> Terms { get { throw null; } }
        public string UpdatedBy { get { throw null; } }
        public long? UpdateTime { get { throw null; } }
        public string Usage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasGlossaryExtInfo System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryExtInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryExtInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasGlossaryExtInfo System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryExtInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryExtInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryExtInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasGlossaryHeader : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryHeader>
    {
        public AtlasGlossaryHeader() { }
        public string DisplayText { get { throw null; } set { } }
        public string GlossaryGuid { get { throw null; } set { } }
        public string RelationGuid { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasGlossaryHeader System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasGlossaryHeader System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasGlossaryTerm : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm>
    {
        public AtlasGlossaryTerm() { }
        public string Abbreviation { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasGlossaryHeader Anchor { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> Antonyms { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedObjectId> AssignedEntities { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, System.BinaryData>> Attributes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasTermCategorizationHeader> Categories { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasClassification> Classifications { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> Classifies { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.ContactInfo>> Contacts { get { throw null; } }
        public string CreatedBy { get { throw null; } set { } }
        public long? CreateTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Examples { get { throw null; } }
        public string Guid { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.PurviewObjectId> HierarchyInfo { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> IsA { get { throw null; } }
        public string LastModifiedTS { get { throw null; } set { } }
        public string LongDescription { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NickName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> PreferredTerms { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> PreferredToTerms { get { throw null; } }
        public string QualifiedName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> ReplacedBy { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> ReplacementTerms { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.ResourceLink> Resources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> SeeAlso { get { throw null; } }
        public string ShortDescription { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.TermStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> Synonyms { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> TemplateName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> TranslatedTerms { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> TranslationTerms { get { throw null; } }
        public string UpdatedBy { get { throw null; } set { } }
        public long? UpdateTime { get { throw null; } set { } }
        public string Usage { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> ValidValues { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader> ValidValuesFor { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasLineageInfo : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasLineageInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasLineageInfo>
    {
        internal AtlasLineageInfo() { }
        public string BaseEntityGuid { get { throw null; } }
        public int? ChildrenCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Analytics.Purview.DataMap.AtlasEntityHeader> GuidEntityMap { get { throw null; } }
        public int? LineageDepth { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.LineageDirection? LineageDirection { get { throw null; } }
        public int? LineageWidth { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.ParentRelation> ParentRelations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.LineageRelation> Relations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IDictionary<string, System.BinaryData>> WidthCounts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasLineageInfo System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasLineageInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasLineageInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasLineageInfo System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasLineageInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasLineageInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasLineageInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasNumberFormat : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasNumberFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasNumberFormat>
    {
        public AtlasNumberFormat() { }
        public System.Collections.Generic.IList<string> AvailableLocales { get { throw null; } }
        public string Currency { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasNumberFormat CurrencyInstance { get { throw null; } set { } }
        public bool? GroupingUsed { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasNumberFormat Instance { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasNumberFormat IntegerInstance { get { throw null; } set { } }
        public int? MaximumFractionDigits { get { throw null; } set { } }
        public int? MaximumIntegerDigits { get { throw null; } set { } }
        public int? MinimumFractionDigits { get { throw null; } set { } }
        public int? MinimumIntegerDigits { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasNumberFormat NumberInstance { get { throw null; } set { } }
        public bool? ParseIntegerOnly { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasNumberFormat PercentInstance { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.RoundingMode? RoundingMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasNumberFormat System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasNumberFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasNumberFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasNumberFormat System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasNumberFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasNumberFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasNumberFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasObjectId : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasObjectId>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasObjectId>
    {
        public AtlasObjectId() { }
        public string Guid { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> UniqueAttributes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasObjectId System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasObjectId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasObjectId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasObjectId System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasObjectId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasObjectId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasObjectId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasRelatedCategoryHeader : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader>
    {
        public AtlasRelatedCategoryHeader() { }
        public string CategoryGuid { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayText { get { throw null; } set { } }
        public string ParentCategoryGuid { get { throw null; } set { } }
        public string RelationGuid { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasRelatedObjectId : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelatedObjectId>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelatedObjectId>
    {
        public AtlasRelatedObjectId() { }
        public string DisplayText { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.EntityStatus? EntityStatus { get { throw null; } set { } }
        public string Guid { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasStruct RelationshipAttributes { get { throw null; } set { } }
        public System.Guid? RelationshipGuid { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.StatusAtlasRelationship? RelationshipStatus { get { throw null; } set { } }
        public string RelationshipType { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> UniqueAttributes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasRelatedObjectId System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelatedObjectId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelatedObjectId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasRelatedObjectId System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelatedObjectId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelatedObjectId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelatedObjectId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasRelatedTermHeader : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader>
    {
        public AtlasRelatedTermHeader() { }
        public string Description { get { throw null; } set { } }
        public string DisplayText { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public string RelationGuid { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasTermRelationshipStatus? Status { get { throw null; } set { } }
        public string Steward { get { throw null; } set { } }
        public string TermGuid { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasRelationship : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelationship>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationship>
    {
        public AtlasRelationship() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public string CreatedBy { get { throw null; } set { } }
        public long? CreateTime { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasObjectId End1 { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasObjectId End2 { get { throw null; } set { } }
        public string Guid { get { throw null; } set { } }
        public string HomeId { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public string LastModifiedTS { get { throw null; } set { } }
        public int? ProvenanceType { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.StatusAtlasRelationship? Status { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
        public string UpdatedBy { get { throw null; } set { } }
        public long? UpdateTime { get { throw null; } set { } }
        public long? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasRelationship System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelationship>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelationship>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasRelationship System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationship>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationship>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationship>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasRelationshipAttributeDef : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipAttributeDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipAttributeDef>
    {
        public AtlasRelationshipAttributeDef() { }
        public Azure.Analytics.Purview.DataMap.CardinalityValue? Cardinality { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasConstraintDef> Constraints { get { throw null; } }
        public string DefaultValue { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IncludeInNotification { get { throw null; } set { } }
        public bool? IsIndexable { get { throw null; } set { } }
        public bool? IsLegacyAttribute { get { throw null; } set { } }
        public bool? IsOptional { get { throw null; } set { } }
        public bool? IsUnique { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Options { get { throw null; } }
        public string RelationshipTypeName { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
        public int? ValuesMaxCount { get { throw null; } set { } }
        public int? ValuesMinCount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasRelationshipAttributeDef System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipAttributeDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipAttributeDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasRelationshipAttributeDef System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipAttributeDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipAttributeDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipAttributeDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasRelationshipDef : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipDef>
    {
        public AtlasRelationshipDef() { }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasAttributeDef> AttributeDefs { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.TypeCategory? Category { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public long? CreateTime { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasDateFormat DateFormatter { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasRelationshipEndDef EndDef1 { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasRelationshipEndDef EndDef2 { get { throw null; } set { } }
        public string Guid { get { throw null; } set { } }
        public string LastModifiedTS { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Options { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.RelationshipCategory? RelationshipCategory { get { throw null; } set { } }
        public string RelationshipLabel { get { throw null; } set { } }
        public string ServiceType { get { throw null; } set { } }
        public string TypeVersion { get { throw null; } set { } }
        public string UpdatedBy { get { throw null; } set { } }
        public long? UpdateTime { get { throw null; } set { } }
        public long? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasRelationshipDef System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasRelationshipDef System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasRelationshipEndDef : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipEndDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipEndDef>
    {
        public AtlasRelationshipEndDef() { }
        public Azure.Analytics.Purview.DataMap.CardinalityValue? Cardinality { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsContainer { get { throw null; } set { } }
        public bool? IsLegacyAttribute { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasRelationshipEndDef System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipEndDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipEndDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasRelationshipEndDef System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipEndDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipEndDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipEndDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasRelationshipWithExtInfo : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipWithExtInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipWithExtInfo>
    {
        internal AtlasRelationshipWithExtInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Analytics.Purview.DataMap.AtlasEntityHeader> ReferredEntities { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.AtlasRelationship Relationship { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasRelationshipWithExtInfo System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipWithExtInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipWithExtInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasRelationshipWithExtInfo System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipWithExtInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipWithExtInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasRelationshipWithExtInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AtlasSortType : System.IEquatable<Azure.Analytics.Purview.DataMap.AtlasSortType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AtlasSortType(string value) { throw null; }
        public static Azure.Analytics.Purview.DataMap.AtlasSortType Ascend { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.AtlasSortType Descend { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.AtlasSortType None { get { throw null; } }
        public bool Equals(Azure.Analytics.Purview.DataMap.AtlasSortType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Purview.DataMap.AtlasSortType left, Azure.Analytics.Purview.DataMap.AtlasSortType right) { throw null; }
        public static implicit operator Azure.Analytics.Purview.DataMap.AtlasSortType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Purview.DataMap.AtlasSortType left, Azure.Analytics.Purview.DataMap.AtlasSortType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AtlasStruct : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasStruct>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasStruct>
    {
        public AtlasStruct() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public string LastModifiedTS { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasStruct System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasStruct>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasStruct>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasStruct System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasStruct>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasStruct>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasStruct>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasStructDef : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasStructDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasStructDef>
    {
        public AtlasStructDef() { }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasAttributeDef> AttributeDefs { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.TypeCategory? Category { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public long? CreateTime { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasDateFormat DateFormatter { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Guid { get { throw null; } set { } }
        public string LastModifiedTS { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Options { get { throw null; } }
        public string ServiceType { get { throw null; } set { } }
        public string TypeVersion { get { throw null; } set { } }
        public string UpdatedBy { get { throw null; } set { } }
        public long? UpdateTime { get { throw null; } set { } }
        public long? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasStructDef System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasStructDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasStructDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasStructDef System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasStructDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasStructDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasStructDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasTermAssignmentHeader : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTermAssignmentHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTermAssignmentHeader>
    {
        public AtlasTermAssignmentHeader() { }
        public int? Confidence { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayText { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public System.Guid? RelationGuid { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasTermAssignmentStatus? Status { get { throw null; } set { } }
        public string Steward { get { throw null; } set { } }
        public System.Guid? TermGuid { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasTermAssignmentHeader System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTermAssignmentHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTermAssignmentHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasTermAssignmentHeader System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTermAssignmentHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTermAssignmentHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTermAssignmentHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AtlasTermAssignmentStatus : System.IEquatable<Azure.Analytics.Purview.DataMap.AtlasTermAssignmentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AtlasTermAssignmentStatus(string value) { throw null; }
        public static Azure.Analytics.Purview.DataMap.AtlasTermAssignmentStatus Deprecated { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.AtlasTermAssignmentStatus Discovered { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.AtlasTermAssignmentStatus Imported { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.AtlasTermAssignmentStatus Obsolete { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.AtlasTermAssignmentStatus Other { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.AtlasTermAssignmentStatus Proposed { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.AtlasTermAssignmentStatus Validated { get { throw null; } }
        public bool Equals(Azure.Analytics.Purview.DataMap.AtlasTermAssignmentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Purview.DataMap.AtlasTermAssignmentStatus left, Azure.Analytics.Purview.DataMap.AtlasTermAssignmentStatus right) { throw null; }
        public static implicit operator Azure.Analytics.Purview.DataMap.AtlasTermAssignmentStatus (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Purview.DataMap.AtlasTermAssignmentStatus left, Azure.Analytics.Purview.DataMap.AtlasTermAssignmentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AtlasTermCategorizationHeader : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTermCategorizationHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTermCategorizationHeader>
    {
        public AtlasTermCategorizationHeader() { }
        public System.Guid? CategoryGuid { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayText { get { throw null; } set { } }
        public System.Guid? RelationGuid { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasTermRelationshipStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasTermCategorizationHeader System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTermCategorizationHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTermCategorizationHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasTermCategorizationHeader System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTermCategorizationHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTermCategorizationHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTermCategorizationHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AtlasTermRelationshipStatus : System.IEquatable<Azure.Analytics.Purview.DataMap.AtlasTermRelationshipStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AtlasTermRelationshipStatus(string value) { throw null; }
        public static Azure.Analytics.Purview.DataMap.AtlasTermRelationshipStatus Active { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.AtlasTermRelationshipStatus Deprecated { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.AtlasTermRelationshipStatus Draft { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.AtlasTermRelationshipStatus Obsolete { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.AtlasTermRelationshipStatus Other { get { throw null; } }
        public bool Equals(Azure.Analytics.Purview.DataMap.AtlasTermRelationshipStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Purview.DataMap.AtlasTermRelationshipStatus left, Azure.Analytics.Purview.DataMap.AtlasTermRelationshipStatus right) { throw null; }
        public static implicit operator Azure.Analytics.Purview.DataMap.AtlasTermRelationshipStatus (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Purview.DataMap.AtlasTermRelationshipStatus left, Azure.Analytics.Purview.DataMap.AtlasTermRelationshipStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AtlasTimeZone : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTimeZone>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTimeZone>
    {
        public AtlasTimeZone() { }
        public System.Collections.Generic.IList<string> AvailableIds { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.AtlasTimeZone Default { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public int? DstSavings { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public int? RawOffset { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasTimeZone System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTimeZone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTimeZone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasTimeZone System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTimeZone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTimeZone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTimeZone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasTypeDef : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTypeDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTypeDef>
    {
        internal AtlasTypeDef() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasAttributeDef> AttributeDefs { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.TypeCategory? Category { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public long? CreateTime { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.AtlasDateFormat DateFormatter { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasEnumElementDef> ElementDefs { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.AtlasRelationshipEndDef EndDef1 { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.AtlasRelationshipEndDef EndDef2 { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> EntityTypes { get { throw null; } }
        public string Guid { get { throw null; } }
        public string LastModifiedTS { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Options { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasRelationshipAttributeDef> RelationshipAttributeDefs { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.RelationshipCategory? RelationshipCategory { get { throw null; } }
        public string RelationshipLabel { get { throw null; } }
        public string ServiceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SuperTypes { get { throw null; } }
        public string TypeVersion { get { throw null; } }
        public string UpdatedBy { get { throw null; } }
        public long? UpdateTime { get { throw null; } }
        public long? Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasTypeDef System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTypeDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTypeDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasTypeDef System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTypeDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTypeDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTypeDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasTypeDefHeader : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTypeDefHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTypeDefHeader>
    {
        internal AtlasTypeDefHeader() { }
        public Azure.Analytics.Purview.DataMap.TypeCategory? Category { get { throw null; } }
        public string Guid { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasTypeDefHeader System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTypeDefHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTypeDefHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasTypeDefHeader System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTypeDefHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTypeDefHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTypeDefHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AtlasTypesDef : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTypesDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTypesDef>
    {
        public AtlasTypesDef() { }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasBusinessMetadataDef> BusinessMetadataDefs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasClassificationDef> ClassificationDefs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasEntityDef> EntityDefs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasEnumDef> EnumDefs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelationshipDef> RelationshipDefs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasStructDef> StructDefs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.TermTemplateDef> TermTemplateDefs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasTypesDef System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTypesDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AtlasTypesDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AtlasTypesDef System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTypesDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTypesDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AtlasTypesDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutoCompleteConfig : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AutoCompleteConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AutoCompleteConfig>
    {
        public AutoCompleteConfig() { }
        public System.BinaryData Filter { get { throw null; } set { } }
        public string Keywords { get { throw null; } set { } }
        public int? Limit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AutoCompleteConfig System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AutoCompleteConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AutoCompleteConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AutoCompleteConfig System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AutoCompleteConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AutoCompleteConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AutoCompleteConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutoCompleteResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AutoCompleteResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AutoCompleteResult>
    {
        internal AutoCompleteResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AutoCompleteResultValue> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AutoCompleteResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AutoCompleteResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AutoCompleteResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AutoCompleteResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AutoCompleteResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AutoCompleteResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AutoCompleteResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutoCompleteResultValue : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AutoCompleteResultValue>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AutoCompleteResultValue>
    {
        internal AutoCompleteResultValue() { }
        public string QueryPlusText { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AutoCompleteResultValue System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AutoCompleteResultValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.AutoCompleteResultValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.AutoCompleteResultValue System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AutoCompleteResultValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AutoCompleteResultValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.AutoCompleteResultValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAnalyticsPurviewDataMapContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAnalyticsPurviewDataMapContext() { }
        public static Azure.Analytics.Purview.DataMap.AzureAnalyticsPurviewDataMapContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BulkImportResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.BulkImportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.BulkImportResult>
    {
        internal BulkImportResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.ImportInfo> FailedImportInfoList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.ImportInfo> SuccessImportInfoList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.BulkImportResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.BulkImportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.BulkImportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.BulkImportResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.BulkImportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.BulkImportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.BulkImportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BusinessAttributeUpdateBehavior : System.IEquatable<Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BusinessAttributeUpdateBehavior(string value) { throw null; }
        public static Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior Ignore { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior Merge { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior Replace { get { throw null; } }
        public bool Equals(Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior left, Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior right) { throw null; }
        public static implicit operator Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior left, Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BusinessMetadataOptions : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.BusinessMetadataOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.BusinessMetadataOptions>
    {
        public BusinessMetadataOptions(System.IO.Stream file) { }
        public System.IO.Stream File { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.BusinessMetadataOptions System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.BusinessMetadataOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.BusinessMetadataOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.BusinessMetadataOptions System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.BusinessMetadataOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.BusinessMetadataOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.BusinessMetadataOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CardinalityValue : System.IEquatable<Azure.Analytics.Purview.DataMap.CardinalityValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CardinalityValue(string value) { throw null; }
        public static Azure.Analytics.Purview.DataMap.CardinalityValue List { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.CardinalityValue Set { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.CardinalityValue Single { get { throw null; } }
        public bool Equals(Azure.Analytics.Purview.DataMap.CardinalityValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Purview.DataMap.CardinalityValue left, Azure.Analytics.Purview.DataMap.CardinalityValue right) { throw null; }
        public static implicit operator Azure.Analytics.Purview.DataMap.CardinalityValue (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Purview.DataMap.CardinalityValue left, Azure.Analytics.Purview.DataMap.CardinalityValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClassificationAssociateConfig : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ClassificationAssociateConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ClassificationAssociateConfig>
    {
        public ClassificationAssociateConfig() { }
        public Azure.Analytics.Purview.DataMap.AtlasClassification Classification { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EntityGuids { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.ClassificationAssociateConfig System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ClassificationAssociateConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ClassificationAssociateConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.ClassificationAssociateConfig System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ClassificationAssociateConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ClassificationAssociateConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ClassificationAssociateConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContactInfo : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ContactInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ContactInfo>
    {
        public ContactInfo() { }
        public string Id { get { throw null; } set { } }
        public string Info { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.ContactInfo System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ContactInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ContactInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.ContactInfo System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ContactInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ContactInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ContactInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContactSearchResultValue : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ContactSearchResultValue>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ContactSearchResultValue>
    {
        internal ContactSearchResultValue() { }
        public string ContactType { get { throw null; } }
        public string Id { get { throw null; } }
        public string Info { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.ContactSearchResultValue System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ContactSearchResultValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ContactSearchResultValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.ContactSearchResultValue System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ContactSearchResultValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ContactSearchResultValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ContactSearchResultValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMapClient
    {
        protected DataMapClient() { }
        public DataMapClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DataMapClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.DataMap.DataMapClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Analytics.Purview.DataMap.Discovery GetDiscoveryClient(string apiVersion = "2023-09-01") { throw null; }
        public virtual Azure.Analytics.Purview.DataMap.Entity GetEntityClient(string apiVersion = "2023-09-01") { throw null; }
        public virtual Azure.Analytics.Purview.DataMap.Glossary GetGlossaryClient(string apiVersion = "2023-09-01") { throw null; }
        public virtual Azure.Analytics.Purview.DataMap.Lineage GetLineageClient(string apiVersion = "2023-09-01") { throw null; }
        public virtual Azure.Analytics.Purview.DataMap.Relationship GetRelationshipClient() { throw null; }
        public virtual Azure.Analytics.Purview.DataMap.TypeDefinition GetTypeDefinitionClient(string apiVersion = "2023-09-01") { throw null; }
    }
    public partial class DataMapClientOptions : Azure.Core.ClientOptions
    {
        public DataMapClientOptions(Azure.Analytics.Purview.DataMap.DataMapClientOptions.ServiceVersion version = Azure.Analytics.Purview.DataMap.DataMapClientOptions.ServiceVersion.V2023_09_01) { }
        public enum ServiceVersion
        {
            V2023_09_01 = 1,
        }
    }
    public partial class Discovery
    {
        protected Discovery() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AutoCompleteResult> AutoComplete(Azure.Analytics.Purview.DataMap.AutoCompleteConfig body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AutoComplete(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AutoCompleteResult>> AutoCompleteAsync(Azure.Analytics.Purview.DataMap.AutoCompleteConfig body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AutoCompleteAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.QueryResult> Query(Azure.Analytics.Purview.DataMap.QueryConfig body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Query(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.QueryResult>> QueryAsync(Azure.Analytics.Purview.DataMap.QueryConfig body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> QueryAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.SuggestResult> Suggest(Azure.Analytics.Purview.DataMap.SuggestConfig body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Suggest(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.SuggestResult>> SuggestAsync(Azure.Analytics.Purview.DataMap.SuggestConfig body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SuggestAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class Entity
    {
        protected Entity() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AddClassification(Azure.Analytics.Purview.DataMap.ClassificationAssociateConfig body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddClassification(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddClassificationAsync(Azure.Analytics.Purview.DataMap.ClassificationAssociateConfig body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddClassificationAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddClassifications(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddClassifications(string guid, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasClassification> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddClassificationsAsync(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddClassificationsAsync(string guid, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasClassification> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddClassificationsByUniqueAttribute(string typeName, Azure.Core.RequestContent content, string attribute = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddClassificationsByUniqueAttribute(string typeName, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasClassification> body, string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddClassificationsByUniqueAttributeAsync(string typeName, Azure.Core.RequestContent content, string attribute = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddClassificationsByUniqueAttributeAsync(string typeName, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasClassification> body, string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddLabel(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddLabel(string guid, System.Collections.Generic.IEnumerable<string> body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddLabelAsync(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddLabelAsync(string guid, System.Collections.Generic.IEnumerable<string> body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddLabelsByUniqueAttribute(string typeName, Azure.Core.RequestContent content, string attribute = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddLabelsByUniqueAttribute(string typeName, System.Collections.Generic.IEnumerable<string> body = null, string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddLabelsByUniqueAttributeAsync(string typeName, Azure.Core.RequestContent content, string attribute = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddLabelsByUniqueAttributeAsync(string typeName, System.Collections.Generic.IEnumerable<string> body = null, string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddOrUpdateBusinessMetadata(string guid, Azure.Core.RequestContent content, bool? overwrite = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddOrUpdateBusinessMetadata(string guid, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, System.BinaryData>> body, bool? overwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddOrUpdateBusinessMetadataAsync(string guid, Azure.Core.RequestContent content, bool? overwrite = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddOrUpdateBusinessMetadataAsync(string guid, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, System.BinaryData>> body, bool? overwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddOrUpdateBusinessMetadataAttributes(string guid, string businessMetadataName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddOrUpdateBusinessMetadataAttributes(string guid, string businessMetadataName, System.Collections.Generic.IDictionary<string, System.BinaryData> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddOrUpdateBusinessMetadataAttributesAsync(string guid, string businessMetadataName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddOrUpdateBusinessMetadataAttributesAsync(string guid, string businessMetadataName, System.Collections.Generic.IDictionary<string, System.BinaryData> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.EntityMutationResult> BatchCreateOrUpdate(Azure.Analytics.Purview.DataMap.AtlasEntitiesWithExtInfo body, string collectionId = null, Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior? businessAttributeUpdateBehavior = default(Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response BatchCreateOrUpdate(Azure.Core.RequestContent content, string collectionId = null, string businessAttributeUpdateBehavior = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.EntityMutationResult>> BatchCreateOrUpdateAsync(Azure.Analytics.Purview.DataMap.AtlasEntitiesWithExtInfo body, string collectionId = null, Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior? businessAttributeUpdateBehavior = default(Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BatchCreateOrUpdateAsync(Azure.Core.RequestContent content, string collectionId = null, string businessAttributeUpdateBehavior = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response BatchDelete(System.Collections.Generic.IEnumerable<string> guid, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.EntityMutationResult> BatchDelete(System.Collections.Generic.IEnumerable<string> guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BatchDeleteAsync(System.Collections.Generic.IEnumerable<string> guid, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.EntityMutationResult>> BatchDeleteAsync(System.Collections.Generic.IEnumerable<string> guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response BatchGetByUniqueAttributes(string typeName, bool? minExtInfo, bool? ignoreRelationships, string attrNQualifiedName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEntitiesWithExtInfo> BatchGetByUniqueAttributes(string typeName, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), string attrNQualifiedName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BatchGetByUniqueAttributesAsync(string typeName, bool? minExtInfo, bool? ignoreRelationships, string attrNQualifiedName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEntitiesWithExtInfo>> BatchGetByUniqueAttributesAsync(string typeName, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), string attrNQualifiedName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<string>> BatchSetClassifications(Azure.Analytics.Purview.DataMap.AtlasEntityHeaders body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response BatchSetClassifications(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<string>>> BatchSetClassificationsAsync(Azure.Analytics.Purview.DataMap.AtlasEntityHeaders body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BatchSetClassificationsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.EntityMutationResult> CreateOrUpdate(Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo body, Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior? businessAttributeUpdateBehavior = default(Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior?), string collectionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrUpdate(Azure.Core.RequestContent content, string businessAttributeUpdateBehavior = null, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.EntityMutationResult>> CreateOrUpdateAsync(Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo body, Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior? businessAttributeUpdateBehavior = default(Azure.Analytics.Purview.DataMap.BusinessAttributeUpdateBehavior?), string collectionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(Azure.Core.RequestContent content, string businessAttributeUpdateBehavior = null, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(string guid, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.EntityMutationResult> Delete(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string guid, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.EntityMutationResult>> DeleteAsync(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteByUniqueAttribute(string typeName, string attribute, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.EntityMutationResult> DeleteByUniqueAttribute(string typeName, string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteByUniqueAttributeAsync(string typeName, string attribute, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.EntityMutationResult>> DeleteByUniqueAttributeAsync(string typeName, string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetBusinessMetadataTemplate(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetBusinessMetadataTemplate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetBusinessMetadataTemplateAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetBusinessMetadataTemplateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetByIds(System.Collections.Generic.IEnumerable<string> guid, bool? minExtInfo, bool? ignoreRelationships, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEntitiesWithExtInfo> GetByIds(System.Collections.Generic.IEnumerable<string> guid, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetByIdsAsync(System.Collections.Generic.IEnumerable<string> guid, bool? minExtInfo, bool? ignoreRelationships, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEntitiesWithExtInfo>> GetByIdsAsync(System.Collections.Generic.IEnumerable<string> guid, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetByUniqueAttribute(string typeName, bool? minExtInfo, bool? ignoreRelationships, string attribute, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo> GetByUniqueAttribute(string typeName, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetByUniqueAttributeAsync(string typeName, bool? minExtInfo, bool? ignoreRelationships, string attribute, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo>> GetByUniqueAttributeAsync(string typeName, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetClassification(string guid, string classificationName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasClassification> GetClassification(string guid, string classificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationAsync(string guid, string classificationName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasClassification>> GetClassificationAsync(string guid, string classificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetClassifications(string guid, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasClassifications> GetClassifications(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationsAsync(string guid, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasClassifications>> GetClassificationsAsync(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEntity(string guid, bool? minExtInfo, bool? ignoreRelationships, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo> GetEntity(string guid, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntityAsync(string guid, bool? minExtInfo, bool? ignoreRelationships, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo>> GetEntityAsync(string guid, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetHeader(string guid, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEntityHeader> GetHeader(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetHeaderAsync(string guid, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEntityHeader>> GetHeaderAsync(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.BulkImportResult> ImportBusinessMetadata(Azure.Analytics.Purview.DataMap.BusinessMetadataOptions body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ImportBusinessMetadata(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.BulkImportResult> ImportBusinessMetadata(System.BinaryData file, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.BulkImportResult>> ImportBusinessMetadataAsync(Azure.Analytics.Purview.DataMap.BusinessMetadataOptions body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ImportBusinessMetadataAsync(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.EntityMutationResult> MoveEntitiesToCollection(string collectionId, Azure.Analytics.Purview.DataMap.MoveEntitiesConfig body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response MoveEntitiesToCollection(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.EntityMutationResult>> MoveEntitiesToCollectionAsync(string collectionId, Azure.Analytics.Purview.DataMap.MoveEntitiesConfig body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> MoveEntitiesToCollectionAsync(string collectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveBusinessMetadata(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveBusinessMetadata(string guid, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, System.BinaryData>> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveBusinessMetadataAsync(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveBusinessMetadataAsync(string guid, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, System.BinaryData>> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveBusinessMetadataAttributes(string guid, string businessMetadataName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveBusinessMetadataAttributes(string guid, string businessMetadataName, System.Collections.Generic.IDictionary<string, System.BinaryData> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveBusinessMetadataAttributesAsync(string guid, string businessMetadataName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveBusinessMetadataAttributesAsync(string guid, string businessMetadataName, System.Collections.Generic.IDictionary<string, System.BinaryData> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveClassification(string guid, string classificationName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveClassificationAsync(string guid, string classificationName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveClassificationByUniqueAttribute(string typeName, string classificationName, string attribute = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveClassificationByUniqueAttributeAsync(string typeName, string classificationName, string attribute = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveLabels(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveLabels(string guid, System.Collections.Generic.IEnumerable<string> body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveLabelsAsync(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveLabelsAsync(string guid, System.Collections.Generic.IEnumerable<string> body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveLabelsByUniqueAttribute(string typeName, Azure.Core.RequestContent content, string attribute = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveLabelsByUniqueAttribute(string typeName, System.Collections.Generic.IEnumerable<string> body = null, string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveLabelsByUniqueAttributeAsync(string typeName, Azure.Core.RequestContent content, string attribute = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveLabelsByUniqueAttributeAsync(string typeName, System.Collections.Generic.IEnumerable<string> body = null, string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetLabels(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SetLabels(string guid, System.Collections.Generic.IEnumerable<string> body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetLabelsAsync(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetLabelsAsync(string guid, System.Collections.Generic.IEnumerable<string> body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetLabelsByUniqueAttribute(string typeName, Azure.Core.RequestContent content, string attribute = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SetLabelsByUniqueAttribute(string typeName, System.Collections.Generic.IEnumerable<string> body = null, string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetLabelsByUniqueAttributeAsync(string typeName, Azure.Core.RequestContent content, string attribute = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetLabelsByUniqueAttributeAsync(string typeName, System.Collections.Generic.IEnumerable<string> body = null, string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateAttributeById(string guid, string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.EntityMutationResult> UpdateAttributeById(string guid, string name, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAttributeByIdAsync(string guid, string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.EntityMutationResult>> UpdateAttributeByIdAsync(string guid, string name, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.EntityMutationResult> UpdateByUniqueAttribute(string typeName, Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo body, string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateByUniqueAttribute(string typeName, Azure.Core.RequestContent content, string attribute = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.EntityMutationResult>> UpdateByUniqueAttributeAsync(string typeName, Azure.Analytics.Purview.DataMap.AtlasEntityWithExtInfo body, string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateByUniqueAttributeAsync(string typeName, Azure.Core.RequestContent content, string attribute = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateClassifications(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateClassifications(string guid, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasClassification> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateClassificationsAsync(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateClassificationsAsync(string guid, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasClassification> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateClassificationsUniqueByAttribute(string typeName, Azure.Core.RequestContent content, string attribute = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateClassificationsUniqueByAttribute(string typeName, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasClassification> body, string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateClassificationsUniqueByAttributeAsync(string typeName, Azure.Core.RequestContent content, string attribute = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateClassificationsUniqueByAttributeAsync(string typeName, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasClassification> body, string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EntityMutationResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.EntityMutationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.EntityMutationResult>
    {
        internal EntityMutationResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> GuidAssignments { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasEntityHeader>> MutatedEntities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasEntityHeader> PartialUpdatedEntities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.EntityMutationResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.EntityMutationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.EntityMutationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.EntityMutationResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.EntityMutationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.EntityMutationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.EntityMutationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityStatus : System.IEquatable<Azure.Analytics.Purview.DataMap.EntityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityStatus(string value) { throw null; }
        public static Azure.Analytics.Purview.DataMap.EntityStatus Active { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.EntityStatus Deleted { get { throw null; } }
        public bool Equals(Azure.Analytics.Purview.DataMap.EntityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Purview.DataMap.EntityStatus left, Azure.Analytics.Purview.DataMap.EntityStatus right) { throw null; }
        public static implicit operator Azure.Analytics.Purview.DataMap.EntityStatus (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Purview.DataMap.EntityStatus left, Azure.Analytics.Purview.DataMap.EntityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Glossary
    {
        protected Glossary() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AssignTermToEntities(string termId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AssignTermToEntities(string termId, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasRelatedObjectId> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AssignTermToEntitiesAsync(string termId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AssignTermToEntitiesAsync(string termId, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasRelatedObjectId> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response BatchGet(int? limit, int? offset, string sort, bool? ignoreTermsAndCategories, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasGlossary>> BatchGet(int? limit = default(int?), int? offset = default(int?), string sort = null, bool? ignoreTermsAndCategories = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BatchGetAsync(int? limit, int? offset, string sort, bool? ignoreTermsAndCategories, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasGlossary>>> BatchGetAsync(int? limit = default(int?), int? offset = default(int?), string sort = null, bool? ignoreTermsAndCategories = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossary> Create(Azure.Analytics.Purview.DataMap.AtlasGlossary body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Create(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossary>> CreateAsync(Azure.Analytics.Purview.DataMap.AtlasGlossary body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateCategories(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory>> CreateCategories(System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateCategoriesAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory>>> CreateCategoriesAsync(System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory> CreateCategory(Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateCategory(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory>> CreateCategoryAsync(Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateCategoryAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm> CreateTerm(Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm body, bool? includeTermHierarchy = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateTerm(Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm>> CreateTermAsync(Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm body, bool? includeTermHierarchy = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateTermAsync(Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateTerms(Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm>> CreateTerms(System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm> body, bool? includeTermHierarchy = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateTermsAsync(Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm>>> CreateTermsAsync(System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm> body, bool? includeTermHierarchy = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string glossaryId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string glossaryId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteCategory(string categoryId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteCategoryAsync(string categoryId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTerm(string termId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTermAssignmentFromEntities(string termId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTermAssignmentFromEntities(string termId, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasRelatedObjectId> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTermAssignmentFromEntitiesAsync(string termId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTermAssignmentFromEntitiesAsync(string termId, System.Collections.Generic.IEnumerable<Azure.Analytics.Purview.DataMap.AtlasRelatedObjectId> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTermAsync(string termId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCategories(string glossaryId, int? limit, int? offset, string sort, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory>> GetCategories(string glossaryId, int? limit = default(int?), int? offset = default(int?), string sort = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCategoriesAsync(string glossaryId, int? limit, int? offset, string sort, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory>>> GetCategoriesAsync(string glossaryId, int? limit = default(int?), int? offset = default(int?), string sort = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCategoriesHeaders(string glossaryId, int? limit, int? offset, string sort, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader>> GetCategoriesHeaders(string glossaryId, int? limit = default(int?), int? offset = default(int?), string sort = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCategoriesHeadersAsync(string glossaryId, int? limit, int? offset, string sort, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader>>> GetCategoriesHeadersAsync(string glossaryId, int? limit = default(int?), int? offset = default(int?), string sort = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCategory(string categoryId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory> GetCategory(string categoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCategoryAsync(string categoryId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory>> GetCategoryAsync(string categoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCategoryTerms(string categoryId, int? limit, int? offset, string sort, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader>> GetCategoryTerms(string categoryId, int? limit = default(int?), int? offset = default(int?), string sort = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCategoryTermsAsync(string categoryId, int? limit, int? offset, string sort, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader>>> GetCategoryTermsAsync(string categoryId, int? limit = default(int?), int? offset = default(int?), string sort = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDetailed(string glossaryId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryExtInfo> GetDetailed(string glossaryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDetailedAsync(string glossaryId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryExtInfo>> GetDetailedAsync(string glossaryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEntitiesAssignedWithTerm(string termId, int? limit, int? offset, string sort, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasRelatedObjectId>> GetEntitiesAssignedWithTerm(string termId, int? limit = default(int?), int? offset = default(int?), string sort = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntitiesAssignedWithTermAsync(string termId, int? limit, int? offset, string sort, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasRelatedObjectId>>> GetEntitiesAssignedWithTermAsync(string termId, int? limit = default(int?), int? offset = default(int?), string sort = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetGlossary(string glossaryId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossary> GetGlossary(string glossaryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossaryAsync(string glossaryId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossary>> GetGlossaryAsync(string glossaryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRelatedCategories(string categoryId, int? limit, int? offset, string sort, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader>>> GetRelatedCategories(string categoryId, int? limit = default(int?), int? offset = default(int?), string sort = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRelatedCategoriesAsync(string categoryId, int? limit, int? offset, string sort, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedCategoryHeader>>>> GetRelatedCategoriesAsync(string categoryId, int? limit = default(int?), int? offset = default(int?), string sort = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRelatedTerms(string termId, int? limit, int? offset, string sort, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader>>> GetRelatedTerms(string termId, int? limit = default(int?), int? offset = default(int?), string sort = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRelatedTermsAsync(string termId, int? limit, int? offset, string sort, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader>>>> GetRelatedTermsAsync(string termId, int? limit = default(int?), int? offset = default(int?), string sort = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTerm(string termId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm> GetTerm(string termId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTermAsync(string termId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm>> GetTermAsync(string termId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTermHeaders(string glossaryId, int? limit, int? offset, string sort, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader>> GetTermHeaders(string glossaryId, int? limit = default(int?), int? offset = default(int?), string sort = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTermHeadersAsync(string glossaryId, int? limit, int? offset, string sort, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasRelatedTermHeader>>> GetTermHeadersAsync(string glossaryId, int? limit = default(int?), int? offset = default(int?), string sort = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTerms(string glossaryId, int? limit, int? offset, string sort, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm>> GetTerms(string glossaryId, int? limit = default(int?), int? offset = default(int?), string sort = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTermsAsync(string glossaryId, int? limit, int? offset, string sort, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm>>> GetTermsAsync(string glossaryId, int? limit = default(int?), int? offset = default(int?), string sort = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PartialUpdate(string glossaryId, Azure.Core.RequestContent content, bool? ignoreTermsAndCategories = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossary> PartialUpdate(string glossaryId, System.Collections.Generic.IDictionary<string, string> body, bool? ignoreTermsAndCategories = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PartialUpdateAsync(string glossaryId, Azure.Core.RequestContent content, bool? ignoreTermsAndCategories = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossary>> PartialUpdateAsync(string glossaryId, System.Collections.Generic.IDictionary<string, string> body, bool? ignoreTermsAndCategories = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PartialUpdateCategory(string categoryId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory> PartialUpdateCategory(string categoryId, System.Collections.Generic.IDictionary<string, string> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PartialUpdateCategoryAsync(string categoryId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory>> PartialUpdateCategoryAsync(string categoryId, System.Collections.Generic.IDictionary<string, string> body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PartialUpdateTerm(string termId, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm> PartialUpdateTerm(string termId, System.Collections.Generic.IDictionary<string, string> body, bool? includeTermHierarchy = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PartialUpdateTermAsync(string termId, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm>> PartialUpdateTermAsync(string termId, System.Collections.Generic.IDictionary<string, string> body, bool? includeTermHierarchy = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossary> Update(string glossaryId, Azure.Analytics.Purview.DataMap.AtlasGlossary body, bool? ignoreTermsAndCategories = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(string glossaryId, Azure.Core.RequestContent content, bool? ignoreTermsAndCategories = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossary>> UpdateAsync(string glossaryId, Azure.Analytics.Purview.DataMap.AtlasGlossary body, bool? ignoreTermsAndCategories = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string glossaryId, Azure.Core.RequestContent content, bool? ignoreTermsAndCategories = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory> UpdateCategory(string categoryId, Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateCategory(string categoryId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory>> UpdateCategoryAsync(string categoryId, Azure.Analytics.Purview.DataMap.AtlasGlossaryCategory body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateCategoryAsync(string categoryId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm> UpdateTerm(string termId, Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm body, bool? includeTermHierarchy = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateTerm(string termId, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm>> UpdateTermAsync(string termId, Azure.Analytics.Purview.DataMap.AtlasGlossaryTerm body, bool? includeTermHierarchy = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateTermAsync(string termId, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class ImportInfo : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ImportInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ImportInfo>
    {
        internal ImportInfo() { }
        public string ChildObjectName { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.ImportStatus? ImportStatus { get { throw null; } }
        public string ParentObjectName { get { throw null; } }
        public string Remarks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.ImportInfo System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ImportInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ImportInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.ImportInfo System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ImportInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ImportInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ImportInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImportStatus : System.IEquatable<Azure.Analytics.Purview.DataMap.ImportStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImportStatus(string value) { throw null; }
        public static Azure.Analytics.Purview.DataMap.ImportStatus Failed { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.ImportStatus Success { get { throw null; } }
        public bool Equals(Azure.Analytics.Purview.DataMap.ImportStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Purview.DataMap.ImportStatus left, Azure.Analytics.Purview.DataMap.ImportStatus right) { throw null; }
        public static implicit operator Azure.Analytics.Purview.DataMap.ImportStatus (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Purview.DataMap.ImportStatus left, Azure.Analytics.Purview.DataMap.ImportStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Lineage
    {
        protected Lineage() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasLineageInfo> GetByUniqueAttribute(string typeName, Azure.Analytics.Purview.DataMap.LineageDirection direction, int? depth = default(int?), string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetByUniqueAttribute(string typeName, string direction, int? depth = default(int?), string attribute = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasLineageInfo>> GetByUniqueAttributeAsync(string typeName, Azure.Analytics.Purview.DataMap.LineageDirection direction, int? depth = default(int?), string attribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetByUniqueAttributeAsync(string typeName, string direction, int? depth = default(int?), string attribute = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasLineageInfo> GetLineage(string guid, Azure.Analytics.Purview.DataMap.LineageDirection direction, int? depth = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLineage(string guid, string direction, int? depth = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasLineageInfo>> GetLineageAsync(string guid, Azure.Analytics.Purview.DataMap.LineageDirection direction, int? depth = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLineageAsync(string guid, string direction, int? depth = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasLineageInfo> GetNextPage(string guid, Azure.Analytics.Purview.DataMap.LineageDirection direction, int? offset = default(int?), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetNextPage(string guid, string direction, int? offset = default(int?), int? limit = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasLineageInfo>> GetNextPageAsync(string guid, Azure.Analytics.Purview.DataMap.LineageDirection direction, int? offset = default(int?), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetNextPageAsync(string guid, string direction, int? offset = default(int?), int? limit = default(int?), Azure.RequestContext context = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LineageDirection : System.IEquatable<Azure.Analytics.Purview.DataMap.LineageDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LineageDirection(string value) { throw null; }
        public static Azure.Analytics.Purview.DataMap.LineageDirection Both { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.LineageDirection Input { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.LineageDirection Output { get { throw null; } }
        public bool Equals(Azure.Analytics.Purview.DataMap.LineageDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Purview.DataMap.LineageDirection left, Azure.Analytics.Purview.DataMap.LineageDirection right) { throw null; }
        public static implicit operator Azure.Analytics.Purview.DataMap.LineageDirection (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Purview.DataMap.LineageDirection left, Azure.Analytics.Purview.DataMap.LineageDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LineageRelation : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.LineageRelation>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.LineageRelation>
    {
        internal LineageRelation() { }
        public string FromEntityId { get { throw null; } }
        public string RelationshipId { get { throw null; } }
        public string ToEntityId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.LineageRelation System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.LineageRelation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.LineageRelation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.LineageRelation System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.LineageRelation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.LineageRelation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.LineageRelation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoveEntitiesConfig : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.MoveEntitiesConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.MoveEntitiesConfig>
    {
        public MoveEntitiesConfig() { }
        public System.Collections.Generic.IList<string> EntityGuids { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.MoveEntitiesConfig System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.MoveEntitiesConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.MoveEntitiesConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.MoveEntitiesConfig System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.MoveEntitiesConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.MoveEntitiesConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.MoveEntitiesConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ParentRelation : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ParentRelation>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ParentRelation>
    {
        internal ParentRelation() { }
        public string ChildEntityId { get { throw null; } }
        public string ParentEntityId { get { throw null; } }
        public string RelationshipId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.ParentRelation System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ParentRelation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ParentRelation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.ParentRelation System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ParentRelation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ParentRelation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ParentRelation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewObjectId : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.PurviewObjectId>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.PurviewObjectId>
    {
        public PurviewObjectId() { }
        public string DisplayText { get { throw null; } set { } }
        public string Guid { get { throw null; } set { } }
        public string ItemPath { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Properties { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> UniqueAttributes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.PurviewObjectId System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.PurviewObjectId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.PurviewObjectId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.PurviewObjectId System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.PurviewObjectId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.PurviewObjectId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.PurviewObjectId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryConfig : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.QueryConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.QueryConfig>
    {
        public QueryConfig() { }
        public string ContinuationToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.SearchFacetItem> Facets { get { throw null; } }
        public System.BinaryData Filter { get { throw null; } set { } }
        public string Keywords { get { throw null; } set { } }
        public int? Limit { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Orderby { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.SearchTaxonomySetting TaxonomySetting { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.QueryConfig System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.QueryConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.QueryConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.QueryConfig System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.QueryConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.QueryConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.QueryConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.QueryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.QueryResult>
    {
        internal QueryResult() { }
        public string ContinuationToken { get { throw null; } }
        public int? SearchCount { get { throw null; } }
        public bool? SearchCountApproximate { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.SearchFacetResultValue SearchFacets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.SearchResultValue> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.QueryResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.QueryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.QueryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.QueryResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.QueryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.QueryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.QueryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Relationship
    {
        protected Relationship() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasRelationship> Create(Azure.Analytics.Purview.DataMap.AtlasRelationship body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Create(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasRelationship>> CreateAsync(Azure.Analytics.Purview.DataMap.AtlasRelationship body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetRelationship(string guid, bool? extendedInfo, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasRelationshipWithExtInfo> GetRelationship(string guid, bool? extendedInfo = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRelationshipAsync(string guid, bool? extendedInfo, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasRelationshipWithExtInfo>> GetRelationshipAsync(string guid, bool? extendedInfo = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasRelationship> Update(Azure.Analytics.Purview.DataMap.AtlasRelationship body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasRelationship>> UpdateAsync(Azure.Analytics.Purview.DataMap.AtlasRelationship body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelationshipCategory : System.IEquatable<Azure.Analytics.Purview.DataMap.RelationshipCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelationshipCategory(string value) { throw null; }
        public static Azure.Analytics.Purview.DataMap.RelationshipCategory Aggregation { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.RelationshipCategory Association { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.RelationshipCategory Composition { get { throw null; } }
        public bool Equals(Azure.Analytics.Purview.DataMap.RelationshipCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Purview.DataMap.RelationshipCategory left, Azure.Analytics.Purview.DataMap.RelationshipCategory right) { throw null; }
        public static implicit operator Azure.Analytics.Purview.DataMap.RelationshipCategory (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Purview.DataMap.RelationshipCategory left, Azure.Analytics.Purview.DataMap.RelationshipCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceLink : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ResourceLink>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ResourceLink>
    {
        public ResourceLink() { }
        public string DisplayName { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.ResourceLink System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ResourceLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.ResourceLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.ResourceLink System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ResourceLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ResourceLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.ResourceLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoundingMode : System.IEquatable<Azure.Analytics.Purview.DataMap.RoundingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoundingMode(string value) { throw null; }
        public static Azure.Analytics.Purview.DataMap.RoundingMode Ceiling { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.RoundingMode Down { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.RoundingMode Floor { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.RoundingMode HalfDown { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.RoundingMode HalfEven { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.RoundingMode HalfUp { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.RoundingMode Unnecessary { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.RoundingMode Up { get { throw null; } }
        public bool Equals(Azure.Analytics.Purview.DataMap.RoundingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Purview.DataMap.RoundingMode left, Azure.Analytics.Purview.DataMap.RoundingMode right) { throw null; }
        public static implicit operator Azure.Analytics.Purview.DataMap.RoundingMode (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Purview.DataMap.RoundingMode left, Azure.Analytics.Purview.DataMap.RoundingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchFacetItem : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchFacetItem>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchFacetItem>
    {
        public SearchFacetItem() { }
        public int? Count { get { throw null; } set { } }
        public string Facet { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.SearchFacetSort Sort { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SearchFacetItem System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchFacetItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchFacetItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SearchFacetItem System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchFacetItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchFacetItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchFacetItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchFacetItemValue : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchFacetItemValue>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchFacetItemValue>
    {
        internal SearchFacetItemValue() { }
        public int? Count { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SearchFacetItemValue System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchFacetItemValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchFacetItemValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SearchFacetItemValue System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchFacetItemValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchFacetItemValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchFacetItemValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchFacetResultValue : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchFacetResultValue>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchFacetResultValue>
    {
        internal SearchFacetResultValue() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> AssetType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> Classification { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> ContactId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> ContactType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> EntityType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> GlossaryType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> Label { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> Term { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> TermStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.SearchFacetItemValue> TermTemplate { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SearchFacetResultValue System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchFacetResultValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchFacetResultValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SearchFacetResultValue System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchFacetResultValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchFacetResultValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchFacetResultValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchFacetSort : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchFacetSort>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchFacetSort>
    {
        public SearchFacetSort() { }
        public Azure.Analytics.Purview.DataMap.SearchSortOrder? Count { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.SearchSortOrder? Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SearchFacetSort System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchFacetSort>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchFacetSort>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SearchFacetSort System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchFacetSort>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchFacetSort>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchFacetSort>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchHighlights : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchHighlights>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchHighlights>
    {
        internal SearchHighlights() { }
        public System.Collections.Generic.IReadOnlyList<string> Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> EntityType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> QualifiedName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SearchHighlights System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchHighlights>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchHighlights>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SearchHighlights System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchHighlights>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchHighlights>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchHighlights>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchResultValue : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchResultValue>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchResultValue>
    {
        internal SearchResultValue() { }
        public System.Collections.Generic.IReadOnlyList<string> AssetType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Classification { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.ContactSearchResultValue> Contact { get { throw null; } }
        public long? CreateTime { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Endorsement { get { throw null; } }
        public string EntityType { get { throw null; } }
        public string Glossary { get { throw null; } }
        public string GlossaryType { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Label { get { throw null; } }
        public string LongDescription { get { throw null; } }
        public string Name { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string Owner { get { throw null; } }
        public string QualifiedName { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.SearchHighlights SearchHighlights { get { throw null; } }
        public float? SearchScore { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.TermSearchResultValue> Term { get { throw null; } }
        public string TermStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TermTemplate { get { throw null; } }
        public long? UpdateTime { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SearchResultValue System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchResultValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchResultValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SearchResultValue System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchResultValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchResultValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchResultValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchSortOrder : System.IEquatable<Azure.Analytics.Purview.DataMap.SearchSortOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchSortOrder(string value) { throw null; }
        public static Azure.Analytics.Purview.DataMap.SearchSortOrder Ascend { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.SearchSortOrder Descend { get { throw null; } }
        public bool Equals(Azure.Analytics.Purview.DataMap.SearchSortOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Purview.DataMap.SearchSortOrder left, Azure.Analytics.Purview.DataMap.SearchSortOrder right) { throw null; }
        public static implicit operator Azure.Analytics.Purview.DataMap.SearchSortOrder (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Purview.DataMap.SearchSortOrder left, Azure.Analytics.Purview.DataMap.SearchSortOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchTaxonomySetting : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchTaxonomySetting>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchTaxonomySetting>
    {
        public SearchTaxonomySetting() { }
        public System.Collections.Generic.IList<string> AssetTypes { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.SearchFacetItem Facet { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SearchTaxonomySetting System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchTaxonomySetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SearchTaxonomySetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SearchTaxonomySetting System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchTaxonomySetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchTaxonomySetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SearchTaxonomySetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StatusAtlasRelationship : System.IEquatable<Azure.Analytics.Purview.DataMap.StatusAtlasRelationship>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StatusAtlasRelationship(string value) { throw null; }
        public static Azure.Analytics.Purview.DataMap.StatusAtlasRelationship Active { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.StatusAtlasRelationship Deleted { get { throw null; } }
        public bool Equals(Azure.Analytics.Purview.DataMap.StatusAtlasRelationship other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Purview.DataMap.StatusAtlasRelationship left, Azure.Analytics.Purview.DataMap.StatusAtlasRelationship right) { throw null; }
        public static implicit operator Azure.Analytics.Purview.DataMap.StatusAtlasRelationship (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Purview.DataMap.StatusAtlasRelationship left, Azure.Analytics.Purview.DataMap.StatusAtlasRelationship right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SuggestConfig : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SuggestConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SuggestConfig>
    {
        public SuggestConfig() { }
        public System.BinaryData Filter { get { throw null; } set { } }
        public string Keywords { get { throw null; } set { } }
        public int? Limit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SuggestConfig System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SuggestConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SuggestConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SuggestConfig System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SuggestConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SuggestConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SuggestConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SuggestResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SuggestResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SuggestResult>
    {
        internal SuggestResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.SuggestResultValue> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SuggestResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SuggestResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SuggestResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SuggestResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SuggestResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SuggestResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SuggestResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SuggestResultValue : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SuggestResultValue>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SuggestResultValue>
    {
        internal SuggestResultValue() { }
        public System.Collections.Generic.IReadOnlyList<string> AssetType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Classification { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.ContactSearchResultValue> Contact { get { throw null; } }
        public long? CreateTime { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Endorsement { get { throw null; } }
        public string EntityType { get { throw null; } }
        public string Glossary { get { throw null; } }
        public string GlossaryType { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Label { get { throw null; } }
        public string LongDescription { get { throw null; } }
        public string Name { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string Owner { get { throw null; } }
        public string QualifiedName { get { throw null; } }
        public float? SearchScore { get { throw null; } }
        public string SearchText { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.TermSearchResultValue> Term { get { throw null; } }
        public string TermStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TermTemplate { get { throw null; } }
        public long? UpdateTime { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SuggestResultValue System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SuggestResultValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.SuggestResultValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.SuggestResultValue System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SuggestResultValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SuggestResultValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.SuggestResultValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TermSearchResultValue : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.TermSearchResultValue>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.TermSearchResultValue>
    {
        internal TermSearchResultValue() { }
        public string GlossaryName { get { throw null; } }
        public string Guid { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.TermSearchResultValue System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.TermSearchResultValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.TermSearchResultValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.TermSearchResultValue System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.TermSearchResultValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.TermSearchResultValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.TermSearchResultValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TermStatus : System.IEquatable<Azure.Analytics.Purview.DataMap.TermStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TermStatus(string value) { throw null; }
        public static Azure.Analytics.Purview.DataMap.TermStatus Alert { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.TermStatus Approved { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.TermStatus Draft { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.TermStatus Expired { get { throw null; } }
        public bool Equals(Azure.Analytics.Purview.DataMap.TermStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Purview.DataMap.TermStatus left, Azure.Analytics.Purview.DataMap.TermStatus right) { throw null; }
        public static implicit operator Azure.Analytics.Purview.DataMap.TermStatus (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Purview.DataMap.TermStatus left, Azure.Analytics.Purview.DataMap.TermStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TermTemplateDef : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.TermTemplateDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.TermTemplateDef>
    {
        public TermTemplateDef() { }
        public System.Collections.Generic.IList<Azure.Analytics.Purview.DataMap.AtlasAttributeDef> AttributeDefs { get { throw null; } }
        public Azure.Analytics.Purview.DataMap.TypeCategory? Category { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public long? CreateTime { get { throw null; } set { } }
        public Azure.Analytics.Purview.DataMap.AtlasDateFormat DateFormatter { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Guid { get { throw null; } set { } }
        public string LastModifiedTS { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Options { get { throw null; } }
        public string ServiceType { get { throw null; } set { } }
        public string TypeVersion { get { throw null; } set { } }
        public string UpdatedBy { get { throw null; } set { } }
        public long? UpdateTime { get { throw null; } set { } }
        public long? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.TermTemplateDef System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.TermTemplateDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.TermTemplateDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.TermTemplateDef System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.TermTemplateDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.TermTemplateDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.TermTemplateDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TimeBoundary : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.TimeBoundary>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.TimeBoundary>
    {
        public TimeBoundary() { }
        public string EndTime { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.TimeBoundary System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.TimeBoundary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Purview.DataMap.TimeBoundary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Purview.DataMap.TimeBoundary System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.TimeBoundary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.TimeBoundary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Purview.DataMap.TimeBoundary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TypeCategory : System.IEquatable<Azure.Analytics.Purview.DataMap.TypeCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TypeCategory(string value) { throw null; }
        public static Azure.Analytics.Purview.DataMap.TypeCategory Array { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.TypeCategory Classification { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.TypeCategory Entity { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.TypeCategory Enum { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.TypeCategory Map { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.TypeCategory ObjectIdType { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.TypeCategory Primitive { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.TypeCategory Relationship { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.TypeCategory Struct { get { throw null; } }
        public static Azure.Analytics.Purview.DataMap.TypeCategory TermTemplate { get { throw null; } }
        public bool Equals(Azure.Analytics.Purview.DataMap.TypeCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Purview.DataMap.TypeCategory left, Azure.Analytics.Purview.DataMap.TypeCategory right) { throw null; }
        public static implicit operator Azure.Analytics.Purview.DataMap.TypeCategory (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Purview.DataMap.TypeCategory left, Azure.Analytics.Purview.DataMap.TypeCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TypeDefinition
    {
        protected TypeDefinition() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasTypesDef> BatchCreate(Azure.Analytics.Purview.DataMap.AtlasTypesDef body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response BatchCreate(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasTypesDef>> BatchCreateAsync(Azure.Analytics.Purview.DataMap.AtlasTypesDef body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BatchCreateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response BatchDelete(Azure.Analytics.Purview.DataMap.AtlasTypesDef body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response BatchDelete(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BatchDeleteAsync(Azure.Analytics.Purview.DataMap.AtlasTypesDef body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BatchDeleteAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasTypesDef> BatchUpdate(Azure.Analytics.Purview.DataMap.AtlasTypesDef body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response BatchUpdate(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasTypesDef>> BatchUpdateAsync(Azure.Analytics.Purview.DataMap.AtlasTypesDef body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BatchUpdateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetBusinessMetadataById(string guid, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasBusinessMetadataDef> GetBusinessMetadataById(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetBusinessMetadataByIdAsync(string guid, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasBusinessMetadataDef>> GetBusinessMetadataByIdAsync(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetBusinessMetadataByName(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasBusinessMetadataDef> GetBusinessMetadataByName(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetBusinessMetadataByNameAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasBusinessMetadataDef>> GetBusinessMetadataByNameAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetById(string guid, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasTypeDef> GetById(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetByIdAsync(string guid, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasTypeDef>> GetByIdAsync(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetByName(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasTypeDef> GetByName(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetByNameAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasTypeDef>> GetByNameAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetClassificationById(string guid, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasClassificationDef> GetClassificationById(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationByIdAsync(string guid, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasClassificationDef>> GetClassificationByIdAsync(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetClassificationByName(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasClassificationDef> GetClassificationByName(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationByNameAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasClassificationDef>> GetClassificationByNameAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEntityById(string guid, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEntityDef> GetEntityById(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntityByIdAsync(string guid, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEntityDef>> GetEntityByIdAsync(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEntityByName(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEntityDef> GetEntityByName(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntityByNameAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEntityDef>> GetEntityByNameAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEnumById(string guid, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEnumDef> GetEnumById(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnumByIdAsync(string guid, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEnumDef>> GetEnumByIdAsync(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEnumByName(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEnumDef> GetEnumByName(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnumByNameAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasEnumDef>> GetEnumByNameAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasTypeDefHeader>> GetHeaders(bool? includeTermTemplate = default(bool?), Azure.Analytics.Purview.DataMap.TypeCategory? type = default(Azure.Analytics.Purview.DataMap.TypeCategory?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetHeaders(bool? includeTermTemplate, string type, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Purview.DataMap.AtlasTypeDefHeader>>> GetHeadersAsync(bool? includeTermTemplate = default(bool?), Azure.Analytics.Purview.DataMap.TypeCategory? type = default(Azure.Analytics.Purview.DataMap.TypeCategory?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetHeadersAsync(bool? includeTermTemplate, string type, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetRelationshipById(string guid, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasRelationshipDef> GetRelationshipById(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRelationshipByIdAsync(string guid, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasRelationshipDef>> GetRelationshipByIdAsync(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRelationshipByName(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasRelationshipDef> GetRelationshipByName(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRelationshipByNameAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasRelationshipDef>> GetRelationshipByNameAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetStructById(string guid, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasStructDef> GetStructById(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetStructByIdAsync(string guid, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasStructDef>> GetStructByIdAsync(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetStructByName(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasStructDef> GetStructByName(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetStructByNameAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasStructDef>> GetStructByNameAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTermTemplateById(string guid, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.TermTemplateDef> GetTermTemplateById(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTermTemplateByIdAsync(string guid, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.TermTemplateDef>> GetTermTemplateByIdAsync(string guid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTermTemplateByName(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.TermTemplateDef> GetTermTemplateByName(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTermTemplateByNameAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.TermTemplateDef>> GetTermTemplateByNameAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Purview.DataMap.AtlasTypesDef> GetTypeDefinition(bool? includeTermTemplate = default(bool?), Azure.Analytics.Purview.DataMap.TypeCategory? type = default(Azure.Analytics.Purview.DataMap.TypeCategory?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTypeDefinition(bool? includeTermTemplate, string type, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Purview.DataMap.AtlasTypesDef>> GetTypeDefinitionAsync(bool? includeTermTemplate = default(bool?), Azure.Analytics.Purview.DataMap.TypeCategory? type = default(Azure.Analytics.Purview.DataMap.TypeCategory?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTypeDefinitionAsync(bool? includeTermTemplate, string type, Azure.RequestContext context) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AnalyticsPurviewDataMapClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.DataMap.DataMapClient, Azure.Analytics.Purview.DataMap.DataMapClientOptions> AddDataMapClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.DataMap.DataMapClient, Azure.Analytics.Purview.DataMap.DataMapClientOptions> AddDataMapClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
