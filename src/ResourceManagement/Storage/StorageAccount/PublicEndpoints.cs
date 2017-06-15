// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Storage.Fluent.Models;

namespace Microsoft.Azure.Management.Storage.Fluent
{
    public class PublicEndpoints
    {
        internal PublicEndpoints(Endpoints primary, Endpoints secondary)
        {
            Primary = primary;
            Secondary = secondary;
        }

        public Endpoints Primary
        {
            get; private set;
        }

        public Endpoints Secondary
        {
            get; private set;
        }
    }
}
