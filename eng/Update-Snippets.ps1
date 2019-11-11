$generatorProject = "$PSScriptRoot\SnippetGenerator\SnippetGenerator.csproj";
dotnet run -p $generatorProject -b "$PSScriptRoot\..\sdk"