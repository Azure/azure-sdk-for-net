// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class CorsOptions
    {
        /// <summary> The list of origins from which JavaScript code will be granted access to your index. Can contain a list of hosts of the form {protocol}://{fully-qualified-domain-name}[:{port#}], or a single &apos;*&apos; to allow all origins (not recommended). </summary>
        public IList<string> AllowedOrigins { get; }
    }
}
