param(
  # Sparse checkout paths (glob optional via no-cone mode)
  [Parameter()]
  [Array]$Paths = @(),
  # Expect like
  # @{
  #     Name = '<org>/<repo>'
  #     Commitish = '<commit sha or branch/tag>'
  #     WorkingDirectory = '<path to clone to>'
  # }
  [Parameter(Mandatory = $true)]
  [Hashtable]$Repository
)

# Setting $PSNativeCommandArgumentPassing to 'Legacy' to use PowerShell
# 7.2 behavior for command argument passing. Newer behaviors will result
# in errors from git.exe.
$PSNativeCommandArgumentPassing = 'Legacy'

$dir = $Repository.WorkingDirectory
if (!$dir) {
  $dir = "./$($Repository.Name)"
}
New-Item $dir -ItemType Directory -Force | Out-Null
Push-Location $dir

if (Test-Path .git/info/sparse-checkout) {
  $hasInitialized = $true
  Write-Host "Repository $($Repository.Name) has already been initialized. Skipping this step."
} else {
  Write-Host "Repository $($Repository.Name) is being initialized."

  if ($Repository.Commitish -match '^refs/pull/\d+/merge$') {
    Write-Host "git clone --no-checkout --filter=tree:0 -c remote.origin.fetch='+$($Repository.Commitish):refs/remotes/origin/$($Repository.Commitish)' https://github.com/$($Repository.Name) ."
    git clone --no-checkout --filter=tree:0 -c remote.origin.fetch=''+$($Repository.Commitish):refs/remotes/origin/$($Repository.Commitish)'' https://github.com/$($Repository.Name) .
  } else {
    Write-Host "git clone --no-checkout --filter=tree:0 https://github.com/$($Repository.Name) ."
    git clone --no-checkout --filter=tree:0 https://github.com/$($Repository.Name) .
  }

  # Turn off git GC for sparse checkout. Note: The devops checkout task does this by default
  Write-Host "git config gc.auto 0"
  git config gc.auto 0

  Write-Host "git sparse-checkout init"
  git sparse-checkout init

  # Set non-cone mode otherwise path filters will not work in git >= 2.37.0
  # See https://github.blog/2022-06-27-highlights-from-git-2-37/#tidbits
  Write-Host "git sparse-checkout set --no-cone '/*' '!/*/' '/eng'"
  git sparse-checkout set --no-cone '/*' '!/*/' '/eng'
}

# Prevent wildcard expansion in Invoke-Expression (e.g. for checkout path '/*')
$quotedPaths = $Paths | ForEach-Object { "'$_'" }
$gitsparsecmd = "git sparse-checkout add $quotedPaths"
Write-Host $gitsparsecmd
Invoke-Expression -Command $gitsparsecmd

Write-Host "Set sparse checkout paths to:"
Get-Content .git/info/sparse-checkout

# sparse-checkout commands after initial checkout will auto-checkout again
if (!$hasInitialized) {
  # Remove refs/heads/ prefix from branch names
  $commitish = $Repository.Commitish -replace '^refs/heads/', ''

  # use -- to prevent git from interpreting the commitish as a path
  Write-Host "git -c advice.detachedHead=false checkout $commitish --"

  # This will use the default branch if repo.Commitish is empty
  git -c advice.detachedHead=false checkout $commitish --
} else {
  Write-Host "Skipping checkout as repo has already been initialized"
}

Pop-Location
