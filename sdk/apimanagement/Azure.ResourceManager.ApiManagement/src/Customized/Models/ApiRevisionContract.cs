// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ApiManagement.Models
{
    // GA shipped a `string PrivateUriString` accessor alongside the typed `Uri PrivateUri`
    // property (the spec only exposes the Uri form). Re-add the string shim as a thin
    // pass-through over <see cref="PrivateUri"/>.AbsoluteUri.
    public partial class ApiRevisionContract
    {
        /// <summary>
        /// Identifier of the API Revision in form of a relative URL (string form of
        /// <see cref="PrivateUri"/>).
        /// </summary>
        public string PrivateUriString => PrivateUri?.AbsoluteUri;
    }
}
