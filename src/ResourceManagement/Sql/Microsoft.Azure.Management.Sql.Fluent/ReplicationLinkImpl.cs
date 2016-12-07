// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// Implementation for SqlServer and its parent interfaces.
    /// </summary>
    internal partial class ReplicationLinkImpl :
        Wrapper<Models.ReplicationLinkInner>,
        IReplicationLink
    {
        private IDatabasesOperations innerCollection;
        private ResourceId resourceId;

        public string ReplicationState()
        {
            return this.Inner.ReplicationState;
        }

        public ReplicationRole Role()
        {
            return this.Inner.Role.GetValueOrDefault();
        }

        public string ResourceGroupName()
        {
            return this.resourceId.ResourceGroupName;
        }

        public string DatabaseName()
        {
            return resourceId.Parent.Name;
        }

        public string SqlServerName()
        {
            return resourceId.Parent.Parent.Name;
        }

        public string PartnerServer()
        {
            return this.Inner.PartnerServer;
        }

        public ReplicationRole PartnerRole()
        {
            return this.Inner.PartnerRole.GetValueOrDefault();
        }

        public IReplicationLink Refresh()
        {
            this.SetInner(this.innerCollection.GetReplicationLink(
            this.ResourceGroupName(),
            this.SqlServerName(),
            this.DatabaseName(),
            this.Name()));

            return this;
        }

        public int PercentComplete()
        {
            return this.Inner.PercentComplete.GetValueOrDefault();
        }

        public void Delete()
        {
            this.innerCollection.DeleteReplicationLink(
            this.ResourceGroupName(),
            this.SqlServerName(),
            this.DatabaseName(),
            this.Name());
        }

        public void ForceFailoverAllowDataLoss()
        {
            this.innerCollection.FailoverReplicationLinkAllowDataLoss(
            this.ResourceGroupName(),
            this.SqlServerName(),
            this.DatabaseName(),
            this.Name());
        }

        internal ReplicationLinkImpl(ReplicationLinkInner innerObject, IDatabasesOperations innerCollection)
            : base(innerObject)
        {
            this.resourceId = ResourceId.ParseResourceId(this.Inner.Id);
            this.innerCollection = innerCollection;
        }

        public void Failover()
        {
            this.innerCollection.FailoverReplicationLink(
            this.ResourceGroupName(),
            this.SqlServerName(),
            this.DatabaseName(),
            this.Name());
        }

        public string PartnerDatabase()
        {
            return this.Inner.PartnerDatabase;
        }

        public string Name()
        {
            return this.resourceId.Name;
        }

        public DateTime StartTime()
        {
            return this.Inner.StartTime.GetValueOrDefault();
        }

        public string Id()
        {
            return this.resourceId.Id;
        }

        public string PartnerLocation()
        {
            return this.Inner.PartnerLocation;
        }
    }
}