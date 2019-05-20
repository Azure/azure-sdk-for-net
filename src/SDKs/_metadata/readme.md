# Code Generation Metadata

This metadata records information required to exactly reproduce the code generation that was done for an SDK.

Historically, this information was only stored in `generate.cmd` files per service which has multiple problems:
* effort: the file has to be updated, PRed and be reviewed as part of the PR ("Was the commit ID updated? Is the acquired AutoRest version recorded? Was the Azure repo used for generation?"). Now, the file can mostly stay the same while AutoRest and the specification versions.
* reliability: the above tasks are potential sources of mistakes (e.g. forget to rev the commit ID after some last minute fixes to the API spec.)
* consistency: Over time, different teams have come up with different workarounds or styles for some details of code generation. While this is perfectly fine per se, it makes it harder for reviewers or customers to get an overview about the tools and versions used by SDK.

The metadata file addresses these problems since it is auto-generated when generating the SDK. No matter whether the `generate.cmd` of an SDK uses the latest or a specific version of AutoRest or whether it uses a fork/branch of the specs repository: The metadata will contain the information necessary to reproduce these steps.
The `generate.cmd` has to be updated only if the *strategy* of code generation changes, but not with every regeneration due to commit IDs.


![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsrc%2FSDKs%2F_metadata%2Freadme.png)
