namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class SynapseAccessControlClient
    {
        protected SynapseAccessControlClient() { }
        public SynapseAccessControlClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.AccessControl.SynapseAdministrationClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CheckPrincipalAccess(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckPrincipalAccessAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response CreateRoleAssignment(string roleAssignmentId, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateRoleAssignmentAsync(string roleAssignmentId, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteRoleAssignmentById(string roleAssignmentId, string scope = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoleAssignmentByIdAsync(string roleAssignmentId, string scope = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetRoleAssignmentById(string roleAssignmentId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRoleAssignmentByIdAsync(string roleAssignmentId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetRoleDefinitionById(string roleDefinitionId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRoleDefinitionByIdAsync(string roleDefinitionId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response ListRoleAssignments(string roleId = null, string principalId = null, string scope = null, string continuationToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListRoleAssignmentsAsync(string roleId = null, string principalId = null, string scope = null, string continuationToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response ListRoleDefinitions(bool? isBuiltIn = default(bool?), string scope = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListRoleDefinitionsAsync(bool? isBuiltIn = default(bool?), string scope = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response ListScopes(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListScopesAsync(Azure.RequestOptions options = null) { throw null; }
    }
    public partial class SynapseAdministrationClientOptions : Azure.Core.ClientOptions
    {
        public SynapseAdministrationClientOptions(Azure.Analytics.Synapse.AccessControl.SynapseAdministrationClientOptions.ServiceVersion version = Azure.Analytics.Synapse.AccessControl.SynapseAdministrationClientOptions.ServiceVersion.V2020_08_01_preview) { }
        public enum ServiceVersion
        {
            V2020_08_01_preview = 1,
        }
    }
}
