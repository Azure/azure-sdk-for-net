function Get-Namespaces-From-DLL($dllPath) {
    $file = [System.IO.File]::OpenRead($dllPath)
    try {
        $pe = [System.Reflection.PortableExecutable.PEReader]::new($file)
        try {
            $meta = [System.Reflection.Metadata.PEReaderExtensions]::GetMetadataReader($pe)
            foreach ($typeHandle in $meta.TypeDefinitions) {
                $type = $meta.GetTypeDefinition($typeHandle)
                $attr = $type.Attributes
                if ($attr -band 'Public' -and !$type.IsNested) {
                    [pscustomobject]@{
                        Name = $meta.GetString($type.Name)
                        Namespace = $meta.GetString($type.Namespace)
                    }
                }
            }
        } finally {
            $pe.Dispose()
        }
    } finally {
        $file.Dispose()
    }
}

function Fetch-Namespaces-From-Dotnet-Nupkg ($nupkgFilePath, $destination) {
    $tempLocation = (Join-Path ([System.IO.Path]::GetTempPath()) "dotnetNupkg")
    if (Test-Path $tempLocation) {
        Remove-Item $tempLocation/* -Recurse -Force 
    }
    else {
        New-Item -ItemType Directory -Path $tempLocation -Force | Out-Null
    }

    Write-Host "Before zip..."
    Write-Host $nupkgFilePath
    Add-Type -AssemblyName System.IO.Compression.FileSystem
    [System.IO.Compression.ZipFile]::ExtractToDirectory($nupkgFilePath, $tempLocation)
    Write-Host "After zip..."
    $firstDllFiles = Get-ChildItem "$tempLocation/lib" -Filter '*.dll' -Recurse
    if (!$firstDllFiles) {
        Write-Error "Can't find any dll file from dotnet $nupkgFilePath."
        return
    }
    # Rename and move to location
    Write-Host "Copying the package name to $destination..."
    Write-Host "The dll name is $($firstDllFiles[0].FullName)"
    $namespaces = Get-Namespaces-From-DLL $firstDllFiles[0].FullName
    if (!$namespaces) {
        Write-Error "Can't find namespaces from dotnet $nupkgFilePath."
        return
    }
    $namespaces = $namespaces.Namespace | Sort-Object | Get-Unique
    Set-Content -Path $destination -Value $namespaces
}