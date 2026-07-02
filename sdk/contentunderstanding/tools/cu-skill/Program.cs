// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Entry point for the Content Understanding analyzer-authoring skill tool.
//
// Subcommands:
//   extract-layout       — stage 1: extract document layout into .layout.{json,md}
//   create-and-test      — stage 2 (single-type): validate, create analyzer, batch-test
//   create-and-test-router — stage 2 (classify-and-route): validate + wire N inner + 1 outer
//
// Run:
//   dotnet run --project sdk/contentunderstanding/tools/cu-skill -- extract-layout --input <file> --output <dir>

using AzureSdkContentUnderstanding.Skills;

if (args.Length == 0 || args[0] is "-h" or "--help")
{
    Console.WriteLine("""
        cu-skill — Content Understanding analyzer-authoring tool.

        Subcommands:
          extract-layout              extract document layout (stage 1)
          create-and-test             validate, create, batch-test a single-type analyzer
          create-and-test-router      classify-and-route variant (N inner + 1 outer)

        Use '<subcommand> --help' for per-command flags.
        """);
    return 0;
}

var sub = args[0];
var rest = args.Skip(1).ToArray();

return sub switch
{
    "extract-layout" => await ExtractLayoutCommand.RunAsync(rest),
    "create-and-test" => await CreateAndTestCommand.RunAsync(rest),
    "create-and-test-router" => await CreateAndTestRouterCommand.RunAsync(rest),
    _ => Fail($"unknown subcommand: {sub}. Run with --help to see options."),
};

static int Fail(string message)
{
    Console.Error.WriteLine(message);
    return 2;
}
