$(
  $repo_name = 'azure-sdk-for-net'
  $branch    = if ($Env:SYSTEM_PULLREQUEST_SOURCEBRANCH) { "$Env:SYSTEM_PULLREQUEST_SOURCEBRANCH" } else { "$Env:BUILD_SOURCEBRANCHNAME" }
  $build     = "$Env:BUILD_BUILDNUMBER"
  $build_url = "$Env:SYSTEM_TEAMFOUNDATIONCOLLECTIONURI$Env:SYSTEM_TEAMPROJECT/_build/results?buildId=$Env:BUILD_BUILDID"
  $commit    = "$Env:BUILD_SOURCEVERSION"
  $isfork    = "$Env:SYSTEM_PULLREQUEST_ISFORK" -eq "True"
  $rel_url   = "$Env:RELEASE_RELEASEWEBURL"
  $release   = "$Env:RELEASE_RELEASENAME"
  $repo      = if ($isfork) { "$Env:BUILD_REPOSITORY_NAME" } else { "Azure/$repo_name" }

  function Capitalize($str) {
    if ($str) { 
      $str.Substring(0,1).ToUpper() + $str.Substring(1).ToLower()
    }
  }

  function Title($str) {
    if ($str) { 
      (Get-Culture).TextInfo.ToTitleCase($str.ToLower())
    }
  }


  function Pluralize($num, $singular, $plural) {
    if ($num -eq 1) { $singular } else { $plural }
  }
)
<!DOCTYPE html>
<html>
  <head>
    <title>$(Capitalize $repo_name) Dependency Report</title>
    <meta charset="UTF-8"/>
    <style>
      body {
          font-family: Verdana, sans-serif;
          font-size: 14px;
          text-size-adjust: none;
      }
      table {
          border-spacing: 0px;
          width: 65%;
          font-size: 14px;
      }
      table.condensed tr td {
          padding: 7px 15px;
      }
      th, td {
          padding: 15px;
          border-bottom: 1px solid #ddd;
          vertical-align:top;
      }
      tr:nth-child(even) {
          background-color: #f2f2f2;
      }
      th {
          background-color: #2E7CAF;
          color: white;
          font-weight: 300;
          text-align: left;
      }
      th a {
        color: white;
      }
      th.inconsistent {
        background-color: #FF0000;
      }
      td.inconsistent {
        color: #FF0000;
      }
      td.version {
          width: 75px;
      }
      code {
        font-family: SFMono-Regular,Consolas,Liberation Mono,Menlo,Courier,monospace;
        background-color: rgba(27,31,35,.05);
        border-radius: 3px;
        font-size: 85%;
        padding: .2em .4em;
      }
      .tooltip {
          position: relative;
          display: inline-block;
          border-bottom: 1px dotted black;
      }
      .tooltip .tooltiptext {
          visibility: hidden;
          background-color: black;
          color: #fff;
          white-space: nowrap;
          text-align: left;
          padding: 5px;
          font-size: 14px;
          position: absolute;
          z-index: 1;
          margin-top: 7px;
          top: 100%;
          left: 0%;
      }
      .tooltip .tooltiptext::after {
          content: " ";
          position: absolute;
          bottom: 100%;  /* At the top of the tooltip */
          left: 5%;
          margin-left: -5px;
          border-width: 5px;
          border-style: solid;
          border-color: transparent transparent black transparent;
      }
      .tooltip:hover .tooltiptext {
          visibility: visible;
      }

      .success {
          color: #00CC00;
      }
      .fail {
          color: #CC0000;
      }

      @media only screen and (max-width: 1350px) {
          body, table {
              font-size: 25px;
          }
          table {
              width: 95%;
          }
          td.version {
              width: 35px;
          }
      }
    </style>
  </head>
  <body>
    <center>
      <h1>$(Capitalize $repo_name) Dependency Report</h1>
      <h3>
        Generated at $([DateTime]::UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"))
        $(
          if ($release) {
            "for release <a href=""$rel_url"">$release</a>"
          } elseif ($build) {
            "for build <a href=""$build_url"">$build</a>"
            if ($branch) {
              "<br/>from branch <a href=""https://github.com/$repo/tree/$branch"">$branch</a>"
              if ($isfork) {
                "in repo <a href=""https://github.com/$repo"">$repo</a>"
              }
            }
            if ($commit) {
              "(<a href=""https://github.com/$repo/commit/$commit"">$($commit.Substring(0, 7))</a>)"
            }
          }
        )
      </h3>
      <p>
        $($Deps.Count - $External.Count) internal and $($External.Count) external package <a href="#dependencies">$(Pluralize $Deps.Count 'dependency</a> was' 'dependencies</a> were') analyzed to determine if any packages declare inconsistent dependency versions.<br/>
        $(
          if ($Inconsistent) {
            "<strong>$($Inconsistent.Count) inconsistent dependency $(Pluralize $Inconsistent.Count 'version was' 'versions were') discovered.</strong><br/><br/>"
          } else {
            "All dependencies verified, no inconsistent dependency versions were discovered.<br/><br/>"
          }
        )
        $(
          if ($Locked) {
            "$($Locked.Count) dependency $(Pluralize $Locked.Count 'version was' 'versions were') discovered in the <a href=""#lockfile"">lockfile</a>.<br/>"
            if ($MismatchedVersions -or $Unlocked) {
              if ($MismatchedVersions) {
                "<strong>$($MismatchedVersions.Count) dependency version $(Pluralize $MismatchedVersions.Count 'override is' 'overrides are') present, causing dependency versions to differ from the version in the lockfile.</strong><br/>"
              }
              if ($Unlocked) {
                "<strong>$($Unlocked.Count) $(Pluralize $Unlocked.Count 'dependency is' 'dependencies are') missing from the lockfile.</strong><br/>"
              }
            } else {
              "All declared dependency versions match those specified in the lockfile.<br/>"
            }
          } else {
            "<strong>No lockfile was provided, or the lockfile was empty. Declared dependency versions were not able to be validated against the lockfile.</strong><br/>"
          }
        )
        <br/>This report scanned $($Pkgs.Count) <a href="#packages">$(Pluralize $Pkgs.Count 'package' 'packages')</a>.
      </p>
      <a name="dependencies"/>
      $(
        $header_written = $false
        foreach ($Dep in ($Deps.Keys | sort)) {
          "<a name=""dep_$Dep""/><table><thead>"
          if (-not $header_written) {
            "<tr><th colspan=""2""><strong>Dependencies Discovered in Packages</strong></th></tr>"
            $header_written = $true
          }
          if ($External.Contains($Dep)) { $dep_type = "external"} else { $dep_type = "internal" }
          if ($Inconsistent.ContainsKey($Dep)) { $dep_type = "inconsistent " + $dep_type }
          "<tr><th colspan=""2"" class=""$dep_type""><strong>$(Title $dep_type) Dependency:</strong> $Dep</th></tr></thead><tbody>"
          foreach ($TargetFramework in ($Deps[$Dep].Keys | sort)) {
            $fw_type = ""
            if ($Inconsistent[$Dep] -and $Inconsistent[$Dep].Contains($TargetFramework)) { $fw_type = "inconsistent" }
            "<tr><td colspan=""2"" class=""$fw_type""><strong>$(Title $fw_type) Target Framework: $TargetFramework</strong></td></tr>"
            foreach ($Version in ($Deps[$Dep][$TargetFramework].Keys | sort)) {
              "<tr><td class=""version"">$Version</td><td>"
              foreach ($PkgName in ($Deps[$Dep][$TargetFramework][$Version] | sort)) {
                "$PkgName<br/>"
              }
              "</td></tr>"
            }
          }
          "</tbody></table><br/>"
        }
      )
      <br/><br/><hr/><br/><br/>
      <a name="lockfile"/>
      <table class="condensed">
        <thead>
          <tr><th colspan="3"><strong>Dependencies Centralized in Lockfile</strong></th></tr>
          $(if ($Locked) { "<tr><th>Dependency</th><th>Centralized Version</th><th>Dependency State</th></tr>" })
        </thead>
        <tbody>
        $(
          foreach ($LockedDep in ($Locked.Keys | sort)) {
            "<tr><td><a href=""#dep_$LockedDep"">$LockedDep</a></td><td>"
            foreach ($LockedVer in ($Locked[$LockedDep].Keys | sort)) {
              foreach ($Condition in ($Locked[$LockedDep][$LockedVer] | sort)) {
                "$LockedVer"
                if ($Condition) {
                  "if <code>$Condition</code><br/>"
                }
              }
            }
            "</td><td>"
            if (-not $Deps.ContainsKey($LockedDep)) {
              "⚠️ No packages reference this dependency"
            } elseif ($MismatchedVersions.ContainsKey($LockedDep)) {
              "<div class=""tooltip"">❌ One or more packages reference a different version of this dependency<span class=""tooltiptext"">"
              foreach ($MismatchedVer in ($MismatchedVersions[$LockedDep].Keys | sort)) {
                  "Version $MismatchedVer is referenced by:<br/>"
                foreach ($MismatchedDep in $MismatchedVersions[$LockedDep][$MismatchedVer]) {
                  "&nbsp;&nbsp;&nbsp;&nbsp;$MismatchedDep<br/>"
                }
              }
              "</span></div>"
            } else {
              "✅ All packages validated against this dependency and version"
            }
            "</td>"
          }
        )
        $(if (-Not $Locked) { "<tr><td colspan=""2"">No lockfile was provided for this report, or the lockfile was empty. Declared dependency versions were not able to be validated.</td></tr>" })
        </tbody>
      </table>
      $(
        if ($Locked -and $Unlocked) {
          "<br/>"
          $header_written = $false
          foreach ($UnlockedDep in ($Unlocked | sort)) {
            "<table class=""condensed""><thead>"
            if (-not $header_written) {
              "<tr><th colspan=""2"" class=""inconsistent""><strong>Dependencies Missing from Lockfile</strong></th></tr>"
              $header_written = $true
            }
            "<tr><th colspan=""2"" class=""inconsistent""><strong>Missing Dependency:</strong> <a href=""#dep_$UnlockedDep"">$UnlockedDep</a></th></tr></thead><tbody>"
            foreach ($TargetFramework in ($Deps[$UnlockedDep].Keys | sort)) {
              "<tr><td colspan=""2""><strong>Target Framework: $TargetFramework</strong></td></tr>"
              foreach ($Version in ($Deps[$UnlockedDep][$TargetFramework].Keys | sort)) {
                "<tr><td class=""version"">$Version</td><td>"
                foreach ($PkgName in ($Deps[$UnlockedDep][$TargetFramework][$Version] | sort)) {
                  "$PkgName<br/>"
                }
                "</td></tr>"
              }
            }
            "</tbody></table>"
          }
        }
      )
      <br/><br/><hr/><br/><br/>
      <a name="packages"/>
      <table class="condensed">
        <thead>
          <tr><th colspan="3"><strong>Packages Scanned for this Report</strong></th></tr>
          <tr><th>Package Analyzed</th><th>Package Version</th><th>Package Source</th></tr>
        </thead>
        <tbody>
        $(
          foreach ($PkgName in ($Pkgs.Keys | sort)) {
            "<tr><td>$PkgName</td><td>$($Pkgs[$PkgName]['Ver'])</td><td>$($Pkgs[$PkgName]['Src'])</td></tr>"
          }
        )
        </tbody>
      </table>
    </center>
  </body>
</html>
