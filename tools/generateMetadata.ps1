Write-Host $([DateTime]::UtcNow.ToString('u').Replace('Z',' UTC'))

Write-Host ""
Write-Host "1) azure-rest-api-specs repository information"
Write-Host "GitHub user:" $Args[0]
Write-Host "Branch:     " $Args[1]
Try
{
    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
    Write-Host "Commit:     " (Invoke-RestMethod "https://api.github.com/repos/$($Args[0])/azure-rest-api-specs/branches/$($Args[1])").commit.sha
}
Catch
{
    # if the above REST call fails, a commit ID was passed, so we already got the information we need
}

Write-Host ""
Write-Host "2) AutoRest information"
Write-Host "Requested version:" $Args[2]
Try
{
    Write-Host "Bootstrapper version:   " (npm list -g autorest)
}
Catch{}
Try
{
    Write-Host "Latest installed version:   " (autorest --list-installed | Where {$_ -like "*Latest Core Installed*"}).Split()[-1]
}
Catch{}
Try
{
    Write-Host "Latest installed version:   " (autorest --list-installed | Where {$_ -like "*@microsoft.azure/autorest-core*"} | Select -Last 1).Split('|')[3]
}
Catch{}