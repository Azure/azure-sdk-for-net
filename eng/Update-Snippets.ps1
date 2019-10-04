dotnet build $PSScriptRoot\SnippetGenerator\SnippetGenerator.csproj

foreach ($file in Get-ChildItem "$PSScriptRoot\..\sdk" -Filter README.md -Recurse)
{
    $samples = Join-Path $file.Directory "samples"
    if (Test-Path $samples)
    {
        dotnet run -p "$PSScriptRoot\SnippetGenerator\SnippetGenerator.csproj" --no-build -u $file.FullName -s $samples
    }
}