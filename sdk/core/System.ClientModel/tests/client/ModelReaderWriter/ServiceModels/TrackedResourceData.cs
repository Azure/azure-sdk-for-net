// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using ClientModel.Tests.ClientShared;

namespace System.ClientModel.Tests.Client.Models.ResourceManager
{
    /// <summary> The resource model definition for an Azure Resource Manager tracked top level resource which has &apos;tags&apos; and a &apos;location&apos;. </summary>
    public abstract partial class TrackedResourceData : ResourceData
    {
        internal TrackedResourceData()
        {
            Tags = new OptionalDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of TrackedResource. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        protected TrackedResourceData(string location)
        {
            Tags = new OptionalDictionary<string, string>();
            Location = location;
        }

        /// <summary> Initializes a new instance of TrackedResource. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. &quot;Microsoft.Compute/virtualMachines&quot; or &quot;Microsoft.Storage/storageAccounts&quot;. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        protected TrackedResourceData(string id, string name, string resourceType, SystemData systemData, IDictionary<string, string> tags, string location) : base(id, name, resourceType, systemData)
        {
            Tags = tags;
            Location = location;
        }

        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }

        private string? _location;
        /// <summary> The geo-location where the resource lives. </summary>
        public string Location
        {
            get
            {
                AssertHasValue(_location, nameof(Location));
                return _location!;
            }
            set { _location = value; }
        }

        private void AssertHasValue<T>(T? value, string name)
        {
            if (value is null)
                throw new ArgumentNullException(name);
        }
    }
}
