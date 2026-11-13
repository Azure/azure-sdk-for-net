// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CommandLine;

namespace Generator;

internal class GenerateOptions
{
    [Option(longName: "filter", shortName: 'f', Required = false, Hidden = false)]
    public string? Filter { get; set; }

    [Option(longName: "generate-schema", shortName: 's', Required = false, Hidden = false, Default = true)]
    public bool GenerateSchema { get; set; }
}
