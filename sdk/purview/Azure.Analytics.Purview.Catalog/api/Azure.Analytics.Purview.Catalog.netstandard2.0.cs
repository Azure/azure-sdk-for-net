namespace Azure.Analytics.Purview.Catalog
{
    public partial class PurviewCatalogClient
    {
        protected PurviewCatalogClient() { }
        public PurviewCatalogClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Catalog.PurviewCatalogClientOptions options = null) { }
        public Azure.Analytics.Purview.Catalog.PurviewEntities Entities { get { throw null; } }
        public Azure.Analytics.Purview.Catalog.PurviewGlossaries Glossaries { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public Azure.Analytics.Purview.Catalog.PurviewRelationships Relationships { get { throw null; } }
        public Azure.Analytics.Purview.Catalog.PurviewTypes Types { get { throw null; } }
        public virtual Azure.Response AutoComplete(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AutoCompleteAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetLineageGraph(string guid, string direction, Azure.RequestOptions options, int? depth = default(int?), int? width = default(int?), bool? includeParent = default(bool?), bool? getDerivedLineage = default(bool?)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLineageGraphAsync(string guid, string direction, Azure.RequestOptions options, int? depth = default(int?), int? width = default(int?), bool? includeParent = default(bool?), bool? getDerivedLineage = default(bool?)) { throw null; }
        public virtual Azure.Response NextPageLineage(string guid, string direction, Azure.RequestOptions options, bool? getDerivedLineage = default(bool?), int? offset = default(int?), int? limit = default(int?)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> NextPageLineageAsync(string guid, string direction, Azure.RequestOptions options, bool? getDerivedLineage = default(bool?), int? offset = default(int?), int? limit = default(int?)) { throw null; }
        public virtual Azure.Response Search(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SearchAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response Suggest(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SuggestAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
    }
    public partial class PurviewCatalogClientOptions : Azure.Core.ClientOptions
    {
        public PurviewCatalogClientOptions(Azure.Analytics.Purview.Catalog.PurviewCatalogClientOptions.ServiceVersion version = Azure.Analytics.Purview.Catalog.PurviewCatalogClientOptions.ServiceVersion.V2021_05_01_preview) { }
        public enum ServiceVersion
        {
            V2021_05_01_preview = 1,
        }
    }
    public partial class PurviewEntities
    {
        protected PurviewEntities() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AddClassification(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddClassificationAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response AddClassifications(string guid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddClassificationsAsync(string guid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response AddClassificationsByUniqueAttribute(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddClassificationsByUniqueAttributeAsync(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response CreateOrUpdate(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateEntities(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateEntitiesAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteByGuid(string guid, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteByGuidAsync(string guid, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteByGuids(System.Collections.Generic.IEnumerable<string> guids, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteByGuidsAsync(System.Collections.Generic.IEnumerable<string> guids, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteByUniqueAttribute(string typeName, string attrQualifiedName = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteByUniqueAttributeAsync(string typeName, string attrQualifiedName = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteClassification(string guid, string classificationName, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteClassificationAsync(string guid, string classificationName, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteClassificationByUniqueAttribute(string typeName, string classificationName, string attrQualifiedName = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteClassificationByUniqueAttributeAsync(string typeName, string classificationName, string attrQualifiedName = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetByGuid(string guid, Azure.RequestOptions options, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetByGuidAsync(string guid, Azure.RequestOptions options, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?)) { throw null; }
        public virtual Azure.Response GetByGuids(System.Collections.Generic.IEnumerable<string> guids, Azure.RequestOptions options, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), System.Collections.Generic.IEnumerable<string> excludeRelationshipTypes = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetByGuidsAsync(System.Collections.Generic.IEnumerable<string> guids, Azure.RequestOptions options, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), System.Collections.Generic.IEnumerable<string> excludeRelationshipTypes = null) { throw null; }
        public virtual Azure.Response GetByUniqueAttributes(string typeName, Azure.RequestOptions options, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), string attrQualifiedName = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetByUniqueAttributesAsync(string typeName, Azure.RequestOptions options, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), string attrQualifiedName = null) { throw null; }
        public virtual Azure.Response GetClassification(string guid, string classificationName, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationAsync(string guid, string classificationName, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetClassifications(string guid, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationsAsync(string guid, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetEntitiesByUniqueAttributes(string typeName, Azure.RequestOptions options, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), string attrNQualifiedName = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntitiesByUniqueAttributesAsync(string typeName, Azure.RequestOptions options, bool? minExtInfo = default(bool?), bool? ignoreRelationships = default(bool?), string attrNQualifiedName = null) { throw null; }
        public virtual Azure.Response GetHeader(string guid, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetHeaderAsync(string guid, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response PartialUpdateEntityAttributeByGuid(string guid, string name, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PartialUpdateEntityAttributeByGuidAsync(string guid, string name, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response PartialUpdateEntityByUniqueAttributes(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PartialUpdateEntityByUniqueAttributesAsync(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response SetClassifications(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetClassificationsAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response UpdateClassifications(string guid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateClassificationsAsync(string guid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response UpdateClassificationsByUniqueAttribute(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateClassificationsByUniqueAttributeAsync(string typeName, Azure.Core.RequestContent content, string attrQualifiedName = null, Azure.RequestOptions options = null) { throw null; }
    }
    public partial class PurviewGlossaries
    {
        protected PurviewGlossaries() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AssignTermToEntities(string termGuid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AssignTermToEntitiesAsync(string termGuid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response CreateGlossary(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateGlossaryAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response CreateGlossaryCategories(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateGlossaryCategoriesAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response CreateGlossaryCategory(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateGlossaryCategoryAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response CreateGlossaryTerm(Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateGlossaryTermAsync(Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response CreateGlossaryTerms(Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateGlossaryTermsAsync(Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteGlossary(string glossaryGuid, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGlossaryAsync(string glossaryGuid, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteGlossaryCategory(string categoryGuid, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGlossaryCategoryAsync(string categoryGuid, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteGlossaryTerm(string termGuid, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGlossaryTermAsync(string termGuid, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteTermAssignmentFromEntities(string termGuid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTermAssignmentFromEntitiesAsync(string termGuid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response ExportGlossaryTermsAsCsv(string glossaryGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExportGlossaryTermsAsCsvAsync(string glossaryGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetCategoryTerms(string categoryGuid, Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCategoryTermsAsync(string categoryGuid, Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual Azure.Response GetDetailedGlossary(string glossaryGuid, Azure.RequestOptions options, bool? includeTermHierarchy = default(bool?)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDetailedGlossaryAsync(string glossaryGuid, Azure.RequestOptions options, bool? includeTermHierarchy = default(bool?)) { throw null; }
        public virtual Azure.Response GetEntitiesAssignedWithTerm(string termGuid, Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntitiesAssignedWithTermAsync(string termGuid, Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual Azure.Response GetGlossaries(Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossariesAsync(Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual Azure.Response GetGlossary(string glossaryGuid, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossaryAsync(string glossaryGuid, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetGlossaryCategories(string glossaryGuid, Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossaryCategoriesAsync(string glossaryGuid, Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual Azure.Response GetGlossaryCategoriesHeaders(string glossaryGuid, Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossaryCategoriesHeadersAsync(string glossaryGuid, Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual Azure.Response GetGlossaryCategory(string categoryGuid, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossaryCategoryAsync(string categoryGuid, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetGlossaryTerm(string termGuid, Azure.RequestOptions options, bool? includeTermHierarchy = default(bool?)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossaryTermAsync(string termGuid, Azure.RequestOptions options, bool? includeTermHierarchy = default(bool?)) { throw null; }
        public virtual Azure.Response GetGlossaryTermHeaders(string glossaryGuid, Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossaryTermHeadersAsync(string glossaryGuid, Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual Azure.Response GetGlossaryTerms(string glossaryGuid, Azure.RequestOptions options, bool? includeTermHierarchy = default(bool?), int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGlossaryTermsAsync(string glossaryGuid, Azure.RequestOptions options, bool? includeTermHierarchy = default(bool?), int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual Azure.Response GetImportCsvOperationStatus(string operationGuid, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetImportCsvOperationStatusAsync(string operationGuid, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetRelatedCategories(string categoryGuid, Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRelatedCategoriesAsync(string categoryGuid, Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual Azure.Response GetRelatedTerms(string termGuid, Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRelatedTermsAsync(string termGuid, Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), string sort = null) { throw null; }
        public virtual Azure.Response GetTermsByGlossaryName(string glossaryName, Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), bool? includeTermHierarchy = default(bool?)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTermsByGlossaryNameAsync(string glossaryName, Azure.RequestOptions options, int? limit = default(int?), int? offset = default(int?), bool? includeTermHierarchy = default(bool?)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> ImportGlossaryTermsViaCsv(string glossaryGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ImportGlossaryTermsViaCsvAsync(string glossaryGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> ImportGlossaryTermsViaCsvByGlossaryName(string glossaryName, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ImportGlossaryTermsViaCsvByGlossaryNameAsync(string glossaryName, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response PartialUpdateGlossary(string glossaryGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PartialUpdateGlossaryAsync(string glossaryGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response PartialUpdateGlossaryCategory(string categoryGuid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PartialUpdateGlossaryCategoryAsync(string categoryGuid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response PartialUpdateGlossaryTerm(string termGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PartialUpdateGlossaryTermAsync(string termGuid, Azure.Core.RequestContent content, bool? includeTermHierarchy = default(bool?), Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response RemoveTermAssignmentFromEntities(string termGuid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveTermAssignmentFromEntitiesAsync(string termGuid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response UpdateGlossary(string glossaryGuid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateGlossaryAsync(string glossaryGuid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response UpdateGlossaryCategory(string categoryGuid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateGlossaryCategoryAsync(string categoryGuid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response UpdateGlossaryTerm(string termGuid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateGlossaryTermAsync(string termGuid, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
    }
    public partial class PurviewRelationships
    {
        protected PurviewRelationships() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Create(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response Delete(string guid, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string guid, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response Get(string guid, Azure.RequestOptions options, bool? extendedInfo = default(bool?)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string guid, Azure.RequestOptions options, bool? extendedInfo = default(bool?)) { throw null; }
        public virtual Azure.Response Update(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
    }
    public partial class PurviewTypes
    {
        protected PurviewTypes() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateTypeDefinitions(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateTypeDefinitionsAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteTypeByName(string name, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTypeByNameAsync(string name, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteTypeDefinitions(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTypeDefinitionsAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetAllTypeDefinitions(Azure.RequestOptions options, bool? includeTermTemplate = default(bool?), string type = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAllTypeDefinitionsAsync(Azure.RequestOptions options, bool? includeTermTemplate = default(bool?), string type = null) { throw null; }
        public virtual Azure.Response GetClassificationDefByGuid(string guid, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationDefByGuidAsync(string guid, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetClassificationDefByName(string name, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationDefByNameAsync(string name, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetEntityDefinitionByGuid(string guid, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntityDefinitionByGuidAsync(string guid, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetEntityDefinitionByName(string name, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntityDefinitionByNameAsync(string name, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetEnumDefByGuid(string guid, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnumDefByGuidAsync(string guid, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetEnumDefByName(string name, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnumDefByNameAsync(string name, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetRelationshipDefByGuid(string guid, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRelationshipDefByGuidAsync(string guid, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetRelationshipDefByName(string name, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRelationshipDefByNameAsync(string name, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetStructDefByGuid(string guid, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetStructDefByGuidAsync(string guid, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetStructDefByName(string name, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetStructDefByNameAsync(string name, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetTermTemplateDefByGuid(string guid, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTermTemplateDefByGuidAsync(string guid, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetTermTemplateDefByName(string name, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTermTemplateDefByNameAsync(string name, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetTypeDefinitionByGuid(string guid, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTypeDefinitionByGuidAsync(string guid, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetTypeDefinitionByName(string name, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTypeDefinitionByNameAsync(string name, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetTypeDefinitionHeaders(Azure.RequestOptions options, bool? includeTermTemplate = default(bool?), string type = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTypeDefinitionHeadersAsync(Azure.RequestOptions options, bool? includeTermTemplate = default(bool?), string type = null) { throw null; }
        public virtual Azure.Response UpdateAtlasTypeDefinitions(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAtlasTypeDefinitionsAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
    }
}
