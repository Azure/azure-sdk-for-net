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
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System;
    using System.IO;

    public partial class PasswordCredentialImpl<T> 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Export the information of this service principal into an auth file.
        /// </summary>
        /// <param name="outputStream">The output stream to export the file.</param>
        /// <return>The next stage in credential definition.</return>
        PasswordCredential.UpdateDefinition.IWithAttach<T> PasswordCredential.UpdateDefinition.IWithAuthFile<T>.WithAuthFileToExport(FileStream outputStream)
        {
            return this.WithAuthFileToExport(outputStream) as PasswordCredential.UpdateDefinition.IWithAttach<T>;
        }

        /// <summary>
        /// Export the information of this service principal into an auth file.
        /// </summary>
        /// <param name="outputStream">The output stream to export the file.</param>
        /// <return>The next stage in credential definition.</return>
        PasswordCredential.Definition.IWithAttach<T> PasswordCredential.Definition.IWithAuthFile<T>.WithAuthFileToExport(FileStream outputStream)
        {
            return this.WithAuthFileToExport(outputStream) as PasswordCredential.Definition.IWithAttach<T>;
        }

        /// <summary>
        /// Specifies the duration for which password or key would be valid. Default value is 1 year.
        /// </summary>
        /// <param name="duration">The duration of validity.</param>
        /// <return>The next stage in credential definition.</return>
        PasswordCredential.UpdateDefinition.IWithAttach<T> PasswordCredential.UpdateDefinition.IWithDuration<T>.WithDateTimeOffset(DateTimeOffset duration)
        {
            return this.WithDuration(duration) as PasswordCredential.UpdateDefinition.IWithAttach<T>;
        }

        /// <summary>
        /// Specifies the duration for which password or key would be valid. Default value is 1 year.
        /// </summary>
        /// <param name="duration">The duration of validity.</param>
        /// <return>The next stage in credential definition.</return>
        PasswordCredential.Definition.IWithAttach<T> PasswordCredential.Definition.IWithDuration<T>.WithDateTimeOffset(DateTimeOffset duration)
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
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        T Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<T>.Attach()
        {
            return this.Attach() as T;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        T Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<T>.Attach()
        {
            return this.Attach() as T;
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