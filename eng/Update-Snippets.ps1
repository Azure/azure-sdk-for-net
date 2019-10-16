$generatorProject = "$PSScriptRoot\SnippetGenerator\SnippetGenerator.csproj";
dotnet build $generatorProject

foreach ($file in Get-ChildItem "$PSScriptRoot\..\sdk" -Filter README.md -Recurse)
{
    $samples = Join-Path $file.Directory "samples"
    if (Test-Path $samples)
    {
        dotnet run -p $generatorProject --no-build -u $file.FullName -s $samples
    }
}