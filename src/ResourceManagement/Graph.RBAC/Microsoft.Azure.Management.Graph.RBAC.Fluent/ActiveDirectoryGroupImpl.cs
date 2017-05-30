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
            //$ return inner().Mail();

            return null;
        }

                public GraphRbacManager Manager()
        {
            //$ return manager;

            return null;
        }

                internal  ActiveDirectoryGroupImpl(ADGroupInner innerModel, GraphRbacManager manager)
        {
            //$ super(innerModel);
            //$ this.manager = manager;
            //$ }

        }

                public string Name()
        {
            //$ return inner().DisplayName();

            return null;
        }

                public string Id()
        {
            //$ return inner().ObjectId();

            return null;
        }

                public bool SecurityEnabled()
        {
            //$ return Utils.ToPrimitiveBoolean(inner().SecurityEnabled());

            return false;
        }
    }
}