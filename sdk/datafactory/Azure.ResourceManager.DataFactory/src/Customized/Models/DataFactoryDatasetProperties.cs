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
    public partial class DataFactoryDatasetProperties
    {
        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFactoryLinkedServiceReference LinkedServiceName { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="DataFactoryDatasetProperties"/> with the required
        /// linked-service reference. Restored as workaround for issue #59298 to match main API surface.
        /// </summary>
        /// <param name="linkedServiceName"> Linked service reference. </param>
        protected DataFactoryDatasetProperties(DataFactoryLinkedServiceReference linkedServiceName) : this(default(string), linkedServiceName)
        {
        }
    }
}
