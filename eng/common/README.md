# Common Engineering System

The `eng/common` directory contains engineering files that are common across the various azure-sdk language repos.
It should remain relatively small and only contain textual based files like scripts, configs, or templates. It
should not contain binary files as they don't play well with git.

## Updating

Any updates to files in the `eng/common` directory should be made in the [azure-sdk-tools](https://github.com/azure/azure-sdk-tools) repo.
All changes made will cause a PR to created in all subscribed azure-sdk language repos which will blindly replace all contents of
the `eng/common` directory in that repo. For that reason do **NOT** make changes to files in this directory in the individual azure-sdk
languages repos as they will be overwritten the next time an update is taken from the common azure-sdk-tools repo.

### Workflow

The 'Sync eng/common directory' PRs will be created in the language repositories when a pull request that touches the eng/common directory is submitted against the master branch. This will make it easier for changes to be tested in each individual language repo before merging the changes in the azure-sdk-tools repo. The workflow is explained below:

1. Create a PR (**Tools PR**) in the `azure-sdk-tools` repo with changes to eng/common directory.
2. `azure-sdk-tools - sync - eng-common` pipeline is triggered for the **Tools PR**
3. The  `azure-sdk-tools - sync - eng-common` pipeline queues test runs for template pipelines in various languages. These help you test your changes in the **Tools PR**.
4. If there are changes in the **Tools PR** that will affect the release stage you should approve the release test pipelines by clicking the approval gate. The test (template) pipeline will automatically release the next eligible version without needing manual intervention for the versioning. Please approve your test releases as quickly as possible. A race condition may occur due to someone else queueing the pipeline and going all the way to release using your version while yours is still waiting. If this occurs manually rerun the pipeline that failed.
5.  If you make additional changes to your **Tools PR** repeat steps 1 - 4 until you have completed the necessary testing of your changes. This includes full releases of the template package, if necessary.
6. Sign off on CreateSyncPRs stage of the sync pipeline using the approval gate. This stage will create the **Sync PRs** in the various language repos. A link to each of the **Sync PRs** will show up in the **Tools PR** for you to click and review.
7. Go review and approve each of your **Sync PRs**.
8. Sign Off on the VerifyAndMerge stage. This will merge any remaining open **Sync PR** and also append `auto-merge` to the **Tools PR**.
