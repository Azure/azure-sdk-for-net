// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298 and
    // https://github.com/Azure/azure-sdk-for-net/issues/59852 :
    // Identity-aliased Azure.Core.Expressions.DataFactory members are dropped from the generated public
    // surface (#59298) and the emitter no longer emits the public constructor for these flattened types
    // (#59852). This partial restores the GA properties (routed through TypeProperties) and the public ctor.
    // TODO: remove once the generator restores both (#59298, #59852).
    public partial class GoogleSheetsLinkedService
    {
        /// <summary> Property restored as workaround for issues #59298 and #59852. </summary>
        public DataFactorySecret ApiToken
        {
            get
            {
                return TypeProperties is null ? default : TypeProperties.ApiToken;
            }
            set
            {
                if (TypeProperties is null)
                {
                    TypeProperties = new GoogleSheetsLinkedServiceTypeProperties();
                }
                TypeProperties.ApiToken = value;
            }
        }

        /// <summary> Initializes a new instance restored as workaround for issues #59298 and #59852. </summary>
        public GoogleSheetsLinkedService(DataFactorySecret apiToken) : base("GoogleSheets")
        {
            TypeProperties = new GoogleSheetsLinkedServiceTypeProperties(apiToken);
        }
    }
}
