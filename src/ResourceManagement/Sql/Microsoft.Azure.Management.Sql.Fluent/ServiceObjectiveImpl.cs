// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    /// <summary>
    /// Implementation for Azure SQL Server's Service Objective.
    /// </summary>
    internal partial class ServiceObjectiveImpl :
        Wrapper<Models.ServiceObjectiveInner>,
        IServiceObjective
    {
        private ResourceId resourceId;
        private IServersOperations serversInner;

        public bool IsSystem()
        {
            return this.Inner.IsSystem.GetValueOrDefault();
        }

        public bool IsDefault()
        {
            return this.Inner.IsDefault.GetValueOrDefault();
        }

        public string ResourceGroupName()
        {
            return this.resourceId.ResourceGroupName;
        }

        public string SqlServerName()
        {
            return this.resourceId.Parent.Name;
        }

        public string Name()
        {
            return this.Inner.Name;
        }

        public string ServiceObjectiveName()
        {
            return this.Inner.ServiceObjectiveName;
        }

        public string Description()
        {
            return this.Inner.Description;
        }

        public IServiceObjective Refresh()
        {
            this.SetInner(this.serversInner.GetServiceObjective(this.ResourceGroupName(), this.SqlServerName(), this.Name()));
            return this;
        }

        public string Id()
        {
            return this.Inner.Id;
        }

        internal ServiceObjectiveImpl(ServiceObjectiveInner innerObject, IServersOperations serversInner)
            : base(innerObject)
        {
            this.resourceId = ResourceId.ParseResourceId(this.Inner.Id);
            this.serversInner = serversInner;
        }

        public bool Enabled()
        {
            return this.Inner.Enabled.GetValueOrDefault();
        }
    }
}