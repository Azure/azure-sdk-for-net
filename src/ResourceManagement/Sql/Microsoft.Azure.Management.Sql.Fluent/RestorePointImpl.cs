// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// Implementation for Restore point interface.
    /// </summary>
    internal partial class RestorePointImpl :
        Wrapper<Models.RestorePointInner>,
        IRestorePoint
    {
        private ResourceId resourceId;

        internal RestorePointImpl(RestorePointInner innerObject)
            : base(innerObject)
        {
            this.resourceId = ResourceId.ParseResourceId(this.Inner.Id);
        }

        public string ResourceGroupName()
        {
            return this.resourceId.ResourceGroupName;
        }

        public string DatabaseName()
        {
            return resourceId.Parent.Name;
        }

        public DateTime RestorePointCreationDate()
        {
            return this.Inner.RestorePointCreationDate.GetValueOrDefault();
        }

        public string SqlServerName()
        {
            return resourceId.Parent.Parent.Name;
        }

        public string Name()
        {
            return this.resourceId.Name;
        }

        public string Id()
        {
            return this.resourceId.Id;
        }

        public RestorePointTypes RestorePointType()
        {
            return this.Inner.RestorePointType.GetValueOrDefault();
        }

        public DateTime EarliestRestoreDate()
        {
            return this.Inner.EarliestRestoreDate.GetValueOrDefault();
        }
    }
}