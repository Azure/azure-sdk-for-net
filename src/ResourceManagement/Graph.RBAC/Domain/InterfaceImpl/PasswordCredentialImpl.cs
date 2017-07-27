// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.UpdateDefinition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Java.Io;
    using System;
    using Org.Joda.Time;

    internal partial class PasswordCredentialImpl<T> 
    {
        /// <summary>
        /// Specifies the duration for which password or key would be valid. Default value is 1 year.
        /// </summary>
        /// <param name="duration">The duration of validity.</param>
        /// <return>The next stage in credential definition.</return>
        PasswordCredential.UpdateDefinition.IWithAttach<T> PasswordCredential.UpdateDefinition.IWithDuration<T>.WithDuration(Duration duration)
        {
            return this.WithDuration(duration) as PasswordCredential.UpdateDefinition.IWithAttach<T>;
        }

        /// <summary>
        /// Specifies the duration for which password or key would be valid. Default value is 1 year.
        /// </summary>
        /// <param name="duration">The duration of validity.</param>
        /// <return>The next stage in credential definition.</return>
        PasswordCredential.Definition.IWithAttach<T> PasswordCredential.Definition.IWithDuration<T>.WithDuration(Duration duration)
        {
            return this.WithDuration(duration) as PasswordCredential.Definition.IWithAttach<T>;
        }

        /// <summary>
        /// Gets start date.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Graph.RBAC.Fluent.ICredential.StartDate
        {
            get
            {
                return this.StartDate();
            }
        }

        /// <summary>
        /// Gets end date.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Graph.RBAC.Fluent.ICredential.EndDate
        {
            get
            {
                return this.EndDate();
            }
        }

        /// <summary>
        /// Gets key value.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.ICredential.Value
        {
            get
            {
                return this.Value();
            }
        }

        /// <summary>
        /// Specifies the "subscription=" field in the auth file.
        /// </summary>
        /// <param name="subscriptionId">The UUID of the subscription.</param>
        /// <return>The next stage in credential definition.</return>
        PasswordCredential.UpdateDefinition.IWithAttach<T> PasswordCredential.UpdateDefinition.IWithSubscriptionInAuthFile<T>.WithSubscriptionId(string subscriptionId)
        {
            return this.WithSubscriptionId(subscriptionId) as PasswordCredential.UpdateDefinition.IWithAttach<T>;
        }

        /// <summary>
        /// Specifies the "subscription=" field in the auth file.
        /// </summary>
        /// <param name="subscriptionId">The UUID of the subscription.</param>
        /// <return>The next stage in credential definition.</return>
        PasswordCredential.Definition.IWithAttach<T> PasswordCredential.Definition.IWithSubscriptionInAuthFile<T>.WithSubscriptionId(string subscriptionId)
        {
            return this.WithSubscriptionId(subscriptionId) as PasswordCredential.Definition.IWithAttach<T>;
        }

        /// <summary>
        /// Use a password as a key.
        /// </summary>
        /// <param name="password">The password value.</param>
        /// <return>The next stage in credential definition.</return>
        PasswordCredential.UpdateDefinition.IWithAttach<T> PasswordCredential.UpdateDefinition.IWithKey<T>.WithPasswordValue(string password)
        {
            return this.WithPasswordValue(password) as PasswordCredential.UpdateDefinition.IWithAttach<T>;
        }

        /// <summary>
        /// Use a password as a key.
        /// </summary>
        /// <param name="password">The password value.</param>
        /// <return>The next stage in credential definition.</return>
        PasswordCredential.Definition.IWithAttach<T> PasswordCredential.Definition.IWithKey<T>.WithPasswordValue(string password)
        {
            return this.WithPasswordValue(password) as PasswordCredential.Definition.IWithAttach<T>;
        }

        /// <summary>
        /// Export the information of this service principal into an auth file.
        /// </summary>
        /// <param name="outputStream">The output stream to export the file.</param>
        /// <return>The next stage in credential definition.</return>
        PasswordCredential.UpdateDefinition.IWithSubscriptionInAuthFile<T> PasswordCredential.UpdateDefinition.IWithAuthFile<T>.WithAuthFileToExport(OutputStream outputStream)
        {
            return this.WithAuthFileToExport(outputStream) as PasswordCredential.UpdateDefinition.IWithSubscriptionInAuthFile<T>;
        }

        /// <summary>
        /// Export the information of this service principal into an auth file.
        /// </summary>
        /// <param name="outputStream">The output stream to export the file.</param>
        /// <return>The next stage in credential definition.</return>
        PasswordCredential.Definition.IWithSubscriptionInAuthFile<T> PasswordCredential.Definition.IWithAuthFile<T>.WithAuthFileToExport(OutputStream outputStream)
        {
            return this.WithAuthFileToExport(outputStream) as PasswordCredential.Definition.IWithSubscriptionInAuthFile<T>;
        }

        /// <summary>
        /// Specifies the start date after which password or key would be valid. Default value is current time.
        /// </summary>
        /// <param name="startDate">The start date for validity.</param>
        /// <return>The next stage in credential definition.</return>
        PasswordCredential.UpdateDefinition.IWithAttach<T> PasswordCredential.UpdateDefinition.IWithStartDate<T>.WithStartDate(DateTime startDate)
        {
            return this.WithStartDate(startDate) as PasswordCredential.UpdateDefinition.IWithAttach<T>;
        }

        /// <summary>
        /// Specifies the start date after which password or key would be valid. Default value is current time.
        /// </summary>
        /// <param name="startDate">The start date for validity.</param>
        /// <return>The next stage in credential definition.</return>
        PasswordCredential.Definition.IWithAttach<T> PasswordCredential.Definition.IWithStartDate<T>.WithStartDate(DateTime startDate)
        {
            return this.WithStartDate(startDate) as PasswordCredential.Definition.IWithAttach<T>;
        }
    }
}