#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# Install the minimal Node handler adapter required by the pinned gh-aw
# manifest. The handler returns the applied reply ID, but the manifest does not
# otherwise retain it; the later thread mutation must verify that exact reply.
param(
    [Parameter(Mandatory)]
    [string] $ActionsDirectory
)

$ErrorActionPreference = 'Stop'
$original = Join-Path $ActionsDirectory 'reply_to_pr_review_comment.cjs'
$implementation = Join-Path $ActionsDirectory 'reply_to_pr_review_comment_impl.cjs'
if (-not [IO.File]::Exists($implementation)) {
    [IO.File]::Copy($original, $implementation)
}
$wrapper = @'
'use strict';
// gh-aw loads this handler as a Node module; retain the applied reply ID.
const impl = require('./reply_to_pr_review_comment_impl.cjs');
module.exports = { ...impl, main: async (...args) => {
  const handler = await impl.main(...args);
  return async (...handlerArgs) => {
    const result = await handler(...handlerArgs);
    return result?.success && Number.isSafeInteger(result.reply_id) && result.reply_id > 0
      ? { ...result, metadata: { ...result.metadata, reply_id: result.reply_id } } : result;
  };
} };
'@
[IO.File]::WriteAllText($original, $wrapper, [Text.UTF8Encoding]::new($false))
