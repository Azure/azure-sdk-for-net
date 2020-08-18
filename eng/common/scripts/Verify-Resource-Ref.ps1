
. (Join-Path $PSScriptRoot common.ps1)
Install-Module -Name powershell-yaml -RequiredVersion 0.4.1 -Force -Scope CurrentUser
$ymlfiles = Get-ChildItem $RepoRoot | Where-Object {$_ -like '*.yml'}
$affectedRepos = @()

foreach ($file in $ymlfiles)
{
  Write-Host "Verifying '${file}'"
  $ymlContent = Get-Content $file.FullName -Raw
  $ymlObject = ConvertFrom-Yaml $ymlContent -Ordered

  if ($ymlObject.Contains("resources"))
  {
    if ($ymlObject["resources"]["repositories"])
    {
      $repositories = $ymlObject["resources"]["repositories"]
      foreach ($repo in $repositories)
      {
        $repoName = $repo["repository"]
        if (-not ($repo.Contains("ref")))
        {
          $errorMessage = "File: ${file}, Repository: ${repoName}."
          $affectedRepos.Add($errorMessage)
        }
      }
    }
  }
}

if ($affectedRepos.Count -gt 0)
{
    Write-Error "Ref not found in the following Repository Resources."
    foreach ($errorMessage in $affectedRepos)
    {
        Write-Information $errorMessage
    }
    Write-Information "Please ensure you add a Ref: when using repository resources"
    Write-Information "More Info at https://aka.ms/azsdk/engsys/tools-versioning"
    exit 1
}

Write-Information "All repository resources in yaml files reference a valid tag.."