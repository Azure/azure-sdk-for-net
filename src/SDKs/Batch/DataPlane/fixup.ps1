foreach($f in (Get-ChildItem ".\Azure.Batch\GeneratedProtocol" -Filter *Operations.cs) + (Get-ChildItem ".\Azure.Batch\GeneratedProtocol" -Filter *OperationsExtensions.cs))
{
    # (Get-Content $f.FullName -Raw).replace('using Microsoft.Azure;`n', '').replace('using Microsoft.Azure.Batch;`n', '') | Set-Content $f.FullName
    $text = [string]::Join("`n", (Get-Content $f.FullName))
    $text = [regex]::Replace($text, " *using Microsoft.Azure;`n", "", "Singleline")
    $text = [regex]::Replace($text, " *using Microsoft.Azure.Batch;`n", "", "Singleline")
    [IO.File]::WriteAllText($f.FullName, $text)
}
