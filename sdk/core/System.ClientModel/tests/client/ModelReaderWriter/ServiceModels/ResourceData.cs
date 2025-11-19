// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.Client.Models.ResourceManager
{
    /// <summary> Common fields that are returned in the response for all Azure Resource Manager resources. </summary>
    public abstract partial class ResourceData
    {
        [Experimental("SCME0001")]
        private JsonPatch _patch;
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Experimental("SCME0001")]
        public ref JsonPatch Patch => ref _patch;

        /// <summary> Initializes a new instance of Resource. </summary>
        protected ResourceData()
        {
        }

        /// <summary> Initializes a new instance of Resource. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. &quot;Microsoft.Compute/virtualMachines&quot; or &quot;Microsoft.Storage/storageAccounts&quot;. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
#pragma warning disable SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        protected ResourceData(string id, string name, string resourceType, SystemData systemData, in JsonPatch jsonPatch)
        {
            Id = id;
            Name = name;
            ResourceType = resourceType;
            SystemData = systemData;
            _patch = jsonPatch;
#pragma warning restore SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        }

        /// <summary> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </summary>
        public string? Id { get; set; }

        /// <summary> The name of the resource. </summary>
        public string? Name { get; set; }

        /// <summary> The type of the resource. E.g. &quot;Microsoft.Compute/virtualMachines&quot; or &quot;Microsoft.Storage/storageAccounts&quot;. </summary>
        public string? ResourceType { get; set; }

        /// <summary> Azure Resource Manager metadata containing createdBy and modifiedBy information. </summary>
        public SystemData? SystemData { get; }
    }
}
