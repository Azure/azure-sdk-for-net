$ErrorActionPreference='Stop'
[Console]::InputEncoding=[Text.UTF8Encoding]::new($false,$true)
[Console]::OutputEncoding=[Text.UTF8Encoding]::new($false)
Import-Module (Join-Path $PSScriptRoot '../pr-re-review/ReviewCapture.psm1') -Force
Import-Module (Join-Path $PSScriptRoot '../pr-re-review/ReviewSerialization.psm1') -Force
$options=[Text.Json.JsonDocumentOptions]::new();$options.MaxDepth=10000
$document=[Text.Json.JsonDocument]::Parse([Console]::In.ReadToEnd(),$options)
try{
 $output=[Collections.Generic.List[string]]::new()
 foreach($case in $document.RootElement.EnumerateArray()){
  $effects=[Collections.Generic.List[string]]::new();$pi=0;$ti=0;$ci=[Collections.Generic.Dictionary[string,int]]::new([StringComparer]::Ordinal)
  try{
   $include=Get-JsonProperty $case 'includeReviews';$preflight=Get-JsonProperty $case 'preflight'
   $state=New-ReviewStateCapture (Get-JsonProperty $case 'repo') (Get-JsonProperty $case 'files') ($null -eq $include -or $include.ValueKind -ne [Text.Json.JsonValueKind]::False) ($null -ne $preflight -and $preflight.ValueKind -eq [Text.Json.JsonValueKind]::True)
   while($null -ne ($effect=Get-ReviewCaptureEffect $state)){
    $effects.Add($effect.Json);$frame=[Text.Json.JsonDocument]::Parse($effect.Json)
    try{
     $fail=Get-JsonProperty $case 'failAt';if($null -ne $fail -and $fail.GetInt64() -eq $effect.Id){throw 'API unavailable'}
     switch -CaseSensitive ($effect.Kind){
      'pull' {$response=(Get-JsonProperty $case 'pulls')[$pi];$pi++}
      'threads' {$response=(Get-JsonProperty $case 'threadPages')[$ti];$ti++}
      'comments' {
       $id=Get-JsString (Get-JsonProperty (Get-JsonProperty $frame.RootElement 'arguments') 'id')
       if(-not $ci.ContainsKey($id)){$ci[$id]=0}
       $response=(Get-JsonProperty (Get-JsonProperty $case 'commentPages') $id)[$ci[$id]];$ci[$id]++
      }
      'reviews' {$response=Get-JsonProperty $case 'reviews'}
      default {throw 'Unexpected effect kind'}
     }
     Complete-ReviewCaptureEffect $state (Get-JsonProperty $frame.RootElement 'effect_id') $response
    }finally{$frame.Dispose()}
   }
   $output.Add(('{"result":'+(Get-ReviewCaptureSnapshot $state)+',"effects":['+($effects -join ',')+']}'))
  }catch{$output.Add(('{"error":'+(ConvertTo-Json -InputObject $_.Exception.Message -Compress)+',"effects":['+($effects -join ',')+']}'))}
 }
 [Console]::Out.Write(('['+($output -join ',')+']'))
}finally{$document.Dispose()}
