// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Mocking
{
    // The TypeSpec emitter currently generates extension-resource entry points only on ArmClient.
    // Preserve the GA ArmResource mocking surface by forwarding to the generated collection.
    /// <summary> A class to add extension methods to <see cref="ArmResource"/>. </summary>
    public partial class MockableServiceLinkerArmResource : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableServiceLinkerArmResource"/> class for mocking. </summary>
        protected MockableServiceLinkerArmResource()
        {
        }

        internal MockableServiceLinkerArmResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Gets a collection of Linker resources. </summary>
        public virtual LinkerResourceCollection GetLinkerResources()
        {
            return GetCachedClient(client => new LinkerResourceCollection(client, Id));
        }

        /// <summary> Gets a Linker resource. </summary>
        public virtual Response<LinkerResource> GetLinkerResource(string linkerName, CancellationToken cancellationToken = default)
        {
            return GetLinkerResources().Get(linkerName, cancellationToken);
        }

        /// <summary> Gets a Linker resource. </summary>
        public virtual async Task<Response<LinkerResource>> GetLinkerResourceAsync(string linkerName, CancellationToken cancellationToken = default)
        {
            return await GetLinkerResources().GetAsync(linkerName, cancellationToken).ConfigureAwait(false);
        }
    }
}
