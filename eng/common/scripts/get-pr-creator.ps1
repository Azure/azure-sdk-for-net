param (
    [Parameter(Mandatory = $true)]
    [string]$RepoOwner,

    [Parameter(Mandatory = $true)]
    [string]$RepoName,

    [Parameter(Mandatory = $true)]
    $PullRequestNumber,

    [Parameter(Mandatory = $true)]
    $VsoPRCreatorVariable,

    [Parameter(Mandatory = $false)]
    $AuthToken
)

$headers = @{ }

if ($AuthToken) {
    $headers = @{
        Authorization = "bearer $AuthToken"
    }
}

try
{
    $prApiUrl = "https://api.github.com/repos/$RepoOwner/$RepoName/pulls/${PullRequestNumber}"
    $response = Invoke-RestMethod -Headers $headers $prApiUrl
    Write-Host "##vso[task.setvariable variable=$VsoPRCreatorVariable;]$($response.user.login)"
}
catch
{
    Write-Error "Invoke-RestMethod ${prApiUrl} failed with exception:`n$_"
    exit 1
}

