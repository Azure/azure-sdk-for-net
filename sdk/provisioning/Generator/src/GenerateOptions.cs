// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CommandLine;

namespace Generator;

internal class GenerateOptions
{
    [Option(longName: "filter", shortName: 'f', Required = false, Hidden = false)]
    public string? Filter { get; set; }
}
