// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.IotHub
{
    /// <summary>
    /// A class representing a IotHubDescription along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="IotHubDescriptionResource"/> from an instance of <see cref="ArmClient"/> using the GetResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetIotHubDescriptions method.
    /// </summary>
    // Customization justification:
    // These shims intentionally preserve public API shapes from the pre-TypeSpec IoT Hub management
    // package. The TypeSpec-generated ARM surface is more strictly aligned with the resource model, but
    // several GA callers rely on older method names, collection entry points, and string-based If-Match
    // overloads. Keeping these members in custom partials lets the generated code remain regeneration-safe
    // while maintaining source and binary compatibility for existing customers.
    [CodeGenSuppress("GetAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAllAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(CancellationToken))]
    public partial class IotHubDescriptionResource
    {
        // The lower-case "iotHubs" route segment is required to keep the generated swagger identical to
        // the checked-in OpenAPI. With that segment casing, the generator no longer treats these private
        // endpoint operations as normal child-resource collection methods on the parent resource. These
        // helpers restore the previous parameterless collection accessors and single-name forwarding
        // methods by using the parent IoT Hub resource identifier as the missing resourceName.
        /// <summary> Gets a collection of IotHubPrivateEndpointConnectionResources in the IotHubDescription. </summary>
        public virtual IotHubPrivateEndpointConnectionCollection GetIotHubPrivateEndpointConnections()
            => GetCachedClient(client => new IotHubPrivateEndpointConnectionCollection(client, Id));

        /// <summary>
        /// Get private endpoint connection properties
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/iotHubs/{resourceName}/privateEndpointConnections/{privateEndpointConnectionName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PrivateEndpointConnections_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-03-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="IotHubPrivateEndpointConnectionResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<IotHubPrivateEndpointConnectionResource>> GetIotHubPrivateEndpointConnectionAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
            => await GetIotHubPrivateEndpointConnections().GetAsync(privateEndpointConnectionName, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get private endpoint connection properties
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/iotHubs/{resourceName}/privateEndpointConnections/{privateEndpointConnectionName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PrivateEndpointConnections_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-03-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="IotHubPrivateEndpointConnectionResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<IotHubPrivateEndpointConnectionResource> GetIotHubPrivateEndpointConnection(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
            => GetIotHubPrivateEndpointConnections().Get(privateEndpointConnectionName, cancellationToken);

        /// <summary> Gets a collection of IotHubPrivateEndpointGroupInformationResources in the IotHubDescription. </summary>
        public virtual IotHubPrivateEndpointGroupInformationCollection GetAllIotHubPrivateEndpointGroupInformation()
            => GetCachedClient(client => new IotHubPrivateEndpointGroupInformationCollection(client, Id));

        /// <summary>
        /// Get the specified private link resource for the given IotHub
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/iotHubs/{resourceName}/privateLinkResources/{groupId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GroupIdInformations_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-03-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="IotHubPrivateEndpointGroupInformationResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="groupId"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<IotHubPrivateEndpointGroupInformationResource>> GetIotHubPrivateEndpointGroupInformationAsync(string groupId, CancellationToken cancellationToken = default)
            => await GetAllIotHubPrivateEndpointGroupInformation().GetAsync(groupId, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get the specified private link resource for the given IotHub
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/iotHubs/{resourceName}/privateLinkResources/{groupId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GroupIdInformations_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-03-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="IotHubPrivateEndpointGroupInformationResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="groupId"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<IotHubPrivateEndpointGroupInformationResource> GetIotHubPrivateEndpointGroupInformation(string groupId, CancellationToken cancellationToken = default)
            => GetAllIotHubPrivateEndpointGroupInformation().Get(groupId, cancellationToken);
    }
}
