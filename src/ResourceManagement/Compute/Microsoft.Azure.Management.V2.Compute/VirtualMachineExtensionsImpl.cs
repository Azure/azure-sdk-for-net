// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.V2.Compute
{
    using Management.Compute;
    using Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Represents a extension collection associated with a virtual machine.
    /// </summary>
    public partial class VirtualMachineExtensionsImpl :
        ExternalChildResources<VirtualMachineExtensionImpl, IVirtualMachineExtension, VirtualMachineExtensionInner, IVirtualMachine, VirtualMachineImpl>
    {
        private IVirtualMachineExtensionsOperations client;
        /// <summary>
        /// Creates new VirtualMachineExtensionsImpl.
        /// </summary>
        /// <param name="client">client the client to perform REST calls on extensions</param>
        /// <param name="parent">parent the parent virtual machine of the extensions</param>
        internal VirtualMachineExtensionsImpl(IVirtualMachineExtensionsOperations client, VirtualMachineImpl parent) 
            : base(parent, "VirtualMachineExtension")
        {
            this.client = client;
            this.InitializeCollection();
        }

        /// <returns>the extension as a map indexed by name.</returns>
        public IDictionary<string, IVirtualMachineExtension> AsMap()
        {
            IDictionary<string, IVirtualMachineExtension> result = new Dictionary<string, IVirtualMachineExtension>();
            foreach (var entry in this.Collection)
            {
                var extension = entry.Value;
                var extensionName = entry.Key;
                if (entry.Value.IsReference.Value)
                {
                    extension = new VirtualMachineExtensionImpl(extensionName,
                        this.Parent,
                        this.client.Get(Parent.ResourceGroupName, Parent.Name, extensionName),
                        this.client);
                }
                result.Add(extensionName, extension);
            }
            return new ReadOnlyDictionary<string, IVirtualMachineExtension>(result);
        }

        /// <summary>
        /// Starts an extension definition chain.
        /// </summary>
        /// <param name="name">name the reference name of the extension to be added</param>
        /// <returns>the extension</returns>
        public VirtualMachineExtensionImpl Define(string name)
        {
            return this.PrepareDefine(name);
        }

        /// <summary>
        /// Starts an extension update chain.
        /// </summary>
        /// <param name="name">name the reference name of the extension to be updated</param>
        /// <returns>the extension</returns>
        public VirtualMachineExtensionImpl Update(string name)
        {
            return this.PrepareUpdate(name);
        }

        /// <summary>
        /// Mark the extension with given name as to be removed.
        /// </summary>
        /// <param name="name">name the reference name of the extension to be removed</param>
        public void Remove(string name)
        {
            this.PrepareRemove(name);
        }

        /// <summary>
        /// Adds the extension to the collection.
        /// </summary>
        /// <param name="extension">extension the extension</param>
        public void AddExtension(VirtualMachineExtensionImpl extension)
        {
            this.AddChildResource(extension);
        }

        protected override IList<VirtualMachineExtensionImpl> ListChildResources()
        {
            List<VirtualMachineExtensionImpl> childResources = new List<VirtualMachineExtensionImpl>();
            if (this.Parent.Inner.Resources != null)
            {
                foreach (VirtualMachineExtensionInner inner in this.Parent.Inner.Resources) {
                    if (inner.Name == null)
                    {
                        inner.Location = this.Parent.RegionName;
                        childResources.Add(new VirtualMachineExtensionImpl(ResourceUtils.NameFromResourceId(inner.Id),
                            this.Parent,
                            inner,
                            this.client));
                    } else
                    {
                        childResources.Add(new VirtualMachineExtensionImpl(inner.Name,
                            this.Parent,
                            inner,
                            this.client));
                    }
                }
            }
            return childResources;
        }

        protected override VirtualMachineExtensionImpl NewChildResource(string name)
        {
            VirtualMachineExtensionImpl extension = VirtualMachineExtensionImpl.NewVirtualMachineExtension(name, this.Parent, this.client);
            return extension;
        }
    }
}