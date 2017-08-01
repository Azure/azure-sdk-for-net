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
    public partial class ActiveDirectoryGroupImpl :
        CreatableUpdatable<IActiveDirectoryGroup, ADGroupInner, ActiveDirectoryGroupImpl, IHasId, ActiveDirectoryGroup.Update.IUpdate>,
        IActiveDirectoryGroup,
        ActiveDirectoryGroup.Definition.IDefinition,
        ActiveDirectoryGroup.Update.IUpdate
    {
        private GraphRbacManager manager;
        private GroupCreateParametersInner createParameters;
        private ISet<string> membersToAdd;
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

        internal ActiveDirectoryGroupImpl(ADGroupInner innerModel, GraphRbacManager manager)
            : base(innerModel.DisplayName, innerModel)
        {
            this.manager = manager;
            this.createParameters = new GroupCreateParametersInner
            {
                DisplayName = innerModel.DisplayName
            };
            membersToAdd = new HashSet<string>();
            membersToRemove = new HashSet<string>();
        }

        public string Id()
        {
            return Inner.ObjectId;
        }

        public bool SecurityEnabled()
        {
            return Inner.SecurityEnabled ?? false;
        }

        public ActiveDirectoryGroupImpl WithEmailAlias(String mailNickname)
        {
            // User providing domain
            if (mailNickname.Contains("@"))
            {
                string[] parts = mailNickname.Split(new char[] { '@' });
                mailNickname = parts[0];
            }
            createParameters.MailNickname = mailNickname;
            return this;
        }

        public ActiveDirectoryGroupImpl WithMember(string objectId)
        {
            membersToAdd.Add(string.Format("https://{0}/{1}/directoryObjects/{2}",
                manager.Inner.BaseUri.Host, manager.tenantId, objectId));
            return this;
        }

        public ActiveDirectoryGroupImpl WithMember(IActiveDirectoryUser user)
        {
            return WithMember(user.Id);
        }

        public ActiveDirectoryGroupImpl WithMember(IActiveDirectoryGroup group)
        {
            return WithMember(group.Id);
        }

        public ActiveDirectoryGroupImpl WithMember(IServicePrincipal servicePrincipal)
        {
            return WithMember(servicePrincipal.Id);
        }

        public ActiveDirectoryGroupImpl WithoutMember(string objectId)
        {
            membersToRemove.Add(objectId);
            return this;
        }

        public ActiveDirectoryGroupImpl WithoutMember(IActiveDirectoryUser user)
        {
            return WithoutMember(user.Id);
        }

        public ActiveDirectoryGroupImpl WithoutMember(IActiveDirectoryGroup group)
        {
            return WithoutMember(group.Id);
        }

        public ActiveDirectoryGroupImpl WithoutMember(IServicePrincipal servicePrincipal)
        {
            return WithoutMember(servicePrincipal.Id);
        }

        public IEnumerable<IActiveDirectoryObject> ListMembers()
        {
            return Extensions.Synchronize(() => manager.Inner.Groups.GetGroupMembersAsync(Id()))
                .AsContinuousCollection(link => Extensions.Synchronize(() => manager.Inner.Groups.GetGroupMembersNextAsync(link)))
                .Select(t => WrapObjectInner(t));
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

        public bool IsInCreateMode()
        {
            return Id() == null;
        }

        public override async Task<IActiveDirectoryGroup> CreateResourceAsync(CancellationToken cancellationToken)
        {
            if (IsInCreateMode())
            {
                ADGroupInner inner = await manager.Inner.Groups.CreateAsync(createParameters, cancellationToken);
                SetInner(inner);
            }

            if (membersToRemove.Count > 0)
            {
                foreach (string remove in membersToRemove)
                {
                    await manager.Inner.Groups.RemoveMemberAsync(Id(), remove, cancellationToken);
                }
                membersToRemove.Clear();
            }

            if (membersToAdd.Count > 0)
            {
                foreach (string add in membersToAdd)
                {
                    await manager.Inner.Groups.AddMemberAsync(Id(), new GroupAddMemberParametersInner
                    {
                        Url = add
                    }, cancellationToken);
                }
                membersToAdd.Clear();
            }

            return this;
        }

        protected override Task<ADGroupInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return manager.Inner.Groups.GetAsync(Id(), cancellationToken);
        }
    }
}