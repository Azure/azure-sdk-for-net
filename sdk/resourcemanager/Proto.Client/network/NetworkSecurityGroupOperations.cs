﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Network
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific NetworkSecurityGroup.
    /// </summary>
    public class NetworkSecurityGroupOperations : ResourceOperationsBase<NetworkSecurityGroup>, ITaggableResource<NetworkSecurityGroup>, IDeletableResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkSecurityGroupOperations"/> class.
        /// </summary>
        /// <param name="genericOperations"> An instance of <see cref="GenericResourceOperations"/> that has an id for a virtual machine. </param>
        internal NetworkSecurityGroupOperations(GenericResourceOperations genericOperations)
            : base(genericOperations)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkSecurityGroupOperations"/> class.
        /// </summary>
        /// <param name="resourceGroup"> The client parameters to use in these operations. </param>
        /// <param name="nsgName"> The network security group name. </param>
        internal NetworkSecurityGroupOperations(ResourceGroupOperations resourceGroup, string nsgName)
            : base(resourceGroup, $"{resourceGroup.Id}/providers/Microsoft.Network/networkSecurityGroups/{nsgName}")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkSecurityGroupOperations"/> class.
        /// </summary>
        /// <param name="operation"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected NetworkSecurityGroupOperations(ResourceOperationsBase operation, ResourceIdentifier id)
            : base(operation, id)
        {
        }

        /// <inheritdoc />
        protected override ResourceType ValidResourceType => ResourceType;

        /// <summary>
        /// Gets the resource type definition for a network security group.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/networkSecurityGroups";

        private NetworkSecurityGroupsOperations Operations => new NetworkManagementClient(
            Id.Subscription,
            BaseUri,
            Credential,
            ClientOptions.Convert<NetworkManagementClientOptions>()).NetworkSecurityGroups;

        /// <summary>
        /// Updates the network security group rules.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <param name="rules"> The rules to be updated. </param>
        /// <returns> An <see cref="ArmOperation{NetworkSecurityGroup}"/> that allows polling for completion of the operation. </returns>
        public ArmOperation<NetworkSecurityGroup> UpdateRules(CancellationToken cancellationToken = default, params SecurityRule[] rules)
        {
            var resource = GetResource();
            foreach (var rule in rules)
            {
                // Note that this makes use of the 
                var matchingRule = resource.Data.SecurityRules.FirstOrDefault(r => ResourceIdentifier.Equals(r.Id, rule.Id));
                if (matchingRule != null)
                {
                    matchingRule.Access = rule.Access;
                    matchingRule.Description = rule.Description;
                    matchingRule.DestinationAddressPrefix = rule.DestinationAddressPrefix;
                    //matchingRule.DestinationAddressPrefixes = rule.DestinationAddressPrefixes;
                    matchingRule.DestinationPortRange = rule.DestinationPortRange;
                    //matchingRule.DestinationPortRanges = rule.DestinationPortRanges;
                    matchingRule.Direction = rule.Direction;
                    matchingRule.Priority = rule.Priority;
                    matchingRule.Protocol = rule.Protocol;
                    matchingRule.SourceAddressPrefix = rule.SourceAddressPrefix;
                    //matchingRule.SourceAddressPrefixes = rule.SourceAddressPrefixes;
                    matchingRule.SourcePortRange = rule.SourcePortRange;
                    //matchingRule.SourcePortRanges = rule.SourcePortRanges;
                }
                else
                {
                    resource.Data.SecurityRules.Add(rule);
                }
            }

            return new PhArmOperation<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(
                Operations.StartCreateOrUpdate(Id.ResourceGroup, Id.Name, resource.Data),
                n => new NetworkSecurityGroup(this, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc/>
        public override ArmResponse<NetworkSecurityGroup> Get()
        {
            return new PhArmResponse<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(Operations.Get(Id.ResourceGroup, Id.Name),
                n => new NetworkSecurityGroup(this, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<NetworkSecurityGroup>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(await Operations.GetAsync(Id.ResourceGroup, Id.Name, null, cancellationToken),
                n => new NetworkSecurityGroup(this, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc/>
        public ArmResponse<NetworkSecurityGroup> AddTag(string key, string value)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmResponse<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(
                Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new NetworkSecurityGroup(this, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<NetworkSecurityGroup>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmResponse<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkSecurityGroup(this, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc/>
        public ArmOperation<NetworkSecurityGroup> StartAddTag(string key, string value)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmOperation<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(
                Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new NetworkSecurityGroup(this, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<NetworkSecurityGroup>> StartAddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return new PhArmOperation<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkSecurityGroup(this, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc/>
        public ArmResponse<Response> Delete()
        {
            return new ArmResponse(Operations.StartDelete(Id.ResourceGroup, Id.Name).WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<Response>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmResponse((await Operations.StartDeleteAsync(Id.ResourceGroup, Id.Name, cancellationToken)).WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <inheritdoc/>
        public ArmOperation<Response> StartDelete(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(Operations.StartDelete(Id.ResourceGroup, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<Response>> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(await Operations.StartDeleteAsync(Id.ResourceGroup, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        protected override NetworkSecurityGroup GetResource()
        {
            return Get().Value;
        }

        /// <inheritdoc/>
        public ArmResponse<NetworkSecurityGroup> SetTags(IDictionary<string, string> tags)
        {
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmResponse<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(
                Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new NetworkSecurityGroup(this, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<NetworkSecurityGroup>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmResponse<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkSecurityGroup(this, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc/>
        public ArmOperation<NetworkSecurityGroup> StartSetTags(IDictionary<string, string> tags)
        {
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmOperation<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(
                Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new NetworkSecurityGroup(this, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<NetworkSecurityGroup>> StartSetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(tags);
            return new PhArmOperation<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkSecurityGroup(this, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc/>
        public ArmResponse<NetworkSecurityGroup> RemoveTag(string key)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmResponse<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(
                Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new NetworkSecurityGroup(this, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<NetworkSecurityGroup>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmResponse<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkSecurityGroup(this, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc/>
        public ArmOperation<NetworkSecurityGroup> StartRemoveTag(string key)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmOperation<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(
                Operations.UpdateTags(Id.ResourceGroup, Id.Name, patchable),
                n => new NetworkSecurityGroup(this, new NetworkSecurityGroupData(n)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<NetworkSecurityGroup>> StartRemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new TagsObject();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return new PhArmOperation<NetworkSecurityGroup, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>(await Operations.UpdateTagsAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                n => new NetworkSecurityGroup(this, new NetworkSecurityGroupData(n)));
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        public IEnumerable<LocationData> ListAvailableLocations()
        {
            return ListAvailableLocations(ResourceType);
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of location that may take multiple service requests to iterate over. </returns>
        /// <exception cref="InvalidOperationException"> The default subscription id is null. </exception>
        public async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken);
        }
    }
}
