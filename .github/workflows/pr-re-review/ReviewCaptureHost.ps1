#Requires -Version 7.3
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.
# Private persistent policy host. Only its native parent performs API and phase
# effects, using the existing injected client and bounded helper supervisors.
$ErrorActionPreference='Stop'
[Console]::InputEncoding=[Text.UTF8Encoding]::new($false,$true)
[Console]::OutputEncoding=[Text.UTF8Encoding]::new($false)
Import-Module (Join-Path $PSScriptRoot 'ReviewCapture.psm1') -Force
Import-Module (Join-Path $PSScriptRoot 'ReviewSerialization.psm1') -Force
$options=[Text.Json.JsonDocumentOptions]::new();$options.MaxDepth=10000
function Owned([string]$Json){$d=[Text.Json.JsonDocument]::Parse($Json,$options);try{return $d.RootElement.Clone()}finally{$d.Dispose()}}
$state=$null;$mode=$null;$phase=$null;$repo=$null;$manifest=$null;$snapshot=$null;$finished=$false;$freshMode=$null;$freshExtra=$null
$serial=[long]0;$active=$null;$exportEnabled=$false;$exportHash=$null;$exportIndex=$null;$exportContext=$null;$reviewIndex=0;$reviewCount=0
$allowed=[Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
foreach($operation in @('initialize','next','accept','finish')){[void]$allowed.Add($operation)}
while($null -ne ($line=[Console]::In.ReadLine())){
 $document=$null;$id=[long]0
 try{
  $document=[Text.Json.JsonDocument]::Parse($line,$options);$root=$document.RootElement;$identifier=Get-JsonProperty $root 'id'
  if($null -eq $identifier -or $identifier.ValueKind -ne [Text.Json.JsonValueKind]::Number -or -not $identifier.TryGetInt64([ref]$id) -or $id -le 0 -or $id -gt 9007199254740991){throw 'Invalid capture request identity.'}
  $operation=Get-JsString (Get-JsonProperty $root 'operation');$payload=Get-JsonProperty $root 'payload'
  if(-not $allowed.Contains($operation) -or $null -eq $payload -or $payload.ValueKind -ne [Text.Json.JsonValueKind]::Object -or $finished){throw 'Invalid capture request.'}
  if($operation -cne 'initialize' -and $null -eq $state){throw 'Capture is not initialized.'}
  switch -CaseSensitive ($operation){
   'initialize' {
    if($null -ne $state){throw 'Capture is already initialized.'}
    $mode=Get-JsString (Get-JsonProperty $payload 'mode')
    $flag=Get-JsonProperty $payload 'exportEnabled';$exportEnabled=$null -ne $flag -and $flag.ValueKind -eq [Text.Json.JsonValueKind]::True
    $fm=Get-JsonProperty $payload 'freshnessMode'
    if($null -ne $fm){
     $freshMode=Get-JsString $fm
     if($mode -cne 'review' -or $freshMode -cnotin @('publication','mutation')){throw 'Invalid capture freshness mode.'}
     $freshExtra=Get-JsonProperty $payload 'extra';if($null -ne $freshExtra){$freshExtra=$freshExtra.Clone()}
    }
    if($mode -cin @('files','full')){
     $identity=Get-JsonProperty $payload 'identity';$state=New-ChangedFileCapture $identity;$phase='files'
     $repo=Owned ('{"owner":'+(Get-JsonProperty $identity 'owner').GetRawText()+',"repo":'+(Get-JsonProperty $identity 'repo').GetRawText()+'}')
    }elseif($mode -cin @('review','context')){
     $repo=(Get-JsonProperty $payload 'repo').Clone();$files=Get-JsonProperty $payload 'files'
     $include=Get-JsonProperty $payload 'includeReviews';$preflight=Get-JsonProperty $payload 'preflight'
     foreach($flag in @($include,$preflight)){if($null -ne $flag -and $flag.ValueKind -notin @([Text.Json.JsonValueKind]::True,[Text.Json.JsonValueKind]::False)){throw 'Invalid capture option.'}}
     $state=New-ReviewStateCapture $repo $files ($null -eq $include -or $include.ValueKind -eq [Text.Json.JsonValueKind]::True) ($null -ne $preflight -and $preflight.ValueKind -eq [Text.Json.JsonValueKind]::True);$phase='review'
    }elseif($mode -ceq 'export'){$snapshot=(Get-JsonProperty $payload 'snapshot').Clone();$state=[pscustomobject]@{ExportOnly=$true};$phase='export'}
    else{throw 'Invalid capture mode.'}
    $result='{"initialized":true}'
   }
   'next' {
    if($null -ne $active){throw 'Capture effect already active.'}
    $local=$null;$kind=$null;$args=$null;$query=''
    while($null -eq $kind -and $phase -cne 'done'){
     switch -CaseSensitive ($phase){
      'files' {
       $local=Get-ChangedFileEffect $state
       if($null -ne $local){$frame=Owned $local.Json;$kind=$local.Kind;$args=(Get-JsonProperty $frame 'arguments').GetRawText()}
       else{$manifest=Owned (Get-ChangedFileManifest $state);$phase=if($mode -ceq 'files'){'done'}else{'manifest'}}
      }
      'review' {
       $local=Get-ReviewCaptureEffect $state
       if($null -ne $local){
        $frame=Owned $local.Json;$kind=$local.Kind;$args=(Get-JsonProperty $frame 'arguments').GetRawText()
        $q=Get-JsonProperty $frame 'query';if($null -ne $q){$query=',"query":'+$q.GetRawText()}
       }else{$snapshot=Owned (Get-ReviewCaptureSnapshot $state);$phase=if($mode -ceq 'review'){'done'}else{'compare'}}
      }
      'manifest' {$kind='manifest';$args='{"manifest":'+$manifest.GetRawText()+'}'}
      'compare' {$kind='compare';$args=Get-ReviewComparisonInput $repo $snapshot}
      'baseline' {$kind='baseline';$args=Get-ReviewBaselineInput $repo $snapshot}
      'export' {$kind='export';$args='{"snapshot":'+$snapshot.GetRawText()+'}'}
      'export-base' {$kind='export-base';$args='{}'}
      'export-history' {$kind='export-history';$args='{"index":'+$reviewIndex+'}'}
      default {throw 'Invalid capture phase.'}
     }
    }
    if($null -eq $kind){$result='{"done":true}'}else{
     $serial++;$active=[pscustomobject]@{Id=$serial;Phase=$phase;LocalId=$(if($null -ne $local){$local.Id}else{0})}
     $result='{"done":false,"effect":{"effect_id":'+$serial+',"kind":"'+$kind+'","arguments":'+$args+$query+'}}'
    }
   }
   'accept' {
    $e=Get-JsonProperty $payload 'effect_id';$n=[long]0
    if($null -eq $active -or $null -eq $e -or $e.ValueKind -ne [Text.Json.JsonValueKind]::Number -or -not $e.TryGetInt64([ref]$n) -or $n -ne $active.Id){throw 'Unexpected capture effect response.'}
    $response=Get-JsonProperty $payload 'response'
    switch -CaseSensitive ($active.Phase){
     'files' {Complete-ChangedFileEffect $state (Owned ([string]$active.LocalId)) $response}
     'review' {Complete-ReviewCaptureEffect $state (Owned ([string]$active.LocalId)) $response}
     'manifest' {
      if($null -eq $response -or $response.ValueKind -ne [Text.Json.JsonValueKind]::True){throw 'Manifest checkpoint was not written.'}
      $state=New-ReviewStateCapture $repo $manifest;$phase='review'
     }
     'compare' {$snapshot=Owned (Add-ReviewDiffBase $snapshot $response);$phase='baseline'}
     'baseline' {$snapshot=Owned (Add-ReviewBaselineInventory $snapshot $response);$phase=if($exportEnabled){'export'}else{'done'}}
     'export' {
      $exportHash=Get-JsString (Get-JsonProperty $response 'snapshotHash');$delivery=Get-JsonProperty $response 'delivery'
      Assert-ReviewDeliveryIndex $snapshot $exportHash $delivery
      $exportIndex=Get-JsString (Get-JsonProperty $response 'indexCanonical');$phase='export-base'
     }
     'export-base' {
      Assert-ReviewExportedBase $snapshot $exportHash $exportIndex $response
      $exportContext=(Get-JsonProperty $response 'context').Clone();$reviewCount=Get-ExpectedCaptureReviewCount $snapshot
      $phase=if($reviewCount -gt 0){'export-history'}else{'done'}
     }
     'export-history' {
      Assert-ReviewExportedHistory (Get-JsonProperty $exportContext 'reviews')[$reviewIndex] $response
      $reviewIndex++;$phase=if($reviewIndex -lt $reviewCount){'export-history'}else{'done'}
     }
     default {throw 'Invalid capture effect phase.'}
    }
    $active=$null;$result='{"accepted":true}'
   }
   'finish' {
    if($phase -cne 'done' -or $null -ne $active){throw 'Capture is incomplete.'}
    $result=if($mode -ceq 'export'){'{"exported":true}'}elseif($null -ne $freshMode){Get-ReviewFreshnessInput $freshMode $state.Files $snapshot $freshExtra}elseif($mode -ceq 'files'){$manifest.GetRawText()}elseif($mode -ceq 'full'){'{"manifest":'+$manifest.GetRawText()+',"snapshot":'+$snapshot.GetRawText()+'}'}else{$snapshot.GetRawText()}
    $finished=$true
   }
  }
  [Console]::Out.WriteLine(('{"id":'+$id+',"result":'+$result+'}'))
 }catch{
  $message=ConvertTo-JsJsonText (ConvertTo-Json -InputObject $_.Exception.Message -Compress)
  [Console]::Out.WriteLine(('{"id":'+$id+',"error":'+$message+'}'));exit 1
 }finally{if($null -ne $document){$document.Dispose()}}
}
if($null -ne $state -and -not $finished){[Console]::Error.WriteLine('Capture closed before verified finalization.');exit 1}
