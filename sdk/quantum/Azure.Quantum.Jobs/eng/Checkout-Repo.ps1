# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
.SYNOPSIS
Checkout a git repository
.DESCRIPTION
This script checkouts a git repository, for a specific branch/commit into a target folder.
It optionally checkout only specific folders (using sparse checkout) to speed-up the checkout process.
.PARAMETER RepoUrl
The URL of the git repo
.PARAMETER TargetFolder
The path of the folder to checkout the git repo
.PARAMETER BranchName
The name of the branch to checkout (defaults to the HEAD branch)
.PARAMETER CommitId
The specific CommitId to checkout (defaults to the HEAD commit id)
.PARAMETER PathAllowList
An array of paths to be checkout (all other paths are not checkout)
.PARAMETER Force
Deletes the TargetFolder before doing the checkout if it already exists

.EXAMPLE
Checkout-Repo.ps1 -RepoUrl https://github.com/microsoft/qdk-python.git -TargetFolder ./qdk-python -Force

# Checks-out the entire qdk-python repo

.EXAMPLE
Checkout-Repo.ps1 -RepoUrl https://github.com/microsoft/qdk-python.git -TargetFolder ./qdk-python -CommitId 8481428bd7eed9d68f960afa6af4ab34de1c75a2 -Force

# Checks-out a specific commit of the qdk-python repo

.EXAMPLE
Checkout-Repo.ps1 -RepoUrl https://github.com/microsoft/qdk-python.git -TargetFolder ./qdk-python -BranchName release/v0.15.2102 -Force

# Checks-out a specific branch of the qdk-python repo

.EXAMPLE
Checkout-Repo.ps1 -RepoUrl https://github.com/microsoft/qdk-python.git -TargetFolder ./qdk-python -PathAllowList /azure-quantum/,/build/ -Force

# Checks-out specific folders of the qdk-python repo

#>

[CmdletBinding()]
Param (
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory=$True)]
    [string] $RepoUrl,
    [ValidateNotNullOrEmpty()]
    [Parameter(Mandatory=$True)]
    [string] $TargetFolder,
    [string] $BranchName,
    [string] $CommitId,
    [string[]] $PathAllowList,
    [switch] $Force
)

$TargetFolderExisted = Test-Path $TargetFolder
if ($TargetFolderExisted)
{
    if ($Force)
    {
        Write-Verbose "Deleting existing folder: $TargetFolder"
        Remove-Item $TargetFolder -Recurse -Force | Write-Verbose
    }
    else
    {
        Write-Verbose "Path already exists: $TargetFolder"
        Write-Verbose "Skipping checkout for $RepoUrl"
        exit 0
    }
}

Write-Verbose "Creating folder: $TargetFolder"
New-Item -ItemType "directory" -Path $TargetFolder -Force | Write-Verbose

Push-Location $TargetFolder 
try {
    git init | Write-Verbose
    if ($LASTEXITCODE -ne 0) { throw "Error initializing git repo" } 

    if (@($PathAllowList).Count -gt 0)
    {
        git config core.sparsecheckout true | Write-Verbose
        if ($LASTEXITCODE -ne 0) { throw "Error enabling git sparse checkout" } 

        git sparse-checkout init --cone | Write-Verbose
        if ($LASTEXITCODE -ne 0) { throw "Error initializing git sparse checkout" } 

        Write-Verbose "Sparse checkout enabled for the following paths:"
        foreach ($Path in $PathAllowList)
        {
            Write-Verbose "  $Path"
            git sparse-checkout add $Path | Write-Verbose
            if ($LASTEXITCODE -ne 0) { throw "Error adding git sparse checkout path: $Path" } 
        }
    }

    Write-Verbose "Git remote URL: $RepoUrl"
    git remote add origin $RepoUrl | Write-Verbose
    if ($LASTEXITCODE -ne 0) { throw "Error adding git remote" } 

    if (![string]::IsNullOrEmpty($CommitId))
    {
        Write-Verbose "Checking out specific commit: $CommitId"
        git fetch --depth=1 origin $CommitId | Write-Verbose
        if ($LASTEXITCODE -ne 0) { throw "Error running git fetch for commit $CommitId" } 
        git checkout $CommitId | Write-Verbose
        if ($LASTEXITCODE -ne 0) { throw "Error running git checkout for commit $CommitId" } 
    }
    elseif (![string]::IsNullOrEmpty($BranchName))
    {
        Write-Verbose "Checking out specific branch: $BranchName"
        git fetch --depth=1 origin $BranchName | Write-Verbose
        if ($LASTEXITCODE -ne 0) { throw "Error running git fetch for branch $BranchName" } 
        git checkout $BranchName | Write-Verbose
        if ($LASTEXITCODE -ne 0) { throw "Error running git fetch for branch $BranchName" } 
    }
    else
    {
        Write-Verbose "Checking out default branch"
        git fetch --depth=1 origin | Write-Verbose
        if ($LASTEXITCODE -ne 0) { throw "Error running git fetch for default branch" } 
        git pull origin HEAD | Write-Verbose
        if ($LASTEXITCODE -ne 0) { throw "Error running git pull for default branch" } 
    }

    exit 0
}
catch {
    # Delete the target folder if it didn't existed before
    # to avoid a partial checkout folder
    if (!$TargetFolderExisted)
    {
        Write-Verbose "Cleaning up partial checkout folder: $TargetFolder"
        Remove-Item $TargetFolder -Recurse -Force | Write-Verbose
    }
    throw
}
finally {
    Pop-Location
}

