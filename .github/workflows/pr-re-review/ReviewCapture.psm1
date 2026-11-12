# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# Pure capture policy: the caller executes only the described read-only
# GitHub effects using its existing injected client. No credentials or I/O here.
# Policy errors are terminal: the host must discard state, never resume a failed
# drain. Some validation paths deliberately mutate transient traversal state.
Import-Module (Join-Path $PSScriptRoot 'ReviewSerialization.psm1') -Scope Local
$script:Ordinal = [StringComparer]::Ordinal
$script:CaptureJsonOptions=[Text.Json.JsonDocumentOptions]::new();$script:CaptureJsonOptions.MaxDepth=10000
function Test-CaptureString($Value, [string] $Expected) {
    return $null -ne $Value -and $Value.ValueKind -eq [Text.Json.JsonValueKind]::String -and $script:Ordinal.Equals((Get-JsString $Value), $Expected)
}
function Test-CaptureInteger($Value, [double] $Minimum, [double] $Maximum) {
    if ($null -eq $Value -or $Value.ValueKind -ne [Text.Json.JsonValueKind]::Number) { return $false }
    $number = $Value.GetDouble()
    return -not [double]::IsInfinity($number) -and -not [double]::IsNaN($number) -and $number -ge $Minimum -and $number -le $Maximum -and [Math]::Floor($number) -eq $number
}
function Test-CaptureSha($Value) {
    return $null -ne $Value -and $Value.ValueKind -eq [Text.Json.JsonValueKind]::String -and [regex]::IsMatch((Get-JsString $Value), '\A[a-fA-F0-9]{40}\z')
}
function New-ChangedFileCapture($Identity) {
    $owner=Get-JsonProperty $Identity 'owner';$repo=Get-JsonProperty $Identity 'repo'
    $number=Get-JsonProperty $Identity 'pullNumber';$head=Get-JsonProperty $Identity 'headSha'
    if (-not (Test-JsTruthy $owner) -or -not (Test-JsTruthy $repo) -or -not (Test-CaptureInteger $number 1 9007199254740991) -or -not (Test-CaptureSha $head)) { throw 'Invalid pull request identity.' }
    return [pscustomobject]@{
        Identity=$Identity.Clone();Stage='before';Serial=[long]0;Active=$null;Page=[long]1;Base=$null;Count=[long]0
        Files=[Collections.Generic.List[string]]::new();Names=[Collections.Generic.HashSet[string]]::new($script:Ordinal)
    }
}
function Get-ChangedFileEffect($State) {
    if ($null -ne $State.Active) { throw 'Capture effect already active.' }
    if ($script:Ordinal.Equals($State.Stage,'done')) { return $null }
    $kind=if ($script:Ordinal.Equals($State.Stage,'files')) {'files'} else {'pull'}
    $args='{"owner":'+(Get-JsonProperty $State.Identity 'owner').GetRawText()+',"repo":'+(Get-JsonProperty $State.Identity 'repo').GetRawText()+',"pull_number":'+(Get-JsonProperty $State.Identity 'pullNumber').GetRawText()
    if ($script:Ordinal.Equals($kind,'files')) { $args+=',"per_page":100,"page":'+$State.Page }
    $args+='}'
    $State.Serial++
    $effect=[pscustomobject]@{Id=$State.Serial;Kind=$kind;Json=('{"effect_id":'+$State.Serial+',"kind":"'+$kind+'","arguments":'+$args+'}')}
    $State.Active=$effect
    return $effect
}
function Assert-ChangedFilePull($State,$Pull) {
    if (-not (Test-CaptureString (Get-JsonProperty $Pull 'state') 'open') -or (Test-JsTruthy (Get-JsonProperty $Pull 'draft')) -or
        -not (Test-CaptureString (Get-JsonProperty (Get-JsonProperty $Pull 'head') 'sha') (Get-JsString (Get-JsonProperty $State.Identity 'headSha'))) -or
        -not (Test-CaptureString (Get-JsonProperty (Get-JsonProperty $Pull 'base') 'sha') $State.Base)) { throw 'Pull request state, head or base changed; refusing a stale review.' }
    if (-not (Test-CaptureInteger (Get-JsonProperty $Pull 'changed_files') 0 3000)) { throw 'Invalid changed-file count or GitHub 3000-file endpoint limit exceeded.' }
}
function Complete-ChangedFileEffect($State,$EffectId,$Response) {
    if ($null -eq $State.Active -or -not (Test-CaptureInteger $EffectId 1 9007199254740991) -or $EffectId.GetDouble() -ne $State.Active.Id) { throw 'Unexpected capture effect response.' }
    switch -CaseSensitive ($State.Stage) {
        'before' {
            $base=Get-JsonProperty (Get-JsonProperty $Response 'base') 'sha'
            if (-not (Test-CaptureSha $base)) { throw 'Invalid pull request base.' }
            $baseText=Get-JsString $base
            Assert-ChangedFilePull ([pscustomobject]@{Identity=$State.Identity;Base=$baseText}) $Response
            $State.Base=$baseText
            $State.Count=[long](Get-JsonProperty $Response 'changed_files').GetDouble()
            $State.Stage='files'
        }
        'files' {
            if ($null -eq $Response -or $Response.ValueKind -ne [Text.Json.JsonValueKind]::Array -or $Response.GetArrayLength() -gt 100) { throw 'Invalid changed-file page.' }
            $pending=[Collections.Generic.List[string]]::new();$names=[Collections.Generic.HashSet[string]]::new($script:Ordinal)
            foreach ($file in $Response.EnumerateArray()) {
                $filename=Get-JsonProperty $file 'filename'
                if ($null -eq $filename -or $filename.ValueKind -ne [Text.Json.JsonValueKind]::String -or (Get-JsString $filename).Length -eq 0 -or
                    $State.Names.Contains((Get-JsString $filename)) -or -not $names.Add((Get-JsString $filename))) { throw 'Invalid or duplicate changed filename.' }
                $fields=[Collections.Generic.List[string]]::new()
                $fields.Add(('"filename":'+$filename.GetRawText()))
                foreach ($name in @('status','previous_filename','patch')) {
                    $value=Get-JsonProperty $file $name
                    if ($null -ne $value) { $fields.Add(('"'+$name+'":'+$value.GetRawText())) }
                }
                $pending.Add(('{'+($fields -join ',')+'}'))
            }
            $count=$State.Files.Count+$pending.Count
            if ($count -gt $State.Count) { throw 'Changed-file count exceeds PR metadata.' }
            $last=$Response.GetArrayLength() -lt 100 -or $count -eq 3000
            if ($last -and $count -ne $State.Count) { throw 'Incomplete changed-file listing: count differs from PR metadata.' }
            foreach ($name in $names) { [void]$State.Names.Add($name) }
            $State.Files.AddRange($pending)
            if ($last) { $State.Stage='after' } else { $State.Page++ }
        }
        'after' {
            Assert-ChangedFilePull $State $Response
            if ((Get-JsonProperty $Response 'changed_files').GetDouble() -ne $State.Count) { throw 'Changed-file count changed during capture.' }
            $State.Stage='done'
        }
        default { throw 'Invalid capture stage.' }
    }
    $State.Active=$null
}
function Get-ChangedFileManifest($State) {
    if (-not $script:Ordinal.Equals($State.Stage,'done') -or $null -ne $State.Active) { throw 'Changed-file capture is incomplete.' }
    $baseJson=ConvertTo-JsJsonText (ConvertTo-Json -InputObject $State.Base -Compress)
    return '{"pull_number":'+(Get-JsonProperty $State.Identity 'pullNumber').GetRawText()+',"head_sha":'+(Get-JsonProperty $State.Identity 'headSha').GetRawText()+',"base_sha":'+$baseJson+',"changed_files":'+$State.Files.Count+',"files":['+($State.Files -join ',')+']}'
}
# Complete review-state capture shares the same effect protocol but keeps its
# own local IDs and traversal state. The host supplies globally monotonic IDs.
$script:CaptureThreadQuery = @'
query($owner:String!,$repo:String!,$number:Int!,$after:String){
  repository(owner:$owner,name:$repo){pullRequest(number:$number){
    reviewThreads(first:100,after:$after){totalCount pageInfo{hasNextPage endCursor} nodes{
      id isResolved isOutdated isCollapsed comments(first:100){pageInfo{hasNextPage endCursor} nodes{
        databaseId body path line originalLine startLine originalStartLine url createdAt updatedAt publishedAt author{login} pullRequestReview{submittedAt}
      }}
    }}
  }}
}
'@
$script:CaptureCommentQuery = @'
query($id:ID!,$after:String){node(id:$id){... on PullRequestReviewThread{
  comments(first:100,after:$after){pageInfo{hasNextPage endCursor} nodes{databaseId body path line originalLine startLine originalStartLine url createdAt updatedAt publishedAt author{login} pullRequestReview{submittedAt}}}
}}}
'@
function ConvertTo-CaptureStringJson([string]$Text) { return ConvertTo-JsJsonText (ConvertTo-Json -InputObject $Text -Compress) }
function Get-CaptureRaw($Value,[string]$Name,[string]$Fallback='null') { $p=Get-JsonProperty $Value $Name;if($null -eq $p){return $Fallback};return $p.GetRawText() }
function Copy-CaptureElement($Value) { if($null -eq $Value){return $null};return $Value.Clone() }
function Test-CaptureSameValue($A,$B) {
    if($null -eq $A -or $null -eq $B){return $null -eq $A -and $null -eq $B}
    if($A.ValueKind -ne $B.ValueKind){return $false}
    switch($A.ValueKind){
        ([Text.Json.JsonValueKind]::String){return $script:Ordinal.Equals((Get-JsString $A),(Get-JsString $B))}
        ([Text.Json.JsonValueKind]::Number){return $A.GetDouble() -eq $B.GetDouble()}
        ([Text.Json.JsonValueKind]::Null){return $true}
        ([Text.Json.JsonValueKind]::True){return $true}
        ([Text.Json.JsonValueKind]::False){return $true}
    }
    return $false
}
function New-ReviewStateCapture($Repo,$Files,[bool]$IncludeReviews=$true,[bool]$PublicationPreflight=$false) {
    return [pscustomobject]@{
        Repo=$Repo.Clone();Files=$Files.Clone();IncludeReviews=$IncludeReviews
        Stage=$(if($PublicationPreflight){'preflight'}else{'before'});Serial=[long]0;Active=$null
        Before=$null;After='null';Total=$null;ThreadPageInfo=$null;CurrentThread=$null;CommentPageInfo=$null;CommentAfter='null';Reviews=$null
        Threads=[Collections.Generic.List[string]]::new();Comments=[Collections.Generic.List[string]]::new()
        Queue=[Collections.Generic.Queue[Text.Json.JsonElement]]::new()
        ThreadIds=[Collections.Generic.HashSet[string]]::new($script:Ordinal)
        ThreadCursors=[Collections.Generic.HashSet[string]]::new($script:Ordinal)
        CommentCursors=[Collections.Generic.HashSet[string]]::new($script:Ordinal)
    }
}
function Assert-ReviewCapturePull($State,$Pull,[switch]$Preflight) {
    if(-not (Test-CaptureString (Get-JsonProperty $Pull 'state') 'open') -or (Test-JsTruthy (Get-JsonProperty $Pull 'draft')) -or
        -not (Test-CaptureSameValue (Get-JsonProperty (Get-JsonProperty $Pull 'head') 'sha') (Get-JsonProperty $State.Files 'head_sha')) -or
        -not (Test-CaptureSameValue (Get-JsonProperty (Get-JsonProperty $Pull 'base') 'sha') (Get-JsonProperty $State.Files 'base_sha')) -or
        -not (Test-CaptureSameValue (Get-JsonProperty $Pull 'changed_files') (Get-JsonProperty $State.Files 'changed_files'))) {
        if($Preflight){throw 'PR state, head or base changed before publication.'}
        throw 'PR state, head, base or file count changed; refusing a stale review.'
    }
}
function Complete-CapturedThread($State) {
    if(-not (Test-JsTruthy $State.CommentPageInfo) -or $State.Comments.Count -eq 0){throw 'Incomplete or duplicate thread comments.'}
    $keys=[Collections.Generic.HashSet[string]]::new($script:Ordinal);$index=0
    foreach($text in $State.Comments){
        $doc=[Text.Json.JsonDocument]::Parse($text,$script:CaptureJsonOptions)
        try{
            if($doc.RootElement.ValueKind -eq [Text.Json.JsonValueKind]::Null){throw "Cannot read properties of null (reading 'databaseId')"}
            $id=Get-JsonProperty $doc.RootElement 'databaseId'
            $key=if($null -eq $id){'undefined'}elseif($id.ValueKind -in @([Text.Json.JsonValueKind]::Object,[Text.Json.JsonValueKind]::Array)){'reference:'+$index}else{$id.GetRawText()}
            if(-not $keys.Add($key)){throw 'Incomplete or duplicate thread comments.'}
        }finally{$doc.Dispose()}
        $index++
    }
    $fields=[Collections.Generic.List[string]]::new()
    foreach($name in @('id','isResolved','isOutdated','isCollapsed')){
        $value=Get-JsonProperty $State.CurrentThread $name
        if($null -ne $value){$fields.Add(('"'+$name+'":'+$value.GetRawText()))}
    }
    $fields.Add(('"comments":['+($State.Comments -join ',')+']'))
    $State.Threads.Add(('{'+($fields -join ',')+'}'))
    $State.CurrentThread=$null;$State.Comments.Clear()
}
function Update-ReviewCaptureDrain($State) {
    while($script:Ordinal.Equals($State.Stage,'drain')){
        if($null -ne $State.CurrentThread){
            if(Test-JsTruthy (Get-JsonProperty $State.CommentPageInfo 'hasNextPage')){
                $cursor=Get-JsonProperty $State.CommentPageInfo 'endCursor'
                if($null -eq $cursor -or $cursor.ValueKind -ne [Text.Json.JsonValueKind]::String -or (Get-JsString $cursor).Length -eq 0 -or -not $State.CommentCursors.Add((Get-JsString $cursor))){throw 'Invalid thread comment cursor.'}
                $State.CommentAfter=$cursor.GetRawText();$State.Stage='comments';return
            }
            Complete-CapturedThread $State
        }
        if($State.Queue.Count -gt 0){
            $thread=$State.Queue.Dequeue();$id=Get-JsonProperty $thread 'id';$resolved=Get-JsonProperty $thread 'isResolved';$comments=Get-JsonProperty $thread 'comments';$nodes=Get-JsonProperty $comments 'nodes'
            if($null -eq $id -or $id.ValueKind -ne [Text.Json.JsonValueKind]::String -or $State.ThreadIds.Contains((Get-JsString $id)) -or
                $null -eq $resolved -or $resolved.ValueKind -notin @([Text.Json.JsonValueKind]::True,[Text.Json.JsonValueKind]::False) -or
                $null -eq $nodes -or $nodes.ValueKind -ne [Text.Json.JsonValueKind]::Array){throw 'Invalid or duplicate thread.'}
            [void]$State.ThreadIds.Add((Get-JsString $id));$State.CurrentThread=$thread
            foreach($comment in $nodes.EnumerateArray()){$State.Comments.Add($comment.GetRawText())}
            $State.CommentPageInfo=Copy-CaptureElement (Get-JsonProperty $comments 'pageInfo');$State.CommentCursors.Clear()
            continue
        }
        if(-not (Test-JsTruthy $State.ThreadPageInfo)){throw 'Missing thread pagination state.'}
        if(Test-JsTruthy (Get-JsonProperty $State.ThreadPageInfo 'hasNextPage')){
            $cursor=Get-JsonProperty $State.ThreadPageInfo 'endCursor'
            if($null -eq $cursor -or $cursor.ValueKind -ne [Text.Json.JsonValueKind]::String -or (Get-JsString $cursor).Length -eq 0 -or -not $State.ThreadCursors.Add((Get-JsString $cursor))){throw 'Invalid thread cursor.'}
            $State.After=$cursor.GetRawText();$State.Stage='threads';return
        }
        if($State.Threads.Count -ne $State.Total){throw 'Incomplete thread listing: count mismatch.'}
        $State.Stage=if($State.IncludeReviews){'reviews'}else{'after'}
    }
}
function Get-ReviewCaptureEffect($State) {
    if($null -ne $State.Active){throw 'Capture effect already active.'}
    Update-ReviewCaptureDrain $State
    if($script:Ordinal.Equals($State.Stage,'done')){return $null}
    $repo=$State.Repo.GetRawText();$repo=$repo.Substring(0,$repo.Length-1)
    if($repo -cne '{'){$repo+=','}
    $number=Get-CaptureRaw $State.Files 'pull_number';$kind=$null;$args=$null
    switch -CaseSensitive ($State.Stage){
        'preflight' {$kind='pull';$args=$repo+'"pull_number":'+$number+'}'}
        'before' {$kind='pull';$args=$repo+'"pull_number":'+$number+'}'}
        'after' {$kind='pull';$args=$repo+'"pull_number":'+$number+'}'}
        'threads' {$kind='threads';$args=$repo+'"number":'+$number+',"after":'+$State.After+'}'}
        'comments' {$kind='comments';$args='{"id":'+(Get-CaptureRaw $State.CurrentThread 'id')+',"after":'+$State.CommentAfter+'}'}
        'reviews' {$kind='reviews';$args=$repo+'"pull_number":'+$number+',"per_page":100}'}
        default {throw 'Invalid review capture stage.'}
    }
    $State.Serial++
    $query=if($kind -ceq 'threads'){',"query":'+(ConvertTo-CaptureStringJson $script:CaptureThreadQuery)}elseif($kind -ceq 'comments'){',"query":'+(ConvertTo-CaptureStringJson $script:CaptureCommentQuery)}else{''}
    $effect=[pscustomobject]@{Id=$State.Serial;Kind=$kind;Json=('{"effect_id":'+$State.Serial+',"kind":"'+$kind+'","arguments":'+$args+$query+'}')}
    $State.Active=$effect;return $effect
}
function Complete-ReviewCaptureEffect($State,$EffectId,$Response) {
    if($null -eq $State.Active -or -not (Test-CaptureInteger $EffectId 1 9007199254740991) -or $EffectId.GetDouble() -ne $State.Active.Id){throw 'Unexpected capture effect response.'}
    switch -CaseSensitive ($State.Stage){
        'preflight' {Assert-ReviewCapturePull $State $Response -Preflight;$State.Stage='before'}
        'before' {Assert-ReviewCapturePull $State $Response;$State.Before=$Response.Clone();$State.Stage='threads'}
        'threads' {
            $connection=Get-JsonProperty (Get-JsonProperty (Get-JsonProperty $Response 'repository') 'pullRequest') 'reviewThreads'
            $nodes=Get-JsonProperty $connection 'nodes';$total=Get-JsonProperty $connection 'totalCount'
            if($null -eq $nodes -or $nodes.ValueKind -ne [Text.Json.JsonValueKind]::Array -or -not (Test-CaptureInteger $total -9007199254740991 9007199254740991)){throw 'Incomplete thread listing.'}
            if($null -ne $State.Total -and $State.Total -ne $total.GetDouble()){throw 'Thread count changed during capture.'}
            $State.Total=$total.GetDouble();$State.ThreadPageInfo=Copy-CaptureElement (Get-JsonProperty $connection 'pageInfo')
            foreach($thread in $nodes.EnumerateArray()){$State.Queue.Enqueue($thread.Clone())}
            $State.Stage='drain'
        }
        'comments' {
            $comments=Get-JsonProperty (Get-JsonProperty $Response 'node') 'comments';$nodes=Get-JsonProperty $comments 'nodes'
            if($null -eq $nodes -or $nodes.ValueKind -ne [Text.Json.JsonValueKind]::Array){throw 'Incomplete thread comment listing.'}
            foreach($comment in $nodes.EnumerateArray()){$State.Comments.Add($comment.GetRawText())}
            $State.CommentPageInfo=Copy-CaptureElement (Get-JsonProperty $comments 'pageInfo');$State.Stage='drain'
        }
        'reviews' {$State.Reviews=Copy-CaptureElement $Response;$State.Stage='after'}
        'after' {Assert-ReviewCapturePull $State $Response;$State.Stage='done'}
        default {throw 'Invalid review capture stage.'}
    }
    $State.Active=$null
}
function Get-CaptureReviewsJson($State){
    if(-not $State.IncludeReviews){return '[]'}
    if($null -eq $State.Reviews -or $State.Reviews.ValueKind -eq [Text.Json.JsonValueKind]::Null){throw "Cannot read properties of null (reading 'map')"}
    if($State.Reviews.ValueKind -ne [Text.Json.JsonValueKind]::Array){throw 'reviews.map is not a function'}
    $rows=[Collections.Generic.List[string]]::new()
    foreach($review in $State.Reviews.EnumerateArray()){
        if($review.ValueKind -eq [Text.Json.JsonValueKind]::Null){throw "Cannot read properties of null (reading 'id')"}
        $fields=[Collections.Generic.List[string]]::new()
        foreach($name in @('id','body','state','commit_id')){$p=Get-JsonProperty $review $name;if($null -ne $p){$fields.Add(('"'+$name+'":'+$p.GetRawText()))}}
        $fields.Add(('"author":'+(Get-CaptureRaw (Get-JsonProperty $review 'user') 'login')))
        foreach($pair in @(@('submittedAt','submitted_at'),@('url','html_url'),@('authorAssociation','author_association'))){$fields.Add(('"'+$pair[0]+'":'+(Get-CaptureRaw $review $pair[1])))}
        $rows.Add(('{'+($fields -join ',')+'}'))
    }
    return '['+($rows -join ',')+']'
}
function Get-ReviewCaptureSnapshot($State){
    if(-not $script:Ordinal.Equals($State.Stage,'done') -or $null -ne $State.Active){throw 'Review capture is incomplete.'}
    $fallback=$null
    $replacements=[Collections.Generic.Dictionary[string,string]]::new($script:Ordinal)
    foreach($side in @('head','base')){
        $p=Get-JsonProperty (Get-JsonProperty (Get-JsonProperty $State.Before $side) 'repo') 'full_name'
        if(Test-JsTruthy $p){$replacements[$side+'_repo']=$p.GetRawText()}
        else{
            if($null -eq $fallback){$fallback=ConvertTo-CaptureStringJson ((ConvertTo-JsValueString (Get-JsonProperty $State.Repo 'owner'))+'/'+(ConvertTo-JsValueString (Get-JsonProperty $State.Repo 'repo')))}
            $replacements[$side+'_repo']=$fallback
        }
    }
    $replacements['threads']='['+($State.Threads -join ',')+']';$replacements['reviews']=Get-CaptureReviewsJson $State
    $fields=[Collections.Generic.List[string]]::new();$seen=[Collections.Generic.HashSet[string]]::new($script:Ordinal)
    foreach($p in $State.Files.EnumerateObject()){
        [void]$seen.Add($p.Name);$raw=if($replacements.ContainsKey($p.Name)){$replacements[$p.Name]}else{$p.Value.GetRawText()}
        $fields.Add(((ConvertTo-CaptureStringJson $p.Name)+':'+$raw))
    }
    foreach($name in @('head_repo','base_repo','threads','reviews')){if(-not $seen.Contains($name)){$fields.Add(('"'+$name+'":'+$replacements[$name]))}}
    return '{'+($fields -join ',')+'}'
}
# Ordered projections retain native property order and omission semantics.
function Select-CaptureProperties($Object,[string[]]$Names){
    $fields=[Collections.Generic.List[string]]::new()
    foreach($name in $Names){$value=Get-JsonProperty $Object $name;if($null -ne $value){$fields.Add(((ConvertTo-CaptureStringJson $name)+':'+$value.GetRawText()))}}
    return '{'+($fields -join ',')+'}'
}
function Merge-CaptureSnapshot($Snapshot,[Collections.Generic.Dictionary[string,string]]$Replacements,[string[]]$Order){
    $fields=[Collections.Generic.List[string]]::new();$seen=[Collections.Generic.HashSet[string]]::new($script:Ordinal)
    foreach($p in $Snapshot.EnumerateObject()){
        [void]$seen.Add($p.Name);$raw=if($Replacements.ContainsKey($p.Name)){$Replacements[$p.Name]}else{$p.Value.GetRawText()}
        $fields.Add(((ConvertTo-CaptureStringJson $p.Name)+':'+$raw))
    }
    foreach($name in $Order){if(-not $seen.Contains($name)){$fields.Add(((ConvertTo-CaptureStringJson $name)+':'+$Replacements[$name]))}}
    return '{'+($fields -join ',')+'}'
}
function Get-ReviewComparisonInput($Repo,$Snapshot){
    $basehead=(Get-JsString (Get-JsonProperty $Snapshot 'base_sha'))+'...'+(Get-JsString (Get-JsonProperty $Snapshot 'head_sha'))
    $prefix=$Repo.GetRawText();$prefix=$prefix.Substring(0,$prefix.Length-1);if($prefix -cne '{'){$prefix+=','}
    return $prefix+'"basehead":'+(ConvertTo-CaptureStringJson $basehead)+',"per_page":1}'
}
function Add-ReviewDiffBase($Snapshot,$Comparison){
    $diff=Get-JsonProperty (Get-JsonProperty $Comparison 'merge_base_commit') 'sha'
    if(-not (Test-CaptureSha $diff) -or -not (Test-CaptureSameValue (Get-JsonProperty (Get-JsonProperty $Comparison 'base_commit') 'sha') (Get-JsonProperty $Snapshot 'base_sha'))){throw 'Cannot establish the captured PR diff base.'}
    $values=[Collections.Generic.Dictionary[string,string]]::new($script:Ordinal);$values['diff_base_sha']=$diff.GetRawText()
    return Merge-CaptureSnapshot $Snapshot $values @('diff_base_sha')
}
function Get-ReviewBaselineInput($Repo,$Snapshot){
    $rows=[Collections.Generic.List[string]]::new()
    foreach($file in (Get-JsonProperty $Snapshot 'files').EnumerateArray()){$rows.Add((Select-CaptureProperties $file @('filename','previous_filename','status')))}
    $metadata=Select-CaptureProperties $Snapshot @('head_sha','base_sha','diff_base_sha','head_repo')
    return '{"repo":'+$Repo.GetRawText()+',"snapshot":'+$metadata.Substring(0,$metadata.Length-1)+',"files":['+($rows -join ',')+']}}'
}
function Add-ReviewBaselineInventory($Snapshot,$Inventory){
    if($null -eq $Inventory -or $Inventory.ValueKind -ne [Text.Json.JsonValueKind]::Array){throw 'Invalid baseline comparison output.'}
    $values=[Collections.Generic.Dictionary[string,string]]::new($script:Ordinal);$values['baseline_suppressions']=$Inventory.GetRawText()
    return Merge-CaptureSnapshot $Snapshot $values @('baseline_suppressions')
}
function Get-ReviewFreshnessInput([string]$Mode,$Expected,$Current,$Extra){
    if($Mode -ceq 'mutation'){$names=@('threads')}elseif($Mode -ceq 'publication'){$names=@('threads','reviews','head_repo','base_repo')}else{throw 'Invalid freshness mode.'}
    $result='{"mode":'+(ConvertTo-CaptureStringJson $Mode)+',"expected":'+(Select-CaptureProperties $Expected $names)+',"current":'+(Select-CaptureProperties $Current $names)
    if($null -ne $Extra){foreach($p in $Extra.EnumerateObject()){$result+=','+(ConvertTo-CaptureStringJson $p.Name)+':'+$p.Value.GetRawText()}}
    return $result+'}'
}
# Independently validate the exporter response before requesting any artifact
# reads, then validate base artifacts and each history in their original order.
function Assert-ReviewDeliveryIndex($Snapshot,[string]$ExpectedHash,$Delivery){
    $hash=Get-JsonProperty $Delivery 'snapshot';$items=Get-JsonProperty $Delivery 'items'
    if(-not (Test-CaptureString $hash $ExpectedHash) -or $null -eq $items -or $items.ValueKind -ne [Text.Json.JsonValueKind]::Object){throw 'Invalid captured delivery index.'}
    $files=Get-JsonProperty $Snapshot 'files';$threads=Get-JsonProperty $Snapshot 'threads'
    $expected=[Collections.Generic.List[object]]::new()
    for($i=0;$i -lt $files.GetArrayLength();$i++){$expected.Add(@(('file:'+$i),'patch'))}
    for($i=0;$i -lt $threads.GetArrayLength();$i++){$expected.Add(@(('thread:'+$i),'history'))}
    $count=0;foreach($p in $items.EnumerateObject()){$count++}
    if($count -ne $expected.Count){throw 'Invalid captured delivery assignments.'}
    foreach($pair in $expected){
        $inputs=Get-JsonProperty $items $pair[0];$kind=$pair[1]
        if($null -eq $inputs -or $inputs.ValueKind -ne [Text.Json.JsonValueKind]::Array -or $inputs.GetArrayLength() -gt 1 -or ($kind -ceq 'history' -and $inputs.GetArrayLength() -ne 1)){throw 'Invalid captured delivery assignments.'}
        foreach($input in $inputs.EnumerateArray()){
            $key=Get-JsonProperty $input 'key'
            if(-not (Test-CaptureString (Get-JsonProperty $input 'kind') $kind) -or $null -eq $key -or $key.ValueKind -ne [Text.Json.JsonValueKind]::String -or
                -not [regex]::IsMatch((Get-JsString $key),('\A'+$kind+':[a-f0-9]{64}\z'))){throw 'Invalid captured delivery assignments.'}
        }
    }
}
function Get-ExpectedCaptureReviewCount($Snapshot){
    $reviews=Get-JsonProperty $Snapshot 'reviews'
    if(-not (Test-JsTruthy $reviews)){return 0}
    if($reviews.ValueKind -ne [Text.Json.JsonValueKind]::Array){throw 'Exported review context does not match the captured snapshot.'}
    return $reviews.GetArrayLength()
}
function Assert-ReviewExportedBase($Snapshot,[string]$ExpectedHash,[string]$ExpectedIndex,$Artifacts){
    if(Test-JsTruthy (Get-JsonProperty $Artifacts 'readError')){throw 'Missing or invalid exported review context.'}
    $context=Get-JsonProperty $Artifacts 'context';$files=Get-JsonProperty $context 'files';$threads=Get-JsonProperty $context 'threads';$reviews=Get-JsonProperty $context 'reviews'
    if(-not (Test-CaptureString (Get-JsonProperty $Artifacts 'snapshotHash') $ExpectedHash) -or -not (Test-CaptureString (Get-JsonProperty $Artifacts 'indexCanonical') $ExpectedIndex) -or
        -not (Test-JsTruthy $context) -or $null -eq $files -or $files.ValueKind -ne [Text.Json.JsonValueKind]::Array -or $files.GetArrayLength() -ne (Get-JsonProperty $Snapshot 'files').GetArrayLength() -or
        $null -eq $threads -or $threads.ValueKind -ne [Text.Json.JsonValueKind]::Array -or $threads.GetArrayLength() -ne (Get-JsonProperty $Snapshot 'threads').GetArrayLength() -or
        $null -eq $reviews -or $reviews.ValueKind -ne [Text.Json.JsonValueKind]::Array -or $reviews.GetArrayLength() -ne (Get-ExpectedCaptureReviewCount $Snapshot)){throw 'Exported review context does not match the captured snapshot.'}
}
function Test-CaptureNativeScalarTag($Expected,$Actual){
    $kind=Get-JsonProperty $Expected 'kind';$other=Get-JsonProperty $Actual 'kind'
    if($null -eq $kind -or $kind.ValueKind -ne [Text.Json.JsonValueKind]::String -or -not (Test-CaptureSameValue $kind $other)){return $false}
    switch -CaseSensitive (Get-JsString $kind){
        'undefined' {return $true}
        'null' {return $true}
        'string' {return Test-CaptureSameValue (Get-JsonProperty $Expected 'value') (Get-JsonProperty $Actual 'value')}
        'number' {return Test-CaptureSameValue (Get-JsonProperty $Expected 'value') (Get-JsonProperty $Actual 'value')}
        'boolean' {return Test-CaptureSameValue (Get-JsonProperty $Expected 'value') (Get-JsonProperty $Actual 'value')}
        default {return $false}
    }
}
function Assert-ReviewExportedHistory($Entry,$Proof){
    if(Test-JsTruthy (Get-JsonProperty $Proof 'readError')){throw 'Missing or invalid exported review history.'}
    $path=Get-JsonProperty $Proof 'expectedPath';$actualPath=Get-JsonProperty $Entry 'history_path'
    if(-not (Test-JsTruthy $Entry) -or -not (Test-CaptureSameValue $path $actualPath)){throw 'Exported review history does not match the captured snapshot.'}
    $readError=Get-JsonProperty $Proof 'expectedReadError'
    if($null -ne $readError){throw ("Cannot read properties of "+(Get-JsString $readError)+" (reading 'id')")}
    if(-not (Test-CaptureNativeScalarTag (Get-JsonProperty $Proof 'expectedId') (Get-JsonProperty $Proof 'actualId')) -or
        -not (Test-CaptureNativeScalarTag (Get-JsonProperty $Proof 'expectedState') (Get-JsonProperty $Proof 'actualState')) -or
        -not (Test-CaptureSameValue (Get-JsonProperty $Proof 'expectedCanonical') (Get-JsonProperty $Proof 'actualCanonical'))){throw 'Exported review history does not match the captured snapshot.'}
}
Export-ModuleMember -Function @(
    'New-ChangedFileCapture', 'Get-ChangedFileEffect', 'Complete-ChangedFileEffect', 'Get-ChangedFileManifest',
    'New-ReviewStateCapture', 'Get-ReviewCaptureEffect', 'Complete-ReviewCaptureEffect', 'Get-ReviewCaptureSnapshot',
    'Get-ReviewComparisonInput', 'Add-ReviewDiffBase', 'Get-ReviewBaselineInput', 'Add-ReviewBaselineInventory',
    'Get-ReviewFreshnessInput', 'Assert-ReviewDeliveryIndex', 'Assert-ReviewExportedBase',
    'Assert-ReviewExportedHistory', 'Get-ExpectedCaptureReviewCount'
)
