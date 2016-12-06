// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System;


    internal partial class ElasticPoolDatabaseActivityImpl 
    {
        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <return>The name of the current Elastic Pool the database is in if available.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.CurrentElasticPoolName
        {
            get
            {
                return this.CurrentElasticPoolName() as string;
            }
        }

        /// <return>The time the operation finished (ISO8601 format).</return>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.EndTime
        {
            get
            {
                return this.EndTime();
            }
        }

        /// <return>The current state of the operation.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.State
        {
            get
            {
                return this.State() as string;
            }
        }

        /// <return>The name of the Azure SQL Server the Elastic Pool is in.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.ServerName
        {
            get
            {
                return this.ServerName() as string;
            }
        }

        /// <return>The error code if available.</return>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.ErrorCode
        {
            get
            {
                return this.ErrorCode();
            }
        }

        /// <return>The operation name.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.Operation
        {
            get
            {
                return this.Operation() as string;
            }
        }

        /// <return>The name for the Elastic Pool the database is moving into if available.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.RequestedElasticPoolName
        {
            get
            {
                return this.RequestedElasticPoolName() as string;
            }
        }

        /// <return>The time the operation started (ISO8601 format).</return>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.StartTime
        {
            get
            {
                return this.StartTime();
            }
        }

        /// <return>The error message if available.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.ErrorMessage
        {
            get
            {
                return this.ErrorMessage() as string;
            }
        }

        /// <return>The name of the requested service objective if available.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.RequestedServiceObjective
        {
            get
            {
                return this.RequestedServiceObjective() as string;
            }
        }

        /// <return>The error severity if available.</return>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.ErrorSeverity
        {
            get
            {
                return this.ErrorSeverity();
            }
        }

        /// <return>The percentage complete if available.</return>
        int Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.PercentComplete
        {
            get
            {
                return this.PercentComplete();
            }
        }

        /// <return>The database name.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.DatabaseName
        {
            get
            {
                return this.DatabaseName() as string;
            }
        }

        /// <return>The name of the current service objective if available.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.CurrentServiceObjective
        {
            get
            {
                return this.CurrentServiceObjective() as string;
            }
        }

        /// <return>The unique operation ID.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity.OperationId
        {
            get
            {
                return this.OperationId() as string;
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
    }
}