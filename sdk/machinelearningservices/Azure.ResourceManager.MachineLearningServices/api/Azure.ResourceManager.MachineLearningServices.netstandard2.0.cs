namespace Azure.ResourceManager.MachineLearningServices
{
    public partial class AzureMachineLearningWorkspacesOperations
    {
        protected AzureMachineLearningWorkspacesOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.WorkspaceSku> ListSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.WorkspaceSku> ListSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeContainersOperations
    {
        protected CodeContainersOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.CodeContainerResource> CreateOrUpdate(string name, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.CodeContainerResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.CodeContainerResource>> CreateOrUpdateAsync(string name, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.CodeContainerResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.CodeContainerResource> Get(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.CodeContainerResource>> GetAsync(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.CodeContainerResource> List(string resourceGroupName, string workspaceName, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.CodeContainerResource> ListAsync(string resourceGroupName, string workspaceName, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeVersionsOperations
    {
        protected CodeVersionsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.CodeVersionResource> CreateOrUpdate(string name, string version, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.CodeVersionResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.CodeVersionResource>> CreateOrUpdateAsync(string name, string version, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.CodeVersionResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string name, string version, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string name, string version, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.CodeVersionResource> Get(string name, string version, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.CodeVersionResource>> GetAsync(string name, string version, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.CodeVersionResource> List(string name, string resourceGroupName, string workspaceName, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.CodeVersionResource> ListAsync(string name, string resourceGroupName, string workspaceName, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataContainersOperations
    {
        protected DataContainersOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DataContainerResource> CreateOrUpdate(string name, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.DataContainerResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DataContainerResource>> CreateOrUpdateAsync(string name, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.DataContainerResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DataContainerResource> Get(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DataContainerResource>> GetAsync(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.DataContainerResource> List(string resourceGroupName, string workspaceName, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.DataContainerResource> ListAsync(string resourceGroupName, string workspaceName, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatastoresOperations
    {
        protected DatastoresOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DatastorePropertiesResource> CreateOrUpdate(string name, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.DatastorePropertiesResource body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DatastorePropertiesResource>> CreateOrUpdateAsync(string name, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.DatastorePropertiesResource body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DatastorePropertiesResource> Get(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DatastorePropertiesResource>> GetAsync(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.DatastorePropertiesResource> List(string resourceGroupName, string workspaceName, string skiptoken = null, int? count = default(int?), bool? isDefault = default(bool?), System.Collections.Generic.IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.DatastorePropertiesResource> ListAsync(string resourceGroupName, string workspaceName, string skiptoken = null, int? count = default(int?), bool? isDefault = default(bool?), System.Collections.Generic.IEnumerable<string> names = null, string searchText = null, string orderBy = null, bool? orderByAsc = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials> ListSecrets(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials>> ListSecretsAsync(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataVersionsOperations
    {
        protected DataVersionsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DataVersionResource> CreateOrUpdate(string name, string version, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.DataVersionResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DataVersionResource>> CreateOrUpdateAsync(string name, string version, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.DataVersionResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string name, string version, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string name, string version, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DataVersionResource> Get(string name, string version, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.DataVersionResource>> GetAsync(string name, string version, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.DataVersionResource> List(string name, string resourceGroupName, string workspaceName, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.DataVersionResource> ListAsync(string name, string resourceGroupName, string workspaceName, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentContainersOperations
    {
        protected EnvironmentContainersOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainerResource> CreateOrUpdate(string name, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainerResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainerResource>> CreateOrUpdateAsync(string name, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainerResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainerResource> Get(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainerResource>> GetAsync(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainerResource> List(string resourceGroupName, string workspaceName, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainerResource> ListAsync(string resourceGroupName, string workspaceName, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentSpecificationVersionsOperations
    {
        protected EnvironmentSpecificationVersionsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationVersionResource> CreateOrUpdate(string name, string version, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationVersionResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationVersionResource>> CreateOrUpdateAsync(string name, string version, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationVersionResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string name, string version, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string name, string version, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationVersionResource> Get(string name, string version, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationVersionResource>> GetAsync(string name, string version, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationVersionResource> List(string name, string resourceGroupName, string workspaceName, string orderby = null, string top = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationVersionResource> ListAsync(string name, string resourceGroupName, string workspaceName, string orderby = null, string top = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobsOperations
    {
        protected JobsOperations() { }
        public virtual Azure.Response Cancel(string id, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(string id, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.JobBaseResource> CreateOrUpdate(string id, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.JobBaseResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.JobBaseResource>> CreateOrUpdateAsync(string id, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.JobBaseResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string id, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string id, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.JobBaseResource> Get(string id, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.JobBaseResource>> GetAsync(string id, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.JobBaseResource> List(string resourceGroupName, string workspaceName, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.JobBaseResource> ListAsync(string resourceGroupName, string workspaceName, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Poll(string id, string operationId, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PollAsync(string id, string operationId, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabelingJobsOperations
    {
        protected LabelingJobsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.LabelingJobResource> CreateOrUpdate(string id, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.LabelingJobResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.LabelingJobResource>> CreateOrUpdateAsync(string id, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.LabelingJobResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string id, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string id, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ExportLabels(string id, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.ExportFormatType? body = default(Azure.ResourceManager.MachineLearningServices.Models.ExportFormatType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExportLabelsAsync(string id, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.ExportFormatType? body = default(Azure.ResourceManager.MachineLearningServices.Models.ExportFormatType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.LabelingJobResource> Get(string id, string resourceGroupName, string workspaceName, bool? includeJobInstructions = default(bool?), bool? includeLabelCategories = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.LabelingJobResource>> GetAsync(string id, string resourceGroupName, string workspaceName, bool? includeJobInstructions = default(bool?), bool? includeLabelCategories = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ExportSummaryResource> GetExportSummary(string id, System.Guid exportId, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ExportSummaryResource>> GetExportSummaryAsync(string id, System.Guid exportId, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.LabelingJobResource> List(string resourceGroupName, string workspaceName, string skiptoken = null, int? count = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.LabelingJobResource> ListAsync(string resourceGroupName, string workspaceName, string skiptoken = null, int? count = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Pause(string id, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PauseAsync(string id, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Resume(string id, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeAsync(string id, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkedServicesOperations
    {
        protected LinkedServicesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.LinkedServiceResponse> Create(string resourceGroupName, string workspaceName, string linkName, Azure.ResourceManager.MachineLearningServices.Models.LinkedServiceRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.LinkedServiceResponse>> CreateAsync(string resourceGroupName, string workspaceName, string linkName, Azure.ResourceManager.MachineLearningServices.Models.LinkedServiceRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string workspaceName, string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string workspaceName, string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.LinkedServiceResponse> Get(string resourceGroupName, string workspaceName, string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.LinkedServiceResponse>> GetAsync(string resourceGroupName, string workspaceName, string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.LinkedServiceList> List(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.LinkedServiceList>> ListAsync(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningComputeCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.Models.ComputeResource>
    {
        protected MachineLearningComputeCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.Models.ComputeResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ComputeResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ComputeResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningComputeDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected MachineLearningComputeDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningComputeOperations
    {
        protected MachineLearningComputeOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ComputeResource> Get(string resourceGroupName, string workspaceName, string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ComputeResource>> GetAsync(string resourceGroupName, string workspaceName, string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.ComputeResource> ListByWorkspace(string resourceGroupName, string workspaceName, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.ComputeResource> ListByWorkspaceAsync(string resourceGroupName, string workspaceName, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ComputeSecrets> ListKeys(string resourceGroupName, string workspaceName, string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ComputeSecrets>> ListKeysAsync(string resourceGroupName, string workspaceName, string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.AmlComputeNodesInformation> ListNodes(string resourceGroupName, string workspaceName, string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.AmlComputeNodesInformation>> ListNodesAsync(string resourceGroupName, string workspaceName, string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Restart(string resourceGroupName, string workspaceName, string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestartAsync(string resourceGroupName, string workspaceName, string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Start(string resourceGroupName, string workspaceName, string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartAsync(string resourceGroupName, string workspaceName, string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.MachineLearningComputeCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string workspaceName, string computeName, Azure.ResourceManager.MachineLearningServices.Models.ComputeResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.MachineLearningComputeCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string workspaceName, string computeName, Azure.ResourceManager.MachineLearningServices.Models.ComputeResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.MachineLearningComputeDeleteOperation StartDelete(string resourceGroupName, string workspaceName, string computeName, Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction underlyingResourceAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.MachineLearningComputeDeleteOperation> StartDeleteAsync(string resourceGroupName, string workspaceName, string computeName, Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction underlyingResourceAction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.MachineLearningComputeUpdateOperation StartUpdate(string resourceGroupName, string workspaceName, string computeName, Azure.ResourceManager.MachineLearningServices.Models.ClusterUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.MachineLearningComputeUpdateOperation> StartUpdateAsync(string resourceGroupName, string workspaceName, string computeName, Azure.ResourceManager.MachineLearningServices.Models.ClusterUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(string resourceGroupName, string workspaceName, string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(string resourceGroupName, string workspaceName, string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningComputeUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.Models.ComputeResource>
    {
        protected MachineLearningComputeUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.Models.ComputeResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ComputeResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ComputeResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningServiceCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.Models.ServiceResource>
    {
        protected MachineLearningServiceCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.Models.ServiceResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ServiceResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ServiceResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningServiceOperations
    {
        protected MachineLearningServiceOperations() { }
        public virtual Azure.Response Delete(string resourceGroupName, string workspaceName, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string workspaceName, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ServiceResource> Get(string resourceGroupName, string workspaceName, string serviceName, bool? expand = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ServiceResource>> GetAsync(string resourceGroupName, string workspaceName, string serviceName, bool? expand = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.ServiceResource> ListByWorkspace(string resourceGroupName, string workspaceName, string skiptoken = null, string modelId = null, string modelName = null, string tag = null, string tags = null, string properties = null, string runId = null, bool? expand = default(bool?), Azure.ResourceManager.MachineLearningServices.Models.OrderString? orderby = default(Azure.ResourceManager.MachineLearningServices.Models.OrderString?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.ServiceResource> ListByWorkspaceAsync(string resourceGroupName, string workspaceName, string skiptoken = null, string modelId = null, string modelName = null, string tag = null, string tags = null, string properties = null, string runId = null, bool? expand = default(bool?), Azure.ResourceManager.MachineLearningServices.Models.OrderString? orderby = default(Azure.ResourceManager.MachineLearningServices.Models.OrderString?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.MachineLearningServiceCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string workspaceName, string serviceName, Azure.ResourceManager.MachineLearningServices.Models.CreateServiceRequest properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.MachineLearningServiceCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string workspaceName, string serviceName, Azure.ResourceManager.MachineLearningServices.Models.CreateServiceRequest properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineLearningServicesManagementClient
    {
        protected MachineLearningServicesManagementClient() { }
        public MachineLearningServicesManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.MachineLearningServices.MachineLearningServicesManagementClientOptions options = null) { }
        public MachineLearningServicesManagementClient(System.Uri endpoint, string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.MachineLearningServices.MachineLearningServicesManagementClientOptions options = null) { }
        public virtual Azure.ResourceManager.MachineLearningServices.AzureMachineLearningWorkspacesOperations AzureMachineLearningWorkspaces { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.CodeContainersOperations CodeContainers { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.CodeVersionsOperations CodeVersions { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.DataContainersOperations DataContainers { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.DatastoresOperations Datastores { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.DataVersionsOperations DataVersions { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.EnvironmentContainersOperations EnvironmentContainers { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.EnvironmentSpecificationVersionsOperations EnvironmentSpecificationVersions { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.JobsOperations Jobs { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.LabelingJobsOperations LabelingJobs { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.LinkedServicesOperations LinkedServices { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.MachineLearningComputeOperations MachineLearningCompute { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.MachineLearningServiceOperations MachineLearningService { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.ModelContainersOperations ModelContainers { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.ModelVersionsOperations ModelVersions { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.NotebooksOperations Notebooks { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.Operations Operations { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.PrivateEndpointConnectionsOperations PrivateEndpointConnections { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.PrivateLinkResourcesOperations PrivateLinkResources { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.QuotasOperations Quotas { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.UsagesOperations Usages { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.VirtualMachineSizesOperations VirtualMachineSizes { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.WorkspaceConnectionsOperations WorkspaceConnections { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.WorkspaceFeaturesOperations WorkspaceFeatures { get { throw null; } }
        public virtual Azure.ResourceManager.MachineLearningServices.WorkspacesOperations Workspaces { get { throw null; } }
    }
    public partial class MachineLearningServicesManagementClientOptions : Azure.Core.ClientOptions
    {
        public MachineLearningServicesManagementClientOptions() { }
    }
    public partial class ModelContainersOperations
    {
        protected ModelContainersOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ModelContainerResource> CreateOrUpdate(string name, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.ModelContainerResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ModelContainerResource>> CreateOrUpdateAsync(string name, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.ModelContainerResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ModelContainerResource> Get(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ModelContainerResource>> GetAsync(string name, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.ModelContainerResource> List(string resourceGroupName, string workspaceName, string skiptoken = null, int? count = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.ModelContainerResource> ListAsync(string resourceGroupName, string workspaceName, string skiptoken = null, int? count = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelVersionsOperations
    {
        protected ModelVersionsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ModelVersionResource> CreateOrUpdate(string name, string version, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.ModelVersionResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ModelVersionResource>> CreateOrUpdateAsync(string name, string version, string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.ModelVersionResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string name, string version, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string name, string version, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ModelVersionResource> Get(string name, string version, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ModelVersionResource>> GetAsync(string name, string version, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.ModelVersionResource> List(string name, string resourceGroupName, string workspaceName, string skiptoken = null, string version = null, string description = null, int? count = default(int?), int? offset = default(int?), string tags = null, string properties = null, string orderBy = null, bool? latestVersionOnly = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.ModelVersionResource> ListAsync(string name, string resourceGroupName, string workspaceName, string skiptoken = null, string version = null, string description = null, int? count = default(int?), int? offset = default(int?), string tags = null, string properties = null, string orderBy = null, bool? latestVersionOnly = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotebooksOperations
    {
        protected NotebooksOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ListNotebookKeysResult> ListKeys(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ListNotebookKeysResult>> ListKeysAsync(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.NotebooksPrepareOperation StartPrepare(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.NotebooksPrepareOperation> StartPrepareAsync(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotebooksPrepareOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.Models.NotebookResourceInfo>
    {
        protected NotebooksPrepareOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.Models.NotebookResourceInfo Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.NotebookResourceInfo>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.NotebookResourceInfo>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Operations
    {
        protected Operations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.Operation> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.Operation> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionsOperations
    {
        protected PrivateEndpointConnectionsOperations() { }
        public virtual Azure.Response Delete(string resourceGroupName, string workspaceName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string workspaceName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnection> Get(string resourceGroupName, string workspaceName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnection>> GetAsync(string resourceGroupName, string workspaceName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnection> Put(string resourceGroupName, string workspaceName, string privateEndpointConnectionName, Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnection properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnection>> PutAsync(string resourceGroupName, string workspaceName, string privateEndpointConnectionName, Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnection properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkResourcesOperations
    {
        protected PrivateLinkResourcesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.PrivateLinkResourceListResult> ListByWorkspace(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.PrivateLinkResourceListResult>> ListByWorkspaceAsync(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QuotasOperations
    {
        protected QuotasOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.ResourceQuota> List(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.ResourceQuota> ListAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.UpdateWorkspaceQuotasResult> Update(string location, Azure.ResourceManager.MachineLearningServices.Models.QuotaUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.UpdateWorkspaceQuotasResult>> UpdateAsync(string location, Azure.ResourceManager.MachineLearningServices.Models.QuotaUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UsagesOperations
    {
        protected UsagesOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.Usage> List(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.Usage> ListAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineSizesOperations
    {
        protected VirtualMachineSizesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSizeListResult> List(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSizeListResult>> ListAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceConnectionsOperations
    {
        protected WorkspaceConnectionsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.WorkspaceConnection> Create(string resourceGroupName, string workspaceName, string connectionName, Azure.ResourceManager.MachineLearningServices.Models.WorkspaceConnectionDto parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.WorkspaceConnection>> CreateAsync(string resourceGroupName, string workspaceName, string connectionName, Azure.ResourceManager.MachineLearningServices.Models.WorkspaceConnectionDto parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string workspaceName, string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string workspaceName, string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.WorkspaceConnection> Get(string resourceGroupName, string workspaceName, string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.WorkspaceConnection>> GetAsync(string resourceGroupName, string workspaceName, string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.WorkspaceConnection> List(string resourceGroupName, string workspaceName, string target = null, string category = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.WorkspaceConnection> ListAsync(string resourceGroupName, string workspaceName, string target = null, string category = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceFeaturesOperations
    {
        protected WorkspaceFeaturesOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.AmlUserFeature> List(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.AmlUserFeature> ListAsync(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspacesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.MachineLearningServices.Models.Workspace>
    {
        protected WorkspacesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.MachineLearningServices.Models.Workspace Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.Workspace>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.Workspace>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspacesDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected WorkspacesDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspacesOperations
    {
        protected WorkspacesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.Workspace> Get(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.Workspace>> GetAsync(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.Workspace> ListByResourceGroup(string resourceGroupName, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.Workspace> ListByResourceGroupAsync(string resourceGroupName, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MachineLearningServices.Models.Workspace> ListBySubscription(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MachineLearningServices.Models.Workspace> ListBySubscriptionAsync(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ListWorkspaceKeysResult> ListKeys(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.ListWorkspaceKeysResult>> ListKeysAsync(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResyncKeys(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResyncKeysAsync(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.WorkspacesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.Workspace parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.WorkspacesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.Workspace parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MachineLearningServices.WorkspacesDeleteOperation StartDelete(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.MachineLearningServices.WorkspacesDeleteOperation> StartDeleteAsync(string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.Workspace> Update(string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.WorkspaceUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MachineLearningServices.Models.Workspace>> UpdateAsync(string resourceGroupName, string workspaceName, Azure.ResourceManager.MachineLearningServices.Models.WorkspaceUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MachineLearningServices.Models
{
    public partial class AccountKeySection
    {
        public AccountKeySection() { }
        public string Key { get { throw null; } set { } }
    }
    public partial class ACIServiceCreateRequest : Azure.ResourceManager.MachineLearningServices.Models.CreateServiceRequest
    {
        public ACIServiceCreateRequest() { }
        public bool? AppInsightsEnabled { get { throw null; } set { } }
        public bool? AuthEnabled { get { throw null; } set { } }
        public string Cname { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ContainerResourceRequirements ContainerResourceRequirements { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ACIServiceCreateRequestDataCollection DataCollection { get { throw null; } set { } }
        public string DnsNameLabel { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ACIServiceCreateRequestEncryptionProperties EncryptionProperties { get { throw null; } set { } }
        public string SslCertificate { get { throw null; } set { } }
        public bool? SslEnabled { get { throw null; } set { } }
        public string SslKey { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ACIServiceCreateRequestVnetConfiguration VnetConfiguration { get { throw null; } set { } }
    }
    public partial class ACIServiceCreateRequestDataCollection : Azure.ResourceManager.MachineLearningServices.Models.ModelDataCollection
    {
        public ACIServiceCreateRequestDataCollection() { }
    }
    public partial class ACIServiceCreateRequestEncryptionProperties : Azure.ResourceManager.MachineLearningServices.Models.EncryptionProperties
    {
        public ACIServiceCreateRequestEncryptionProperties(string vaultBaseUrl, string keyName, string keyVersion) : base (default(string), default(string), default(string)) { }
    }
    public partial class ACIServiceCreateRequestVnetConfiguration : Azure.ResourceManager.MachineLearningServices.Models.VnetConfiguration
    {
        public ACIServiceCreateRequestVnetConfiguration() { }
    }
    public partial class ACIServiceResponse : Azure.ResourceManager.MachineLearningServices.Models.ServiceResponseBase
    {
        public ACIServiceResponse() { }
        public bool? AppInsightsEnabled { get { throw null; } set { } }
        public bool? AuthEnabled { get { throw null; } set { } }
        public string Cname { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ContainerResourceRequirements ContainerResourceRequirements { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ACIServiceResponseDataCollection DataCollection { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ACIServiceResponseEncryptionProperties EncryptionProperties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ACIServiceResponseEnvironmentImageRequest EnvironmentImageRequest { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> ModelConfigMap { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.Model> Models { get { throw null; } }
        public string PublicFqdn { get { throw null; } set { } }
        public string PublicIp { get { throw null; } set { } }
        public string ScoringUri { get { throw null; } }
        public string SslCertificate { get { throw null; } set { } }
        public bool? SslEnabled { get { throw null; } set { } }
        public string SslKey { get { throw null; } set { } }
        public string SwaggerUri { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ACIServiceResponseVnetConfiguration VnetConfiguration { get { throw null; } set { } }
    }
    public partial class ACIServiceResponseDataCollection : Azure.ResourceManager.MachineLearningServices.Models.ModelDataCollection
    {
        public ACIServiceResponseDataCollection() { }
    }
    public partial class ACIServiceResponseEncryptionProperties : Azure.ResourceManager.MachineLearningServices.Models.EncryptionProperties
    {
        public ACIServiceResponseEncryptionProperties(string vaultBaseUrl, string keyName, string keyVersion) : base (default(string), default(string), default(string)) { }
    }
    public partial class ACIServiceResponseEnvironmentImageRequest : Azure.ResourceManager.MachineLearningServices.Models.EnvironmentImageResponse
    {
        public ACIServiceResponseEnvironmentImageRequest() { }
    }
    public partial class ACIServiceResponseVnetConfiguration : Azure.ResourceManager.MachineLearningServices.Models.VnetConfiguration
    {
        public ACIServiceResponseVnetConfiguration() { }
    }
    public partial class AKS : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public AKS() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AKSProperties Properties { get { throw null; } set { } }
    }
    public partial class AksComputeSecrets : Azure.ResourceManager.MachineLearningServices.Models.ComputeSecrets
    {
        internal AksComputeSecrets() { }
        public string AdminKubeConfig { get { throw null; } }
        public string ImagePullSecretName { get { throw null; } }
        public string UserKubeConfig { get { throw null; } }
    }
    public partial class AksNetworkingConfiguration
    {
        public AksNetworkingConfiguration() { }
        public string DnsServiceIP { get { throw null; } set { } }
        public string DockerBridgeCidr { get { throw null; } set { } }
        public string ServiceCidr { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
    }
    public partial class AKSProperties
    {
        public AKSProperties() { }
        public int? AgentCount { get { throw null; } set { } }
        public string AgentVMSize { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AksNetworkingConfiguration AksNetworkingConfiguration { get { throw null; } set { } }
        public string ClusterFqdn { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SslConfiguration SslConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.SystemService> SystemServices { get { throw null; } }
    }
    public partial class AKSReplicaStatus
    {
        internal AKSReplicaStatus() { }
        public int? AvailableReplicas { get { throw null; } }
        public int? DesiredReplicas { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.AKSReplicaStatusError Error { get { throw null; } }
        public int? UpdatedReplicas { get { throw null; } }
    }
    public partial class AKSReplicaStatusError : Azure.ResourceManager.MachineLearningServices.Models.ErrorResponse
    {
        internal AKSReplicaStatusError() { }
    }
    public partial class AKSServiceCreateRequest : Azure.ResourceManager.MachineLearningServices.Models.CreateEndpointVariantRequest
    {
        public AKSServiceCreateRequest() { }
        public bool? AadAuthEnabled { get { throw null; } set { } }
        public bool? AppInsightsEnabled { get { throw null; } set { } }
        public bool? AuthEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AKSServiceCreateRequestAutoScaler AutoScaler { get { throw null; } set { } }
        public string ComputeName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ContainerResourceRequirements ContainerResourceRequirements { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AKSServiceCreateRequestDataCollection DataCollection { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AKSServiceCreateRequestLivenessProbeRequirements LivenessProbeRequirements { get { throw null; } set { } }
        public int? MaxConcurrentRequestsPerContainer { get { throw null; } set { } }
        public int? MaxQueueWaitMs { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public int? NumReplicas { get { throw null; } set { } }
        public int? ScoringTimeoutMs { get { throw null; } set { } }
    }
    public partial class AKSServiceCreateRequestAutoScaler : Azure.ResourceManager.MachineLearningServices.Models.AutoScaler
    {
        public AKSServiceCreateRequestAutoScaler() { }
    }
    public partial class AKSServiceCreateRequestDataCollection : Azure.ResourceManager.MachineLearningServices.Models.ModelDataCollection
    {
        public AKSServiceCreateRequestDataCollection() { }
    }
    public partial class AKSServiceCreateRequestLivenessProbeRequirements : Azure.ResourceManager.MachineLearningServices.Models.LivenessProbeRequirements
    {
        public AKSServiceCreateRequestLivenessProbeRequirements() { }
    }
    public partial class AKSServiceResponse : Azure.ResourceManager.MachineLearningServices.Models.AKSVariantResponse
    {
        public AKSServiceResponse() { }
        public bool? AadAuthEnabled { get { throw null; } set { } }
        public bool? AppInsightsEnabled { get { throw null; } set { } }
        public bool? AuthEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AKSServiceResponseAutoScaler AutoScaler { get { throw null; } set { } }
        public string ComputeName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ContainerResourceRequirements ContainerResourceRequirements { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AKSServiceResponseDataCollection DataCollection { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AKSServiceResponseDeploymentStatus DeploymentStatus { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.AKSServiceResponseEnvironmentImageRequest EnvironmentImageRequest { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AKSServiceResponseLivenessProbeRequirements LivenessProbeRequirements { get { throw null; } set { } }
        public int? MaxConcurrentRequestsPerContainer { get { throw null; } set { } }
        public int? MaxQueueWaitMs { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> ModelConfigMap { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.Model> Models { get { throw null; } }
        public string Namespace { get { throw null; } set { } }
        public int? NumReplicas { get { throw null; } set { } }
        public int? ScoringTimeoutMs { get { throw null; } set { } }
        public string ScoringUri { get { throw null; } }
        public string SwaggerUri { get { throw null; } }
    }
    public partial class AKSServiceResponseAutoScaler : Azure.ResourceManager.MachineLearningServices.Models.AutoScaler
    {
        public AKSServiceResponseAutoScaler() { }
    }
    public partial class AKSServiceResponseDataCollection : Azure.ResourceManager.MachineLearningServices.Models.ModelDataCollection
    {
        public AKSServiceResponseDataCollection() { }
    }
    public partial class AKSServiceResponseDeploymentStatus : Azure.ResourceManager.MachineLearningServices.Models.AKSReplicaStatus
    {
        internal AKSServiceResponseDeploymentStatus() { }
    }
    public partial class AKSServiceResponseEnvironmentImageRequest : Azure.ResourceManager.MachineLearningServices.Models.EnvironmentImageResponse
    {
        public AKSServiceResponseEnvironmentImageRequest() { }
    }
    public partial class AKSServiceResponseLivenessProbeRequirements : Azure.ResourceManager.MachineLearningServices.Models.LivenessProbeRequirements
    {
        public AKSServiceResponseLivenessProbeRequirements() { }
    }
    public partial class AKSVariantResponse : Azure.ResourceManager.MachineLearningServices.Models.ServiceResponseBase
    {
        public AKSVariantResponse() { }
        public bool? IsDefault { get { throw null; } set { } }
        public float? TrafficPercentile { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.VariantType? Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllocationState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.AllocationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllocationState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.AllocationState Resizing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.AllocationState Steady { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.AllocationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.AllocationState left, Azure.ResourceManager.MachineLearningServices.Models.AllocationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.AllocationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.AllocationState left, Azure.ResourceManager.MachineLearningServices.Models.AllocationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AmlCompute : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public AmlCompute() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AmlComputeProperties Properties { get { throw null; } set { } }
    }
    public partial class AmlComputeNodeInformation
    {
        internal AmlComputeNodeInformation() { }
        public string NodeId { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.NodeState? NodeState { get { throw null; } }
        public int? Port { get { throw null; } }
        public string PrivateIpAddress { get { throw null; } }
        public string PublicIpAddress { get { throw null; } }
        public string RunId { get { throw null; } }
    }
    public partial class AmlComputeNodesInformation : Azure.ResourceManager.MachineLearningServices.Models.ComputeNodesInformation
    {
        internal AmlComputeNodesInformation() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.AmlComputeNodeInformation> Nodes { get { throw null; } }
    }
    public partial class AmlComputeProperties
    {
        public AmlComputeProperties() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AllocationState? AllocationState { get { throw null; } }
        public System.DateTimeOffset? AllocationStateTransitionTime { get { throw null; } }
        public int? CurrentNodeCount { get { throw null; } }
        public bool? EnableNodePublicIp { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServiceError> Errors { get { throw null; } }
        public bool? IsolatedNetwork { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.NodeStateCounts NodeStateCounts { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.OsType? OsType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess? RemoteLoginPortPublicAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ScaleSettings ScaleSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceId Subnet { get { throw null; } set { } }
        public int? TargetNodeCount { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.UserAccountCredentials UserAccountCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineImage VirtualMachineImage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.VmPriority? VmPriority { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class AmlUserFeature
    {
        internal AmlUserFeature() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationSharingPolicy : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationSharingPolicy(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy Personal { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy Shared { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy left, Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy left, Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssetPath
    {
        public AssetPath(string path) { }
        public bool? IsDirectory { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class AssignedUser
    {
        public AssignedUser(string objectId, string tenantId) { }
        public string ObjectId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
    }
    public partial class AuthKeys
    {
        public AuthKeys() { }
        public string PrimaryKey { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
    }
    public partial class AutoScaler
    {
        public AutoScaler() { }
        public bool? AutoscaleEnabled { get { throw null; } set { } }
        public int? MaxReplicas { get { throw null; } set { } }
        public int? MinReplicas { get { throw null; } set { } }
        public int? RefreshPeriodInSeconds { get { throw null; } set { } }
        public int? TargetUtilization { get { throw null; } set { } }
    }
    public partial class AzureDataLakeSection
    {
        public AzureDataLakeSection(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials credentials, string storeName) { }
        public Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials Credentials { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
    }
    public partial class AzureMySqlSection
    {
        public AzureMySqlSection(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials credentials, string databaseName, string endpoint, int portNumber, string serverName) { }
        public Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials Credentials { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public int PortNumber { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlSection
    {
        public AzurePostgreSqlSection(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials credentials, string databaseName, string endpoint, int portNumber, string serverName) { }
        public Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials Credentials { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public bool? EnableSSL { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public int PortNumber { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
    }
    public partial class AzureSqlDatabaseSection
    {
        public AzureSqlDatabaseSection(Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials credentials, string databaseName, string endpoint, int portNumber, string serverName) { }
        public Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials Credentials { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public int PortNumber { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
    }
    public partial class AzureStorageSection
    {
        public AzureStorageSection(string accountName, string containerName, Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials credentials, string endpoint, string protocol) { }
        public string AccountName { get { throw null; } set { } }
        public int? BlobCacheTimeout { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.DatastoreCredentials Credentials { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingCurrency : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingCurrency(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency USD { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency left, Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency left, Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CertificateSection
    {
        public CertificateSection(System.Guid tenantId, System.Guid clientId, string thumbprint) { }
        public string AuthorityUrl { get { throw null; } set { } }
        public string Certificate { get { throw null; } set { } }
        public System.Guid ClientId { get { throw null; } set { } }
        public string ResourceUri { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
    }
    public partial class ClusterUpdateParameters
    {
        public ClusterUpdateParameters() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ScaleSettings ScaleSettings { get { throw null; } set { } }
    }
    public partial class CodeConfiguration
    {
        public CodeConfiguration(string command) { }
        public string CodeArtifactId { get { throw null; } set { } }
        public string Command { get { throw null; } set { } }
    }
    public partial class CodeContainer
    {
        public CodeContainer() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CodeContainerResource
    {
        public CodeContainerResource(Azure.ResourceManager.MachineLearningServices.Models.CodeContainer properties) { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.CodeContainer Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SystemData SystemData { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class CodeVersion
    {
        public CodeVersion() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AssetPath AssetPath { get { throw null; } set { } }
        public string DatastoreId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CodeVersionResource
    {
        public CodeVersionResource(Azure.ResourceManager.MachineLearningServices.Models.CodeVersion properties) { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.CodeVersion Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SystemData SystemData { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class CommandJob : Azure.ResourceManager.MachineLearningServices.Models.ComputeJobBase
    {
        public CommandJob(Azure.ResourceManager.MachineLearningServices.Models.ComputeBinding computeBinding, Azure.ResourceManager.MachineLearningServices.Models.CodeConfiguration codeConfiguration) : base (default(Azure.ResourceManager.MachineLearningServices.Models.ComputeBinding)) { }
        public Azure.ResourceManager.MachineLearningServices.Models.CodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.DataBinding> DataBindings { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.DistributionConfiguration DistributionConfiguration { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public long? MaxRunDurationSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.JobStatus? Status { get { throw null; } set { } }
    }
    public partial class Compute
    {
        public Compute() { }
        public string ComputeLocation { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsAttachedCompute { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServiceError> ProvisioningErrors { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class ComputeBinding
    {
        public ComputeBinding() { }
        public string ComputeId { get { throw null; } set { } }
        public bool? IsLocal { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeEnvironmentType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ComputeEnvironmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeEnvironmentType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeEnvironmentType ACI { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeEnvironmentType AKS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ComputeEnvironmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ComputeEnvironmentType left, Azure.ResourceManager.MachineLearningServices.Models.ComputeEnvironmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ComputeEnvironmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ComputeEnvironmentType left, Azure.ResourceManager.MachineLearningServices.Models.ComputeEnvironmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeInstance : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public ComputeInstance() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceProperties Properties { get { throw null; } set { } }
    }
    public partial class ComputeInstanceApplication
    {
        internal ComputeInstanceApplication() { }
        public string DisplayName { get { throw null; } }
        public string EndpointUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeInstanceAuthorizationType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeInstanceAuthorizationType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType Personal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType left, Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType left, Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeInstanceConnectivityEndpoints
    {
        internal ComputeInstanceConnectivityEndpoints() { }
        public string PrivateIpAddress { get { throw null; } }
        public string PublicIpAddress { get { throw null; } }
    }
    public partial class ComputeInstanceCreatedBy
    {
        internal ComputeInstanceCreatedBy() { }
        public string UserId { get { throw null; } }
        public string UserName { get { throw null; } }
        public string UserOrgId { get { throw null; } }
    }
    public partial class ComputeInstanceLastOperation
    {
        internal ComputeInstanceLastOperation() { }
        public Azure.ResourceManager.MachineLearningServices.Models.OperationName? OperationName { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.OperationStatus? OperationStatus { get { throw null; } }
        public System.DateTimeOffset? OperationTime { get { throw null; } }
    }
    public partial class ComputeInstanceProperties
    {
        public ComputeInstanceProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceApplication> Applications { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ApplicationSharingPolicy? ApplicationSharingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceAuthorizationType? ComputeInstanceAuthorizationType { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceConnectivityEndpoints ConnectivityEndpoints { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceCreatedBy CreatedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.MachineLearningServiceError> Errors { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceLastOperation LastOperation { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.PersonalComputeInstanceSettings PersonalComputeInstanceSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceSshSettings SshSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState? State { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceId Subnet { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class ComputeInstanceSshSettings
    {
        public ComputeInstanceSshSettings() { }
        public string AdminPublicKey { get { throw null; } set { } }
        public string AdminUserName { get { throw null; } }
        public int? SshPort { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess? SshPublicAccess { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeInstanceState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeInstanceState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState JobRunning { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Restarting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState SettingUp { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState SetupFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Starting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Stopped { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Stopping { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState Unusable { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState UserSettingUp { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState UserSetupFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState left, Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState left, Azure.ResourceManager.MachineLearningServices.Models.ComputeInstanceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeJobBase : Azure.ResourceManager.MachineLearningServices.Models.JobBase
    {
        public ComputeJobBase(Azure.ResourceManager.MachineLearningServices.Models.ComputeBinding computeBinding) { }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeBinding ComputeBinding { get { throw null; } set { } }
        public string ExperimentName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.JobOutput Output { get { throw null; } set { } }
    }
    public partial class ComputeNodesInformation
    {
        internal ComputeNodesInformation() { }
        public string NextLink { get { throw null; } }
    }
    public partial class ComputeResource : Azure.ResourceManager.MachineLearningServices.Models.Resource
    {
        public ComputeResource() { }
        public Azure.ResourceManager.MachineLearningServices.Models.Compute Properties { get { throw null; } set { } }
    }
    public partial class ComputeSecrets
    {
        internal ComputeSecrets() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ComputeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType AKS { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType AmlCompute { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType ComputeInstance { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType Databricks { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType DataFactory { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType DataLakeAnalytics { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType HDInsight { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ComputeType VirtualMachine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ComputeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ComputeType left, Azure.ResourceManager.MachineLearningServices.Models.ComputeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ComputeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ComputeType left, Azure.ResourceManager.MachineLearningServices.Models.ComputeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistry
    {
        public ContainerRegistry() { }
        public string Address { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class ContainerRegistryResponse
    {
        public ContainerRegistryResponse() { }
        public string Address { get { throw null; } set { } }
    }
    public partial class ContainerResourceRequirements
    {
        public ContainerResourceRequirements() { }
        public double? Cpu { get { throw null; } set { } }
        public int? Fpga { get { throw null; } set { } }
        public int? Gpu { get { throw null; } set { } }
        public double? MemoryInGB { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentsType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ContentsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentsType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ContentsType AzureBlob { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ContentsType AzureDataLake { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ContentsType AzureDataLakeGen2 { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ContentsType AzureFile { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ContentsType AzureMySql { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ContentsType AzurePostgreSql { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ContentsType AzureSqlDatabase { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ContentsType GlusterFs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ContentsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ContentsType left, Azure.ResourceManager.MachineLearningServices.Models.ContentsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ContentsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ContentsType left, Azure.ResourceManager.MachineLearningServices.Models.ContentsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.CreatedByType left, Azure.ResourceManager.MachineLearningServices.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.CreatedByType left, Azure.ResourceManager.MachineLearningServices.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreateEndpointVariantRequest : Azure.ResourceManager.MachineLearningServices.Models.CreateServiceRequest
    {
        public CreateEndpointVariantRequest() { }
        public bool? IsDefault { get { throw null; } set { } }
        public float? TrafficPercentile { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.VariantType? Type { get { throw null; } set { } }
    }
    public partial class CreateServiceRequest
    {
        public CreateServiceRequest() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.CreateServiceRequestEnvironmentImageRequest EnvironmentImageRequest { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.CreateServiceRequestKeys Keys { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> KvTags { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
    }
    public partial class CreateServiceRequestEnvironmentImageRequest : Azure.ResourceManager.MachineLearningServices.Models.EnvironmentImageRequest
    {
        public CreateServiceRequestEnvironmentImageRequest() { }
    }
    public partial class CreateServiceRequestKeys : Azure.ResourceManager.MachineLearningServices.Models.AuthKeys
    {
        public CreateServiceRequestKeys() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CredentialsType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.CredentialsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CredentialsType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.CredentialsType AccountKey { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.CredentialsType Certificate { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.CredentialsType None { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.CredentialsType Sas { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.CredentialsType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.CredentialsType SqlAdmin { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.CredentialsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.CredentialsType left, Azure.ResourceManager.MachineLearningServices.Models.CredentialsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.CredentialsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.CredentialsType left, Azure.ResourceManager.MachineLearningServices.Models.CredentialsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBinding
    {
        public DataBinding() { }
        public string LocalReference { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.DataBindingMode? Mode { get { throw null; } set { } }
        public string SourceDataReference { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBindingMode : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.DataBindingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBindingMode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.DataBindingMode Download { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DataBindingMode Mount { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DataBindingMode Upload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.DataBindingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.DataBindingMode left, Azure.ResourceManager.MachineLearningServices.Models.DataBindingMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.DataBindingMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.DataBindingMode left, Azure.ResourceManager.MachineLearningServices.Models.DataBindingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Databricks : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public Databricks() { }
        public Azure.ResourceManager.MachineLearningServices.Models.DatabricksProperties Properties { get { throw null; } set { } }
    }
    public partial class DatabricksComputeSecrets : Azure.ResourceManager.MachineLearningServices.Models.ComputeSecrets
    {
        internal DatabricksComputeSecrets() { }
        public string DatabricksAccessToken { get { throw null; } }
    }
    public partial class DatabricksProperties
    {
        public DatabricksProperties() { }
        public string DatabricksAccessToken { get { throw null; } set { } }
    }
    public partial class DataContainer
    {
        public DataContainer() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataContainerResource
    {
        public DataContainerResource(Azure.ResourceManager.MachineLearningServices.Models.DataContainer properties) { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.DataContainer Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SystemData SystemData { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class DataFactory : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public DataFactory() { }
    }
    public partial class DataLakeAnalytics : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public DataLakeAnalytics() { }
        public Azure.ResourceManager.MachineLearningServices.Models.DataLakeAnalyticsProperties Properties { get { throw null; } set { } }
    }
    public partial class DataLakeAnalyticsProperties
    {
        public DataLakeAnalyticsProperties() { }
        public string DataLakeStoreAccountName { get { throw null; } set { } }
    }
    public partial class DatasetReference
    {
        public DatasetReference() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatasetType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.DatasetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatasetType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.DatasetType Dataflow { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DatasetType Simple { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.DatasetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.DatasetType left, Azure.ResourceManager.MachineLearningServices.Models.DatasetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.DatasetType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.DatasetType left, Azure.ResourceManager.MachineLearningServices.Models.DatasetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatastoreContents
    {
        public DatastoreContents(Azure.ResourceManager.MachineLearningServices.Models.ContentsType type) { }
        public Azure.ResourceManager.MachineLearningServices.Models.AzureDataLakeSection AzureDataLake { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AzureMySqlSection AzureMySql { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AzurePostgreSqlSection AzurePostgreSql { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AzureSqlDatabaseSection AzureSqlDatabase { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.AzureStorageSection AzureStorage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.GlusterFsSection GlusterFs { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ContentsType Type { get { throw null; } set { } }
    }
    public partial class DatastoreCredentials
    {
        public DatastoreCredentials(Azure.ResourceManager.MachineLearningServices.Models.CredentialsType type) { }
        public Azure.ResourceManager.MachineLearningServices.Models.AccountKeySection AccountKey { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.CertificateSection Certificate { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SasSection Sas { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ServicePrincipalSection ServicePrincipal { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SqlAdminSection SqlAdmin { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.CredentialsType Type { get { throw null; } set { } }
    }
    public partial class DatastoreProperties
    {
        public DatastoreProperties(Azure.ResourceManager.MachineLearningServices.Models.DatastoreContents contents) { }
        public Azure.ResourceManager.MachineLearningServices.Models.DatastoreContents Contents { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? HasBeenValidated { get { throw null; } }
        public bool? IsDefault { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.LinkedInfo LinkedInfo { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DatastorePropertiesResource
    {
        public DatastorePropertiesResource(Azure.ResourceManager.MachineLearningServices.Models.DatastoreProperties properties) { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.DatastoreProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SystemData SystemData { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class DataVersion
    {
        public DataVersion() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AssetPath AssetPath { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.DatasetType? DatasetType { get { throw null; } set { } }
        public string DatastoreId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataVersionResource
    {
        public DataVersionResource(Azure.ResourceManager.MachineLearningServices.Models.DataVersion properties) { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.DataVersion Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SystemData SystemData { get { throw null; } }
        public string Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.DeploymentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentType Batch { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentType GrpcRealtimeEndpoint { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DeploymentType HttpRealtimeEndpoint { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.DeploymentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.DeploymentType left, Azure.ResourceManager.MachineLearningServices.Models.DeploymentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.DeploymentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.DeploymentType left, Azure.ResourceManager.MachineLearningServices.Models.DeploymentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DistributionConfiguration
    {
        public DistributionConfiguration() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DistributionType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.DistributionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DistributionType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.DistributionType Mpi { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DistributionType PyTorch { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DistributionType TensorFlow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.DistributionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.DistributionType left, Azure.ResourceManager.MachineLearningServices.Models.DistributionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.DistributionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.DistributionType left, Azure.ResourceManager.MachineLearningServices.Models.DistributionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DockerSpecification
    {
        public DockerSpecification() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DockerSpecificationType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.DockerSpecificationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DockerSpecificationType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.DockerSpecificationType Build { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.DockerSpecificationType Image { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.DockerSpecificationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.DockerSpecificationType left, Azure.ResourceManager.MachineLearningServices.Models.DockerSpecificationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.DockerSpecificationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.DockerSpecificationType left, Azure.ResourceManager.MachineLearningServices.Models.DockerSpecificationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EarlyTerminationPolicyConfiguration
    {
        public EarlyTerminationPolicyConfiguration() { }
        public int? DelayEvaluation { get { throw null; } set { } }
        public int? EvaluationInterval { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EarlyTerminationPolicyType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EarlyTerminationPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType Bandit { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType MedianStopping { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType TruncationSelection { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType left, Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType left, Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionProperties
    {
        public EncryptionProperties(string vaultBaseUrl, string keyName, string keyVersion) { }
        public string KeyName { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public string VaultBaseUrl { get { throw null; } set { } }
    }
    public partial class EncryptionProperty
    {
        public EncryptionProperty(Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus status, Azure.ResourceManager.MachineLearningServices.Models.KeyVaultProperties keyVaultProperties) { }
        public Azure.ResourceManager.MachineLearningServices.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus left, Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus left, Azure.ResourceManager.MachineLearningServices.Models.EncryptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvironmentContainer
    {
        public EnvironmentContainer() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class EnvironmentContainerResource
    {
        public EnvironmentContainerResource(Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainer properties) { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.EnvironmentContainer Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SystemData SystemData { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class EnvironmentImageRequest
    {
        public EnvironmentImageRequest() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.ImageAsset> Assets { get { throw null; } }
        public string DriverProgram { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EnvironmentImageRequestEnvironment Environment { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EnvironmentImageRequestEnvironmentReference EnvironmentReference { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ModelIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.Model> Models { get { throw null; } }
    }
    public partial class EnvironmentImageRequestEnvironment : Azure.ResourceManager.MachineLearningServices.Models.ModelEnvironmentDefinition
    {
        public EnvironmentImageRequestEnvironment() { }
    }
    public partial class EnvironmentImageRequestEnvironmentReference : Azure.ResourceManager.MachineLearningServices.Models.EnvironmentReference
    {
        public EnvironmentImageRequestEnvironmentReference() { }
    }
    public partial class EnvironmentImageResponse
    {
        public EnvironmentImageResponse() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.ImageAsset> Assets { get { throw null; } }
        public string DriverProgram { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EnvironmentImageResponseEnvironment Environment { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EnvironmentImageResponseEnvironmentReference EnvironmentReference { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ModelIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.Model> Models { get { throw null; } }
    }
    public partial class EnvironmentImageResponseEnvironment : Azure.ResourceManager.MachineLearningServices.Models.ModelEnvironmentDefinitionResponse
    {
        public EnvironmentImageResponseEnvironment() { }
    }
    public partial class EnvironmentImageResponseEnvironmentReference : Azure.ResourceManager.MachineLearningServices.Models.EnvironmentReference
    {
        public EnvironmentImageResponseEnvironmentReference() { }
    }
    public partial class EnvironmentReference
    {
        public EnvironmentReference() { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentSpecificationType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentSpecificationType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationType Curated { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationType UserCreated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationType left, Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationType left, Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvironmentSpecificationVersion
    {
        public EnvironmentSpecificationVersion() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AssetPath AssetPath { get { throw null; } set { } }
        public string CondaFile { get { throw null; } set { } }
        public string DatastoreId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.DockerSpecification Docker { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationType? Type { get { throw null; } }
    }
    public partial class EnvironmentSpecificationVersionResource
    {
        public EnvironmentSpecificationVersionResource(Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationVersion properties) { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.EnvironmentSpecificationVersion Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SystemData SystemData { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ErrorDetail
    {
        internal ErrorDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class ErrorResponse
    {
        internal ErrorResponse() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.ErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class EstimatedVMPrice
    {
        internal EstimatedVMPrice() { }
        public Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType OsType { get { throw null; } }
        public double RetailPrice { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.VMTier VmTier { get { throw null; } }
    }
    public partial class EstimatedVMPrices
    {
        internal EstimatedVMPrices() { }
        public Azure.ResourceManager.MachineLearningServices.Models.BillingCurrency BillingCurrency { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure UnitOfMeasure { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.EstimatedVMPrice> Values { get { throw null; } }
    }
    public partial class EvaluationConfiguration
    {
        public EvaluationConfiguration(string primaryMetricName, Azure.ResourceManager.MachineLearningServices.Models.PrimaryMetricGoal primaryMetricGoal) { }
        public Azure.ResourceManager.MachineLearningServices.Models.PrimaryMetricGoal PrimaryMetricGoal { get { throw null; } set { } }
        public string PrimaryMetricName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportFormatType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ExportFormatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportFormatType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ExportFormatType Coco { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ExportFormatType CSV { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ExportFormatType Dataset { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ExportFormatType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ExportFormatType left, Azure.ResourceManager.MachineLearningServices.Models.ExportFormatType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ExportFormatType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ExportFormatType left, Azure.ResourceManager.MachineLearningServices.Models.ExportFormatType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExportSummary
    {
        internal ExportSummary() { }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } }
        public long? ExportedRowCount { get { throw null; } }
        public System.Guid? ExportId { get { throw null; } }
        public string LabelingJobId { get { throw null; } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.LabelExportState? State { get { throw null; } }
    }
    public partial class ExportSummaryResource
    {
        internal ExportSummaryResource() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ExportSummary Properties { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.SystemData SystemData { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class GlusterFsSection
    {
        public GlusterFsSection(string serverAddress, string volumeName) { }
        public string ServerAddress { get { throw null; } set { } }
        public string VolumeName { get { throw null; } set { } }
    }
    public partial class HDInsight : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public HDInsight() { }
        public Azure.ResourceManager.MachineLearningServices.Models.HDInsightProperties Properties { get { throw null; } set { } }
    }
    public partial class HDInsightProperties
    {
        public HDInsightProperties() { }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } set { } }
        public int? SshPort { get { throw null; } set { } }
    }
    public partial class Identity
    {
        public Identity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    public partial class ImageAsset
    {
        public ImageAsset() { }
        public string Id { get { throw null; } set { } }
        public string MimeType { get { throw null; } set { } }
        public bool? Unpack { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
    }
    public partial class JobBase
    {
        public JobBase() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.JobBaseInteractionEndpoints InteractionEndpoints { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class JobBaseInteractionEndpoints
    {
        internal JobBaseInteractionEndpoints() { }
        public object Grafana { get { throw null; } }
        public object Local { get { throw null; } }
        public object LocalRequest { get { throw null; } }
        public object Studio { get { throw null; } }
        public object Tensorboard { get { throw null; } }
        public object Tracking { get { throw null; } }
    }
    public partial class JobBaseResource
    {
        public JobBaseResource(Azure.ResourceManager.MachineLearningServices.Models.JobBase properties) { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.JobBase Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SystemData SystemData { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class JobOutput
    {
        public JobOutput() { }
        public string DatastoreId { get { throw null; } }
        public string Path { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus CancelRequested { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Finalizing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus NotResponding { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Paused { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Preparing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobStatus Starting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.JobStatus left, Azure.ResourceManager.MachineLearningServices.Models.JobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.JobStatus left, Azure.ResourceManager.MachineLearningServices.Models.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.JobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobType AutoML { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobType Command { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobType Data { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobType Labeling { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobType Pipeline { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.JobType Sweep { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.JobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.JobType left, Azure.ResourceManager.MachineLearningServices.Models.JobType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.JobType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.JobType left, Azure.ResourceManager.MachineLearningServices.Models.JobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties(string keyVaultArmId, string keyIdentifier) { }
        public string IdentityClientId { get { throw null; } set { } }
        public string KeyIdentifier { get { throw null; } set { } }
        public string KeyVaultArmId { get { throw null; } set { } }
    }
    public partial class LabelCategory
    {
        public LabelCategory() { }
        public bool? AllowMultiSelect { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.LabelClass> Classes { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
    }
    public partial class LabelClass
    {
        public LabelClass() { }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.LabelClass> Subclasses { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LabelExportState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.LabelExportState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LabelExportState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.LabelExportState Completed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.LabelExportState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.LabelExportState Requested { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.LabelExportState Running { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.LabelExportState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.LabelExportState left, Azure.ResourceManager.MachineLearningServices.Models.LabelExportState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.LabelExportState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.LabelExportState left, Azure.ResourceManager.MachineLearningServices.Models.LabelExportState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LabelingDatasetConfiguration
    {
        public LabelingDatasetConfiguration() { }
        public string AssetName { get { throw null; } set { } }
        public string DatasetVersion { get { throw null; } set { } }
        public bool? IncrementalDatasetRefreshEnabled { get { throw null; } set { } }
    }
    public partial class LabelingJob : Azure.ResourceManager.MachineLearningServices.Models.JobBase
    {
        public LabelingJob() { }
        public System.DateTimeOffset? CreatedTimeUtc { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.LabelingDatasetConfiguration DatasetConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.LabelingJobInstructions JobInstructions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.LabelCategory> LabelCategories { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.LabelingJobMediaProperties LabelingJobMediaProperties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.MLAssistConfiguration MlAssistConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ProgressMetrics ProgressMetrics { get { throw null; } set { } }
        public System.Guid? ProjectId { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.JobStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.StatusMessage> StatusMessages { get { throw null; } }
    }
    public partial class LabelingJobInstructions
    {
        public LabelingJobInstructions() { }
        public string Uri { get { throw null; } set { } }
    }
    public partial class LabelingJobMediaProperties
    {
        public LabelingJobMediaProperties() { }
    }
    public partial class LabelingJobResource
    {
        public LabelingJobResource(Azure.ResourceManager.MachineLearningServices.Models.LabelingJob properties) { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.LabelingJob Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SystemData SystemData { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class LinkedInfo
    {
        public LinkedInfo() { }
        public string LinkedId { get { throw null; } set { } }
        public string LinkedResourceName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.OriginType? Origin { get { throw null; } set { } }
    }
    public partial class LinkedServiceList
    {
        internal LinkedServiceList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.LinkedServiceResponse> Value { get { throw null; } }
    }
    public partial class LinkedServiceProps
    {
        public LinkedServiceProps(string linkedServiceResourceId) { }
        public System.DateTimeOffset? CreatedTime { get { throw null; } set { } }
        public string LinkedServiceResourceId { get { throw null; } set { } }
        public string LinkType { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedTime { get { throw null; } set { } }
    }
    public partial class LinkedServiceRequest
    {
        public LinkedServiceRequest() { }
        public Azure.ResourceManager.MachineLearningServices.Models.Identity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.LinkedServiceProps Properties { get { throw null; } set { } }
    }
    public partial class LinkedServiceResponse
    {
        internal LinkedServiceResponse() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.Identity Identity { get { throw null; } }
        public string Location { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.LinkedServiceProps Properties { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ListNotebookKeysResult
    {
        internal ListNotebookKeysResult() { }
        public string PrimaryAccessKey { get { throw null; } }
        public string SecondaryAccessKey { get { throw null; } }
    }
    public partial class ListWorkspaceKeysResult
    {
        internal ListWorkspaceKeysResult() { }
        public string AppInsightsInstrumentationKey { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.RegistryListCredentialsResult ContainerRegistryCredentials { get { throw null; } }
        public string UserStorageKey { get { throw null; } }
        public string UserStorageResourceId { get { throw null; } }
    }
    public partial class LivenessProbeRequirements
    {
        public LivenessProbeRequirements() { }
        public int? FailureThreshold { get { throw null; } set { } }
        public int? InitialDelaySeconds { get { throw null; } set { } }
        public int? PeriodSeconds { get { throw null; } set { } }
        public int? SuccessThreshold { get { throw null; } set { } }
        public int? TimeoutSeconds { get { throw null; } set { } }
    }
    public partial class MachineLearningServiceError
    {
        internal MachineLearningServiceError() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ErrorResponse Error { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.MediaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.MediaType Image { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.MediaType Text { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.MediaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.MediaType left, Azure.ResourceManager.MachineLearningServices.Models.MediaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.MediaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.MediaType left, Azure.ResourceManager.MachineLearningServices.Models.MediaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MLAssistConfiguration
    {
        public MLAssistConfiguration() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeBinding InferencingComputeBinding { get { throw null; } set { } }
        public bool? MlAssistEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ComputeBinding TrainingComputeBinding { get { throw null; } set { } }
    }
    public partial class Model
    {
        public Model(string name, string url, string mimeType) { }
        public System.DateTimeOffset? CreatedTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.DatasetReference> Datasets { get { throw null; } }
        public System.Collections.Generic.IList<string> DerivedModelIds { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string ExperimentName { get { throw null; } set { } }
        public string Framework { get { throw null; } set { } }
        public string FrameworkVersion { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> KvTags { get { throw null; } }
        public string MimeType { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedTime { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ParentModelId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ContainerResourceRequirements ResourceRequirements { get { throw null; } set { } }
        public string RunId { get { throw null; } set { } }
        public string SampleInputData { get { throw null; } set { } }
        public string SampleOutputData { get { throw null; } set { } }
        public bool? Unpack { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
        public long? Version { get { throw null; } set { } }
    }
    public partial class ModelContainer
    {
        public ModelContainer() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.ModelVersionResource> LatestVersions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ModelContainerResource
    {
        public ModelContainerResource(Azure.ResourceManager.MachineLearningServices.Models.ModelContainer properties) { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelContainer Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SystemData SystemData { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ModelDataCollection
    {
        public ModelDataCollection() { }
        public bool? EventHubEnabled { get { throw null; } set { } }
        public bool? StorageEnabled { get { throw null; } set { } }
    }
    public partial class ModelDockerSection
    {
        public ModelDockerSection() { }
        public string BaseDockerfile { get { throw null; } set { } }
        public string BaseImage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelDockerSectionBaseImageRegistry BaseImageRegistry { get { throw null; } set { } }
    }
    public partial class ModelDockerSectionBaseImageRegistry : Azure.ResourceManager.MachineLearningServices.Models.ContainerRegistry
    {
        public ModelDockerSectionBaseImageRegistry() { }
    }
    public partial class ModelDockerSectionResponse
    {
        public ModelDockerSectionResponse() { }
        public string BaseDockerfile { get { throw null; } set { } }
        public string BaseImage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelDockerSectionResponseBaseImageRegistry BaseImageRegistry { get { throw null; } set { } }
    }
    public partial class ModelDockerSectionResponseBaseImageRegistry : Azure.ResourceManager.MachineLearningServices.Models.ContainerRegistryResponse
    {
        public ModelDockerSectionResponseBaseImageRegistry() { }
    }
    public partial class ModelEnvironmentDefinition
    {
        public ModelEnvironmentDefinition() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelEnvironmentDefinitionDocker Docker { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public string InferencingStackVersion { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelEnvironmentDefinitionPython Python { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelEnvironmentDefinitionR R { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelEnvironmentDefinitionSpark Spark { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ModelEnvironmentDefinitionDocker : Azure.ResourceManager.MachineLearningServices.Models.ModelDockerSection
    {
        public ModelEnvironmentDefinitionDocker() { }
    }
    public partial class ModelEnvironmentDefinitionPython : Azure.ResourceManager.MachineLearningServices.Models.ModelPythonSection
    {
        public ModelEnvironmentDefinitionPython() { }
    }
    public partial class ModelEnvironmentDefinitionR : Azure.ResourceManager.MachineLearningServices.Models.RSection
    {
        public ModelEnvironmentDefinitionR() { }
    }
    public partial class ModelEnvironmentDefinitionResponse
    {
        public ModelEnvironmentDefinitionResponse() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelEnvironmentDefinitionResponseDocker Docker { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public string InferencingStackVersion { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelEnvironmentDefinitionResponsePython Python { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelEnvironmentDefinitionResponseR R { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelEnvironmentDefinitionResponseSpark Spark { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ModelEnvironmentDefinitionResponseDocker : Azure.ResourceManager.MachineLearningServices.Models.ModelDockerSectionResponse
    {
        public ModelEnvironmentDefinitionResponseDocker() { }
    }
    public partial class ModelEnvironmentDefinitionResponsePython : Azure.ResourceManager.MachineLearningServices.Models.ModelPythonSection
    {
        public ModelEnvironmentDefinitionResponsePython() { }
    }
    public partial class ModelEnvironmentDefinitionResponseR : Azure.ResourceManager.MachineLearningServices.Models.RSectionResponse
    {
        public ModelEnvironmentDefinitionResponseR() { }
    }
    public partial class ModelEnvironmentDefinitionResponseSpark : Azure.ResourceManager.MachineLearningServices.Models.ModelSparkSection
    {
        public ModelEnvironmentDefinitionResponseSpark() { }
    }
    public partial class ModelEnvironmentDefinitionSpark : Azure.ResourceManager.MachineLearningServices.Models.ModelSparkSection
    {
        public ModelEnvironmentDefinitionSpark() { }
    }
    public partial class ModelPythonSection
    {
        public ModelPythonSection() { }
        public string BaseCondaEnvironment { get { throw null; } set { } }
        public object CondaDependencies { get { throw null; } set { } }
        public string InterpreterPath { get { throw null; } set { } }
        public bool? UserManagedDependencies { get { throw null; } set { } }
    }
    public partial class ModelSparkSection
    {
        public ModelSparkSection() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.SparkMavenPackage> Packages { get { throw null; } }
        public bool? PrecachePackages { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Repositories { get { throw null; } }
    }
    public partial class ModelVersion
    {
        public ModelVersion() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AssetPath AssetPath { get { throw null; } set { } }
        public string DatastoreId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string Stage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ModelVersionResource
    {
        public ModelVersionResource(Azure.ResourceManager.MachineLearningServices.Models.ModelVersion properties) { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ModelVersion Properties { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SystemData SystemData { get { throw null; } }
        public string Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.NodeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Idle { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Leaving { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Preempted { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Preparing { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Running { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.NodeState Unusable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.NodeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.NodeState left, Azure.ResourceManager.MachineLearningServices.Models.NodeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.NodeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.NodeState left, Azure.ResourceManager.MachineLearningServices.Models.NodeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NodeStateCounts
    {
        internal NodeStateCounts() { }
        public int? IdleNodeCount { get { throw null; } }
        public int? LeavingNodeCount { get { throw null; } }
        public int? PreemptedNodeCount { get { throw null; } }
        public int? PreparingNodeCount { get { throw null; } }
        public int? RunningNodeCount { get { throw null; } }
        public int? UnusableNodeCount { get { throw null; } }
    }
    public partial class NotebookPreparationError
    {
        internal NotebookPreparationError() { }
        public string ErrorMessage { get { throw null; } }
        public int? StatusCode { get { throw null; } }
    }
    public partial class NotebookResourceInfo
    {
        internal NotebookResourceInfo() { }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.NotebookPreparationError NotebookPreparationError { get { throw null; } }
        public string ResourceId { get { throw null; } }
    }
    public partial class Operation
    {
        internal Operation() { }
        public Azure.ResourceManager.MachineLearningServices.Models.OperationDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class OperationDisplay
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationName : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OperationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationName(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Create { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Delete { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Reimage { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Restart { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Start { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationName Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OperationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OperationName left, Azure.ResourceManager.MachineLearningServices.Models.OperationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OperationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OperationName left, Azure.ResourceManager.MachineLearningServices.Models.OperationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus ReimageFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus RestartFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus StartFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus StopFailed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OperationStatus left, Azure.ResourceManager.MachineLearningServices.Models.OperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OperationStatus left, Azure.ResourceManager.MachineLearningServices.Models.OperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrderString : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OrderString>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrderString(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OrderString CreatedAtAsc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OrderString CreatedAtDesc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OrderString UpdatedAtAsc { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OrderString UpdatedAtDesc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OrderString other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OrderString left, Azure.ResourceManager.MachineLearningServices.Models.OrderString right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OrderString (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OrderString left, Azure.ResourceManager.MachineLearningServices.Models.OrderString right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OriginType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OriginType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OriginType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OriginType Synapse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OriginType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OriginType left, Azure.ResourceManager.MachineLearningServices.Models.OriginType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OriginType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OriginType left, Azure.ResourceManager.MachineLearningServices.Models.OriginType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OsType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.OsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OsType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.OsType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.OsType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.OsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.OsType left, Azure.ResourceManager.MachineLearningServices.Models.OsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.OsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.OsType left, Azure.ResourceManager.MachineLearningServices.Models.OsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ParameterSamplingConfiguration
    {
        public ParameterSamplingConfiguration(object parameterSpace, Azure.ResourceManager.MachineLearningServices.Models.ParameterSamplingType samplingType) { }
        public object ParameterSpace { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ParameterSamplingType SamplingType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterSamplingType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ParameterSamplingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterSamplingType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ParameterSamplingType Bayesian { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ParameterSamplingType Grid { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ParameterSamplingType Random { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ParameterSamplingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ParameterSamplingType left, Azure.ResourceManager.MachineLearningServices.Models.ParameterSamplingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ParameterSamplingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ParameterSamplingType left, Azure.ResourceManager.MachineLearningServices.Models.ParameterSamplingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Password
    {
        internal Password() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class PersonalComputeInstanceSettings
    {
        public PersonalComputeInstanceSettings() { }
        public Azure.ResourceManager.MachineLearningServices.Models.AssignedUser AssignedUser { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrimaryMetricGoal : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.PrimaryMetricGoal>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrimaryMetricGoal(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrimaryMetricGoal Maximize { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrimaryMetricGoal Minimize { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.PrimaryMetricGoal other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.PrimaryMetricGoal left, Azure.ResourceManager.MachineLearningServices.Models.PrimaryMetricGoal right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.PrimaryMetricGoal (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.PrimaryMetricGoal left, Azure.ResourceManager.MachineLearningServices.Models.PrimaryMetricGoal right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpoint
    {
        public PrivateEndpoint() { }
        public string Id { get { throw null; } }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.MachineLearningServices.Models.Resource
    {
        public PrivateEndpointConnection() { }
        public Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpoint PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.MachineLearningServices.Models.Resource
    {
        public PrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class PrivateLinkResourceListResult
    {
        internal PrivateLinkResourceListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.PrivateLinkResource> Value { get { throw null; } }
    }
    public partial class PrivateLinkServiceConnectionState
    {
        public PrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class ProgressMetrics
    {
        public ProgressMetrics() { }
        public long? CompletedDatapointCount { get { throw null; } }
        public System.DateTimeOffset? IncrementalDatasetLastRefreshTime { get { throw null; } }
        public long? SkippedDatapointCount { get { throw null; } }
        public long? TotalDatapointCount { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState left, Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaBaseProperties
    {
        public QuotaBaseProperties() { }
        public string Id { get { throw null; } set { } }
        public long? Limit { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit? Unit { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuotaUnit : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuotaUnit(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit left, Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit left, Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaUpdateParameters
    {
        public QuotaUpdateParameters() { }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.QuotaBaseProperties> Value { get { throw null; } }
    }
    public partial class RCranPackage
    {
        public RCranPackage() { }
        public string Name { get { throw null; } set { } }
        public string Repository { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReasonCode : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.ReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.ReasonCode NotAvailableForRegion { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.ReasonCode NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.ReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.ReasonCode left, Azure.ResourceManager.MachineLearningServices.Models.ReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.ReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.ReasonCode left, Azure.ResourceManager.MachineLearningServices.Models.ReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegistryListCredentialsResult
    {
        internal RegistryListCredentialsResult() { }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.Password> Passwords { get { throw null; } }
        public string Username { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteLoginPortPublicAccess : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteLoginPortPublicAccess(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess left, Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess left, Azure.ResourceManager.MachineLearningServices.Models.RemoteLoginPortPublicAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Resource
    {
        public Resource() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.Identity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ResourceId
    {
        public ResourceId(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public enum ResourceIdentityType
    {
        SystemAssigned = 0,
        SystemAssignedUserAssigned = 1,
        UserAssigned = 2,
        None = 3,
    }
    public partial class ResourceName
    {
        internal ResourceName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ResourceQuota
    {
        internal ResourceQuota() { }
        public string AmlWorkspaceLocation { get { throw null; } }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ResourceName Name { get { throw null; } }
        public string Type { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit? Unit { get { throw null; } }
    }
    public partial class ResourceSkuLocationInfo
    {
        internal ResourceSkuLocationInfo() { }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.ResourceSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ResourceSkuZoneDetails
    {
        internal ResourceSkuZoneDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.SKUCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
    }
    public partial class Restriction
    {
        internal Restriction() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ReasonCode? ReasonCode { get { throw null; } }
        public string Type { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    public partial class RGitHubPackage
    {
        public RGitHubPackage() { }
        public string AuthToken { get { throw null; } set { } }
        public string Repository { get { throw null; } set { } }
    }
    public partial class RGitHubPackageResponse
    {
        public RGitHubPackageResponse() { }
        public string Repository { get { throw null; } set { } }
    }
    public partial class RSection
    {
        public RSection() { }
        public System.Collections.Generic.IList<string> BioConductorPackages { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.RCranPackage> CranPackages { get { throw null; } }
        public System.Collections.Generic.IList<string> CustomUrlPackages { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.RGitHubPackage> GitHubPackages { get { throw null; } }
        public string RscriptPath { get { throw null; } set { } }
        public string RVersion { get { throw null; } set { } }
        public string SnapshotDate { get { throw null; } set { } }
        public bool? UserManaged { get { throw null; } set { } }
    }
    public partial class RSectionResponse
    {
        public RSectionResponse() { }
        public System.Collections.Generic.IList<string> BioConductorPackages { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.RCranPackage> CranPackages { get { throw null; } }
        public System.Collections.Generic.IList<string> CustomUrlPackages { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.RGitHubPackageResponse> GitHubPackages { get { throw null; } }
        public string RscriptPath { get { throw null; } set { } }
        public string RVersion { get { throw null; } set { } }
        public string SnapshotDate { get { throw null; } set { } }
        public bool? UserManaged { get { throw null; } set { } }
    }
    public partial class SasSection
    {
        public SasSection() { }
        public string SasToken { get { throw null; } set { } }
    }
    public partial class ScaleSettings
    {
        public ScaleSettings(int maxNodeCount) { }
        public int MaxNodeCount { get { throw null; } set { } }
        public int? MinNodeCount { get { throw null; } set { } }
        public System.TimeSpan? NodeIdleTimeBeforeScaleDown { get { throw null; } set { } }
    }
    public partial class ServicePrincipalSection
    {
        public ServicePrincipalSection(System.Guid tenantId, System.Guid clientId) { }
        public string AuthorityUrl { get { throw null; } set { } }
        public System.Guid ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string ResourceUri { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
    }
    public partial class ServiceResource : Azure.ResourceManager.MachineLearningServices.Models.Resource
    {
        public ServiceResource() { }
        public Azure.ResourceManager.MachineLearningServices.Models.ServiceResponseBase Properties { get { throw null; } set { } }
    }
    public partial class ServiceResponseBase
    {
        public ServiceResponseBase() { }
        public Azure.ResourceManager.MachineLearningServices.Models.DeploymentType? DeploymentType { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ServiceResponseBaseError Error { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> KvTags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.WebServiceState? State { get { throw null; } }
    }
    public partial class ServiceResponseBaseError : Azure.ResourceManager.MachineLearningServices.Models.ErrorResponse
    {
        internal ServiceResponseBaseError() { }
    }
    public partial class SharedPrivateLinkResource
    {
        public SharedPrivateLinkResource() { }
        public string GroupId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string PrivateLinkResourceId { get { throw null; } set { } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class Sku
    {
        public Sku() { }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class SKUCapability
    {
        internal SKUCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class SparkMavenPackage
    {
        public SparkMavenPackage() { }
        public string Artifact { get { throw null; } set { } }
        public string Group { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class SqlAdminSection
    {
        public SqlAdminSection(string userId) { }
        public string Password { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SshPublicAccess : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SshPublicAccess(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess left, Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess left, Azure.ResourceManager.MachineLearningServices.Models.SshPublicAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SslConfiguration
    {
        public SslConfiguration() { }
        public string Cert { get { throw null; } set { } }
        public string Cname { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SslConfigurationStatus : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslConfigurationStatus(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus left, Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus left, Azure.ResourceManager.MachineLearningServices.Models.SslConfigurationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status Failure { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status InvalidQuotaBelowClusterMinimum { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status InvalidQuotaExceedsSubscriptionLimit { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status InvalidVMFamilyName { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status OperationNotEnabledForRegion { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status OperationNotSupportedForSku { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status Success { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.Status Undefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.Status left, Azure.ResourceManager.MachineLearningServices.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.Status left, Azure.ResourceManager.MachineLearningServices.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StatusMessage
    {
        public StatusMessage() { }
        public string Code { get { throw null; } }
        public System.DateTimeOffset? CreatedTimeUtc { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.StatusMessageLevel? Level { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StatusMessageLevel : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.StatusMessageLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StatusMessageLevel(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.StatusMessageLevel Error { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.StatusMessageLevel Information { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.StatusMessageLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.StatusMessageLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.StatusMessageLevel left, Azure.ResourceManager.MachineLearningServices.Models.StatusMessageLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.StatusMessageLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.StatusMessageLevel left, Azure.ResourceManager.MachineLearningServices.Models.StatusMessageLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SweepJob : Azure.ResourceManager.MachineLearningServices.Models.ComputeJobBase
    {
        public SweepJob(Azure.ResourceManager.MachineLearningServices.Models.ComputeBinding computeBinding, Azure.ResourceManager.MachineLearningServices.Models.ParameterSamplingConfiguration parameterSamplingConfiguration, Azure.ResourceManager.MachineLearningServices.Models.EvaluationConfiguration evaluationConfiguration) : base (default(Azure.ResourceManager.MachineLearningServices.Models.ComputeBinding)) { }
        public Azure.ResourceManager.MachineLearningServices.Models.EvaluationConfiguration EvaluationConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.ParameterSamplingConfiguration ParameterSamplingConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.JobStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TerminationConfiguration TerminationConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.TrialComponent TrialComponent { get { throw null; } set { } }
    }
    public partial class SystemData
    {
        internal SystemData() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.CreatedByType? CreatedByType { get { throw null; } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.CreatedByType? LastModifiedByType { get { throw null; } }
    }
    public partial class SystemService
    {
        internal SystemService() { }
        public string PublicIpAddress { get { throw null; } }
        public string SystemServiceType { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class TerminationConfiguration
    {
        public TerminationConfiguration() { }
        public Azure.ResourceManager.MachineLearningServices.Models.EarlyTerminationPolicyConfiguration EarlyTerminationPolicyConfiguration { get { throw null; } set { } }
        public int? MaxConcurrentRuns { get { throw null; } set { } }
        public int? MaxDurationMinutes { get { throw null; } set { } }
        public int? MaxTotalRuns { get { throw null; } set { } }
    }
    public partial class TrialComponent
    {
        public TrialComponent() { }
        public Azure.ResourceManager.MachineLearningServices.Models.CodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.MachineLearningServices.Models.DataBinding> DataBindings { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.DistributionConfiguration DistributionConfiguration { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnderlyingResourceAction : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnderlyingResourceAction(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction Delete { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction left, Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction left, Azure.ResourceManager.MachineLearningServices.Models.UnderlyingResourceAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnitOfMeasure : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnitOfMeasure(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure OneHour { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure left, Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure left, Azure.ResourceManager.MachineLearningServices.Models.UnitOfMeasure right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateWorkspaceQuotas
    {
        internal UpdateWorkspaceQuotas() { }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.Status? Status { get { throw null; } }
        public string Type { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.QuotaUnit? Unit { get { throw null; } }
    }
    public partial class UpdateWorkspaceQuotasResult
    {
        internal UpdateWorkspaceQuotasResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.UpdateWorkspaceQuotas> Value { get { throw null; } }
    }
    public partial class Usage
    {
        internal Usage() { }
        public string AmlWorkspaceLocation { get { throw null; } }
        public long? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.UsageName Name { get { throw null; } }
        public string Type { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.UsageUnit? Unit { get { throw null; } }
    }
    public partial class UsageName
    {
        internal UsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsageUnit : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.UsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.UsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.UsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.UsageUnit left, Azure.ResourceManager.MachineLearningServices.Models.UsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.UsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.UsageUnit left, Azure.ResourceManager.MachineLearningServices.Models.UsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserAccountCredentials
    {
        public UserAccountCredentials(string adminUserName) { }
        public string AdminUserName { get { throw null; } set { } }
        public string AdminUserPassword { get { throw null; } set { } }
        public string AdminUserSshPublicKey { get { throw null; } set { } }
    }
    public partial class UserAssignedIdentity
    {
        public UserAssignedIdentity() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VariantType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.VariantType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VariantType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.VariantType Control { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.VariantType Treatment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.VariantType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.VariantType left, Azure.ResourceManager.MachineLearningServices.Models.VariantType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.VariantType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.VariantType left, Azure.ResourceManager.MachineLearningServices.Models.VariantType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachine : Azure.ResourceManager.MachineLearningServices.Models.Compute
    {
        public VirtualMachine() { }
        public Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineProperties Properties { get { throw null; } set { } }
    }
    public partial class VirtualMachineImage
    {
        public VirtualMachineImage(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public partial class VirtualMachineProperties
    {
        public VirtualMachineProperties() { }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } set { } }
        public int? SshPort { get { throw null; } set { } }
        public string VirtualMachineSize { get { throw null; } set { } }
    }
    public partial class VirtualMachineSecrets : Azure.ResourceManager.MachineLearningServices.Models.ComputeSecrets
    {
        internal VirtualMachineSecrets() { }
        public Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSshCredentials AdministratorAccount { get { throw null; } }
    }
    public partial class VirtualMachineSize
    {
        internal VirtualMachineSize() { }
        public Azure.ResourceManager.MachineLearningServices.Models.EstimatedVMPrices EstimatedVMPrices { get { throw null; } }
        public string Family { get { throw null; } }
        public int? Gpus { get { throw null; } }
        public bool? LowPriorityCapable { get { throw null; } }
        public int? MaxResourceVolumeMB { get { throw null; } }
        public double? MemoryGB { get { throw null; } }
        public string Name { get { throw null; } }
        public int? OsVhdSizeMB { get { throw null; } }
        public bool? PremiumIO { get { throw null; } }
        public int? VCPUs { get { throw null; } }
    }
    public partial class VirtualMachineSizeListResult
    {
        internal VirtualMachineSizeListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.VirtualMachineSize> AmlCompute { get { throw null; } }
    }
    public partial class VirtualMachineSshCredentials
    {
        public VirtualMachineSshCredentials() { }
        public string Password { get { throw null; } set { } }
        public string PrivateKeyData { get { throw null; } set { } }
        public string PublicKeyData { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VMPriceOSType : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMPriceOSType(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType left, Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType left, Azure.ResourceManager.MachineLearningServices.Models.VMPriceOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmPriority : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.VmPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmPriority(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.VmPriority Dedicated { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.VmPriority LowPriority { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.VmPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.VmPriority left, Azure.ResourceManager.MachineLearningServices.Models.VmPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.VmPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.VmPriority left, Azure.ResourceManager.MachineLearningServices.Models.VmPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VMTier : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.VMTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMTier(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.VMTier LowPriority { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.VMTier Spot { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.VMTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.VMTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.VMTier left, Azure.ResourceManager.MachineLearningServices.Models.VMTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.VMTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.VMTier left, Azure.ResourceManager.MachineLearningServices.Models.VMTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VnetConfiguration
    {
        public VnetConfiguration() { }
        public string SubnetName { get { throw null; } set { } }
        public string VnetName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebServiceState : System.IEquatable<Azure.ResourceManager.MachineLearningServices.Models.WebServiceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebServiceState(string value) { throw null; }
        public static Azure.ResourceManager.MachineLearningServices.Models.WebServiceState Failed { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.WebServiceState Healthy { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.WebServiceState Transitioning { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.WebServiceState Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.MachineLearningServices.Models.WebServiceState Unschedulable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MachineLearningServices.Models.WebServiceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MachineLearningServices.Models.WebServiceState left, Azure.ResourceManager.MachineLearningServices.Models.WebServiceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MachineLearningServices.Models.WebServiceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MachineLearningServices.Models.WebServiceState left, Azure.ResourceManager.MachineLearningServices.Models.WebServiceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Workspace : Azure.ResourceManager.MachineLearningServices.Models.Resource
    {
        public Workspace() { }
        public bool? AllowPublicAccessWhenBehindVnet { get { throw null; } set { } }
        public string ApplicationInsights { get { throw null; } set { } }
        public string ContainerRegistry { get { throw null; } set { } }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DiscoveryUrl { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.EncryptionProperty Encryption { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public bool? HbiWorkspace { get { throw null; } set { } }
        public string ImageBuildCompute { get { throw null; } set { } }
        public string KeyVault { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.PrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public int? PrivateLinkCount { get { throw null; } }
        public Azure.ResourceManager.MachineLearningServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ServiceProvisionedResourceGroup { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MachineLearningServices.Models.SharedPrivateLinkResource> SharedPrivateLinkResources { get { throw null; } }
        public string StorageAccount { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } }
    }
    public partial class WorkspaceConnection
    {
        internal WorkspaceConnection() { }
        public string AuthType { get { throw null; } }
        public string Category { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Target { get { throw null; } }
        public string Type { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class WorkspaceConnectionDto
    {
        public WorkspaceConnectionDto() { }
        public string AuthType { get { throw null; } set { } }
        public string Category { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class WorkspaceSku
    {
        internal WorkspaceSku() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.SKUCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.ResourceSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MachineLearningServices.Models.Restriction> Restrictions { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class WorkspaceUpdateParameters
    {
        public WorkspaceUpdateParameters() { }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.MachineLearningServices.Models.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
