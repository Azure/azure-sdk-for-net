$(
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
            "<strong>$($Inconsistent.Count) inconsistent package dependency $(Pluralize $Inconsistent.Count 'version was' 'versions were') discovered.</strong><br/><br/>"
          } else {
            "No inconsistent package dependency versions were discovered.<br/><br/>"
          }
        )
        $(
          if ($Frozen) {
            "$($Frozen.Count) dependency $(Pluralize $Frozen.Count 'version was' 'versions were') discovered in the <a href=""#lockfile"">lockfile</a>.<br/>"
            if ($Overrides) {
              "<strong>$($Overrides.Count) dependency version $(Pluralize $Overrides.Count 'override is' 'overrides are') present, causing package depenceny versions to differ from the version in the lockfile.</strong><br/>"
            } else {
              "All declared dependency versions were match those specified in the lockfile.<br/>"
            }
          } else {
            "<strong>No lockfile was provided for this report, declared dependency versions were not able to be validated.</strong><br/>"
          }
        )
        <br/>This report scanned $($Packages.Count) <a href="#packages">$(Pluralize $Packages.Count 'package' 'packages')</a>.
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
      <a name="packages"/>
      <table class="condensed">
        <thead>
          <tr><th colspan="3"><strong>Packages Scanned for this Report</strong></th></tr>
          <tr><th>Package Analyzed</th><th>Package Version</th><th>Package Source</th></tr>
        </thead>
        <tbody>
        $(
          foreach ($PkgName in ($Packages.Keys | sort)) {
            "<tr><td>$PkgName</td><td>$($Packages[$PkgName][0])</td><td>$($Packages[$PkgName][1])</td></tr>"
          }
        )
        </tbody>
      </table>
    </center>
  </body>
</html>
