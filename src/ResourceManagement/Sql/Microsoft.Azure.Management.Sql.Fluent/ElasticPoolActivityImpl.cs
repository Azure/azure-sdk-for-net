// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// Implementation for Elastic Pool Activity interface.
    /// </summary>
    internal partial class ElasticPoolActivityImpl :
        Wrapper<Models.ElasticPoolActivityInner>,
        IElasticPoolActivity
    {
        private ResourceId resourceId;

        public string ElasticPoolName()
        {
            return this.Inner.ElasticPoolName;
        }

        public string ResourceGroupName()
        {
            return this.resourceId.ResourceGroupName;
        }

        public int RequestedDatabaseDtuMin()
        {
            return this.Inner.RequestedDatabaseDtuMin.GetValueOrDefault();
        }

        public string ErrorMessage()
        {
            return this.Inner.ErrorMessage;
        }

        public int ErrorSeverity()
        {
            return this.Inner.ErrorSeverity.GetValueOrDefault();
        }

        public int ErrorCode()
        {
            return this.Inner.ErrorCode.GetValueOrDefault();
        }

        public string ServerName()
        {
            return this.Inner.ServerName;
        }

        public int PercentComplete()
        {
            return this.Inner.PercentComplete.GetValueOrDefault();
        }

        public int RequestedDtu()
        {
            return this.Inner.RequestedDtu.GetValueOrDefault();
        }

        public string RequestedElasticPoolName()
        {
            return this.Inner.RequestedElasticPoolName;
        }

        internal ElasticPoolActivityImpl(ElasticPoolActivityInner innerObject) : base(innerObject)
        {
            this.resourceId = ResourceId.ParseResourceId(this.Inner.Id);
        }

        public long RequestedStorageLimitInGB()
        {
            return this.Inner.RequestedStorageLimitInGB.GetValueOrDefault();
        }

        public string Name()
        {
            return this.resourceId.Name;
        }

        public int RequestedDatabaseDtuMax()
        {
            return this.Inner.RequestedDatabaseDtuMax.GetValueOrDefault();
        }

        public string OperationId()
        {
            return this.Inner.OperationId;
        }

        public DateTime StartTime()
        {
            return this.Inner.StartTime.GetValueOrDefault();
        }

        public string Id()
        {
            return this.resourceId.Id;
        }

        public DateTime EndTime()
        {
            return this.Inner.EndTime.GetValueOrDefault();
        }

        public string State()
        {
            return this.Inner.State;
        }

        public string Operation()
        {
            return this.Inner.Operation;
        }
    }
}