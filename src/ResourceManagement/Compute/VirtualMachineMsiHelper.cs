// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Utility class to set Managed Service Identity (MSI) and MSI related resources for a virtual machine.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVNc2lIZWxwZXI=
    public partial class VirtualMachineMsiHelper
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
        /// Checks the virtual machine already has the Managed Service Identity extension installed if so return it.
        /// </summary>
        /// <param name="virtualMachine">The virtual machine.</param>
        /// <param name="typeName">The Managed Service Identity extension type name.</param>
        /// <return>An observable that emits MSI extension if exists.</return>
        ///GENMHASH:38C8AA5C741C6C6C48EA5E76D0AAE275:A765201FB3773E8424CAFCCC348578C6
        private async Task<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension> GetMSIExtensionAsync(IVirtualMachine virtualMachine, string typeName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var installedExtensions = await virtualMachine.ListExtensionsAsync(cancellationToken);
            return installedExtensions.FirstOrDefault(extension => extension.PublisherName.Equals(MSI_EXTENSION_PUBLISHER_NAME, System.StringComparison.OrdinalIgnoreCase) && extension.TypeName.Equals(typeName, System.StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// If any of the scope in  this.rolesToAssign and  this.roleDefinitionsToAssign is marked
        /// with CURRENT_RESOURCE_GROUP_SCOPE placeholder then resolve it and replace the placeholder with actual
        /// resource group scope (id).
        /// </summary>
        /// <param name="virtualMachine">The virtual machine.</param>
        /// <return>An observable that emits true once if there was a scope to resolve, otherwise emits false once.</return>
        ///GENMHASH:8D4717249F7C4A623C932FA898F9A735:B413455CAD5D93E8A5986EBD438883D2
        private async Task<bool> ResolveCurrentResourceGroupScopeAsync(IVirtualMachine virtualMachine, CancellationToken cancellationToken = default(CancellationToken))
        {
            IEnumerable<string> keysWithCurrentResourceGroupScopeForRoles = this.rolesToAssign
                .Where(role => role.Value.Item1.Equals(CURRENT_RESOURCE_GROUP_SCOPE, System.StringComparison.OrdinalIgnoreCase))
                .Select(role => role.Key)
                .ToList(); // ToList() is required as we are going to modify the same source collection below

            IEnumerable<string> keysWithCurrentResourceGroupScopeForRoleDefinitions = this.roleDefinitionsToAssign
                .Where(role => role.Value.Item1.Equals(CURRENT_RESOURCE_GROUP_SCOPE, System.StringComparison.OrdinalIgnoreCase))
                .Select(role => role.Key)
                .ToList();

            if (!keysWithCurrentResourceGroupScopeForRoles.Any() 
                && !keysWithCurrentResourceGroupScopeForRoleDefinitions.Any())
            {
                return false;
            }

            var resourceGroup = await virtualMachine.Manager.ResourceManager
                .ResourceGroups
                .GetByNameAsync(virtualMachine.ResourceGroupName, cancellationToken);

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
        /// Specifies that Managed Service Identity property needs to be set in the virtual machine.
        /// If MSI extension is already installed then the access token will be available in the virtual machine
        /// at port specified in the extension public setting, otherwise the port for new extension will be 50342.
        /// </summary>
        /// <param name="virtualMachineInner">The virtual machine to set the identity.</param>
        /// <return>VirtualMachineMsiHelper.</return>
        ///GENMHASH:F2A9278603EEA1AE0415FD9B63A054F6:0D906721D2B4DF5C476A867DCC72ED39
        internal VirtualMachineMsiHelper WithManagedServiceIdentity(VirtualMachineInner virtualMachineInner)
        {
            return WithManagedServiceIdentity(null, virtualMachineInner);
        }

        /// <summary>
        /// Specifies that Managed Service Identity property needs to be set in the virtual machine.
        /// The access token will be available in the virtual machine at given port.
        /// </summary>
        /// <param name="port">The port in the virtual machine to get the access token from.</param>
        /// <param name="virtualMachineInner">The virtual machine to set the identity.</param>
        /// <param name="virtualMachineInner">The virtual machine to set the identity.</param>
        /// <return>VirtualMachineMsiHelper.</return>
        ///GENMHASH:4189D61DE8E151C0FB589513AA0D4612:40AA004E3EDDABF6FA387290F36BF4D4
        internal VirtualMachineMsiHelper WithManagedServiceIdentity(int? port, VirtualMachineInner virtualMachineInner)
        {
            this.requireSetup = true;
            this.tokenPort = port;
            if (virtualMachineInner.Identity == null)
            {
                virtualMachineInner.Identity = new VirtualMachineIdentity();
            }
            if (virtualMachineInner.Identity.Type == null)
            {
                virtualMachineInner.Identity.Type = ResourceIdentityType.SystemAssigned;
            }
            return this;
        }

        /// <summary>
        /// Creates RBAC role assignments for the virtual machine service principal.
        /// </summary>
        /// <param name="virtualMachine">The virtual machine.</param>
        /// <return>An observable that emits the created role assignments.</return>
        ///GENMHASH:ACFB6162939077C3462B391EB2DD5A18:01A98853651D800A25EE02E4E8B4FAB6
        private async Task<List<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment>> CreateRbacRoleAssignmentsAsync(IVirtualMachine virtualMachine, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<IRoleAssignment> roleAssignments = new List<IRoleAssignment>();
            if (!this.rolesToAssign.Any()
                && !this.roleDefinitionsToAssign.Any())
            {
                return roleAssignments;
            }
            var servicePrincipal = await  rbacManager.ServicePrincipals.GetByIdAsync(virtualMachine.Inner.Identity.PrincipalId, cancellationToken);
            await ResolveCurrentResourceGroupScopeAsync(virtualMachine);

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
        /// Specifies that applications running on the virtual machine requires the given access role
        /// with scope of access limited to the arm resource identified by the resource id specified
        /// in the scope parameter.
        /// </summary>
        /// <param name="scope">Scope of the access represented in arm resource id format.</param>
        /// <param name="asRole">Access role to assigned to the virtual machine.</param>
        /// <return>VirtualMachineMsiHelper.</return>
        ///GENMHASH:EFFF7ECD982913DB369E1EF1644031CB:9F5B63517E99FAB38D9622B261E856C1
        internal VirtualMachineMsiHelper WithRoleBasedAccessTo(string scope, BuiltInRole asRole)
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
        /// Install Managed Service Identity extension in the virtual machine.
        /// </summary>
        /// <param name="virtualMachine">The virtual machine.</param>
        /// <param name="typeName">The Managed Service Identity extension type name.</param>
        /// <return>An observable that emits true indicating MSI extension installed.</return>
        ///GENMHASH:1323CC85C0A1885A60EFB332F13728A2:8BCFEF0F08C73A93F81A9FF83289D068
        private async Task<bool> InstallMSIExtensionAsync(IVirtualMachine virtualMachine, string typeName, CancellationToken cancellationToken = default(CancellationToken))
        {
            int tokenPortToUse = tokenPort != null ? tokenPort.Value : DEFAULT_TOKEN_PORT;
            var publicSettings = new Dictionary<string, object>();
            publicSettings.Add("port", tokenPortToUse);
            VirtualMachineExtensionInner extensionParameter = new VirtualMachineExtensionInner()
            {
                Publisher = MSI_EXTENSION_PUBLISHER_NAME,
                VirtualMachineExtensionType = typeName,
                TypeHandlerVersion = "1.0",
                AutoUpgradeMinorVersion = true,
                Location = virtualMachine.RegionName,
                Settings = publicSettings,
                ProtectedSettings = null
            };
            await virtualMachine.Manager.Inner.VirtualMachineExtensions.CreateOrUpdateAsync(virtualMachine.ResourceGroupName, virtualMachine.Name, typeName, extensionParameter, cancellationToken);
            return true;
        }

        /// <summary>
        /// Update the Managed Service Identity extension installed in the virtual machine.
        /// </summary>
        /// <param name="virtualMachine">The virtual machine.</param>
        /// <param name="extension">The Managed Service Identity extension.</param>
        /// <param name="typeName">The Managed Service Identity extension type name.</param>
        /// <return>An observable that emits true if MSI extension updated, false otherwise.</return>
        ///GENMHASH:360C529D50EA598D26E2D035C1C0AFBE:2159D1C204127807EC19DE8A5CE77BD6
        private async Task<bool> UpdateMSIExtensionAsync(IVirtualMachine virtualMachine, IVirtualMachineExtension extension, string typeName, CancellationToken cancellationToken = default(CancellationToken))
        {
            int? currentTokenPort = Microsoft.Azure.Management.Compute.Fluent.ComputeUtils.ObjectToInteger(extension.PublicSettings["port"]);
            int? tokenPortToUse;
            if (this.tokenPort != null)
            {
                // User specified a port
                tokenPortToUse = this.tokenPort;
            }
            else if (currentTokenPort == null)
            {
                // User didn't specify a port and port is not already set
                tokenPortToUse = this.DEFAULT_TOKEN_PORT;
            }
            else
            {
                // User didn't specify a port and port is already set in the extension
                // No need to do a PUT on extension
                //
                return false;
            }
            var publicSettings = new Dictionary<string, object>();
            publicSettings.Add("port", tokenPortToUse);
            extension.Inner.Settings = publicSettings;
            await virtualMachine.Manager.Inner.VirtualMachineExtensions.CreateOrUpdateAsync(virtualMachine.ResourceGroupName, virtualMachine.Name, typeName, extension.Inner, cancellationToken);
            return true;
        }

        /// <summary>
        /// Specifies that applications running on the virtual machine requires the access described
        /// in the given role definition with scope of access limited to the arm resource identified
        /// by the resource id specified in the scope parameter.
        /// </summary>
        /// <param name="scope">Scope of the access represented in arm resource id format.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the virtual machine.</param>
        /// <return>VirtualMachineMsiHelper.</return>
        ///GENMHASH:DEF511724D2CC8CA91F24E084BC9AA22:066796D662276CCCE437835307CFEED8
        internal VirtualMachineMsiHelper WithRoleDefinitionBasedAccessTo(string scope, string roleDefinitionId)
        {
            this.requireSetup = true;
            string key = scope.ToLower() + "_" + roleDefinitionId.ToLower();
            if (!this.roleDefinitionsToAssign.ContainsKey(key))
            {
                this.roleDefinitionsToAssign.Add(key, new System.Tuple<string, string>(scope, roleDefinitionId));
            }
            return this;
        }

        /// <summary>
        /// Specifies that applications running on the virtual machine requires the given access role
        /// with scope of access limited to the current resource group that the virtual machine
        /// resides.
        /// </summary>
        /// <param name="asRole">Access role to assigned to the virtual machine.</param>
        /// <return>VirtualMachineMsiHelper.</return>
        ///GENMHASH:F6C5721A84FA825F62951BE51537DD36:3B28EC7DC783C825B70ABCF4EB8FC542
        internal VirtualMachineMsiHelper WithRoleBasedAccessToCurrentResourceGroup(BuiltInRole asRole)
        {
            return this.WithRoleBasedAccessTo(CURRENT_RESOURCE_GROUP_SCOPE, asRole);
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
        /// Creates VirtualMachineMsiHelper.
        /// </summary>
        /// <param name="rbacManager">The graph rbac manager.</param>
        ///GENMHASH:4B4A4AD2D9CD3095EFC5D25D8ADB59C4:0B494D62307BC80DFFADD0731B914984
        internal  VirtualMachineMsiHelper(IGraphRbacManager rbacManager)
        {
            this.rbacManager = rbacManager;
            this.rolesToAssign = new Dictionary<string, Tuple<string, BuiltInRole>>();
            this.roleDefinitionsToAssign = new Dictionary<string, Tuple<string, string>>();
            Clear();
        }

        /// <summary>
        /// Install or update the MSI extension in the virtual machine and creates a RBAC role assignment
        /// for the auto created service principal with the given role and scope.
        /// </summary>
        /// <param name="virtualMachine">The virtual machine for which the MSI needs to be enabled.</param>
        /// <return>The observable that emits result of MSI resource setup.</return>
        ///GENMHASH:4DF1DA36D30C3D5D08DB9CDE1D4BC40D:CC126234D2C8A916279E40B570059949
        internal async Task<Microsoft.Azure.Management.Compute.Fluent.MSIResourcesSetupResult> SetupVirtualMachineMSIResourcesAsync(IVirtualMachine virtualMachine, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!requireSetup)
            {
                return new MSIResourcesSetupResult();
            }
            if (!virtualMachine.IsManagedServiceIdentityEnabled)
            {
                // The principal id and tenant id needs to be set before performing role assignments
                //
                return new MSIResourcesSetupResult();
            }
            
            OperatingSystemTypes osType = virtualMachine.OSType;
            string extensionTypeName = osType == OperatingSystemTypes.Linux ? LINUX_MSI_EXTENSION : WINDOWS_MSI_EXTENSION;
            MSIResourcesSetupResult result = new MSIResourcesSetupResult();
            try
            {
                var extension = await GetMSIExtensionAsync(virtualMachine, extensionTypeName);
                if (extension != null)
                {
                    result.IsExtensionInstalledOrUpdated = await UpdateMSIExtensionAsync(virtualMachine, extension, extensionTypeName, cancellationToken);
                }
                else
                {
                    result.IsExtensionInstalledOrUpdated = await InstallMSIExtensionAsync(virtualMachine, extensionTypeName);
                }
                result.RoleAssignments = await CreateRbacRoleAssignmentsAsync(virtualMachine, cancellationToken);
                return result;
            } 
            finally
            {
                Clear();
            }
        }

        /// <summary>
        /// Specifies that applications running on the virtual machine requires the given access role
        /// with scope of access limited to the current resource group that the virtual machine
        /// resides.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the virtual machine.</param>
        /// <return>VirtualMachineMsiHelper.</return>
        ///GENMHASH:5FD7E26022EAFDACD062A87DDA8FD39A:C7C1F35D2A566D22AD14F3E781827F65
        internal VirtualMachineMsiHelper WithRoleDefinitionBasedAccessToCurrentResourceGroup(string roleDefinitionId)
        {
            return this.WithRoleDefinitionBasedAccessTo(CURRENT_RESOURCE_GROUP_SCOPE, roleDefinitionId);
        }
    }

///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVNc2lIZWxwZXIuTVNJUmVzb3VyY2VzU2V0dXBSZXN1bHQ=
    public partial class MSIResourcesSetupResult
    {
         public bool IsExtensionInstalledOrUpdated { get; set; }
         public IList<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> RoleAssignments { get; set; }

        ///GENMHASH:814F342B6C7875109FB61B12401ED998:7A348D51C5366D5955D70807A98B7511
        internal  MSIResourcesSetupResult()
        {
            this.IsExtensionInstalledOrUpdated = false;
            this.RoleAssignments = new List<IRoleAssignment>();
        }
    }
}