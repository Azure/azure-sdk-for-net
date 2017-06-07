// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for Group and its parent interfaces.
    /// </summary>
    public partial class ActiveDirectoryGroupImpl  :
        Wrapper<Models.ADGroupInner>,
        IActiveDirectoryGroup
    {
        private GraphRbacManager manager;
                public string Mail()
        {
            return Inner.Mail;
        }

                public GraphRbacManager Manager()
        {
            return manager;
        }

                internal  ActiveDirectoryGroupImpl(ADGroupInner innerModel, GraphRbacManager manager)
                    : base(innerModel)
        {
            this.manager = manager;
        }

                public string Name()
        {
            return Inner.DisplayName;
        }

                public string Id()
        {
            return Inner.ObjectId;
        }

                public bool SecurityEnabled()
        {
            return Inner.SecurityEnabled ?? false;
        }
    }
}