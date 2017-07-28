// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Newtonsoft.Json;
    using Microsoft.Rest.Serialization;

    /// <summary>
    /// Implementation for Group and its parent interfaces.
    /// </summary>
    public partial class ActiveDirectoryGroupImpl  :
        CreatableUpdatable<IActiveDirectoryGroup, ADGroupInner, ActiveDirectoryGroupImpl, IHasId, ActiveDirectoryGroup.Update.IUpdate>,
        IActiveDirectoryGroup,
        ActiveDirectoryGroup.Definition.IDefinition,
        ActiveDirectoryGroup.Update.IUpdate
    {
        private GraphRbacManager manager;
        private GroupCreateParametersInner createParameters;
        private ISet<string> memebersToAdd;
        private ISet<string> membersToRemove;

        string IHasId.Id => Inner.ObjectId;

        GraphRbacManager IHasManager<GraphRbacManager>.Manager => throw new NotImplementedException();

        public string Mail()
        {
            return Inner.Mail;
        }

                public GraphRbacManager Manager()
        {
            return manager;
        }

                internal  ActiveDirectoryGroupImpl(ADGroupInner innerModel, GraphRbacManager manager)
                    : base(innerModel.DisplayName, innerModel)
        {
            this.manager = manager;
        }

                public string Id()
        {
            return Inner.ObjectId;
        }

                public bool SecurityEnabled()
        {
            return Inner.SecurityEnabled ?? false;
        }

        public IEnumerable<IActiveDirectoryObject> ListMembers()
        {
            return manager.Inner.Groups.GetGroupMembers(Id()).Select(t => WrapObjectInner(t));
        }

        public async Task<IPagedCollection<IActiveDirectoryObject>> ListMembersAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IActiveDirectoryObject, AADObjectInner>.LoadPage(
                async (cancellation) => await manager.Inner.Groups.GetGroupMembersAsync(Id(), cancellation),
                manager.Inner.Groups.GetGroupMembersNextAsync,
                (inner) => WrapObjectInner(inner), true, cancellationToken);
        }

        private IActiveDirectoryObject WrapObjectInner(AADObjectInner inner)
        {
            String serialized = SafeJsonConvert.SerializeObject(inner);
            switch (inner.ObjectType)
            {
                case "User":
                    UserInner user = SafeJsonConvert.DeserializeObject<UserInner>(serialized);
                    return new ActiveDirectoryUserImpl(user, manager);
                case "Group":
                    ADGroupInner group = SafeJsonConvert.DeserializeObject<ADGroupInner>(serialized);
                    return new ActiveDirectoryGroupImpl(group, manager);
                case "ServicePrincipal":
                    ServicePrincipalInner sp = SafeJsonConvert.DeserializeObject<ServicePrincipalInner>(serialized);
                    return new ServicePrincipalImpl(sp, manager);
                case "Application":
                    ApplicationInner app = SafeJsonConvert.DeserializeObject<ApplicationInner>(serialized);
                    return new ActiveDirectoryApplicationImpl(app, manager);
                default:
                    return null;
            }
        }

        public override Task<IActiveDirectoryGroup> CreateResourceAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<ADGroupInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return manager.Inner.Groups.GetAsync(Id(), cancellationToken);
        }
    }
}