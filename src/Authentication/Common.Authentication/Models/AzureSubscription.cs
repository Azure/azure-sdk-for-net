// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Common.Authentication.Models
{
    [Serializable]
    public partial class AzureSubscription
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Environment { get; set; }

        public string Account { get; set; }

        public string State { get; set; }

        public Dictionary<Property, string> Properties { get; set; }

        public enum Property
        {
            /// <summary>
            /// Comma separated registered resource providers, i.e.: websites,compute,hdinsight
            /// </summary>
            RegisteredResourceProviders,

            /// <summary>
            /// Associated tenants
            /// </summary>
            Tenants,

            /// <summary>
            /// If this property existed on the subscription indicates that it's default one.
            /// </summary>
            Default,

            StorageAccount
        }
    }
}
