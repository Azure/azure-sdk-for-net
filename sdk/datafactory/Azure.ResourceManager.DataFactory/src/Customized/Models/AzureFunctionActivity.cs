// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Customization to restore property dropped/renamed by MPG generator (issue #59298).
    public partial class AzureFunctionActivity
    {
        /// <summary> Property restored as workaround for issue #59298. </summary>
        public IDictionary<string, DataFactoryElement<string>> Headers { get; } = new ChangeTrackingDictionary<string, DataFactoryElement<string>>();
    }
}
