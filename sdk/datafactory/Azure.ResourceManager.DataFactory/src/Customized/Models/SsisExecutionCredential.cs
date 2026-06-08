// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298 :
    // identity-aliased Azure.Core.Expressions.DataFactory model types can be omitted from generated
    // model surfaces. This partial restores the GA API surface for compatibility.
    // TODO: remove once the generator preserves members whose types use @@alternateType identity (#59298).
    public partial class SsisExecutionCredential
    {
        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFactorySecretString Password { get; set; }

        /// <summary> Initializes a new instance restored as workaround for issue #59298. </summary>
        public SsisExecutionCredential(DataFactoryElement<string> domain, DataFactoryElement<string> userName, DataFactorySecretString password)
            : this()
        {
            Domain = domain;
            UserName = userName;
            Password = password;
        }
    }
}
