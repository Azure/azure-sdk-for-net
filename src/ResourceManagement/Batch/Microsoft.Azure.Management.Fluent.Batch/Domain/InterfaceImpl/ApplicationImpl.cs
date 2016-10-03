// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Batch
{

    using Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Batch.Models;
    using System.Threading;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Fluent.Batch.Application.Update;
    using Microsoft.Azure.Management.Fluent.Batch.Application.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Batch.Application.Definition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    public partial class ApplicationImpl 
    {
        /// <summary>
        /// Allow automatic application updates.
        /// </summary>
        /// <param name="allowUpdates">allowUpdates true to allow the automatic updates of application, otherwise false</param>
        /// <returns>parent batch account update definition.</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate> Microsoft.Azure.Management.Fluent.Batch.Application.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate>.WithAllowUpdates(bool allowUpdates) { 
            return this.WithAllowUpdates( allowUpdates) as Microsoft.Azure.Management.Fluent.Batch.Application.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the display name for the application.
        /// </summary>
        /// <param name="displayName">displayName display name for the application.</param>
        /// <returns>parent batch account update definition.</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate> Microsoft.Azure.Management.Fluent.Batch.Application.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate>.WithDisplayName(string displayName) { 
            return this.WithDisplayName( displayName) as Microsoft.Azure.Management.Fluent.Batch.Application.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate>;
        }

        /// <summary>
        /// Allow automatic application updates.
        /// </summary>
        /// <param name="allowUpdates">allowUpdates true to allow the automatic updates of application, otherwise false</param>
        /// <returns>parent batch account definition.</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithApplicationAndStorage> Microsoft.Azure.Management.Fluent.Batch.Application.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithApplicationAndStorage>.WithAllowUpdates(bool allowUpdates) { 
            return this.WithAllowUpdates( allowUpdates) as Microsoft.Azure.Management.Fluent.Batch.Application.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithApplicationAndStorage>;
        }

        /// <summary>
        /// Specifies the display name for the application.
        /// </summary>
        /// <param name="displayName">displayName the displayName value to set</param>
        /// <returns>parent batch account definition.</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithApplicationAndStorage> Microsoft.Azure.Management.Fluent.Batch.Application.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithApplicationAndStorage>.WithDisplayName(string displayName) { 
            return this.WithDisplayName( displayName) as Microsoft.Azure.Management.Fluent.Batch.Application.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithApplicationAndStorage>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate;
        }

        /// <summary>
        /// First stage to create new application package in Batch account application.
        /// </summary>
        /// <param name="version">version the version of the application</param>
        /// <returns>next stage to create the application.</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate> Microsoft.Azure.Management.Fluent.Batch.Application.UpdateDefinition.IWithApplicationPackage<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate>.DefineNewApplicationPackage(string version) { 
            return this.DefineNewApplicationPackage( version) as Microsoft.Azure.Management.Fluent.Batch.Application.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate>;
        }

        /// <summary>
        /// First stage to create new application package in Batch account application.
        /// </summary>
        /// <param name="applicationPackageName">applicationPackageName the version of the application</param>
        /// <returns>next stage to create the application.</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithApplicationAndStorage> Microsoft.Azure.Management.Fluent.Batch.Application.Definition.IWithApplicationPackage<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithApplicationAndStorage>.DefineNewApplicationPackage(string applicationPackageName) { 
            return this.DefineNewApplicationPackage( applicationPackageName) as Microsoft.Azure.Management.Fluent.Batch.Application.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithApplicationAndStorage>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithApplicationAndStorage Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithApplicationAndStorage>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithApplicationAndStorage;
        }

        /// <summary>
        /// Allow automatic application updates.
        /// </summary>
        /// <param name="allowUpdates">allowUpdates true to allow the automatic updates of application, otherwise false</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.Update.IUpdate Microsoft.Azure.Management.Fluent.Batch.Application.Update.IWithOptionalProperties.WithAllowUpdates(bool allowUpdates) { 
            return this.WithAllowUpdates( allowUpdates) as Microsoft.Azure.Management.Fluent.Batch.Application.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the display name for the application.
        /// </summary>
        /// <param name="displayName">displayName the displayName value to set</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.Update.IUpdate Microsoft.Azure.Management.Fluent.Batch.Application.Update.IWithOptionalProperties.WithDisplayName(string displayName) { 
            return this.WithDisplayName( displayName) as Microsoft.Azure.Management.Fluent.Batch.Application.Update.IUpdate;
        }

        /// <returns>true if automatic updates are allowed, otherwise false</returns>
        bool Microsoft.Azure.Management.Fluent.Batch.IApplication.UpdatesAllowed
        {
            get
            { 
            return this.UpdatesAllowed();
            }
        }
        /// <returns>the list of application packages</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Batch.IApplicationPackage> Microsoft.Azure.Management.Fluent.Batch.IApplication.ApplicationPackages
        {
            get
            { 
            return this.ApplicationPackages() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Batch.IApplicationPackage>;
            }
        }
        /// <returns>the display name for application</returns>
        string Microsoft.Azure.Management.Fluent.Batch.IApplication.DisplayName
        {
            get
            { 
            return this.DisplayName() as string;
            }
        }
        /// <returns>the default version for application.</returns>
        string Microsoft.Azure.Management.Fluent.Batch.IApplication.DefaultVersion
        {
            get
            { 
            return this.DefaultVersion() as string;
            }
        }
        /// <summary>
        /// First stage to create new application package in Batch account application.
        /// </summary>
        /// <param name="version">version the version of the application</param>
        /// <returns>next stage to create the application.</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.Update.IUpdate Microsoft.Azure.Management.Fluent.Batch.Application.Update.IWithApplicationPackage.DefineNewApplicationPackage(string version) { 
            return this.DefineNewApplicationPackage( version) as Microsoft.Azure.Management.Fluent.Batch.Application.Update.IUpdate;
        }

        /// <summary>
        /// Deletes specified application package from the application.
        /// </summary>
        /// <param name="version">version the reference version of the application to be removed</param>
        /// <returns>the stage representing updatable batch account definition.</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.Update.IUpdate Microsoft.Azure.Management.Fluent.Batch.Application.Update.IWithApplicationPackage.WithoutApplicationPackage(string version) { 
            return this.WithoutApplicationPackage( version) as Microsoft.Azure.Management.Fluent.Batch.Application.Update.IUpdate;
        }

    }
}