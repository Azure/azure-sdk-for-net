// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Batch.Fluent.Application.Definition;
    using Microsoft.Azure.Management.Batch.Fluent.Application.Update;
    using Microsoft.Azure.Management.Batch.Fluent.Application.UpdateDefinition;
    using Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition;
    using Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System.Collections.Generic;

    internal partial class ApplicationImpl 
    {
        /// <summary>
        /// Allows automatic application updates.
        /// </summary>
        /// <param name="allowUpdates">True to allow automatic updates of a Batch application, otherwise false.</param>
        /// <return>The next stage of the definition.</return>
        Application.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Application.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithAllowUpdates(bool allowUpdates)
        {
            return this.WithAllowUpdates(allowUpdates) as Application.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the display name for the Batch application.
        /// </summary>
        /// <param name="displayName">A display name for the application.</param>
        /// <return>The next stage of the definition.</return>
        Application.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Application.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>.WithDisplayName(string displayName)
        {
            return this.WithDisplayName(displayName) as Application.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>;
        }

        /// <summary>
        /// The stage of a Batch application definition allowing automatic application updates.
        /// </summary>
        /// <param name="allowUpdates">True to allow the automatic updates of application, otherwise false.</param>
        /// <return>The next stage of the definition.</return>
        Application.Definition.IWithAttach<BatchAccount.Definition.IWithApplicationAndStorage> Application.Definition.IWithAttach<BatchAccount.Definition.IWithApplicationAndStorage>.WithAllowUpdates(bool allowUpdates)
        {
            return this.WithAllowUpdates(allowUpdates) as Application.Definition.IWithAttach<BatchAccount.Definition.IWithApplicationAndStorage>;
        }

        /// <summary>
        /// Specifies a display name for the Batch application.
        /// </summary>
        /// <param name="displayName">A display name.</param>
        /// <return>The next stage of the definition.</return>
        Application.Definition.IWithAttach<BatchAccount.Definition.IWithApplicationAndStorage> Application.Definition.IWithAttach<BatchAccount.Definition.IWithApplicationAndStorage>.WithDisplayName(string displayName)
        {
            return this.WithDisplayName(displayName) as Application.Definition.IWithAttach<BatchAccount.Definition.IWithApplicationAndStorage>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        BatchAccount.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<BatchAccount.Update.IUpdate>.Attach()
        {
            return this.Attach() as BatchAccount.Update.IUpdate;
        }

        /// <summary>
        /// First stage to create new application package in Batch account application.
        /// </summary>
        /// <param name="version">The version of the application.</param>
        /// <return>Next stage to create the application.</return>
        Application.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate> Application.UpdateDefinition.IWithApplicationPackage<BatchAccount.Update.IUpdate>.DefineNewApplicationPackage(string version)
        {
            return this.DefineNewApplicationPackage(version) as Application.UpdateDefinition.IWithAttach<BatchAccount.Update.IUpdate>;
        }

        /// <summary>
        /// The first stage of a new application package definition in a Batch account application.
        /// </summary>
        /// <param name="applicationPackageName">The version of the application.</param>
        /// <return>The next stage of the definition.</return>
        Application.Definition.IWithAttach<BatchAccount.Definition.IWithApplicationAndStorage> Application.Definition.IWithApplicationPackage<BatchAccount.Definition.IWithApplicationAndStorage>.DefineNewApplicationPackage(string applicationPackageName)
        {
            return this.DefineNewApplicationPackage(applicationPackageName) as Application.Definition.IWithAttach<BatchAccount.Definition.IWithApplicationAndStorage>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        BatchAccount.Definition.IWithApplicationAndStorage Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<BatchAccount.Definition.IWithApplicationAndStorage>.Attach()
        {
            return this.Attach() as BatchAccount.Definition.IWithApplicationAndStorage;
        }

        /// <summary>
        /// Allows automatic application updates.
        /// </summary>
        /// <param name="allowUpdates">True to allow the automatic updates of the application, otherwise false.</param>
        /// <return>The next stage of the update.</return>
        Application.Update.IUpdate Application.Update.IWithOptionalProperties.WithAllowUpdates(bool allowUpdates)
        {
            return this.WithAllowUpdates(allowUpdates) as Application.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the display name for the application.
        /// </summary>
        /// <param name="displayName">A display name.</param>
        /// <return>The next stage of the update.</return>
        Application.Update.IUpdate Application.Update.IWithOptionalProperties.WithDisplayName(string displayName)
        {
            return this.WithDisplayName(displayName) as Application.Update.IUpdate;
        }

        /// <summary>
        /// Gets the display name of the application.
        /// </summary>
        string Microsoft.Azure.Management.Batch.Fluent.IApplication.DisplayName
        {
            get
            {
                return this.DisplayName();
            }
        }

        /// <summary>
        /// Gets true if automatic updates are allowed, otherwise false.
        /// </summary>
        bool Microsoft.Azure.Management.Batch.Fluent.IApplication.UpdatesAllowed
        {
            get
            {
                return this.UpdatesAllowed();
            }
        }

        /// <summary>
        /// Gets application packages.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Batch.Fluent.IApplicationPackage> Microsoft.Azure.Management.Batch.Fluent.IApplication.ApplicationPackages
        {
            get
            {
                return this.ApplicationPackages() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Batch.Fluent.IApplicationPackage>;
            }
        }

        /// <summary>
        /// Gets the default version for the application.
        /// </summary>
        string Microsoft.Azure.Management.Batch.Fluent.IApplication.DefaultVersion
        {
            get
            {
                return this.DefaultVersion();
            }
        }

        /// <summary>
        /// First stage to create new application package in Batch account application.
        /// </summary>
        /// <param name="version">The version of the application.</param>
        /// <return>Next stage to create the application.</return>
        Application.Update.IUpdate Application.Update.IWithApplicationPackage.DefineNewApplicationPackage(string version)
        {
            return this.DefineNewApplicationPackage(version) as Application.Update.IUpdate;
        }

        /// <summary>
        /// Deletes specified application package from the application.
        /// </summary>
        /// <param name="version">The reference version of the application to be removed.</param>
        /// <return>The stage representing updatable batch account definition.</return>
        Application.Update.IUpdate Application.Update.IWithApplicationPackage.WithoutApplicationPackage(string version)
        {
            return this.WithoutApplicationPackage(version) as Application.Update.IUpdate;
        }
    }
}