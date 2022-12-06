Param(
    [string] $rpName = "*",
    [string] $localSwagger = $null,
    [string] $mockServerFolder = $null,
    [switch] $help
)

if ($help) {
    $ScriptName = $MyInvocation.MyCommand.Name
    Write-Host "## Parameters:"
    Write-Host "##   rpName: compute/keyvault/..., default to be *. Setting specific rpName can accelerate the launching time."
    Write-Host "##   localSwagger: path of the local swagger repo to serve the mock-service-host. Will use https://github.com/Azure/azure-rest-api-specs if this is not assigned."
    Write-Host "##   mockServerFolder: installation folder or mock-service-host. Default to be $$TEMP/mock-service-host."
    Write-Host "##"
    Write-Host "## Typical Usages:"
    Write-Host "##   1) $ScriptName"
    Write-Host "##   2) $ScriptName -rpName compute"
    Write-Host "##   3) $ScriptName -localSwagger C:\projects\azure-rest-api-specs"
    Write-Host "##   4) $ScriptName -rpName compute -localSwagger C:\projects\azure-rest-api-specs -mockServerFolder C:\projects\mock-service-host"
    exit
}

$env:TEMP = [System.IO.Path]::GetTempPath()
$tmpBackupFolder = Join-Path $env:TEMP "mock-service-host-backup"
if (-Not $mockServerFolder) {
    $mockServerFolder = Join-Path $env:TEMP "mock-service-host"
}
$sshFolder = Join-Path $mockServerFolder "node_modules" "@azure-tools" "mock-service-host" ".ssh"

New-Item -ItemType Directory -Force -Path $mockServerFolder | Out-Null
if (-Not (Test-Path -Path $mockServerFolder -PathType Container))
{
    Write-Host "##[error]Failed to create folder $mockServerFolder" -ForegroundColor Red
    exit $LASTEXITCODE
}
Push-Location $mockServerFolder
Write-Host "Will install and launch mock-service-host at $mockServerFolder" -ForegroundColor Green

function PrepareMockServer()
{
    # backup existing certificates
    if (Test-Path $tmpBackupFolder) {
        Remove-Item $tmpBackupFolder -Recurse -Force
    }
    New-Item -ItemType Directory -Force -Path $tmpBackupFolder | Out-Null
    if (Test-Path -Path $sshFolder -PathType Container) {
        Copy-item -Force -Recurse $sshFolder\* -Destination $tmpBackupFolder
    }
    
    # install mock server
    npm install @azure-tools/mock-service-host

    # restore certificates
    Copy-item -Force -Recurse $tmpBackupFolder\* -Destination $sshFolder
}

function TrustMockServerCertificate()
{
    $pemPath = Join-Path $sshFolder "localhost-ca.pem"
    $certPath = Join-Path $sshFolder "localhost-ca.crt"
    if (-Not (Test-Path -Path $pemPath -PathType Leaf)) {
        dir $sshFolder
        if (-Not (Get-Command openssl -errorAction SilentlyContinue))
        {
            Write-Host "##[error]The openssl need to be available. Refer to https://www.openssl.org/source for installation." -ForegroundColor Red
            exit $LASTEXITCODE
        }
        $renewPath = Join-Path $mockServerFolder "node_modules" "@azure-tools" "mock-service-host" "script" "renew-ssh.bat"
        iex $renewPath
        if (-Not (Test-Path -Path $pemPath -PathType Leaf))
        {
            Write-Host "##[error]Failed to create self-signed certificate!" -ForegroundColor Red
            exit $LASTEXITCODE
        }
    }

    if (Test-Administrator) {
        echo "$certPath"
        $cert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2 "$certPath"
        $store = New-Object System.Security.Cryptography.X509Certificates.X509Store "AuthRoot","LocalMachine"
        $store.Open("ReadWrite")
        $store.Add($cert)
        $store.Close()
    }
    else {
        Write-Host "##[warn]Not in Administrator Mode. Please make sure $certPath is in your 'Trusted Root Certification Authorities'" -ForegroundColor Yellow
        Write-Host "##      Double click the file to trust it." -ForegroundColor Yellow
    }
}

function StartMockServer($specName, $commitID)
{
    # change .env file to use the specific swagger file
    $envFile = Join-Path $mockServerFolder .env
    New-Item -Path $envFile -ItemType File -Value '' -Force | Out-Null
    if ($localSwagger) {
        $relativeLocalSwagger = [System.IO.Path]::GetRelativePath($mockServerFolder, $localSwagger)
        Add-Content $envFile "specRetrievalMethod=filesystem
specRetrievalLocalRelativePath=$relativeLocalSwagger
validationPathsPattern=specification/$rpName/resource-manager/**/*.json"
    }
    else {
        Add-Content $envFile "specRetrievalGitUrl=https://github.com/Azure/azure-rest-api-specs
specRetrievalGitBranch=main
validationPathsPattern=specification/$rpName/resource-manager/**/*.json"
    }

    $mainApp = Join-Path "node_modules" "@azure-tools" "mock-service-host" "dist" "src" "main.js"
    node --max_old_space_size=8192 $mainApp
}

function Test-Administrator  
{  
    $user = [Security.Principal.WindowsIdentity]::GetCurrent();
    (New-Object Security.Principal.WindowsPrincipal $user).IsInRole([Security.Principal.WindowsBuiltinRole]::Administrator)  
}

PrepareMockServer
TrustMockServerCertificate
StartMockServer
Pop-Location