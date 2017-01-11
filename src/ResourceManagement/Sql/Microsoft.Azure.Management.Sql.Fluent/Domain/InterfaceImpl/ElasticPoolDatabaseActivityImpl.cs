// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    internal partial class ElasticPoolDatabaseActivityImpl 
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
        /// Gets the name of the current Elastic Pool the database is in if available.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.CurrentElasticPoolName
        {
            get
            {
                return this.CurrentElasticPoolName();
            }
        }

        /// <summary>
        /// Gets the time the operation finished (ISO8601 format).
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.EndTime
        {
            get
            {
                return this.EndTime();
            }
        }

        /// <summary>
        /// Gets the current state of the operation.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.State
        {
            get
            {
                return this.State();
            }
        }

        /// <summary>
        /// Gets the name of the Azure SQL Server the Elastic Pool is in.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.ServerName
        {
            get
            {
                return this.ServerName();
            }
        }

        /// <summary>
        /// Gets the error code if available.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.ErrorCode
        {
            get
            {
                return this.ErrorCode();
            }
        }

        /// <summary>
        /// Gets the operation name.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.Operation
        {
            get
            {
                return this.Operation();
            }
        }

        /// <summary>
        /// Gets the name for the Elastic Pool the database is moving into if available.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.RequestedElasticPoolName
        {
            get
            {
                return this.RequestedElasticPoolName();
            }
        }

        /// <summary>
        /// Gets the time the operation started (ISO8601 format).
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.StartTime
        {
            get
            {
                return this.StartTime();
            }
        }

        /// <summary>
        /// Gets the error message if available.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.ErrorMessage
        {
            get
            {
                return this.ErrorMessage();
            }
        }

        /// <summary>
        /// Gets the name of the requested service objective if available.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.RequestedServiceObjective
        {
            get
            {
                return this.RequestedServiceObjective();
            }
        }

        /// <summary>
        /// Gets the error severity if available.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.ErrorSeverity
        {
            get
            {
                return this.ErrorSeverity();
            }
        }

        /// <summary>
        /// Gets the percentage complete if available.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.PercentComplete
        {
            get
            {
                return this.PercentComplete();
            }
        }

        /// <summary>
        /// Gets the database name.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.DatabaseName
        {
            get
            {
                return this.DatabaseName();
            }
        }

        /// <summary>
        /// Gets the name of the current service objective if available.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.CurrentServiceObjective
        {
            get
            {
                return this.CurrentServiceObjective();
            }
        }

        /// <summary>
        /// Gets the unique operation ID.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.OperationId
        {
            get
            {
                return this.OperationId();
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
    }
}