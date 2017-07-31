// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryGroup.Update;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    public partial class ActiveDirectoryGroupImpl 
    {
        /// <summary>
        /// Lists the members in the group.
        /// </summary>
        /// <return>An unmodifiable set of the members.</return>
        async Task<IPagedCollection<IActiveDirectoryObject>> Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup.ListMembersAsync(CancellationToken cancellationToken)
        {
            return await this.ListMembersAsync(cancellationToken) as IPagedCollection<IActiveDirectoryObject>;
        }

        /// <summary>
        /// Gets security enabled field.
        /// </summary>
        bool Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup.SecurityEnabled
        {
            get
            {
                return this.SecurityEnabled();
            }
        }

        /// <summary>
        /// Gets mail field.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup.Mail
        {
            get
            {
                return this.Mail();
            }
        }

        /// <summary>
        /// Lists the members in the group.
        /// </summary>
        /// <return>An unmodifiable set of the members.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryObject> Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup.ListMembers()
        {
            return this.ListMembers() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryObject>;
        }

        /// <summary>
        /// Add a member based on its object id. The member can be a user, a group, a service principal, or an application.
        /// </summary>
        /// <param name="objectId">The Active Directory object's id.</param>
        /// <return>The next AD Group definition stage.</return>
        ActiveDirectoryGroup.Definition.IWithCreate ActiveDirectoryGroup.Definition.IWithMemberBeta.WithMember(string objectId)
        {
            return this.WithMember(objectId) as ActiveDirectoryGroup.Definition.IWithCreate;
        }

        /// <summary>
        /// Adds a user as a member in the group.
        /// </summary>
        /// <param name="user">The Active Directory user to add.</param>
        /// <return>The next AD group definition stage.</return>
        ActiveDirectoryGroup.Definition.IWithCreate ActiveDirectoryGroup.Definition.IWithMemberBeta.WithMember(IActiveDirectoryUser user)
        {
            return this.WithMember(user) as ActiveDirectoryGroup.Definition.IWithCreate;
        }

        /// <summary>
        /// Adds a group as a member in the group.
        /// </summary>
        /// <param name="group">The Active Directory group to add.</param>
        /// <return>The next AD group definition stage.</return>
        ActiveDirectoryGroup.Definition.IWithCreate ActiveDirectoryGroup.Definition.IWithMemberBeta.WithMember(IActiveDirectoryGroup group)
        {
            return this.WithMember(group) as ActiveDirectoryGroup.Definition.IWithCreate;
        }

        /// <summary>
        /// Adds a service principal as a member in the group.
        /// </summary>
        /// <param name="servicePrincipal">The service principal to add.</param>
        /// <return>The next AD group definition stage.</return>
        ActiveDirectoryGroup.Definition.IWithCreate ActiveDirectoryGroup.Definition.IWithMemberBeta.WithMember(IServicePrincipal servicePrincipal)
        {
            return this.WithMember(servicePrincipal) as ActiveDirectoryGroup.Definition.IWithCreate;
        }

        /// <summary>
        /// Adds a member based on its object id. The member can be a user, a group, a service principal, or an application.
        /// </summary>
        /// <param name="objectId">The Active Directory object's id.</param>
        /// <return>The next AD Group update stage.</return>
        ActiveDirectoryGroup.Update.IUpdate ActiveDirectoryGroup.Update.IWithMemberBeta.WithMember(string objectId)
        {
            return this.WithMember(objectId) as ActiveDirectoryGroup.Update.IUpdate;
        }

        /// <summary>
        /// Adds a user as a member in the group.
        /// </summary>
        /// <param name="user">The Active Directory user to add.</param>
        /// <return>The next AD group update stage.</return>
        ActiveDirectoryGroup.Update.IUpdate ActiveDirectoryGroup.Update.IWithMemberBeta.WithMember(IActiveDirectoryUser user)
        {
            return this.WithMember(user) as ActiveDirectoryGroup.Update.IUpdate;
        }

        /// <summary>
        /// Adds a group as a member in the group.
        /// </summary>
        /// <param name="group">The Active Directory group to add.</param>
        /// <return>The next AD group update stage.</return>
        ActiveDirectoryGroup.Update.IUpdate ActiveDirectoryGroup.Update.IWithMemberBeta.WithMember(IActiveDirectoryGroup group)
        {
            return this.WithMember(group) as ActiveDirectoryGroup.Update.IUpdate;
        }

        /// <summary>
        /// Adds a service principal as a member in the group.
        /// </summary>
        /// <param name="servicePrincipal">The service principal to add.</param>
        /// <return>The next AD group update stage.</return>
        ActiveDirectoryGroup.Update.IUpdate ActiveDirectoryGroup.Update.IWithMemberBeta.WithMember(IServicePrincipal servicePrincipal)
        {
            return this.WithMember(servicePrincipal) as ActiveDirectoryGroup.Update.IUpdate;
        }

        /// <summary>
        /// Removes a member based on its object id.
        /// </summary>
        /// <param name="objectId">The Active Directory object's id.</param>
        /// <return>The next AD Group update stage.</return>
        ActiveDirectoryGroup.Update.IUpdate ActiveDirectoryGroup.Update.IWithMemberBeta.WithoutMember(string objectId)
        {
            return this.WithoutMember(objectId) as ActiveDirectoryGroup.Update.IUpdate;
        }

        /// <summary>
        /// Removes a user as a member in the group.
        /// </summary>
        /// <param name="user">The Active Directory user to remove.</param>
        /// <return>The next AD group update stage.</return>
        ActiveDirectoryGroup.Update.IUpdate ActiveDirectoryGroup.Update.IWithMemberBeta.WithoutMember(IActiveDirectoryUser user)
        {
            return this.WithoutMember(user) as ActiveDirectoryGroup.Update.IUpdate;
        }

        /// <summary>
        /// Removes a group as a member in the group.
        /// </summary>
        /// <param name="group">The Active Directory group to remove.</param>
        /// <return>The next AD group update stage.</return>
        ActiveDirectoryGroup.Update.IUpdate ActiveDirectoryGroup.Update.IWithMemberBeta.WithoutMember(IActiveDirectoryGroup group)
        {
            return this.WithoutMember(group) as ActiveDirectoryGroup.Update.IUpdate;
        }

        /// <summary>
        /// Removes a service principal as a member in the group.
        /// </summary>
        /// <param name="servicePrincipal">The service principal to remove.</param>
        /// <return>The next AD group update stage.</return>
        ActiveDirectoryGroup.Update.IUpdate ActiveDirectoryGroup.Update.IWithMemberBeta.WithoutMember(IServicePrincipal servicePrincipal)
        {
            return this.WithoutMember(servicePrincipal) as ActiveDirectoryGroup.Update.IUpdate;
        }

        ActiveDirectoryGroup.Definition.IWithCreate ActiveDirectoryGroup.Definition.IWithEmailAliasBeta.WithEmailAlias(string mailNickname)
        {
            return this.WithEmailAlias(mailNickname) as ActiveDirectoryGroup.Definition.IWithCreate;
        }
    }
}