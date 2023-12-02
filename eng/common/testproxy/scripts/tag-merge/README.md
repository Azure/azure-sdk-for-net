# Merge Proxy Tags Script

This script is intended to allow simpler combination of proxy tags. This is necessary due a few facts:

- Feature teams often need to combine their efforts while adding features. This means parallel re-recording or addition of tests.
- Instead of recordings being directly alongside the feature work, able to be merged simultaneously, now recordings are a single external reference from `assets.json`.

This script merely allows the abstraction of some of this "combination" work.

## Usage

### PreReqs

- Must have `git` available on your PATH
- Must have the `test-proxy` available on your PATH
  - `test-proxy` is honored when the proxy is installed as a `dotnet tool`
  - `Azure.Sdk.Tools.TestProxy` is honored when the standalone executable is on your PATH
  - Preference for `dotnet tool` if present

### Call the script

```powershell
cd "path/to/language/repo/root"
./eng/common/testproxy/scripts/tag-merge/merge-proxy-tags.ps1 sdk/storage/azure-storage-blob/assets.json integration/example/storage_feature_addition2 integration/example/storage_feature_addition1
#                                                                                                                 ^ Combined Tag 1                                    ^ Combined Tag 2
test-proxy push -a sdk/storage/azure-storage-blob/assets.json
```

### Resolve Conflicts

If the script ends early to a `git conflict` occurring, the script leaves the asset repo in a resolvable state.

- `cd` to the working directory described in the output from the script before it starts working.
- `git status`, then resolve the conflicts in the files. you don't need to commit the result
- Invoke the script **with the original arguments**
  - If the script stopped to resolve a conflict, it drops a tiny file (`.mergeprogress`) at repo root to remember where it stopped progressing. It will utilize this file to avoid cherry-picking already completed commits.

### Push the result

Once the script has completed successfully, `test-proxy push` the results!

C:\repo\azure-sdk-tools\eng\common\testproxy\scripts\tag-merge\merge-proxy-tags.ps1 "C:/repo/azure-sdk-for-python/sdk/storage/azure-storage-blob/assets.json" integration/example/storage_feature_addition2 integration/example/storage_feature_addition1