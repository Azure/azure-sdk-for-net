// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.IndependentChild.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Update;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    internal partial class SqlFirewallRuleImpl 
    {
        /// <summary>
        /// Sets the ending IP address of SQL server's firewall rule.
        /// </summary>
        /// <param name="endIPAddress">End IP address in IPv4 format.</param>
        /// <return>The next stage of the update.</return>
        SqlFirewallRule.Update.IUpdate SqlFirewallRule.Update.IWithEndIPAddress.WithEndIPAddress(string endIPAddress)
        {
            return this.WithEndIpAddress(endIPAddress) as SqlFirewallRule.Update.IUpdate;
        }

        /// <summary>
        /// Sets the starting IP address of SQL server's firewall rule.
        /// </summary>
        /// <param name="startIPAddress">Start IP address in IPv4 format.</param>
        /// <return>The next stage of the update.</return>
        SqlFirewallRule.Update.IUpdate SqlFirewallRule.Update.IWithStartIPAddress.WithStartIPAddress(string startIPAddress)
        {
            return this.WithStartIpAddress(startIPAddress) as SqlFirewallRule.Update.IUpdate;
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Sql.Fluent.ISqlManager>.Manager
        {
            get
            {
                return this.Manager as Microsoft.Azure.Management.Sql.Fluent.ISqlManager;
            }
        }

        /// <summary>
        /// Sets the ending IP address of SQL server's firewall rule.
        /// </summary>
        /// <param name="ipAddress">IP address in IPv4 format.</param>
        /// <return>The next stage of the definition.</return>
        SqlFirewallRule.Definition.IWithCreate SqlFirewallRule.Definition.IWithIPAddress.WithIPAddress(string ipAddress)
        {
            return this.WithIpAddress(ipAddress) as SqlFirewallRule.Definition.IWithCreate;
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
        /// Creates a new child resource under parent resource.
        /// </summary>
        /// <param name="parentResourceCreatable">A creatable definition for the parent resource.</param>
        /// <return>The creatable for the child resource.</return>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> Microsoft.Azure.Management.ResourceManager.Fluent.Core.IndependentChild.Definition.IWithParentResource<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule,Microsoft.Azure.Management.Sql.Fluent.ISqlServer>.WithNewParentResource(ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlServer> parentResourceCreatable)
        {
            return this.WithNewParentResource(parentResourceCreatable) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>;
        }

        /// <summary>
        /// Creates a new child resource under parent resource.
        /// </summary>
        /// <param name="groupName">The name of the resource group for parent resource.</param>
        /// <param name="parentName">The name of the parent resource.</param>
        /// <return>The creatable for the child resource.</return>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> Microsoft.Azure.Management.ResourceManager.Fluent.Core.IndependentChild.Definition.IWithParentResource<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule,Microsoft.Azure.Management.Sql.Fluent.ISqlServer>.WithExistingParentResource(string groupName, string parentName)
        {
            return this.WithExistingParentResource(groupName, parentName) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>;
        }

        /// <summary>
        /// Creates a new child resource under parent resource.
        /// </summary>
        /// <param name="existingParentResource">The parent resource under which this resource to be created.</param>
        /// <return>The creatable for the child resource.</return>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> Microsoft.Azure.Management.ResourceManager.Fluent.Core.IndependentChild.Definition.IWithParentResource<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule,Microsoft.Azure.Management.Sql.Fluent.ISqlServer>.WithExistingParentResource(ISqlServer existingParentResource)
        {
            return this.WithExistingParentResource(existingParentResource) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>;
        }

        /// <summary>
        /// Sets the starting IP address of SQL server's firewall rule.
        /// </summary>
        /// <param name="startIPAddress">Starting IP address in IPv4 format.</param>
        /// <param name="endIPAddress">Starting IP address in IPv4 format.</param>
        /// <return>The next stage of the definition.</return>
        SqlFirewallRule.Definition.IWithCreate SqlFirewallRule.Definition.IWithIPAddressRange.WithIPAddressRange(string startIPAddress, string endIPAddress)
        {
            return this.WithIpAddressRange(startIPAddress, endIPAddress) as SqlFirewallRule.Definition.IWithCreate;
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

        /// <summary>
        /// Gets the start IP address (in IPv4 format) of the Azure SQL Server Firewall Rule.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.StartIPAddress
        {
            get
            {
                return this.StartIpAddress();
            }
        }

        /// <summary>
        /// Gets region of SQL Server that contains this firewall rule.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.Region
        {
            get
            {
                return this.Region() as Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region;
            }
        }

        /// <summary>
        /// Gets the end IP address (in IPv4 format) of the Azure SQL Server Firewall Rule.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.EndIPAddress
        {
            get
            {
                return this.EndIpAddress();
            }
        }

        /// <summary>
        /// Gets kind of SQL Server that contains this firewall rule.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.Kind
        {
            get
            {
                return this.Kind();
            }
        }

        /// <summary>
        /// Gets name of the SQL Server to which this firewall rule belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Deletes the firewall rule.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule.Delete()
        {
 
            this.Delete();
        }
    }
}