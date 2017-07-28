// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Collections.Generic;
    using ResourceManager.Fluent.Core;
    using Models;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Threading;

    /// <summary>
    /// Represents a extension collection associated with a virtual machine.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVFeHRlbnNpb25zSW1wbA==
    internal partial class VirtualMachineExtensionsImpl :
        ExternalChildResourcesCached<
            VirtualMachineExtensionImpl,
            IVirtualMachineExtension,
            VirtualMachineExtensionInner,
            IVirtualMachine,
            VirtualMachineImpl>
    {
        /// <summary>
        /// Creates new VirtualMachineExtensionsImpl.
        /// </summary>
        /// <param name="client">The client to perform REST calls on extensions.</param>
        /// <param name="parent">The parent virtual machine of the extensions.</param>
        ///GENMHASH:5FE619A4E78C738ABAB49088366D56E9:A3B8391A0D11DA58771A04AD80F595FB
        internal VirtualMachineExtensionsImpl(VirtualMachineImpl parent) 
            : base(parent, "VirtualMachineExtension")
        {
            this.CacheCollection();
        }

        /// <return>The extension as a map indexed by name.</return>

        ///GENMHASH:310B2185D2F2431DF2BBDBC06E585C74:F003E4397C7BD6AC051C07C6076BF2D5
        public IReadOnlyDictionary<string, IVirtualMachineExtension> AsMap()
        {
            return Extensions.Synchronize(() => this.AsMapAsync());
        }

        /// <summary>
        /// Starts an extension definition chain.
        /// </summary>
        /// <param name="name">The reference name of the extension to be added.</param>
        /// <return>The extension.</return>

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:E3D9E623E212362C450DC90E92DF3FCC
        public VirtualMachineExtensionImpl Define(string name)
        {
            return this.PrepareDefine(name);
        }

        /// <summary>
        /// Starts an extension update chain.
        /// </summary>
        /// <param name="name">The reference name of the extension to be updated.</param>
        /// <return>The extension.</return>

        ///GENMHASH:C45CF357E710B1EC18EFF0A7FCD36915:3FB710926B53C5FC505B69CE66B544B2
        public VirtualMachineExtensionImpl Update(string name)
        {
            return this.PrepareUpdate(name);
        }

        /// <summary>
        /// Mark the extension with given name as to be removed.
        /// </summary>
        /// <param name="name">The reference name of the extension to be removed.</param>

        ///GENMHASH:FC8ECF797E9AF86E82C3899A3D5C00BB:97028F0C4A32755497D72429D22C1125
        public void Remove(string name)
        {
            this.PrepareRemove(name);
        }

        /// <summary>
        /// Adds the extension to the collection.
        /// </summary>
        /// <param name="extension">The extension.</param>

        ///GENMHASH:A699C0E0CB5117B44B60B8BA5AB70E0D:C26A95D3106CF566351D42FA65A89642
        public void AddExtension(VirtualMachineExtensionImpl extension)
        {
            this.AddChildResource(extension);
        }

        ///GENMHASH:6A122C62EB559D6E6E53725061B422FB:BBFC34CF308571F286DFAC418AD70B78
        protected override IList<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtensionImpl> ListChildResources()
        {
            List<VirtualMachineExtensionImpl> childResources = new List<VirtualMachineExtensionImpl>();
            if (this.Parent.Inner.Resources != null)
            {
                foreach (VirtualMachineExtensionInner inner in this.Parent.Inner.Resources) {
                    if (inner.Name == null)
                    {
                        inner.Location = this.Parent.RegionName;
                        childResources.Add(new VirtualMachineExtensionImpl(ResourceUtils.NameFromResourceId(inner.Id), Parent, inner));
                    } else
                    {
                        childResources.Add(new VirtualMachineExtensionImpl(inner.Name, Parent, inner));
                    }
                }
            }
            return childResources;
        }

        ///GENMHASH:8E8DA5B84731A2D412247D25A544C502:A46E953787CEB47EF54D89C635EAF3F8
        protected override VirtualMachineExtensionImpl NewChildResource(string name)
        {
            VirtualMachineExtensionImpl extension = VirtualMachineExtensionImpl.NewVirtualMachineExtension(name, Parent);
            return extension;
        }

        /// <return>An observable emits extensions in this collection as a map indexed by name.</return>
        ///GENMHASH:8F0A24162CE08C4C74F06A527A9961A6:7E2A0D98F7FF37B726A757DFE36DF931
        public async Task<IReadOnlyDictionary<string, IVirtualMachineExtension>> AsMapAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IDictionary<string, IVirtualMachineExtension> map = new Dictionary<string, IVirtualMachineExtension>();
            var extensions = await ListAsync(cancellationToken);
            foreach (var extension in extensions)
            {
                map.Add(extension.Name, extension);
            }
            return new ReadOnlyDictionary<string, IVirtualMachineExtension>(map);
        }

        /// <return>An observable emits extensions in this collection.</return>
        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:AD716846445280039AFCFD4C2966F1B7
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IList<IVirtualMachineExtension> result = new List<IVirtualMachineExtension>();
            foreach (var entry in this.Collection)
            {
                var extension = entry.Value;
                var extensionName = entry.Key;
                if (entry.Value.IsReference())
                {
                    extension = new VirtualMachineExtensionImpl(
                        extensionName,
                        Parent,
                        await Parent.Manager.Inner.VirtualMachineExtensions.GetAsync(Parent.ResourceGroupName, Parent.Name, extensionName, cancellationToken: cancellationToken));
                }
                result.Add(extension);
            }
            return new ReadOnlyCollection<IVirtualMachineExtension>(result);
        }
    }
}
