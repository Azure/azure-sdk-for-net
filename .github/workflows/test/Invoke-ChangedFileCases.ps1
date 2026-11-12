$ErrorActionPreference='Stop'
[Console]::InputEncoding=[Text.UTF8Encoding]::new($false,$true)
[Console]::OutputEncoding=[Text.UTF8Encoding]::new($false)
Import-Module (Join-Path $PSScriptRoot '../pr-re-review/ReviewCapture.psm1') -Force
Import-Module (Join-Path $PSScriptRoot '../pr-re-review/ReviewSerialization.psm1') -Force
$options=[Text.Json.JsonDocumentOptions]::new();$options.MaxDepth=10000
$document=[Text.Json.JsonDocument]::Parse([Console]::In.ReadToEnd(),$options)
try {
 $outputs=[Collections.Generic.List[string]]::new()
 foreach($case in $document.RootElement.EnumerateArray()) {
  $effects=[Collections.Generic.List[string]]::new();$pullIndex=0
  try {
   $state=New-ChangedFileCapture (Get-JsonProperty $case 'identity')
   while($null -ne ($effect=Get-ChangedFileEffect $state)) {
    $effects.Add($effect.Json)
    $frame=[Text.Json.JsonDocument]::Parse($effect.Json)
    try {
     if($effect.Kind -ceq 'pull') {$response=(Get-JsonProperty $case 'pulls')[$pullIndex];$pullIndex++}
     else {$page=(Get-JsonProperty (Get-JsonProperty $frame.RootElement 'arguments') 'page').GetInt32();$response=(Get-JsonProperty $case 'pages')[$page-1]}
     Complete-ChangedFileEffect $state (Get-JsonProperty $frame.RootElement 'effect_id') $response
    } finally {$frame.Dispose()}
   }
   $outputs.Add(('{"result":'+(Get-ChangedFileManifest $state)+',"effects":['+($effects -join ',')+']}'))
  }catch{
   $message=ConvertTo-Json -InputObject $_.Exception.Message -Compress
   $outputs.Add(('{"error":'+$message+',"effects":['+($effects -join ',')+']}'))
  }
 }
 [Console]::Out.Write(('['+($outputs -join ',')+']'))
} finally {$document.Dispose()}
