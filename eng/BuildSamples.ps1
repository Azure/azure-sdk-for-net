$baseDir = (Get-Item -Path "$env:BUILD_SOURCESDIRECTORY\samples\" -Verbose).FullName
$items = Get-ChildItem -Path $baseDir -Include *.csproj -Recurse
foreach ($item in $items){
    dotnet build $item
}