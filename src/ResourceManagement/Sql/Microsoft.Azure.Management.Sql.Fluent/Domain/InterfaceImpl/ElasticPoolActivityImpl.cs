// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;


    internal partial class ElasticPoolActivityImpl 
    {
        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <return>The resource ID string.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id() as string;
            }
        }

        /// <return>The name of the resource group.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName() as string;
            }
        }

        /// <return>The requested min DTU per database if available.</return>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.RequestedDatabaseDtuMin
        {
            get
            {
                return this.RequestedDatabaseDtuMin();
            }
        }

        /// <return>The requested DTU for the pool if available.</return>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.RequestedDtu
        {
            get
            {
                return this.RequestedDtu();
            }
        }

        /// <return>The requested max DTU per database if available.</return>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.RequestedDatabaseDtuMax
        {
            get
            {
                return this.RequestedDatabaseDtuMax();
            }
        }

        /// <return>The time the operation finished (ISO8601 format).</return>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.EndTime
        {
            get
            {
                return this.EndTime();
            }
        }

        /// <return>The current state of the operation.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.State
        {
            get
            {
                return this.State() as string;
            }
        }

        /// <return>The name of the Azure SQL Server the Elastic Pool is in.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.ServerName
        {
            get
            {
                return this.ServerName() as string;
            }
        }

        /// <return>The error code if available.</return>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.ErrorCode
        {
            get
            {
                return this.ErrorCode();
            }
        }

        /// <return>The operation name.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.Operation
        {
            get
            {
                return this.Operation() as string;
            }
        }

        /// <return>The requested name for the Elastic Pool if available.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.RequestedElasticPoolName
        {
            get
            {
                return this.RequestedElasticPoolName() as string;
            }
        }

        /// <return>The name of the Elastic Pool.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.ElasticPoolName
        {
            get
            {
                return this.ElasticPoolName() as string;
            }
        }

        /// <return>The time the operation started (ISO8601 format).</return>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.StartTime
        {
            get
            {
                return this.StartTime();
            }
        }

        /// <return>The error message if available.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.ErrorMessage
        {
            get
            {
                return this.ErrorMessage() as string;
            }
        }

        /// <return>The requested storage limit for the pool in GB if available.</return>
        long Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.RequestedStorageLimitInGB
        {
            get
            {
                return this.RequestedStorageLimitInGB();
            }
        }

        /// <return>The error severity if available.</return>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.ErrorSeverity
        {
            get
            {
                return this.ErrorSeverity();
            }
        }

        /// <return>The percentage complete if available.</return>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.PercentComplete
        {
            get
            {
                return this.PercentComplete();
            }
        }

        /// <return>The unique operation ID.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.OperationId
        {
            get
            {
                return this.OperationId() as string;
            }
        }
    }
}