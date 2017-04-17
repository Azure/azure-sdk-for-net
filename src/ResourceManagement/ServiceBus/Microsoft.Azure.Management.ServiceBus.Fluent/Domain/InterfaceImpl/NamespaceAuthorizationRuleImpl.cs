// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ServiceBus.Fluent.AuthorizationRule.Definition;
    using Microsoft.Azure.Management.ServiceBus.Fluent.AuthorizationRule.Update;
    using Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Definition;
    using Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Update;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Models;
    using System.Collections.Generic;

    internal partial class NamespaceAuthorizationRuleImpl 
    {
        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusManager>.Manager
        {
            get
            {
                return this.Manager as Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusManager;
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id;
            }
        }

        /// <summary>
        /// Gets the name of the parent namespace name.
        /// </summary>
        string Microsoft.Azure.Management.ServiceBus.Fluent.INamespaceAuthorizationRule.NamespaceName
        {
            get
            {
                return this.NamespaceName();
            }
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name;
            }
        }

        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.AuthorizationRule.Definition.IWithListen<Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Definition.IWithCreate>.WithListeningEnabled()
        {
            return this.WithListeningEnabled() as Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Definition.IWithCreate;
        }

        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.AuthorizationRule.Update.IWithListen<Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Update.IUpdate>.WithListeningEnabled()
        {
            return this.WithListeningEnabled() as Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Update.IUpdate;
        }

        /// <return>The primary, secondary keys and connection strings.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationRule<Microsoft.Azure.Management.ServiceBus.Fluent.INamespaceAuthorizationRule>.GetKeys()
        {
            return this.GetKeys() as Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys;
        }

        /// <summary>
        /// Regenerates primary or secondary keys.
        /// </summary>
        /// <param name="policykey">The key to regenerate.</param>
        /// <return>Primary, secondary keys and connection strings.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationRule<Microsoft.Azure.Management.ServiceBus.Fluent.INamespaceAuthorizationRule>.RegenerateKey(Policykey policykey)
        {
            return this.RegenerateKey(policykey) as Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys;
        }

        /// <summary>
        /// Regenerates primary or secondary keys.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="policykey">The key to regenerate.</param>
        /// <return>Stream that emits primary, secondary keys and connection strings.</return>
        async Task<Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys> Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationRule<Microsoft.Azure.Management.ServiceBus.Fluent.INamespaceAuthorizationRule>.RegenerateKeyAsync(Policykey policykey, CancellationToken cancellationToken)
        {
            return await this.RegenerateKeyAsync(policykey, cancellationToken) as Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys;
        }

        /// <summary>
        /// Gets rights associated with the rule.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.ServiceBus.Fluent.Models.AccessRights> Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationRule<Microsoft.Azure.Management.ServiceBus.Fluent.INamespaceAuthorizationRule>.Rights
        {
            get
            {
                return this.Rights() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.ServiceBus.Fluent.Models.AccessRights>;
            }
        }

        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <return>Stream that emits primary, secondary keys and connection strings.</return>
        async Task<Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys> Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationRule<Microsoft.Azure.Management.ServiceBus.Fluent.INamespaceAuthorizationRule>.GetKeysAsync(CancellationToken cancellationToken)
        {
            return await this.GetKeysAsync(cancellationToken) as Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationKeys;
        }

        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.AuthorizationRule.Definition.IWithManage<Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Definition.IWithCreate>.WithManagementEnabled()
        {
            return this.WithManagementEnabled() as Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Definition.IWithCreate;
        }

        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.AuthorizationRule.Update.IWithManage<Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Update.IUpdate>.WithManagementEnabled()
        {
            return this.WithManagementEnabled() as Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Update.IUpdate;
        }

        /// <summary>
        /// Gets the name of the region the resource is in.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.RegionName
        {
            get
            {
                return this.RegionName;
            }
        }

        /// <summary>
        /// Gets the tags for the resource.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Tags
        {
            get
            {
                return this.Tags as System.Collections.Generic.IReadOnlyDictionary<string,string>;
            }
        }

        /// <summary>
        /// Gets the region the resource is in.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Region
        {
            get
            {
                return this.Region as Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region;
            }
        }

        /// <summary>
        /// Gets the type of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Type
        {
            get
            {
                return this.Type;
            }
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName;
            }
        }

        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.AuthorizationRule.Definition.IWithSend<Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Definition.IWithCreate>.WithSendingEnabled()
        {
            return this.WithSendingEnabled() as Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Definition.IWithCreate;
        }

        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.AuthorizationRule.Update.IWithSend<Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Update.IUpdate>.WithSendingEnabled()
        {
            return this.WithSendingEnabled() as Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Update.IUpdate;
        }
    }
}