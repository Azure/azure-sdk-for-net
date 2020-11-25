[string] $RepoRoot = "${PSScriptRoot}/../.."
[string] $dotnetInstallScriptVersion = "v1"

function GetDotNetInstallScript() {
    $installScript = Join-Path $RepoRoot 'dotnet-install.ps1'
    if (!(Test-Path $installScript)) {
        New-Item -Path $RepoRoot -Force -ItemType 'Directory' | Out-Null
        $maxRetries = 5
        $retries = 1
       
        $uri = "https://dot.net/$dotnetInstallScriptVersion/dotnet-install.ps1"
        while ($true) {
            try {
                Write-Host "GET $uri"
                Invoke-WebRequest $uri -OutFile $installScript
                break
            }
            catch {
                Write-Host "Failed to download '$uri'"
                Write-Error $_.Exception.Message -ErrorAction Continue
            }
            if (++$retries -le $maxRetries) {
                $delayInSeconds = [math]::Pow(2, $retries) - 1 # Exponential backoff
                Write-Host "Retrying. Waiting for $delayInSeconds seconds before next attempt ($retries of $maxRetries)."
                Start-Sleep -Seconds $delayInSeconds
            }
            else {
                throw "Unable to download file in $maxRetries attempts."
            }
        }
    }

    return $installScript
}

$GlobalJson = Get-Content -Raw -Path (Join-Path $RepoRoot 'global.json') | ConvertFrom-Json
$dotnetSdkVersion = $GlobalJson.sdk.version

$installScript = GetDotNetInstallScript
& $installScript -Version $dotnetSdkVersion

if (Test-Path $installScript) {
    Remove-Item $installScript
}
