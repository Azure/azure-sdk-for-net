// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public readonly partial struct NetworkApiVersion
    {
        [CodeGenMember("TwoThousandTwenty1101")]
        public static NetworkApiVersion v2020_11_01 { get; } = new NetworkApiVersion(TwoThousandTwenty1101Value);
        [CodeGenMember("TwoThousandTwentyTwo1101")]
        public static NetworkApiVersion v2022_11_01 { get; } = new NetworkApiVersion(TwoThousandTwentyTwo1101Value);

        [CodeGenMember("TwoThousandTwenty1101")]
        public static NetworkApiVersion TwoThousandTwenty1101 { get; } = v2020_11_01;

        [CodeGenMember("TwoThousandTwentyTwo1101")]
        public static NetworkApiVersion TwoThousandTwentyTwo1101 { get; } = v2022_11_01;
    }
}
