function Invoke-ErrorFunction {
    Write-Host "[ERROR] Failed to create sdk project folder.service:service,package:package,"
    Write-Host "[ERROR] sdkPath:sdkRootPath,readme:readmeFile.exit code: $?."
    Write-Host "[ERROR] Please review the detail errors for potential fixes."
    Write-Host "[ERROR] If the issue persists, contact the DotNet language support channel at DotNetSupportChannelLink and include this spec pull request."
    Write-Host "AAPath doesn't exist. create template."
    $DotNetSupportChannelLink = 'DotNetSupportChannelLink';
    $serviceA = 'serviceA';
    try {
        Write-Error "[ERROR] AAThe service $serviceA is not onboarded yet. We will not support onboard a new service from swagger. Please contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request." -ErrorAction SilentlyContinue
    } catch {
        Write-Output "ERROR: $($_.Exception.Message)"
    }
    Write-Error "[ERROR] BBThe service $serviceA is not onboarded yet. We will not support onboard a new service from swagger. Please contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request." 2>&1
    exit(1)
}

