// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Update.Admin;
using Microsoft.AzureStack.Management.Update.Admin.Models;
using System;
using Xunit;

namespace Update.Tests
{

    public class UpdateTestBase : AzureStackTestBase<UpdateAdminClient>
    {
        public UpdateTestBase()
        {
            // Empty
        }

        private bool Equal(string first, string second) {
            return String.Equals(first.ToLower(), second.ToLower());
        }

        protected bool ValidResource(Resource resource) {
            return resource != null && resource.Name != null && resource.Id != null && resource.Location != null && resource.Type != null;
        }

        protected bool ResourceAreSame(Resource expected, Resource found) {
            if (expected == null) return (found == null);

            return Equal(expected.Name, found.Name) && Equal(expected.Id, found.Id) && Equal(expected.Location, found.Location) && Equal(expected.Type, found.Type);
        }

        protected override void ValidateClient(UpdateAdminClient client)
        {
            // validate creation
            Assert.NotNull(client);

            // validate objects
            Assert.NotNull(client.UpdateLocations);
            Assert.NotNull(client.UpdateRuns);
            Assert.NotNull(client.Updates);
        }
    }
}

