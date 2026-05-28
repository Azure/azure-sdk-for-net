// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public readonly partial struct NetworkApiVersion
    {
        /// <summary> 2020-11-01. </summary>
        [CodeGenMember("TwoThousandTwenty1101")]
        public static NetworkApiVersion v2020_11_01 { get; } = new NetworkApiVersion(v2020_11_01Value);
        /// <summary> 2022-11-01. </summary>
        [CodeGenMember("TwoThousandTwentyTwo1101")]
        public static NetworkApiVersion v2022_11_01 { get; } = new NetworkApiVersion(v2022_11_01Value);

        /// <summary> 2020-11-01. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkApiVersion TwoThousandTwenty1101 { get; } = v2020_11_01;
    }
}
