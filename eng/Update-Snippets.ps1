$generatorProject = "$PSScriptRoot\SnippetGenerator\SnippetGenerator.csproj";
dotnet run -p $generatorProject --no-build -b "$PSScriptRoot\..\sdk"