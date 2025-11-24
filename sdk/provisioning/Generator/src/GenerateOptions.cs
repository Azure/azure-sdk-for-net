// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CommandLine;

namespace Generator;

internal class GenerateOptions
{
    [Option(longName: "filter", shortName: 'f', Required = false, Hidden = false)]
    public string? Filter { get; set; }

    [Option(longName: "schema", shortName: 's', Required = false, Default = true, Hidden = false)]
    public bool GenerateSchema { get; set; }
}
