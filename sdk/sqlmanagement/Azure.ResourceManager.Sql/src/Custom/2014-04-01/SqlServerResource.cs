// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A Class representing a SqlServer along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="SqlServerResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetSqlServerResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetSqlServer method.
    /// </summary>
    public partial class SqlServerResource : ArmResource
    {
        /// <summary> Gets a collection of ServiceObjectiveResources in the SqlServer. </summary>
        /// <returns> An object representing collection of ServiceObjectiveResources and their operations over a ServiceObjectiveResource. </returns>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ServiceObjectiveCollection GetServiceObjectives()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets a database service objective.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/serviceObjectives/{serviceObjectiveName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServiceObjectives_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ServiceObjectiveResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="serviceObjectiveName"> The name of the service objective to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="serviceObjectiveName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="serviceObjectiveName"/> is an empty string, and was expected to be non-empty. </exception>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<ServiceObjectiveResource>> GetServiceObjectiveAsync(string serviceObjectiveName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets a database service objective.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/serviceObjectives/{serviceObjectiveName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServiceObjectives_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ServiceObjectiveResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="serviceObjectiveName"> The name of the service objective to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="serviceObjectiveName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="serviceObjectiveName"/> is an empty string, and was expected to be non-empty. </exception>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ServiceObjectiveResource> GetServiceObjective(string serviceObjectiveName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary> Gets a collection of SqlServerCommunicationLinkResources in the SqlServer. </summary>
        /// <returns> An object representing collection of SqlServerCommunicationLinkResources and their operations over a SqlServerCommunicationLinkResource. </returns>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SqlServerCommunicationLinkCollection GetSqlServerCommunicationLinks()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Returns a server communication link.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/communicationLinks/{communicationLinkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerCommunicationLinks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SqlServerCommunicationLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="communicationLinkName"> The name of the server communication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="communicationLinkName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="communicationLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<SqlServerCommunicationLinkResource>> GetSqlServerCommunicationLinkAsync(string communicationLinkName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Returns a server communication link.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/communicationLinks/{communicationLinkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerCommunicationLinks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SqlServerCommunicationLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="communicationLinkName"> The name of the server communication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="communicationLinkName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="communicationLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<SqlServerCommunicationLinkResource> GetSqlServerCommunicationLink(string communicationLinkName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }
    }
}
