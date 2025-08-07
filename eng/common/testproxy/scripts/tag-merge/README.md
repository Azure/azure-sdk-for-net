# Merge Proxy Tags Script

This script is intended to allow simpler combination of proxy tags. This is necessary due a few facts:

- Feature teams often need to combine their efforts while adding features. This means parallel re-recording or addition of tests.
- Instead of recordings being directly alongside the feature work, able to be merged simultaneously, now recordings are a single external reference from `assets.json`.

This script merely allows the abstraction of some of this "combination" work.

## Usage

### PreReqs

- Must have []`pshell 6+`](https://learn.microsoft.com/powershell/scripting/install/installing-powershell-on-windows)
- Must have `git` available on your PATH
- Must have the `test-proxy` available on your PATH
  - `test-proxy` is honored when the proxy is installed as a `dotnet tool`
  - `Azure.Sdk.Tools.TestProxy` is honored when the standalone executable is on your PATH
  - Defaults to `dotnet tool` if both are present on the PATH.

### Call the script

```powershell
cd "path/to/language/repo/root"
./eng/common/testproxy/scripts/tag-merge/merge-proxy-tags.ps1 sdk/storage/azure-storage-blob/assets.json integration/example/storage_feature_addition2 integration/example/storage_feature_addition1
#                                                                                                                 ^ Combined Tag 1                                    ^ Combined Tag 2
test-proxy push -a sdk/storage/azure-storage-blob/assets.json
```

### Resolve Conflicts

If the script ends early to a `git conflict` occurring, the script leaves the asset repo in a resolvable state.

- `cd` to the working directory described in the output from the script before it starts working. ("The work will be complete in...")
- `git status` to identify which files are conflicted

You will see something along these lines:

```bash
C:/repo/azure-sdk-for-python/.assets/eDscgL1p9G/python |>git status
HEAD detached from python/storage/azure-storage-blob_12c8154ae2
You are currently cherry-picking commit 1fd0865.
  (fix conflicts and run "git cherry-pick --continue")
  (use "git cherry-pick --skip" to skip this patch)
  (use "git cherry-pick --abort" to cancel the cherry-pick operation)

You are in a sparse checkout with 100% of tracked files present.

Unmerged paths:
  (use "git add <file>..." to mark resolution)
        both added:      sdk/storage/azure-storage-blob/tests/recordings/test_append_blob_async.pyTestStorageAppendBlobAsynctest_append_blob_from_text_new.json

no changes added to commit (use "git add" and/or "git commit -a")
```

Resolve the conflicts in the file, then add it using `git add <filename>`. Once the conflict is fully resolved, use

```bash
C:/repo/azure-sdk-for-python/.assets/eDscgL1p9G/python [???]|>git cherry-pick --continue
[detached HEAD 236e234] add the same file names as what was present in tag integration/example/storage_feature_addition2. In this case, the files themselves are just different enough from integration/example/storage_feature_addition2 that we should intentionally cause a conflict
 Date: Fri Dec 1 16:57:52 2023 -0800
 1 file changed, 2 insertions(+), 2 deletions(-)
```

Once you've resolved the conflict, re-run the same script. The results of the cherry-pick resolution will be visible.

```bash
C:/repo/azure-sdk-for-python [test-storage-tag-combination]|>eng/common/testproxy/scripts/tag-merge/merge-proxy-tags.ps1 sdk/storage/azure-storage-blob/assets.json integration/example/storage_feature_addition2 integration/example/storage_feature_addition2_conflict integration/example/storage_feature_addition1
Excluding tag integration/example/storage_feature_addition2 because we have already done work against it in a previous script invocation.
Excluding tag integration/example/storage_feature_addition2_conflict because we have already done work against it in a previous script invocation.
This script has detected the presence of a .mergeprogress file within folder C:\repo\azure-sdk-for-python.
If the presence of a previous execution of this script is surprising, delete the .assets folder and .mergeprogress file before invoking the script again.
Attempting to continue from a previous run, and excluding:
 - integration/example/storage_feature_addition2
 - integration/example/storage_feature_addition2_conflict
But continuing with:
 - integration/example/storage_feature_addition1
If the above looks correct, press enter, otherwise, ctrl-c:
```

On successful result, the following will be present:

```
Successfully combined 3 tags. Invoke "test-proxy push C:\repo\azure-sdk-for-python\sdk\storage\azure-storage-blob\assets.json" to push the results as a new tag.
```

Just follow the instructions to push your combined tag!

### Push the result

Once the script has completed successfully, `test-proxy push` the results!

```bash
test-proxy push sdk/storage/azure-storage-blob/assets.json
```
