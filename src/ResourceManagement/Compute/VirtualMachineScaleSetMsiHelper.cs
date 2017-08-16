// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Utility class to set Managed Service Identity (MSI) and MSI related resources for a virtual machine scale set.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldE1zaUhlbHBlcg==
    public partial class VirtualMachineScaleSetMsiHelper  :
        object
    {
        private readonly string CURRENT_RESOURCE_GROUP_SCOPE = "CURRENT_RESOURCE_GROUP";
        private readonly int DEFAULT_TOKEN_PORT = 50342;
        private readonly string MSI_EXTENSION_PUBLISHER_NAME = "Microsoft.ManagedIdentity";
        private readonly string LINUX_MSI_EXTENSION = "ManagedIdentityExtensionForLinux";
        private readonly string WINDOWS_MSI_EXTENSION = "ManagedIdentityExtensionForWindows";
        private IGraphRbacManager rbacManager;
        private int? tokenPort;
        private bool requireSetup;
        private IDictionary<string, System.Tuple<string, BuiltInRole>> rolesToAssign;
        private IDictionary<string, System.Tuple<string, string>> roleDefinitionsToAssign;

        /// <summary>
        /// Creates RBAC role assignments for the virtual machine scale set MSI service principal.
        /// </summary>
        /// <param name="scaleSet">The virtual machine scale set.</param>
        /// <return>An observable that emits the created role assignments.</return>
        ///GENMHASH:2E7E577AEA0C43B5B8D7B57BEFEF1E29:DDAE54B3372466B701A29E3B6A6362B2
        internal async Task<List<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment>> CreateMSIRbacRoleAssignmentsAsync(IVirtualMachineScaleSet scaleSet, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!requireSetup)
            {
                return new List<IRoleAssignment>();
            }
            else if (!scaleSet.IsManagedServiceIdentityEnabled)
            {
                return new List<IRoleAssignment>();
            }
            else if (!this.rolesToAssign.Any() && !this.roleDefinitionsToAssign.Any())
            {
                return new List<IRoleAssignment>();
            }

            try
            {
                var servicePrincipal = await rbacManager
                    .ServicePrincipals
                    .GetByIdAsync(scaleSet.Inner.Identity.PrincipalId, cancellationToken);

                await ResolveCurrentResourceGroupScopeAsync(scaleSet);

                List<IRoleAssignment> roleAssignments = new List<IRoleAssignment>();
                var roleAssignments1 = await Task.WhenAll(rolesToAssign.Values.Select(async (scopeAndRole) =>
                {
                    BuiltInRole role = scopeAndRole.Item2;
                    string scope = scopeAndRole.Item1;
                    return await CreateRbacRoleAssignmentIfNotExistsAsync(servicePrincipal, role.ToString(), scope, true, cancellationToken);
                }));
                roleAssignments.AddRange(roleAssignments1);

                var roleAssignments2 = await Task.WhenAll(roleDefinitionsToAssign.Values.Select(async (scopeAndRole) =>
                {
                    string roleDefinition = scopeAndRole.Item2;
                    string scope = scopeAndRole.Item1;
                    return await CreateRbacRoleAssignmentIfNotExistsAsync(servicePrincipal, roleDefinition, scope, false, cancellationToken);
                }));
                roleAssignments.AddRange(roleAssignments2);

                return roleAssignments.FindAll(roleAssignment => roleAssignment != null);
            }
            finally
            {
                Clear();
            }
        }

        /// <summary>
        /// Creates VirtualMachineScaleSetMsiHelper.
        /// </summary>
        /// <param name="rbacManager">The graph rbac manager.</param>
        ///GENMHASH:0BDA99FBDDE9E5E56C04FBD8624B1659:3E04D74F93A4BF712A2E5D50102895B8
        internal  VirtualMachineScaleSetMsiHelper(IGraphRbacManager rbacManager)
        {
            this.rbacManager = rbacManager;
            this.rolesToAssign = new Dictionary<string, Tuple<string, BuiltInRole>>();
            this.roleDefinitionsToAssign = new Dictionary<string, Tuple<string, string>>();
            Clear();
        }

        /// <summary>
        /// If any of the scope in  this.rolesToAssign is marked with CURRENT_RESOURCE_GROUP_SCOPE placeholder then
        /// resolve it and replace the placeholder with actual resource group scope (id).
        /// </summary>
        /// <param name="scaleSet">The virtual machine scale set.</param>
        /// <return>An observable that emits true once if there was a scope to resolve, otherwise emits false once.</return>
        ///GENMHASH:1830FCA3FFF54663B3A5702EF2F5721B:F61A8EF35EDD42D392559C585A71073F
        private async Task<bool> ResolveCurrentResourceGroupScopeAsync(IVirtualMachineScaleSet scaleSet, CancellationToken cancellationToken = default(CancellationToken))
        {
            IEnumerable<string> keysWithCurrentResourceGroupScopeForRoles = this.rolesToAssign
                .Where(role => role.Value.Item1.Equals(CURRENT_RESOURCE_GROUP_SCOPE, System.StringComparison.OrdinalIgnoreCase))
                .Select(role => role.Key)
                .ToList();  // ToList() is required as we are going to modify the same source collection below

            IEnumerable<string> keysWithCurrentResourceGroupScopeForRoleDefinitions = this.roleDefinitionsToAssign
                .Where(role => role.Value.Item1.Equals(CURRENT_RESOURCE_GROUP_SCOPE, System.StringComparison.OrdinalIgnoreCase))
                .Select(role => role.Key)
                .ToList();

            if (!keysWithCurrentResourceGroupScopeForRoles.Any()
                && !keysWithCurrentResourceGroupScopeForRoleDefinitions.Any())
            {
                return false;
            }

            var resourceGroup = await scaleSet.Manager.ResourceManager
                .ResourceGroups
                .GetByNameAsync(scaleSet.ResourceGroupName, cancellationToken);

            foreach (string key in keysWithCurrentResourceGroupScopeForRoles)
            {
                rolesToAssign[key] = new System.Tuple<string, BuiltInRole>(resourceGroup.Id, rolesToAssign[key].Item2);
            }

            foreach (string key in keysWithCurrentResourceGroupScopeForRoleDefinitions)
            {
                roleDefinitionsToAssign[key] = new System.Tuple<string, string>(resourceGroup.Id, roleDefinitionsToAssign[key].Item2);
            }
            return true;
        }

        /// <summary>
        /// Specifies that Managed Service Identity property needs to be set in the virtual machine scale set.
        /// If MSI extension is already installed then the access token will be available in the virtual machine
        /// scale set instance at port specified in the extension public setting, otherwise the port for
        /// new extension will be 50342.
        /// </summary>
        /// <param name="scaleSetInner">The virtual machine scale set to set the identity.</param>
        /// <return>VirtualMachineScaleSetMsiHelper.</return>
        ///GENMHASH:1D02816AA567687856A358E81DB99773:E64D1862840D63C171CB834051EF21E8
        internal VirtualMachineScaleSetMsiHelper WithManagedServiceIdentity(VirtualMachineScaleSetInner scaleSetInner)
        {
            return WithManagedServiceIdentity(null, scaleSetInner);
        }

        /// <summary>
        /// Specifies that Managed Service Identity property needs to be set in the virtual machine scale set.
        /// The access token will be available in the virtual machine at given port.
        /// </summary>
        /// <param name="port">The port in the virtual machine scale set instance to get the access token from.</param>
        /// <param name="scaleSetInner">The virtual machine scale set to set the identity.</param>
        /// <return>VirtualMachineScaleSetMsiHelper.</return>
        ///GENMHASH:5241398EC0DF56AB83CB75D6856D17A8:B16DB3B1494A86E6266A914618A6D036
        internal VirtualMachineScaleSetMsiHelper WithManagedServiceIdentity(int? port, VirtualMachineScaleSetInner scaleSetInner)
        {
            this.requireSetup = true;
            this.tokenPort = port;
            if (scaleSetInner.Identity == null) {
                scaleSetInner.Identity = new VirtualMachineScaleSetIdentity();
            }
            if (scaleSetInner.Identity.Type == null) {
                scaleSetInner.Identity.Type = ResourceIdentityType.SystemAssigned;
            }
            return this;
        }

        /// <summary>
        /// Given the OS type, gets the Managed Service Identity extension type.
        /// </summary>
        /// <param name="osType">The os type.</param>
        /// <return>The extension type.</return>
        ///GENMHASH:347A8526F0F1F396CA3E182F37C2C503:276F60357BD496C24A92D647654BF343
        private string MsiExtensionType(OperatingSystemTypes osType)
        {
            return osType == OperatingSystemTypes.Linux ? LINUX_MSI_EXTENSION : WINDOWS_MSI_EXTENSION;
        }

        /// <summary>
        /// Clear internal properties.
        /// </summary>
        ///GENMHASH:BDEEEC08EF65465346251F0F99D16258:4E2732AAF7CB45D14823B96A3FD27379
        private void Clear()
        {
            this.requireSetup = false;
            this.tokenPort = null;
            this.rolesToAssign.Clear();
            this.roleDefinitionsToAssign.Clear();

        }

        /// <summary>
        /// Specifies that applications running on the virtual machine scale set instance requires the
        /// given access role with scope of access limited to the arm resource identified by the resource
        /// id specified in the scope parameter.
        /// </summary>
        /// <param name="scope">Scope of the access represented in arm resource id format.</param>
        /// <param name="asRole">Access role to assigned to the virtual machine scale set.</param>
        /// <return>VirtualMachineScaleSetMsiHelper.</return>
        ///GENMHASH:EFFF7ECD982913DB369E1EF1644031CB:9F5B63517E99FAB38D9622B261E856C1
        internal VirtualMachineScaleSetMsiHelper WithRoleBasedAccessTo(string scope, BuiltInRole asRole)
        {
            this.requireSetup = true;
            string key = scope.ToLower() + "_" + asRole.ToString().ToLower();
            if (!this.rolesToAssign.ContainsKey(key))
            {
                this.rolesToAssign.Add(key, new System.Tuple<string, BuiltInRole>(scope, asRole));
            }
            return this;
        }

        /// <summary>
        /// Gets the Managed Service Identity extension from the given extensions.
        /// </summary>
        /// <param name="extensions">The extensions.</param>
        /// <param name="typeName">The extension type.</param>
        /// <return>The MSI extension if exists, null otherwise.</return>
        ///GENMHASH:4FEDAFC9FF189A3AE2D0023895BD9967:94C04C6B7F4FB16948D8C34B232E7692
        private IVirtualMachineScaleSetExtension GetMSIExtension(IReadOnlyDictionary<string,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension> extensions, string typeName)
        {
            return extensions.Values.FirstOrDefault(extension => 
                extension.PublisherName.Equals(MSI_EXTENSION_PUBLISHER_NAME, System.StringComparison.OrdinalIgnoreCase) && extension.TypeName.Equals(typeName, System.StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Specifies that applications running on the virtual machine scale set instance requires
        /// the access described in the given role definition with scope of access limited to the
        /// arm resource identified by the resource id specified in the scope parameter.
        /// </summary>
        /// <param name="scope">Scope of the access represented in arm resource id format.</param>
        /// <param name="roleDefinition">Access role definition to assigned to the virtual machine scale set.</param>
        /// <return>VirtualMachineMsiHelper.</return>
        ///GENMHASH:DEF511724D2CC8CA91F24E084BC9AA22:988B0602BFE7029EF703F401D29118A0
        internal VirtualMachineScaleSetMsiHelper WithRoleDefinitionBasedAccessTo(string scope, string roleDefinition)
        {
            this.requireSetup = true;
            string key = scope.ToLower() + "_" + roleDefinition.ToLower();
            if (!this.roleDefinitionsToAssign.ContainsKey(key))
            {
                this.roleDefinitionsToAssign.Add(key, new System.Tuple<string, string>(scope, roleDefinition));
            }
            return this;
        }

        /// <summary>
        /// Specifies that applications running on the virtual machine scale set instance requires
        /// the given access role with scope of access limited to the current resource group that
        /// the virtual machine resides.
        /// </summary>
        /// <param name="asRole">Access role to assigned to the virtual machine.</param>
        /// <return>VirtualMachineScaleSetMsiHelper.</return>
        ///GENMHASH:F6C5721A84FA825F62951BE51537DD36:3B28EC7DC783C825B70ABCF4EB8FC542
        internal VirtualMachineScaleSetMsiHelper WithRoleBasedAccessToCurrentResourceGroup(BuiltInRole asRole)
        {
            return this.WithRoleBasedAccessTo(CURRENT_RESOURCE_GROUP_SCOPE, asRole);
        }

        /// <summary>
        /// Add or update the Managed Service Identity extension for the given virtual machine scale set.
        /// </summary>
        /// <param name="scaleSetImpl">The scale set.</param>
        ///GENMHASH:997210D729E5BF9AFDCB591B758BDA05:D5712C2936A1D66C353AD2D485B40474
        internal void AddOrUpdateMSIExtension(VirtualMachineScaleSetImpl scaleSetImpl)
        {
            if (!requireSetup) {
                return;
            }
            // To add or update MSI extension, we relay on methods exposed from interfaces instead of from
            // impl so that any breaking change in the contract cause a compile time error here. So do not
            // change the below 'updateExtension' or 'defineNewExtension' to use impls.
            //
            String msiExtensionType = MsiExtensionType(scaleSetImpl.OSTypeIntern());
            IVirtualMachineScaleSetExtension msiExtension = GetMSIExtension(scaleSetImpl.Extensions(), msiExtensionType);
            if (msiExtension != null)
            {
                Object currentTokenPortObj = msiExtension.PublicSettings["port"];
                int? currentTokenPort = ComputeUtils.ObjectToInteger(currentTokenPortObj);
                int? newPort;
                if (this.tokenPort != null)
                {
                    // user specified a port
                    newPort = this.tokenPort;
                }
                else if (currentTokenPort != null)
                {
                    // user didn't specify a port and currently there is a port
                    newPort = currentTokenPort;
                }
                else
                {
                    // user didn't specify a port and currently there is no port
                    newPort = DEFAULT_TOKEN_PORT;
                }
                VirtualMachineScaleSet.Update.IUpdate appliableVMSS = scaleSetImpl;
                appliableVMSS.UpdateExtension(msiExtension.Name)
                    .WithPublicSetting("port", newPort)
                    .Parent();
            }
            else
            {
                int? port;
                if (this.tokenPort != null)
                {
                    port = this.tokenPort;
                }
                else
                {
                    port = DEFAULT_TOKEN_PORT;
                }
                if (scaleSetImpl.Inner.Id == null) // InCreateMode
                {
                    VirtualMachineScaleSet.Definition.IWithCreate creatableVMSS = scaleSetImpl;
                    creatableVMSS.DefineNewExtension(msiExtensionType)
                        .WithPublisher(MSI_EXTENSION_PUBLISHER_NAME)
                        .WithType(msiExtensionType)
                        .WithVersion("1.0")
                        .WithMinorVersionAutoUpgrade()
                        .WithPublicSetting("port", port)
                        .Attach();
                }
                else
                {
                    VirtualMachineScaleSet.Update.IUpdate appliableVMSS = scaleSetImpl;
                    appliableVMSS.DefineNewExtension(msiExtensionType)
                        .WithPublisher(MSI_EXTENSION_PUBLISHER_NAME)
                        .WithType(msiExtensionType)
                        .WithVersion("1.0")
                        .WithMinorVersionAutoUpgrade()
                        .WithPublicSetting("port", port)
                        .Attach();
                }
            }
        }

        /// <summary>
        /// Creates a RBAC role assignment (using role or role definition) for the given service principal.
        /// </summary>
        /// <param name="servicePrincipal">The service principal.</param>
        /// <param name="roleOrRoleDefinition">The role or role definition.</param>
        /// <param name="scope">The scope for the role assignment.</param>
        /// <return>An observable that emits the role assignment if it is created, null if assignment already exists.</return>
        ///GENMHASH:85AA7846D5642A1F7125332B46A901BE:A2437532CFAD0C7032A34C1FD573957E
        private async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> CreateRbacRoleAssignmentIfNotExistsAsync(IServicePrincipal servicePrincipal, string roleOrRoleDefinition, string scope, bool isRole, CancellationToken cancellationToken = default(CancellationToken))
        {
            string roleAssignmentName = SdkContext.RandomGuid();
            try
            {
                if (isRole)
                {
                    return await rbacManager
                        .RoleAssignments
                        .Define(roleAssignmentName)
                        .ForServicePrincipal(servicePrincipal)
                        .WithBuiltInRole(BuiltInRole.Parse(roleOrRoleDefinition))
                        .WithScope(scope)
                        .CreateAsync(cancellationToken);
                }
                else
                {
                    return await rbacManager
                        .RoleAssignments
                        .Define(roleAssignmentName)
                        .ForServicePrincipal(servicePrincipal)
                        .WithRoleDefinition(roleOrRoleDefinition)
                        .WithScope(scope)
                        .CreateAsync(cancellationToken);
                }
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Body != null && cloudException.Body.Code != null && cloudException.Body.Code.Equals("RoleAssignmentExists", StringComparison.OrdinalIgnoreCase))
                {
                    // NOTE: We are unable to lookup the role assignment from principal.RoleAssignments() list
                    // because role assignment object does not contain 'role' name (the roleDefinitionId refer
                    // 'role' using id with GUID).
                    return null;
                }
                throw cloudException;
            }
        }

        /// <summary>
        /// Specifies that applications running on the virtual machine scale set instance requires
        /// the access described in the given role definition with scope of access limited to the
        /// current resource group that the virtual machine resides.
        /// </summary>
        /// <param name="roleDefintionId">The role definition to assigned to the virtual machine.</param>
        /// <return>VirtualMachineScaleSetMsiHelper.</return>
        ///GENMHASH:5FD7E26022EAFDACD062A87DDA8FD39A:87F0A1C8FDB24F2D4D644CFD5D02802D
        internal VirtualMachineScaleSetMsiHelper WithRoleDefinitionBasedAccessToCurrentResourceGroup(string roleDefintionId)
        {
            return this.WithRoleDefinitionBasedAccessTo(CURRENT_RESOURCE_GROUP_SCOPE, roleDefintionId);
        }
    }
}