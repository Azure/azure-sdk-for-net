// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customization added as a workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298

#nullable disable

using System.Collections.Generic;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    public partial class WebActivity
    {
        /// <summary> Property restored as workaround for issue #59298. </summary>
        public IList<DataFactoryLinkedServiceReference> LinkedServices { get; } = new List<DataFactoryLinkedServiceReference>();
    }
}
