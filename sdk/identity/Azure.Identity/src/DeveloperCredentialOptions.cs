// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Identity
{
    /// <summary>
    /// Options for configuring the <see cref="DeveloperCredential"/>.
    /// </summary>
    public class DeveloperCredentialOptions : TokenCredentialOptions
    {
        public DeveloperCredentialOptions(DeveloperSignOnSources sources)
        {
            Sources = sources;
        }

        public DeveloperSignOnSources Sources { get; }
    }
}
