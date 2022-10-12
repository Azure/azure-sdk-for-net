namespace Azure.Analytics.Purview.Share
{
    public partial class AcceptedSentSharesClient
    {
        protected AcceptedSentSharesClient() { }
        public AcceptedSentSharesClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public AcceptedSentSharesClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetAcceptedSentShare(string sentShareName, string acceptedSentShareName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAcceptedSentShareAsync(string sentShareName, string acceptedSentShareName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAcceptedSentShares(string sentShareName, string skipToken = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAcceptedSentSharesAsync(string sentShareName, string skipToken = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Reinstate(Azure.WaitUntil waitUntil, string sentShareName, string acceptedSentShareName, Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ReinstateAsync(Azure.WaitUntil waitUntil, string sentShareName, string acceptedSentShareName, Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Revoke(Azure.WaitUntil waitUntil, string sentShareName, string acceptedSentShareName, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> RevokeAsync(Azure.WaitUntil waitUntil, string sentShareName, string acceptedSentShareName, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> UpdateExpiration(Azure.WaitUntil waitUntil, string sentShareName, string acceptedSentShareName, Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> UpdateExpirationAsync(Azure.WaitUntil waitUntil, string sentShareName, string acceptedSentShareName, Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class AssetMappingsClient
    {
        protected AssetMappingsClient() { }
        public AssetMappingsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public AssetMappingsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> Create(Azure.WaitUntil waitUntil, string receivedShareName, string assetMappingName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateAsync(Azure.WaitUntil waitUntil, string receivedShareName, string assetMappingName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Delete(Azure.WaitUntil waitUntil, string receivedShareName, string assetMappingName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteAsync(Azure.WaitUntil waitUntil, string receivedShareName, string assetMappingName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAssetMapping(string receivedShareName, string assetMappingName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssetMappingAsync(string receivedShareName, string assetMappingName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAssetMappings(string receivedShareName, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAssetMappingsAsync(string receivedShareName, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class AssetsClient
    {
        protected AssetsClient() { }
        public AssetsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public AssetsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> Create(Azure.WaitUntil waitUntil, string sentShareName, string assetName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateAsync(Azure.WaitUntil waitUntil, string sentShareName, string assetName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Delete(Azure.WaitUntil waitUntil, string sentShareName, string assetName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteAsync(Azure.WaitUntil waitUntil, string sentShareName, string assetName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAsset(string sentShareName, string assetName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssetAsync(string sentShareName, string assetName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAssets(string sentShareName, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAssetsAsync(string sentShareName, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ClassificationRulesClient
    {
        protected ClassificationRulesClient() { }
        public ClassificationRulesClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public ClassificationRulesClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(string classificationRuleName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(string classificationRuleName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(string classificationRuleName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string classificationRuleName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetClassificationRule(string classificationRuleName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationRuleAsync(string classificationRuleName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetClassificationRules(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetClassificationRulesAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetVersionsByClassificationRuleName(string classificationRuleName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetVersionsByClassificationRuleNameAsync(string classificationRuleName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response TagClassificationVersion(string classificationRuleName, int classificationRuleVersion, string action, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TagClassificationVersionAsync(string classificationRuleName, int classificationRuleVersion, string action, Azure.RequestContext context = null) { throw null; }
    }
    public partial class CollectionClient
    {
        protected CollectionClient() { }
        public CollectionClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public CollectionClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(string collection, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(string collection, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateBulk(string collection, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateBulkAsync(string collection, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response MoveEntitiesToCollection(string collection, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> MoveEntitiesToCollectionAsync(string collection, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class DataSourcesClient
    {
        protected DataSourcesClient() { }
        public DataSourcesClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public DataSourcesClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(string dataSourceName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(string dataSourceName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(string dataSourceName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string dataSourceName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDataSource(string dataSourceName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDataSourceAsync(string dataSourceName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDataSources(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDataSourcesAsync(Azure.RequestContext context = null) { throw null; }
    }
    public partial class DiscoveryClient
    {
        protected DiscoveryClient() { }
        public DiscoveryClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public DiscoveryClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AutoComplete(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AutoCompleteAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Browse(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BrowseAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Query(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> QueryAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Suggest(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SuggestAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class EmailRegistrationClient
    {
        protected EmailRegistrationClient() { }
        public EmailRegistrationClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public EmailRegistrationClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Activate(Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ActivateAsync(Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Register(string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegisterAsync(string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class EntityClient
    {
        protected EntityClient() { }
        public EntityClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public EntityClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AddClassification(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddClassificationAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddClassifications(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddClassificationsAsync(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddClassificationsByUniqueAttribute(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddClassificationsByUniqueAttributeAsync(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddLabel(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddLabelAsync(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddLabelsByUniqueAttribute(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddLabelsByUniqueAttributeAsync(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddOrUpdateBusinessMetadata(string guid, Azure.Core.RequestContent content, bool? isOverwrite = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddOrUpdateBusinessMetadataAsync(string guid, Azure.Core.RequestContent content, bool? isOverwrite = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddOrUpdateBusinessMetadataAttributes(string guid, string bmName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddOrUpdateBusinessMetadataAttributesAsync(string guid, string bmName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdate(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateEntities(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateEntitiesAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteBusinessMetadata(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteBusinessMetadataAsync(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteBusinessMetadataAttributes(string guid, string bmName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteBusinessMetadataAttributesAsync(string guid, string bmName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteByGuid(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteByGuidAsync(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteByGuids(System.Collections.Generic.IEnumerable<string> guids, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteByGuidsAsync(System.Collections.Generic.IEnumerable<string> guids, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteByUniqueAttribute(string typeName, string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteByUniqueAttributeAsync(string typeName, string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteClassification(string guid, string classificationName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteClassificationAsync(string guid, string classificationName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteClassificationByUniqueAttribute(string typeName, string classificationName, string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteClassificationByUniqueAttributeAsync(string typeName, string classificationName, string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteLabels(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteLabelsAsync(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteLabelsByUniqueAttribute(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteLabelsByUniqueAttributeAsync(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetByGuid(string guid, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetByGuidAsync(string guid, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetByUniqueAttributes(string typeName, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetByUniqueAttributesAsync(string typeName, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetClassification(string guid, string classificationName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationAsync(string guid, string classificationName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetClassifications(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationsAsync(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEntitiesByGuids(System.Collections.Generic.IEnumerable<string> guids, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), System.Collections.Generic.IEnumerable<string> excludeRelationshipTypes = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntitiesByGuidsAsync(System.Collections.Generic.IEnumerable<string> guids, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), System.Collections.Generic.IEnumerable<string> excludeRelationshipTypes = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEntitiesByUniqueAttributes(string typeName, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), string attrNQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntitiesByUniqueAttributesAsync(string typeName, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), string attrNQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetHeader(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetHeaderAsync(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSampleBusinessMetadataTemplate(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSampleBusinessMetadataTemplateAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ImportBusinessMetadata(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ImportBusinessMetadataAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response PartialUpdateEntityAttributeByGuid(string guid, string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PartialUpdateEntityAttributeByGuidAsync(string guid, string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response PartialUpdateEntityByUniqueAttributes(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PartialUpdateEntityByUniqueAttributesAsync(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SetClassifications(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetClassificationsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SetLabels(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetLabelsAsync(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SetLabelsByUniqueAttribute(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetLabelsByUniqueAttributeAsync(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateClassifications(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateClassificationsAsync(string guid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateClassificationsByUniqueAttribute(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateClassificationsByUniqueAttributeAsync(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class FiltersClient
    {
        protected FiltersClient() { }
        public FiltersClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public FiltersClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(string dataSourceName, string scanName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(string dataSourceName, string scanName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetFilter(string dataSourceName, string scanName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFilterAsync(string dataSourceName, string scanName, Azure.RequestContext context = null) { throw null; }
    }
    public partial class GlossaryClient
    {
        protected GlossaryClient() { }
        public GlossaryClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public GlossaryClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AssignTermToEntities(string termGuid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AssignTermToEntitiesAsync(string termGuid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateGlossary(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateGlossaryAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateGlossaryCategories(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateGlossaryCategoriesAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateGlossaryCategory(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateGlossaryCategoryAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateGlossaryTerm(Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateGlossaryTermAsync(Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateGlossaryTerms(Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateGlossaryTermsAsync(Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteGlossary(string glossaryGuid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGlossaryAsync(string glossaryGuid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteGlossaryCategory(string categoryGuid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGlossaryCategoryAsync(string categoryGuid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteGlossaryTerm(string termGuid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGlossaryTermAsync(string termGuid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTermAssignmentFromEntities(string termGuid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTermAssignmentFromEntitiesAsync(string termGuid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ExportGlossaryTermsAsCsv(string glossaryGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExportGlossaryTermsAsCsvAsync(string glossaryGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCategoryTerms(string categoryGuid, int? limit = default(int?), int? offset = default(int?), string sort = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCategoryTermsAsync(string categoryGuid, int? limit = default(int?), int? offset = default(int?), string sort = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDetailedGlossary(string glossaryGuid, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDetailedGlossaryAsync(string glossaryGuid, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEntitiesAssignedWithTerm(string termGuid, int? limit = default(int?), int? offset = default(int?), string sort = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntitiesAssignedWithTermAsync(string termGuid, int? limit = default(int?), int? offset = default(int?), string sort = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetGlossaries(int? limit = default(int?), int? offset = default(int?), string sort = null, bool? ignoreTermsAndCategories = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossariesAsync(int? limit = default(int?), int? offset = default(int?), string sort = null, bool? ignoreTermsAndCategories = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetGlossary(string glossaryGuid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossaryAsync(string glossaryGuid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetGlossaryCategories(string glossaryGuid, int? limit = default(int?), int? offset = default(int?), string sort = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossaryCategoriesAsync(string glossaryGuid, int? limit = default(int?), int? offset = default(int?), string sort = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetGlossaryCategoriesHeaders(string glossaryGuid, int? limit = default(int?), int? offset = default(int?), string sort = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossaryCategoriesHeadersAsync(string glossaryGuid, int? limit = default(int?), int? offset = default(int?), string sort = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetGlossaryCategory(string categoryGuid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossaryCategoryAsync(string categoryGuid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetGlossaryTerm(string termGuid, bool? includeTermHierarchy = default(bool?), System.Collections.Generic.IEnumerable<string> excludeRelationshipTypeList = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossaryTermAsync(string termGuid, bool? includeTermHierarchy = default(bool?), System.Collections.Generic.IEnumerable<string> excludeRelationshipTypeList = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetGlossaryTermHeaders(string glossaryGuid, int? limit = default(int?), int? offset = default(int?), string sort = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossaryTermHeadersAsync(string glossaryGuid, int? limit = default(int?), int? offset = default(int?), string sort = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetGlossaryTerms(string glossaryGuid, bool? includeTermHierarchy = default(bool?), int? limit = default(int?), int? offset = default(int?), string sort = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossaryTermsAsync(string glossaryGuid, bool? includeTermHierarchy = default(bool?), int? limit = default(int?), int? offset = default(int?), string sort = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetImportCsvOperationStatus(string operationGuid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetImportCsvOperationStatusAsync(string operationGuid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetRelatedCategories(string categoryGuid, int? limit = default(int?), int? offset = default(int?), string sort = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRelatedCategoriesAsync(string categoryGuid, int? limit = default(int?), int? offset = default(int?), string sort = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetRelatedTerms(string termGuid, int? limit = default(int?), int? offset = default(int?), string sort = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRelatedTermsAsync(string termGuid, int? limit = default(int?), int? offset = default(int?), string sort = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTermsByGlossaryName(string glossaryName, int? limit = default(int?), int? offset = default(int?), bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTermsByGlossaryNameAsync(string glossaryName, int? limit = default(int?), int? offset = default(int?), bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> ImportGlossaryTermsViaCsv(Azure.WaitUntil waitUntil, string glossaryGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ImportGlossaryTermsViaCsvAsync(Azure.WaitUntil waitUntil, string glossaryGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> ImportGlossaryTermsViaCsvByGlossaryName(Azure.WaitUntil waitUntil, string glossaryName, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ImportGlossaryTermsViaCsvByGlossaryNameAsync(Azure.WaitUntil waitUntil, string glossaryName, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response PartialUpdateGlossary(string glossaryGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PartialUpdateGlossaryAsync(string glossaryGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response PartialUpdateGlossaryCategory(string categoryGuid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PartialUpdateGlossaryCategoryAsync(string categoryGuid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response PartialUpdateGlossaryTerm(string termGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PartialUpdateGlossaryTermAsync(string termGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RemoveTermAssignmentFromEntities(string termGuid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveTermAssignmentFromEntitiesAsync(string termGuid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateGlossary(string glossaryGuid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateGlossaryAsync(string glossaryGuid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateGlossaryCategory(string categoryGuid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateGlossaryCategoryAsync(string categoryGuid, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateGlossaryTerm(string termGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateGlossaryTermAsync(string termGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class KeyVaultConnectionsClient
    {
        protected KeyVaultConnectionsClient() { }
        public KeyVaultConnectionsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public KeyVaultConnectionsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Create(string keyVaultName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(string keyVaultName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(string keyVaultName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string keyVaultName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetKeyVaultConnection(string keyVaultName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetKeyVaultConnectionAsync(string keyVaultName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetKeyVaultConnections(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetKeyVaultConnectionsAsync(Azure.RequestContext context = null) { throw null; }
    }
    public partial class LineageClient
    {
        protected LineageClient() { }
        public LineageClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public LineageClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetLineageByUniqueAttribute(string typeName, string direction, int? depth = default(int?), int? width = default(int?), bool? includeParent = default(bool?), bool? getDerivedLineage = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLineageByUniqueAttributeAsync(string typeName, string direction, int? depth = default(int?), int? width = default(int?), bool? includeParent = default(bool?), bool? getDerivedLineage = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLineageGraph(string guid, string direction, int? depth = default(int?), int? width = default(int?), bool? includeParent = default(bool?), bool? getDerivedLineage = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLineageGraphAsync(string guid, string direction, int? depth = default(int?), int? width = default(int?), bool? includeParent = default(bool?), bool? getDerivedLineage = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response NextPageLineage(string guid, string direction, bool? getDerivedLineage = default(bool?), int? offset = default(int?), int? limit = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> NextPageLineageAsync(string guid, string direction, bool? getDerivedLineage = default(bool?), int? offset = default(int?), int? limit = default(int?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class MetadataPolicyClient
    {
        protected MetadataPolicyClient() { }
        public MetadataPolicyClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public MetadataPolicyClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetMetadataPolicies(string collectionName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetMetadataPoliciesAsync(string collectionName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetMetadataPolicy(string policyId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMetadataPolicyAsync(string policyId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Update(string policyId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string policyId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class MetadataRolesClient
    {
        protected MetadataRolesClient() { }
        public MetadataRolesClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public MetadataRolesClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetMetadataRoles(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetMetadataRolesAsync(Azure.RequestContext context = null) { throw null; }
    }
    public partial class PurviewShareClientOptions : Azure.Core.ClientOptions
    {
        public PurviewShareClientOptions(Azure.Analytics.Purview.Share.PurviewShareClientOptions.ServiceVersion version = Azure.Analytics.Purview.Share.PurviewShareClientOptions.ServiceVersion.V2022_03_01_Preview) { }
        public enum ServiceVersion
        {
            V2018_12_01_Preview = 1,
            V2021_07_01_Preview = 2,
            V2021_09_01_Preview = 3,
            V2022_03_01_Preview = 4,
        }
    }
    public partial class ReceivedAssetsClient
    {
        protected ReceivedAssetsClient() { }
        public ReceivedAssetsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public ReceivedAssetsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetReceivedAssets(string receivedShareName, string skipToken = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetReceivedAssetsAsync(string receivedShareName, string skipToken = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ReceivedInvitationsClient
    {
        protected ReceivedInvitationsClient() { }
        public ReceivedInvitationsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public ReceivedInvitationsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetReceivedInvitation(string receivedInvitationName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReceivedInvitationAsync(string receivedInvitationName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetReceivedInvitations(string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetReceivedInvitationsAsync(string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Reject(string receivedInvitationName, Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectAsync(string receivedInvitationName, Azure.Core.RequestContent content, string repeatabilityRequestId = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ReceivedSharesClient
    {
        protected ReceivedSharesClient() { }
        public ReceivedSharesClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public ReceivedSharesClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Create(string receivedShareName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(string receivedShareName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Delete(Azure.WaitUntil waitUntil, string receivedShareName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteAsync(Azure.WaitUntil waitUntil, string receivedShareName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetReceivedShare(string receivedShareName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReceivedShareAsync(string receivedShareName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetReceivedShares(string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetReceivedSharesAsync(string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class RelationshipClient
    {
        protected RelationshipClient() { }
        public RelationshipClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public RelationshipClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Create(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetRelationship(string guid, bool? extendedInfo = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRelationshipAsync(string guid, bool? extendedInfo = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Update(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ScanResultClient
    {
        protected ScanResultClient() { }
        public ScanResultClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public ScanResultClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelScan(string dataSourceName, string scanName, string runId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelScanAsync(string dataSourceName, string scanName, string runId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetScanHistories(string dataSourceName, string scanName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetScanHistoriesAsync(string dataSourceName, string scanName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RunScan(string dataSourceName, string scanName, string runId, string scanLevel = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunScanAsync(string dataSourceName, string scanName, string runId, string scanLevel = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ScanRulesetsClient
    {
        protected ScanRulesetsClient() { }
        public ScanRulesetsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public ScanRulesetsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(string scanRulesetName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(string scanRulesetName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(string scanRulesetName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string scanRulesetName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetScanRuleset(string scanRulesetName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScanRulesetAsync(string scanRulesetName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetScanRulesets(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetScanRulesetsAsync(Azure.RequestContext context = null) { throw null; }
    }
    public partial class ScansClient
    {
        protected ScansClient() { }
        public ScansClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public ScansClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(string dataSourceName, string scanName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(string dataSourceName, string scanName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(string dataSourceName, string scanName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string dataSourceName, string scanName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetScan(string dataSourceName, string scanName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScanAsync(string dataSourceName, string scanName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetScansByDataSource(string dataSourceName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetScansByDataSourceAsync(string dataSourceName, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SentShareInvitationsClient
    {
        protected SentShareInvitationsClient() { }
        public SentShareInvitationsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public SentShareInvitationsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(string sentShareName, string sentShareInvitationName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(string sentShareName, string sentShareInvitationName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(string sentShareName, string sentShareInvitationName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string sentShareName, string sentShareInvitationName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSentShareInvitation(string sentShareName, string sentShareInvitationName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSentShareInvitationAsync(string sentShareName, string sentShareInvitationName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSentShareInvitations(string sentShareName, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSentShareInvitationsAsync(string sentShareName, string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SentSharesClient
    {
        protected SentSharesClient() { }
        public SentSharesClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public SentSharesClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(string sentShareName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(string sentShareName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Delete(Azure.WaitUntil waitUntil, string sentShareName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteAsync(Azure.WaitUntil waitUntil, string sentShareName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSentShare(string sentShareName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSentShareAsync(string sentShareName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSentShares(string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSentSharesAsync(string skipToken = null, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SystemScanRulesetsClient
    {
        protected SystemScanRulesetsClient() { }
        public SystemScanRulesetsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public SystemScanRulesetsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetByVersion(int version, string dataSourceType = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetByVersionAsync(int version, string dataSourceType = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLatest(string dataSourceType = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLatestAsync(string dataSourceType = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSystemScanRuleset(string dataSourceType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSystemScanRulesetAsync(string dataSourceType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSystemScanRulesets(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSystemScanRulesetsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetVersionsByDataSource(string dataSourceType = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetVersionsByDataSourceAsync(string dataSourceType = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class TriggersClient
    {
        protected TriggersClient() { }
        public TriggersClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public TriggersClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateTrigger(string dataSourceName, string scanName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateTriggerAsync(string dataSourceName, string scanName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTrigger(string dataSourceName, string scanName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTriggerAsync(string dataSourceName, string scanName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTrigger(string dataSourceName, string scanName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTriggerAsync(string dataSourceName, string scanName, Azure.RequestContext context = null) { throw null; }
    }
    public partial class TypesClient
    {
        protected TypesClient() { }
        public TypesClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public TypesClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Share.PurviewShareClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateTypeDefinitions(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateTypeDefinitionsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTypeByName(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTypeByNameAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTypeDefinitions(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTypeDefinitionsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAllTypeDefinitions(bool? includeTermTemplate = default(bool?), string type = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAllTypeDefinitionsAsync(bool? includeTermTemplate = default(bool?), string type = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetBusinessMetadataDefByGuid(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetBusinessMetadataDefByGuidAsync(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetBusinessMetadataDefByName(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetBusinessMetadataDefByNameAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetClassificationDefByGuid(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationDefByGuidAsync(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetClassificationDefByName(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationDefByNameAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEntityDefinitionByGuid(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntityDefinitionByGuidAsync(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEntityDefinitionByName(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntityDefinitionByNameAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEnumDefByGuid(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnumDefByGuidAsync(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEnumDefByName(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnumDefByNameAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetRelationshipDefByGuid(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRelationshipDefByGuidAsync(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetRelationshipDefByName(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRelationshipDefByNameAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetStructDefByGuid(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetStructDefByGuidAsync(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetStructDefByName(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetStructDefByNameAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTermTemplateDefByGuid(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTermTemplateDefByGuidAsync(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTermTemplateDefByName(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTermTemplateDefByNameAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTypeDefinitionByGuid(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTypeDefinitionByGuidAsync(string guid, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTypeDefinitionByName(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTypeDefinitionByNameAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTypeDefinitionHeaders(bool? includeTermTemplate = default(bool?), string type = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTypeDefinitionHeadersAsync(bool? includeTermTemplate = default(bool?), string type = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateAtlasTypeDefinitions(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAtlasTypeDefinitionsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
}
