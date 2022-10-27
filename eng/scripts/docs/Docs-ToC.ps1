function Get-NamepspacesFromDll($dllPath) {
    $file = [System.IO.File]::OpenRead($dllPath)
    $namespaces = @()
    try {
        # Use to parse the namespaces out from the dll file.
        $pe = [System.Reflection.PortableExecutable.PEReader]::new($file)
        try {
            $meta = [System.Reflection.Metadata.PEReaderExtensions]::GetMetadataReader($pe)
            foreach ($typeHandle in $meta.TypeDefinitions) {
                $type = $meta.GetTypeDefinition($typeHandle)
                $attr = $type.Attributes
                if ($attr -band 'Public' -and !$type.IsNested) {
                    $namespaces += $meta.GetString($type.Namespace)
                }
            }
        } finally {
            $pe.Dispose()
        }
    } finally {
        $file.Dispose()
    }
    return $namespaces | Sort-Object -Unique
}
