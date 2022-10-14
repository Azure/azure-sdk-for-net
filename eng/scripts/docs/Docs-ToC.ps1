function Get-NamepspacesFromDll($dllPath) {
    $file = [System.IO.File]::OpenRead($dllPath)
    try {
        # Use to parse the namespaces out from the dll file.
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

function Fetch-NamespacesFromNupkg ($nupkgFilePath, $destination) {
    $tempLocation = (Join-Path ([System.IO.Path]::GetTempPath()) "dotnetNupkg")
    if (Test-Path $tempLocation) {
        Remove-Item $tempLocation/* -Recurse -Force 
    }
    else {
        New-Item -ItemType Directory -Path $tempLocation -Force | Out-Null
    }

    Write-Host "Unzipping nupkg..."
    Write-Host $nupkgFilePath
    Add-Type -AssemblyName System.IO.Compression.FileSystem
    [System.IO.Compression.ZipFile]::ExtractToDirectory($nupkgFilePath, $tempLocation)
    # .NET core includes multiple target framework. We currently have the same namespaces for different framework. 
    # Will use whatever the first dll file.
    Write-Host "Searching ddl file..."
    $firstDllFiles = Get-ChildItem "$tempLocation/lib" -Filter '*.dll' -Recurse
    if (!$firstDllFiles) {
        Write-Error "Can't find any dll file from dotnet $nupkgFilePath."
        return
    }
    Write-Host "Dll file found: $($firstDllFiles[0].FullName)"
    $namespaces = Get-NamepspacesFromDll $firstDllFiles[0].FullName
    if (!$namespaces) {
        Write-Error "Can't find namespaces from dotnet $nupkgFilePath."
        return
    }
    $namespaces = $namespaces.Namespace | Sort-Object -Unique
    # Rename and move to location
    Write-Host "Copying the package namespaces to $destination..."
    Set-Content -Path $destination -Value $namespaces
}
