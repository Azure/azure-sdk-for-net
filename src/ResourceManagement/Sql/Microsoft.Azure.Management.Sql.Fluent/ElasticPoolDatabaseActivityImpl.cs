// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// Implementation for Elastic Pool DatabaseActivity interface.
    /// </summary>
    internal partial class ElasticPoolDatabaseActivityImpl :
        Wrapper<Models.ElasticPoolDatabaseActivityInner>,
        IElasticPoolDatabaseActivity
    {
        private ResourceId resourceId;

        public string ResourceGroupName()
        {
            return this.resourceId.ResourceGroupName;
        }

        public string DatabaseName()
        {
            return this.Inner.DatabaseName;
        }

        internal ElasticPoolDatabaseActivityImpl(ElasticPoolDatabaseActivityInner innerObject) : base(innerObject)
        {
            this.resourceId = ResourceId.ParseResourceId(this.Inner.Id);
        }

        public string CurrentElasticPoolName()
        {
            return this.Inner.CurrentElasticPoolName;
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

        public string CurrentServiceObjective()
        {
            return this.Inner.CurrentServiceObjective;
        }

        public string RequestedElasticPoolName()
        {
            return this.Inner.RequestedElasticPoolName;
        }

        public string RequestedServiceObjective()
        {
            return this.Inner.RequestedServiceObjective;
        }

        public string Name()
        {
            return this.Inner.Name;
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
            return this.Inner.Id;
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