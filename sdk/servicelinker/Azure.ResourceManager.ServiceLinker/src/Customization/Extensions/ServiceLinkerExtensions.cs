// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ServiceLinker.Mocking;

namespace Azure.ResourceManager.ServiceLinker
{
    // The TypeSpec emitter currently generates extension-resource entry points only on ArmClient.
    // Preserve the GA ArmResource extensions and their mockable forwarding surface.
    public static partial class ServiceLinkerExtensions
    {
        private static MockableServiceLinkerArmResource GetMockableServiceLinkerArmResource(ArmResource armResource)
        {
            return armResource.GetCachedClient(client => new MockableServiceLinkerArmResource(client, armResource.Id));
        }

        /// <summary> Gets a collection of Linker resources. </summary>
        public static LinkerResourceCollection GetLinkerResources(this ArmResource armResource)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));
            return GetMockableServiceLinkerArmResource(armResource).GetLinkerResources();
        }

        /// <summary> Gets a Linker resource. </summary>
        [ForwardsClientCalls]
        public static Response<LinkerResource> GetLinkerResource(this ArmResource armResource, string linkerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));
            return GetMockableServiceLinkerArmResource(armResource).GetLinkerResource(linkerName, cancellationToken);
        }

        /// <summary> Gets a Linker resource. </summary>
        [ForwardsClientCalls]
        public static async Task<Response<LinkerResource>> GetLinkerResourceAsync(this ArmResource armResource, string linkerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(armResource, nameof(armResource));
            return await GetMockableServiceLinkerArmResource(armResource).GetLinkerResourceAsync(linkerName, cancellationToken).ConfigureAwait(false);
        }
    }
}
