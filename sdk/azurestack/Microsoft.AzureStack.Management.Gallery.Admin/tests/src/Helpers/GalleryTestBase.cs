// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Gallery.Admin;
using Microsoft.AzureStack.Management.Gallery.Admin.Models;
using Xunit;

namespace Gallery.Tests
{

    public class GalleryTestBase : AzureStackTestBase<GalleryAdminClient>
    {
        public GalleryTestBase()
        {
            // Empty
        }

        protected bool ResourcesSame(Resource expected, Resource given) {
            if (expected == null) return given == null;
            return given != null && expected.Name == given.Name && expected.Type == given.Type && expected.Id == given.Id && expected.Location == given.Location;
        }

        protected override void ValidateClient(GalleryAdminClient client)
        {
            // validate creation
            Assert.NotNull(client);

            // validate objects
            Assert.NotNull(client.GalleryItems);
        }
    }
}
