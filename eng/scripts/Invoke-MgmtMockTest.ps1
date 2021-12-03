Param(
    [string] $filter
)

$MOCK_SERVER_NAME = "mock-server"
$MOCK_SERVER_READY = "validator initialized"
$MOCK_SERVER_WAIT_TIME = 600
$AUTOREST_CONFIG_FILE = "src/autorest.md"

. (Join-Path $PSScriptRoot .. common scripts common.ps1)

function PrepareMockServer()
{
    # install mock server
    $folder = Join-Path $env:TEMP "mock-service-host"
    StopMockServer
    try
    {
        Remove-Item -Recurse -Force -Path $folder
    }
    catch
    {
        Write-Host "Mock service host folder: $folder not existed"
    }
    New-Item -ItemType Directory -Force -Path $folder
    Set-Location $folder
    npm install @azure-tools/mock-service-host
}

function StartMockServer($specName, $commitID)
{
    $folder = Join-Path $env:TEMP  "mock-service-host"
    Set-Location $folder

    # change .env file to use the specific swagger file
    $envFile = Join-Path $folder .env
    if ([string]::IsNullOrEmpty($specName))
    {
        $specName = "*"
    }
    New-Item -Path $envFile -ItemType File -Value '' -Force
    Add-Content $envFile "specRetrievalGitUrl=https://github.com/Azure/azure-rest-api-specs
specRetrievalGitBranch=main
specRetrievalGitCommitID=$commitID
validationPathsPattern=specification/$specName/resource-manager/**/*.json"

    # start mock server and check status
    Start-Job -Name $MOCK_SERVER_NAME -ScriptBlock { node node_modules/@azure-tools/mock-service-host/dist/src/main.js 2>&1 }
    $output = Receive-Job $MOCK_SERVER_NAME
    Write-Host "Mock sever status: `n $("$output")"
    $time = 0
    try
    {
        while ("$output" -notmatch $MOCK_SERVER_READY)
        {
            if ($time -gt $MOCK_SERVER_WAIT_TIME)
            {
                Write-Host "##[error] mock server start timeout"
                StopMockServer
                exit 1
            }
            Write-Host "Server not ready, wait for annother 10 seconds"
            $time += 10
            Start-Sleep -Seconds 10
            $output = Receive-Job $MOCK_SERVER_NAME
            Write-Host "Mock sever status: `n $("$output")"
        }
    }
    catch
    {
        Write-Host "##[error]wait for mock server start:`n$_"
        exit 1
    }
}

function StopMockServer()
{
    try
    {
        Stop-Job -Name $MOCK_SERVER_NAME
    }
    catch
    {
        Write-Host "##[error]can not stop mock server:`n$_"
    }
}

function GetSwaggerInfo($dir)
{
    Set-Location $dir
    $swaggerInfoRegex = "(?<commitID>[0-9a-f]{40})\/specification\/(?<specName>.*)\/resource-manager\/readme.md"
    try
    {
        $content = Get-Content .\$AUTOREST_CONFIG_FILE -Raw
        if ($content -match $swaggerInfoRegex)
        {
            return $matches["specName"], $matches["commitID"]
        }
    }
    catch
    {
        Write-Error "Error parsing swagger info"
        Write-Error $_
    }
    Write-Host "Cannot find swagger info"
    exit 1
}

function TestAndGenerateReport($dir)
{
    Set-Location $dir
    # dependencies for go coverage report generation
    go get github.com/jstemmer/go-junit-report
    go get github.com/axw/gocov/gocov
    go get github.com/AlekSi/gocov-xml
    go get github.com/matm/gocov-html

    # set azidentity env for mock test
    $Env:AZURE_TENANT_ID = "mock-test"
    $Env:AZURE_CLIENT_ID = "mock-test"
    $Env:AZURE_USERNAME = "mock-test"
    $Env:AZURE_PASSWORD = "mock-test"

    # do test with corage report and convert to cobertura format
    Write-Host "go cmd: go test -v -coverprofile coverage.txt | Tee-Object -FilePath output.txt"
    go test -v -coverprofile coverage.txt | Tee-Object -FilePath output.txt
    Write-Host "report.xml: cat output.txt | go-junit-report > report.xml"
    cat output.txt | go-junit-report > report.xml
    Write-Host "coverage.json: gocov convert ./coverage.txt > ./coverage.json"
    gocov convert ./coverage.txt > ./coverage.json
    Write-Host "coverage.xml: Get-Content ./coverage.json | gocov-xml > ./coverage.xml"
    Get-Content ./coverage.json | gocov-xml > ./coverage.xml
    Write-Host "coverage.html: Get-Content ./coverage.json | gocov-html > ./coverage.html"
    Get-Content ./coverage.json | gocov-html > ./coverage.html
}

function JudgeExitCode($errorMsg = "execution error")
{
    if (!$?)
    {
        Write-Host "##[error] $errorMsg"
        exit $LASTEXITCODE
    }
}

function ExecuteSingleTest($sdk)
{
    Write-Host "Start mock server"
    $swaggerInfo = GetSwaggerInfo $sdk.DirectoryPath
    StartMockServer $swaggerInfo[0] $swaggerInfo[1]
    # Write-Host "Execute mock test for $($sdk.Name)"
    # TestAndGenerateReport $sdk.DirectoryPath
    # Write-Host "Stop mock server"
    # StopMockServer
}

$env:TEMP = [System.IO.Path]::GetTempPath()
Write-Host "Path tmp: $env:TEMP"

$sdks = Get-AllPackageInfoFromRepo $filter

Write-Host "Prepare mock server"
if ($sdks.Count -eq 0)
{
    Write-Host "No package need to be test"
    exit 0
}
else
{
    PrepareMockServer
    Write-Host "Try Stop mock server"
    StopMockServer
}

foreach ($sdk in $sdks)
{
    if ($sdk.SdkType -eq "mgmt")
    {
        try
        {
            ExecuteSingleTest $sdk
        }
        catch
        {
            Write-Host "##[error]can not finish single test for $sdks :`n$_"
            exit 1
        }
    }
}

Write-Host "Try Stop mock server"
StopMockServer