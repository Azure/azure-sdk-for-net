namespace Azure.Graph.Rbac
{
    public partial class ApplicationsClient
    {
        protected ApplicationsClient() { }
        public virtual Azure.Response AddOwner(string applicationObjectId, Azure.Graph.Rbac.Models.AddOwnerParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddOwnerAsync(string applicationObjectId, Azure.Graph.Rbac.Models.AddOwnerParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Graph.Rbac.Models.Application> Create(Azure.Graph.Rbac.Models.ApplicationCreateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Graph.Rbac.Models.Application>> CreateAsync(Azure.Graph.Rbac.Models.ApplicationCreateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string applicationObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string applicationObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Graph.Rbac.Models.Application> Get(string applicationObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Graph.Rbac.Models.Application>> GetAsync(string applicationObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Graph.Rbac.Models.ServicePrincipalObjectResult> GetServicePrincipalsIdByAppId(string applicationID, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Graph.Rbac.Models.ServicePrincipalObjectResult>> GetServicePrincipalsIdByAppIdAsync(string applicationID, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.Application> List(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.Application> ListAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.KeyCredential> ListKeyCredentials(string applicationObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.KeyCredential> ListKeyCredentialsAsync(string applicationObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.Application> ListNext(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.Application> ListNextAsync(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.DirectoryObject> ListOwners(string applicationObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.DirectoryObject> ListOwnersAsync(string applicationObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.PasswordCredential> ListPasswordCredentials(string applicationObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.PasswordCredential> ListPasswordCredentialsAsync(string applicationObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Patch(string applicationObjectId, Azure.Graph.Rbac.Models.ApplicationUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PatchAsync(string applicationObjectId, Azure.Graph.Rbac.Models.ApplicationUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveOwner(string applicationObjectId, string ownerObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveOwnerAsync(string applicationObjectId, string ownerObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateKeyCredentials(string applicationObjectId, Azure.Graph.Rbac.Models.KeyCredentialsUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateKeyCredentialsAsync(string applicationObjectId, Azure.Graph.Rbac.Models.KeyCredentialsUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdatePasswordCredentials(string applicationObjectId, Azure.Graph.Rbac.Models.PasswordCredentialsUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdatePasswordCredentialsAsync(string applicationObjectId, Azure.Graph.Rbac.Models.PasswordCredentialsUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedApplicationsClient
    {
        protected DeletedApplicationsClient() { }
        public virtual Azure.Response HardDelete(string applicationObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HardDeleteAsync(string applicationObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.Application> List(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.Application> ListAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.Application> ListNext(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.Application> ListNextAsync(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Graph.Rbac.Models.Application> Restore(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Graph.Rbac.Models.Application>> RestoreAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DomainsClient
    {
        protected DomainsClient() { }
        public virtual Azure.Response<Azure.Graph.Rbac.Models.Domain> Get(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Graph.Rbac.Models.Domain>> GetAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.Domain> List(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.Domain> ListAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GroupsClient
    {
        protected GroupsClient() { }
        public virtual Azure.Response AddMember(string groupObjectId, Azure.Graph.Rbac.Models.GroupAddMemberParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddMemberAsync(string groupObjectId, Azure.Graph.Rbac.Models.GroupAddMemberParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddOwner(string objectId, Azure.Graph.Rbac.Models.AddOwnerParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddOwnerAsync(string objectId, Azure.Graph.Rbac.Models.AddOwnerParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Graph.Rbac.Models.ADGroup> Create(Azure.Graph.Rbac.Models.GroupCreateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Graph.Rbac.Models.ADGroup>> CreateAsync(Azure.Graph.Rbac.Models.GroupCreateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Graph.Rbac.Models.ADGroup> Get(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Graph.Rbac.Models.ADGroup>> GetAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.DirectoryObject> GetGroupMembers(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.DirectoryObject> GetGroupMembersAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.DirectoryObject> GetGroupMembersNext(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.DirectoryObject> GetGroupMembersNextAsync(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetMemberGroups(string objectId, Azure.Graph.Rbac.Models.GroupGetMemberGroupsParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetMemberGroupsAsync(string objectId, Azure.Graph.Rbac.Models.GroupGetMemberGroupsParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Graph.Rbac.Models.CheckGroupMembershipResult> IsMemberOf(Azure.Graph.Rbac.Models.CheckGroupMembershipParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Graph.Rbac.Models.CheckGroupMembershipResult>> IsMemberOfAsync(Azure.Graph.Rbac.Models.CheckGroupMembershipParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.ADGroup> List(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.ADGroup> ListAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.ADGroup> ListNext(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.ADGroup> ListNextAsync(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.DirectoryObject> ListOwners(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.DirectoryObject> ListOwnersAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveMember(string groupObjectId, string memberObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveMemberAsync(string groupObjectId, string memberObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveOwner(string objectId, string ownerObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveOwnerAsync(string objectId, string ownerObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OAuth2PermissionGrantClient
    {
        protected OAuth2PermissionGrantClient() { }
        public virtual Azure.Response<Azure.Graph.Rbac.Models.OAuth2PermissionGrant> Create(Azure.Graph.Rbac.Models.OAuth2PermissionGrant body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Graph.Rbac.Models.OAuth2PermissionGrant>> CreateAsync(Azure.Graph.Rbac.Models.OAuth2PermissionGrant body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.OAuth2PermissionGrant> List(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.OAuth2PermissionGrant> ListAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.OAuth2PermissionGrant> ListNext(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.OAuth2PermissionGrant> ListNextAsync(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ObjectsClient
    {
        protected ObjectsClient() { }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.DirectoryObject> GetObjectsByObjectIds(Azure.Graph.Rbac.Models.GetObjectsParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.DirectoryObject> GetObjectsByObjectIdsAsync(Azure.Graph.Rbac.Models.GetObjectsParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.DirectoryObject> GetObjectsByObjectIdsNext(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.DirectoryObject> GetObjectsByObjectIdsNextAsync(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RbacManagementClient
    {
        protected RbacManagementClient() { }
        public RbacManagementClient(string tenantID, Azure.Core.TokenCredential tokenCredential, Azure.Graph.Rbac.RbacManagementClientOptions options = null) { }
        public RbacManagementClient(string tenantID, System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Graph.Rbac.RbacManagementClientOptions options = null) { }
        public virtual Azure.Graph.Rbac.ApplicationsClient GetApplicationsClient() { throw null; }
        public virtual Azure.Graph.Rbac.DeletedApplicationsClient GetDeletedApplicationsClient() { throw null; }
        public virtual Azure.Graph.Rbac.DomainsClient GetDomainsClient() { throw null; }
        public virtual Azure.Graph.Rbac.GroupsClient GetGroupsClient() { throw null; }
        public virtual Azure.Graph.Rbac.OAuth2PermissionGrantClient GetOAuth2PermissionGrantClient() { throw null; }
        public virtual Azure.Graph.Rbac.ObjectsClient GetObjectsClient() { throw null; }
        public virtual Azure.Graph.Rbac.ServicePrincipalsClient GetServicePrincipalsClient() { throw null; }
        public virtual Azure.Graph.Rbac.SignedInUserClient GetSignedInUserClient() { throw null; }
        public virtual Azure.Graph.Rbac.UsersClient GetUsersClient() { throw null; }
    }
    public partial class RbacManagementClientOptions : Azure.Core.ClientOptions
    {
        public RbacManagementClientOptions() { }
    }
    public partial class ServicePrincipalsClient
    {
        protected ServicePrincipalsClient() { }
        public virtual Azure.Response<Azure.Graph.Rbac.Models.ServicePrincipal> Create(Azure.Graph.Rbac.Models.ServicePrincipalCreateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Graph.Rbac.Models.ServicePrincipal>> CreateAsync(Azure.Graph.Rbac.Models.ServicePrincipalCreateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Graph.Rbac.Models.ServicePrincipal> Get(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Graph.Rbac.Models.ServicePrincipal>> GetAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.ServicePrincipal> List(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.ServicePrincipal> ListAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.KeyCredential> ListKeyCredentials(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.KeyCredential> ListKeyCredentialsAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.ServicePrincipal> ListNext(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.ServicePrincipal> ListNextAsync(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.DirectoryObject> ListOwners(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.DirectoryObject> ListOwnersAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.PasswordCredential> ListPasswordCredentials(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.PasswordCredential> ListPasswordCredentialsAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(string objectId, Azure.Graph.Rbac.Models.ServicePrincipalBase parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string objectId, Azure.Graph.Rbac.Models.ServicePrincipalBase parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateKeyCredentials(string objectId, Azure.Graph.Rbac.Models.KeyCredentialsUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateKeyCredentialsAsync(string objectId, Azure.Graph.Rbac.Models.KeyCredentialsUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdatePasswordCredentials(string objectId, Azure.Graph.Rbac.Models.PasswordCredentialsUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdatePasswordCredentialsAsync(string objectId, Azure.Graph.Rbac.Models.PasswordCredentialsUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SignedInUserClient
    {
        protected SignedInUserClient() { }
        public virtual Azure.Response<Azure.Graph.Rbac.Models.User> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Graph.Rbac.Models.User>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.DirectoryObject> ListOwnedObjects(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.DirectoryObject> ListOwnedObjectsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.DirectoryObject> ListOwnedObjectsNext(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.DirectoryObject> ListOwnedObjectsNextAsync(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UsersClient
    {
        protected UsersClient() { }
        public virtual Azure.Response<Azure.Graph.Rbac.Models.User> Create(Azure.Graph.Rbac.Models.UserCreateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Graph.Rbac.Models.User>> CreateAsync(Azure.Graph.Rbac.Models.UserCreateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string upnOrObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string upnOrObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Graph.Rbac.Models.User> Get(string upnOrObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Graph.Rbac.Models.User>> GetAsync(string upnOrObjectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetMemberGroups(string objectId, Azure.Graph.Rbac.Models.UserGetMemberGroupsParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetMemberGroupsAsync(string objectId, Azure.Graph.Rbac.Models.UserGetMemberGroupsParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.User> List(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.User> ListAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Graph.Rbac.Models.User> ListNext(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Graph.Rbac.Models.User> ListNextAsync(string nextLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(string upnOrObjectId, Azure.Graph.Rbac.Models.UserUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string upnOrObjectId, Azure.Graph.Rbac.Models.UserUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Graph.Rbac.Models
{
    public partial class AddOwnerParameters : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public AddOwnerParameters(string url) { }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public string Url { get { throw null; } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class ADGroup : Azure.Graph.Rbac.Models.DirectoryObject
    {
        internal ADGroup() { }
        public string DisplayName { get { throw null; } }
        public string Mail { get { throw null; } }
        public bool? MailEnabled { get { throw null; } }
        public string MailNickname { get { throw null; } }
        public bool? SecurityEnabled { get { throw null; } }
    }
    public partial class Application : Azure.Graph.Rbac.Models.DirectoryObject
    {
        internal Application() { }
        public bool? AllowGuestsSignIn { get { throw null; } }
        public bool? AllowPassthroughUsers { get { throw null; } }
        public string AppId { get { throw null; } }
        public string AppLogoUrl { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AppPermissions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.AppRole> AppRoles { get { throw null; } }
        public bool? AvailableToOtherTenants { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string ErrorUrl { get { throw null; } }
        public Azure.Graph.Rbac.Models.GroupMembershipClaimTypes? GroupMembershipClaims { get { throw null; } }
        public string Homepage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IdentifierUris { get { throw null; } }
        public Azure.Graph.Rbac.Models.InformationalUrl InformationalUrls { get { throw null; } }
        public bool? IsDeviceOnlyAuthSupported { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.KeyCredential> KeyCredentials { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> KnownClientApplications { get { throw null; } }
        public string LogoutUrl { get { throw null; } }
        public bool? Oauth2AllowImplicitFlow { get { throw null; } }
        public bool? Oauth2AllowUrlPathMatching { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.OAuth2Permission> Oauth2Permissions { get { throw null; } }
        public bool? Oauth2RequirePostResponse { get { throw null; } }
        public Azure.Graph.Rbac.Models.OptionalClaims OptionalClaims { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> OrgRestrictions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.PasswordCredential> PasswordCredentials { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.PreAuthorizedApplication> PreAuthorizedApplications { get { throw null; } }
        public bool? PublicClient { get { throw null; } }
        public string PublisherDomain { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReplyUrls { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.RequiredResourceAccess> RequiredResourceAccess { get { throw null; } }
        public string SamlMetadataUrl { get { throw null; } }
        public string SignInAudience { get { throw null; } }
        public string WwwHomepage { get { throw null; } }
    }
    public partial class ApplicationBase
    {
        public ApplicationBase() { }
        public bool? AllowGuestsSignIn { get { throw null; } set { } }
        public bool? AllowPassthroughUsers { get { throw null; } set { } }
        public string AppLogoUrl { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AppPermissions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Graph.Rbac.Models.AppRole> AppRoles { get { throw null; } set { } }
        public bool? AvailableToOtherTenants { get { throw null; } set { } }
        public string ErrorUrl { get { throw null; } set { } }
        public Azure.Graph.Rbac.Models.GroupMembershipClaimTypes? GroupMembershipClaims { get { throw null; } set { } }
        public string Homepage { get { throw null; } set { } }
        public Azure.Graph.Rbac.Models.InformationalUrl InformationalUrls { get { throw null; } set { } }
        public bool? IsDeviceOnlyAuthSupported { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Graph.Rbac.Models.KeyCredential> KeyCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> KnownClientApplications { get { throw null; } set { } }
        public string LogoutUrl { get { throw null; } set { } }
        public bool? Oauth2AllowImplicitFlow { get { throw null; } set { } }
        public bool? Oauth2AllowUrlPathMatching { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Graph.Rbac.Models.OAuth2Permission> Oauth2Permissions { get { throw null; } set { } }
        public bool? Oauth2RequirePostResponse { get { throw null; } set { } }
        public Azure.Graph.Rbac.Models.OptionalClaims OptionalClaims { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> OrgRestrictions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Graph.Rbac.Models.PasswordCredential> PasswordCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Graph.Rbac.Models.PreAuthorizedApplication> PreAuthorizedApplications { get { throw null; } set { } }
        public bool? PublicClient { get { throw null; } set { } }
        public string PublisherDomain { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ReplyUrls { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Graph.Rbac.Models.RequiredResourceAccess> RequiredResourceAccess { get { throw null; } set { } }
        public string SamlMetadataUrl { get { throw null; } set { } }
        public string SignInAudience { get { throw null; } set { } }
        public string WwwHomepage { get { throw null; } set { } }
    }
    public partial class ApplicationCreateParameters : Azure.Graph.Rbac.Models.ApplicationBase
    {
        public ApplicationCreateParameters(string displayName) { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IList<string> IdentifierUris { get { throw null; } set { } }
    }
    public partial class ApplicationListResult
    {
        internal ApplicationListResult() { }
        public string OdataNextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.Application> Value { get { throw null; } }
    }
    public partial class ApplicationUpdateParameters : Azure.Graph.Rbac.Models.ApplicationBase
    {
        public ApplicationUpdateParameters() { }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IdentifierUris { get { throw null; } set { } }
    }
    public partial class AppRole
    {
        public AppRole() { }
        public System.Collections.Generic.IList<string> AllowedMemberTypes { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class CheckGroupMembershipParameters : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public CheckGroupMembershipParameters(string groupId, string memberId) { }
        public string GroupId { get { throw null; } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public string MemberId { get { throw null; } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class CheckGroupMembershipResult : System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyDictionary<string, object>, System.Collections.IEnumerable
    {
        internal CheckGroupMembershipResult() { }
        public object this[string key] { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Keys { get { throw null; } }
        int System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        public bool? Value { get { throw null; } }
        public System.Collections.Generic.IEnumerable<object> Values { get { throw null; } }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsentType : System.IEquatable<Azure.Graph.Rbac.Models.ConsentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsentType(string value) { throw null; }
        public static Azure.Graph.Rbac.Models.ConsentType AllPrincipals { get { throw null; } }
        public static Azure.Graph.Rbac.Models.ConsentType Principal { get { throw null; } }
        public bool Equals(Azure.Graph.Rbac.Models.ConsentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Graph.Rbac.Models.ConsentType left, Azure.Graph.Rbac.Models.ConsentType right) { throw null; }
        public static implicit operator Azure.Graph.Rbac.Models.ConsentType (string value) { throw null; }
        public static bool operator !=(Azure.Graph.Rbac.Models.ConsentType left, Azure.Graph.Rbac.Models.ConsentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DirectoryObject : System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyDictionary<string, object>, System.Collections.IEnumerable
    {
        internal DirectoryObject() { }
        public System.DateTimeOffset? DeletionTimestamp { get { throw null; } }
        public object this[string key] { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Keys { get { throw null; } }
        public string ObjectId { get { throw null; } }
        int System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        public System.Collections.Generic.IEnumerable<object> Values { get { throw null; } }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class DirectoryObjectListResult
    {
        internal DirectoryObjectListResult() { }
        public string OdataNextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.DirectoryObject> Value { get { throw null; } }
    }
    public partial class Domain : System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyDictionary<string, object>, System.Collections.IEnumerable
    {
        internal Domain() { }
        public string AuthenticationType { get { throw null; } }
        public bool? IsDefault { get { throw null; } }
        public bool? IsVerified { get { throw null; } }
        public object this[string key] { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Keys { get { throw null; } }
        public string Name { get { throw null; } }
        int System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        public System.Collections.Generic.IEnumerable<object> Values { get { throw null; } }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class DomainListResult
    {
        internal DomainListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.Domain> Value { get { throw null; } }
    }
    public partial class GetObjectsParameters : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public GetObjectsParameters() { }
        public bool? IncludeDirectoryObjectReferences { get { throw null; } set { } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public System.Collections.Generic.IList<string> ObjectIds { get { throw null; } set { } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public System.Collections.Generic.IList<string> Types { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class GroupAddMemberParameters : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public GroupAddMemberParameters(string url) { }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public string Url { get { throw null; } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class GroupCreateParameters : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public GroupCreateParameters(string displayName, string mailNickname) { }
        public string DisplayName { get { throw null; } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public bool MailEnabled { get { throw null; } }
        public string MailNickname { get { throw null; } }
        public bool SecurityEnabled { get { throw null; } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class GroupGetMemberGroupsParameters : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public GroupGetMemberGroupsParameters(bool securityEnabledOnly) { }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public bool SecurityEnabledOnly { get { throw null; } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class GroupGetMemberGroupsResult
    {
        internal GroupGetMemberGroupsResult() { }
        public System.Collections.Generic.IReadOnlyList<string> Value { get { throw null; } }
    }
    public partial class GroupListResult
    {
        internal GroupListResult() { }
        public string OdataNextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.ADGroup> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GroupMembershipClaimTypes : System.IEquatable<Azure.Graph.Rbac.Models.GroupMembershipClaimTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GroupMembershipClaimTypes(string value) { throw null; }
        public static Azure.Graph.Rbac.Models.GroupMembershipClaimTypes All { get { throw null; } }
        public static Azure.Graph.Rbac.Models.GroupMembershipClaimTypes None { get { throw null; } }
        public static Azure.Graph.Rbac.Models.GroupMembershipClaimTypes SecurityGroup { get { throw null; } }
        public bool Equals(Azure.Graph.Rbac.Models.GroupMembershipClaimTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Graph.Rbac.Models.GroupMembershipClaimTypes left, Azure.Graph.Rbac.Models.GroupMembershipClaimTypes right) { throw null; }
        public static implicit operator Azure.Graph.Rbac.Models.GroupMembershipClaimTypes (string value) { throw null; }
        public static bool operator !=(Azure.Graph.Rbac.Models.GroupMembershipClaimTypes left, Azure.Graph.Rbac.Models.GroupMembershipClaimTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InformationalUrl
    {
        public InformationalUrl() { }
        public string Marketing { get { throw null; } set { } }
        public string Privacy { get { throw null; } set { } }
        public string Support { get { throw null; } set { } }
        public string TermsOfService { get { throw null; } set { } }
    }
    public partial class KeyCredential : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public KeyCredential() { }
        public string CustomKeyIdentifier { get { throw null; } set { } }
        public System.DateTimeOffset? EndDate { get { throw null; } set { } }
        public object this[string key] { get { throw null; } set { } }
        public string KeyId { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public System.DateTimeOffset? StartDate { get { throw null; } set { } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public string Type { get { throw null; } set { } }
        public string Usage { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class KeyCredentialListResult
    {
        internal KeyCredentialListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.KeyCredential> Value { get { throw null; } }
    }
    public partial class KeyCredentialsUpdateParameters
    {
        public KeyCredentialsUpdateParameters(System.Collections.Generic.IEnumerable<Azure.Graph.Rbac.Models.KeyCredential> value) { }
        public System.Collections.Generic.IList<Azure.Graph.Rbac.Models.KeyCredential> Value { get { throw null; } }
    }
    public partial class OAuth2Permission
    {
        public OAuth2Permission() { }
        public string AdminConsentDescription { get { throw null; } set { } }
        public string AdminConsentDisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public string UserConsentDescription { get { throw null; } set { } }
        public string UserConsentDisplayName { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class OAuth2PermissionGrant
    {
        public OAuth2PermissionGrant() { }
        public string ClientId { get { throw null; } set { } }
        public Azure.Graph.Rbac.Models.ConsentType? ConsentType { get { throw null; } set { } }
        public string ExpiryTime { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public string OdataType { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
    }
    public partial class OAuth2PermissionGrantListResult
    {
        internal OAuth2PermissionGrantListResult() { }
        public string OdataNextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.OAuth2PermissionGrant> Value { get { throw null; } }
    }
    public partial class OptionalClaim
    {
        public OptionalClaim() { }
        public object AdditionalProperties { get { throw null; } set { } }
        public bool? Essential { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
    }
    public partial class OptionalClaims
    {
        public OptionalClaims() { }
        public System.Collections.Generic.IList<Azure.Graph.Rbac.Models.OptionalClaim> AccessToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Graph.Rbac.Models.OptionalClaim> IdToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Graph.Rbac.Models.OptionalClaim> SamlToken { get { throw null; } set { } }
    }
    public partial class PasswordCredential : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public PasswordCredential() { }
        public byte[] CustomKeyIdentifier { get { throw null; } set { } }
        public System.DateTimeOffset? EndDate { get { throw null; } set { } }
        public object this[string key] { get { throw null; } set { } }
        public string KeyId { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public System.DateTimeOffset? StartDate { get { throw null; } set { } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public string Value { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class PasswordCredentialListResult
    {
        internal PasswordCredentialListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.PasswordCredential> Value { get { throw null; } }
    }
    public partial class PasswordCredentialsUpdateParameters
    {
        public PasswordCredentialsUpdateParameters(System.Collections.Generic.IEnumerable<Azure.Graph.Rbac.Models.PasswordCredential> value) { }
        public System.Collections.Generic.IList<Azure.Graph.Rbac.Models.PasswordCredential> Value { get { throw null; } }
    }
    public partial class PasswordProfile : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public PasswordProfile(string password) { }
        public bool? ForceChangePasswordNextLogin { get { throw null; } set { } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public string Password { get { throw null; } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class PreAuthorizedApplication
    {
        public PreAuthorizedApplication() { }
        public string AppId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Graph.Rbac.Models.PreAuthorizedApplicationExtension> Extensions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Graph.Rbac.Models.PreAuthorizedApplicationPermission> Permissions { get { throw null; } set { } }
    }
    public partial class PreAuthorizedApplicationExtension
    {
        public PreAuthorizedApplicationExtension() { }
        public System.Collections.Generic.IList<string> Conditions { get { throw null; } set { } }
    }
    public partial class PreAuthorizedApplicationPermission
    {
        public PreAuthorizedApplicationPermission() { }
        public System.Collections.Generic.IList<string> AccessGrants { get { throw null; } set { } }
        public bool? DirectAccessGrant { get { throw null; } set { } }
    }
    public partial class RequiredResourceAccess : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public RequiredResourceAccess(System.Collections.Generic.IEnumerable<Azure.Graph.Rbac.Models.ResourceAccess> resourceAccess) { }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Graph.Rbac.Models.ResourceAccess> ResourceAccess { get { throw null; } }
        public string ResourceAppId { get { throw null; } set { } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class ResourceAccess : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public ResourceAccess(string id) { }
        public string Id { get { throw null; } set { } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public string Type { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class ServicePrincipal : Azure.Graph.Rbac.Models.DirectoryObject
    {
        internal ServicePrincipal() { }
        public bool? AccountEnabled { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AlternativeNames { get { throw null; } }
        public string AppDisplayName { get { throw null; } }
        public string AppId { get { throw null; } }
        public string AppOwnerTenantId { get { throw null; } }
        public bool? AppRoleAssignmentRequired { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.AppRole> AppRoles { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string ErrorUrl { get { throw null; } }
        public string Homepage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.KeyCredential> KeyCredentials { get { throw null; } }
        public string LogoutUrl { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.OAuth2Permission> Oauth2Permissions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.PasswordCredential> PasswordCredentials { get { throw null; } }
        public string PreferredTokenSigningKeyThumbprint { get { throw null; } }
        public string PublisherName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReplyUrls { get { throw null; } }
        public string SamlMetadataUrl { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ServicePrincipalNames { get { throw null; } }
        public string ServicePrincipalType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Tags { get { throw null; } }
    }
    public partial class ServicePrincipalBase
    {
        public ServicePrincipalBase() { }
        public bool? AccountEnabled { get { throw null; } set { } }
        public bool? AppRoleAssignmentRequired { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Graph.Rbac.Models.KeyCredential> KeyCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Graph.Rbac.Models.PasswordCredential> PasswordCredentials { get { throw null; } set { } }
        public string ServicePrincipalType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } set { } }
    }
    public partial class ServicePrincipalCreateParameters : Azure.Graph.Rbac.Models.ServicePrincipalBase
    {
        public ServicePrincipalCreateParameters(string appId) { }
        public string AppId { get { throw null; } }
    }
    public partial class ServicePrincipalListResult
    {
        internal ServicePrincipalListResult() { }
        public string OdataNextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.ServicePrincipal> Value { get { throw null; } }
    }
    public partial class ServicePrincipalObjectResult
    {
        internal ServicePrincipalObjectResult() { }
        public string OdataMetadata { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ServicePrincipalUpdateParameters : Azure.Graph.Rbac.Models.ServicePrincipalBase
    {
        public ServicePrincipalUpdateParameters() { }
    }
    public partial class SignInName : System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyDictionary<string, object>, System.Collections.IEnumerable
    {
        internal SignInName() { }
        public object this[string key] { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Keys { get { throw null; } }
        int System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        public string Type { get { throw null; } }
        public string Value { get { throw null; } }
        public System.Collections.Generic.IEnumerable<object> Values { get { throw null; } }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class User : Azure.Graph.Rbac.Models.DirectoryObject
    {
        internal User() { }
        public bool? AccountEnabled { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string GivenName { get { throw null; } }
        public string ImmutableId { get { throw null; } }
        public string Mail { get { throw null; } }
        public string MailNickname { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.SignInName> SignInNames { get { throw null; } }
        public string Surname { get { throw null; } }
        public string UsageLocation { get { throw null; } }
        public string UserPrincipalName { get { throw null; } }
        public Azure.Graph.Rbac.Models.UserType? UserType { get { throw null; } }
    }
    public partial class UserBase : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public UserBase() { }
        public string GivenName { get { throw null; } set { } }
        public string ImmutableId { get { throw null; } set { } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public string Surname { get { throw null; } set { } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public string UsageLocation { get { throw null; } set { } }
        public Azure.Graph.Rbac.Models.UserType? UserType { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class UserCreateParameters : Azure.Graph.Rbac.Models.UserBase
    {
        public UserCreateParameters(bool accountEnabled, string displayName, Azure.Graph.Rbac.Models.PasswordProfile passwordProfile, string userPrincipalName, string mailNickname) { }
        public bool AccountEnabled { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Mail { get { throw null; } set { } }
        public string MailNickname { get { throw null; } }
        public Azure.Graph.Rbac.Models.PasswordProfile PasswordProfile { get { throw null; } }
        public string UserPrincipalName { get { throw null; } }
    }
    public partial class UserGetMemberGroupsParameters : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public UserGetMemberGroupsParameters(bool securityEnabledOnly) { }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public bool SecurityEnabledOnly { get { throw null; } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class UserGetMemberGroupsResult
    {
        internal UserGetMemberGroupsResult() { }
        public System.Collections.Generic.IReadOnlyList<string> Value { get { throw null; } }
    }
    public partial class UserListResult
    {
        internal UserListResult() { }
        public string OdataNextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Graph.Rbac.Models.User> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UserType : System.IEquatable<Azure.Graph.Rbac.Models.UserType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UserType(string value) { throw null; }
        public static Azure.Graph.Rbac.Models.UserType Guest { get { throw null; } }
        public static Azure.Graph.Rbac.Models.UserType Member { get { throw null; } }
        public bool Equals(Azure.Graph.Rbac.Models.UserType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Graph.Rbac.Models.UserType left, Azure.Graph.Rbac.Models.UserType right) { throw null; }
        public static implicit operator Azure.Graph.Rbac.Models.UserType (string value) { throw null; }
        public static bool operator !=(Azure.Graph.Rbac.Models.UserType left, Azure.Graph.Rbac.Models.UserType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserUpdateParameters : Azure.Graph.Rbac.Models.UserBase
    {
        public UserUpdateParameters() { }
        public bool? AccountEnabled { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string MailNickname { get { throw null; } set { } }
        public Azure.Graph.Rbac.Models.PasswordProfile PasswordProfile { get { throw null; } set { } }
        public string UserPrincipalName { get { throw null; } set { } }
    }
}
