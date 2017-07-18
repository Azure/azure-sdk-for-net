Write-Host ""
Write-Host "1) azure-rest-api-specs repository information"
Write-Host "GitHub user:" $Args[0]
Write-Host "Branch:     " $Args[1]
Write-Host "Commit:     " (Invoke-RestMethod "https://api.github.com/repos/$($Args[0])/azure-rest-api-specs/branches/$($Args[1])").commit.sha

Write-Host ""
Write-Host "2) AutoRest information"
Write-Host "Requested version:" $Args[2]
Write-Host "Latest version:   " (autorest --list-installed | Where {$_ -like "*Latest Core Installed*"}).Split()[-1]