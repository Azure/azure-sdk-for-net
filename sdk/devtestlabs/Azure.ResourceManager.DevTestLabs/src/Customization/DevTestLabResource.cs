// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.DevTestLabs.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DevTestLabs
{
    // [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetDevTestLabServiceFabricSchedules")]
    // [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetDevTestLabVmSchedules")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetDevTestLabPolicies")]
    // [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetDevTestLabServiceFabricScheduleAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    // [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetDevTestLabServiceFabricSchedule", typeof(string), typeof(string), typeof(CancellationToken))]
    // [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetDevTestLabVmScheduleAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    // [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetDevTestLabVmSchedule", typeof(string), typeof(string), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetDevTestLabPolicyAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetDevTestLabPolicy", typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class DevTestLabResource : ArmResource
    {
        /* /// <summary> Gets a collection of DevTestLabServiceFabricSchedules in the <see cref="DevTestLabResource"/>. </summary>
        /// <param name="userName"> The userName for the resource. </param>
        /// <param name="serviceFabricName"> The serviceFabricName for the resource. </param>
        /// <returns> An object representing collection of DevTestLabServiceFabricSchedules and their operations over a DevTestLabServiceFabricScheduleResource. </returns>
        public virtual DevTestLabServiceFabricScheduleCollection GetDevTestLabServiceFabricSchedules(string userName, string serviceFabricName)
        {
            return this.GetCachedClient(client => new DevTestLabServiceFabricScheduleCollection(client, Id));
        }

        /// <summary> Gets a collection of DevTestLabVmSchedules in the <see cref="DevTestLabResource"/>. </summary>
        /// <param name="virtualMachineName"> The virtualMachineName for the resource. </param>
        /// <returns> An object representing collection of DevTestLabVmSchedules and their operations over a DevTestLabVmScheduleResource. </returns>
        public virtual DevTestLabVmScheduleCollection GetDevTestLabVmSchedules(string virtualMachineName)
        {
            return this.GetCachedClient(client => new DevTestLabVmScheduleCollection(client, Id));
        } */

        /// <summary> Gets a collection of DevTestLabPolicies in the <see cref="DevTestLabResource"/>. </summary>
        /// <param name="policySetName"> The policySetName for the resource. </param>
        /// <returns> An object representing collection of DevTestLabPolicies and their operations over a DevTestLabPolicyResource. </returns>
        public virtual DevTestLabPolicyCollection GetDevTestLabPolicies(string policySetName)
        {
            return this.GetCachedClient(client => new DevTestLabPolicyCollection(client, Id, policySetName));
        }

        /* /// <summary> Get schedule. </summary>
        /// <param name="userName"> The userName for the resource. </param>
        /// <param name="serviceFabricName"> The serviceFabricName for the resource. </param>
        /// <param name="name"> The name of the Schedule. </param>
        /// <param name="expand"> Specify the $expand query. Example: 'properties($select=status)'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DevTestLabServiceFabricScheduleResource>> GetDevTestLabServiceFabricScheduleAsync(string userName, string serviceFabricName, string name, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return await this.GetDevTestLabServiceFabricSchedules(userName, serviceFabricName).GetAsync(name, serviceFabricName, name, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get schedule. </summary>
        /// <param name="userName"> The userName for the resource. </param>
        /// <param name="serviceFabricName"> The serviceFabricName for the resource. </param>
        /// <param name="name"> The name of the Schedule. </param>
        /// <param name="expand"> Specify the $expand query. Example: 'properties($select=status)'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DevTestLabServiceFabricScheduleResource> GetDevTestLabServiceFabricSchedule(string userName, string serviceFabricName, string name, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return this.GetDevTestLabServiceFabricSchedules(userName, serviceFabricName).Get(name, serviceFabricName, name, expand, cancellationToken);
        }

        /// <summary> Get schedule. </summary>
        /// <param name="virtualMachineName"> The virtualMachineName for the resource. </param>
        /// <param name="name"> The name of the Schedule. </param>
        /// <param name="expand"> Specify the $expand query. Example: 'properties($select=status)'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DevTestLabVmScheduleResource>> GetDevTestLabVmScheduleAsync(string virtualMachineName, string name, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return await this.GetDevTestLabVmSchedules(virtualMachineName).GetAsync(virtualMachineName, name, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get schedule. </summary>
        /// <param name="virtualMachineName"> The virtualMachineName for the resource. </param>
        /// <param name="name"> The name of the Schedule. </param>
        /// <param name="expand"> Specify the $expand query. Example: 'properties($select=status)'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DevTestLabVmScheduleResource> GetDevTestLabVmSchedule(string virtualMachineName, string name, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return this.GetDevTestLabVmSchedules(virtualMachineName).Get(virtualMachineName, name, expand, cancellationToken);
        } */

        /// <summary> Get policy. </summary>
        /// <param name="policySetName"> The policySetName for the resource. </param>
        /// <param name="name"> The name of the Policy. </param>
        /// <param name="expand"> Specify the $expand query. Example: 'properties($select=description)'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DevTestLabPolicyResource>> GetDevTestLabPolicyAsync(string policySetName, string name, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return await this.GetDevTestLabPolicies(policySetName).GetAsync(name, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get policy. </summary>
        /// <param name="policySetName"> The policySetName for the resource. </param>
        /// <param name="name"> The name of the Policy. </param>
        /// <param name="expand"> Specify the $expand query. Example: 'properties($select=description)'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DevTestLabPolicyResource> GetDevTestLabPolicy(string policySetName, string name, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return this.GetDevTestLabPolicies(policySetName).Get(name, expand, cancellationToken);
        }

        /// <summary>
        /// List disk images available for custom image creation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{name}/listVhds</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Labs_ListVhds</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-09-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DevTestLabResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This operation is not supported. Please use the method GetDevTestLabVhdsAsync instead.", false)]
        public virtual AsyncPageable<SubResource> GetVhdsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This operation is not supported. Please use the method GetDevTestLabVhdsAsync instead.");
        }

        /// <summary>
        /// List disk images available for custom image creation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{name}/listVhds</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Labs_ListVhds</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-09-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DevTestLabResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This operation is not supported. Please use the method GetDevTestLabVhds instead.", false)]
        public virtual Pageable<SubResource> GetVhds(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This operation is not supported. Please use the method GetDevTestLabVhds instead.");
        }
    }
}
