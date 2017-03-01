Function Log-Info
{
    [CmdletBinding()]
    param( [string] [Parameter(Position=0)] $info = "")

    $info = [string]::Format("[INFO]: {0}", $info)
    Write-Host $info -ForegroundColor Yellow
}


function Write-Log
{
    [CmdletBinding()]
    param( [Object] [Parameter(Position=0, ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$false)] $obj = "")
    PROCESS
    {
        $obj | Out-String | Write-Verbose
    }
}
export-modulemember -Function Log-Info
export-modulemember -Function Write-Log