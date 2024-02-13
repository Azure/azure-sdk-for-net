# Merge Proxy Tags Script

This script is intended to allow easy resolution of a conflicting `assets.json` file.

In most cases where two branches `X` and `Y` have progressed alongside each other, a simple

`git checkout X && git merge Y` can successfully merge _other_ than the `assets.json` file.

That often will end up looking like this:

```text
{
  "AssetsRepo": "Azure/azure-sdk-assets-integration",
  "AssetsRepoPrefixPath": "python",
  "TagPrefix": "python/storage/azure-storage-blob",
<<<<<<< HEAD
  "Tag": "integration/example/storage_feature_addition2"
=======
  "Tag": "integration/example/storage_feature_addition1"
>>>>>>> test-storage-tag-combination
}
```

This script uses `git` to tease out the source and target tags, then merge the incoming tag into the recordings of the base tag.

This script should _only_ be used on an already conflicted `assets.json` file. Otherwise, no action will be executed.

## Usage

### PreReqs

- Must have []`pshell 6+`](https://learn.microsoft.com/powershell/scripting/install/installing-powershell-on-windows)
- Must have `git` available on your PATH
- Must have the `test-proxy` available on your PATH
  - `test-proxy` is honored when the proxy is installed as a `dotnet tool`
  - `Azure.Sdk.Tools.TestProxy` is honored when the standalone executable is on your PATH
  - Defaults to `dotnet tool` if both are present on the PATH.

### Call the script

For simplicity when resolving merge-conflicts, invoke the script from the root of the repo. The help instructions from `merge-asset-tags` use paths relative from repo root.

```powershell
# including context to get into a merge conflict
cd "path/to/language/repo/root"
git checkout base-branch
git merge target-branch
# auto resolve / merge conflicting tag values
./eng/common/testproxy/scripts/resolve-asset-conflict/resolve-asset-conflict.ps1 sdk/storage/azure-storage-blob/assets.json
# user pushes
test-proxy push -a sdk/storage/azure-storage-blob/assets.json
```

### Resolving conflicts

When an assets.json merge has conflicts on the **test recordings** side, the `merge-proxy-tags` script will exit with an error describing how to re-invoke the `merge-proxy-tags` script AFTER you resolve the conflicts.

- `cd` into the assets location output by the script
- resolve the conflict or conflicts
- add the resolution, and invoke `git cherry-pick --continue`

Afterwards, re-invoke the `merge-proxy-tags` script with arguments given to you in original error. This will leave the assets in a `touched` state that can be `test-proxy push`-ed.
