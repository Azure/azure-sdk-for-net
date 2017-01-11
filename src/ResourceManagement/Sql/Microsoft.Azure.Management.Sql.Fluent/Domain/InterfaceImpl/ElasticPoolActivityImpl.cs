// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    internal partial class ElasticPoolActivityImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <summary>
        /// Gets the requested min DTU per database if available.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.RequestedDatabaseDtuMin
        {
            get
            {
                return this.RequestedDatabaseDtuMin();
            }
        }

        /// <summary>
        /// Gets the requested DTU for the pool if available.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.RequestedDtu
        {
            get
            {
                return this.RequestedDtu();
            }
        }

        /// <summary>
        /// Gets the requested max DTU per database if available.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.RequestedDatabaseDtuMax
        {
            get
            {
                return this.RequestedDatabaseDtuMax();
            }
        }

        /// <summary>
        /// Gets the time the operation finished (ISO8601 format).
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.EndTime
        {
            get
            {
                return this.EndTime();
            }
        }

        /// <summary>
        /// Gets the current state of the operation.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.State
        {
            get
            {
                return this.State();
            }
        }

        /// <summary>
        /// Gets the name of the Azure SQL Server the Elastic Pool is in.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.ServerName
        {
            get
            {
                return this.ServerName();
            }
        }

        /// <summary>
        /// Gets the error code if available.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.ErrorCode
        {
            get
            {
                return this.ErrorCode();
            }
        }

        /// <summary>
        /// Gets the operation name.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.Operation
        {
            get
            {
                return this.Operation();
            }
        }

        /// <summary>
        /// Gets the requested name for the Elastic Pool if available.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.RequestedElasticPoolName
        {
            get
            {
                return this.RequestedElasticPoolName();
            }
        }

        /// <summary>
        /// Gets the name of the Elastic Pool.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.ElasticPoolName
        {
            get
            {
                return this.ElasticPoolName();
            }
        }

        /// <summary>
        /// Gets the time the operation started (ISO8601 format).
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.StartTime
        {
            get
            {
                return this.StartTime();
            }
        }

        /// <summary>
        /// Gets the error message if available.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.ErrorMessage
        {
            get
            {
                return this.ErrorMessage();
            }
        }

        /// <summary>
        /// Gets the requested storage limit for the pool in GB if available.
        /// </summary>
        long Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.RequestedStorageLimitInGB
        {
            get
            {
                return this.RequestedStorageLimitInGB();
            }
        }

        /// <summary>
        /// Gets the error severity if available.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.ErrorSeverity
        {
            get
            {
                return this.ErrorSeverity();
            }
        }

        /// <summary>
        /// Gets the percentage complete if available.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.PercentComplete
        {
            get
            {
                return this.PercentComplete();
            }
        }

        /// <summary>
        /// Gets the unique operation ID.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity.OperationId
        {
            get
            {
                return this.OperationId();
            }
        }
    }
}