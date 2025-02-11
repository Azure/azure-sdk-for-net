# Azure Batch File Conventions

A convention-based library for saving and retrieving Azure Batch task output files.

## Purpose

When you run a task in Azure Batch, the files created by that task are on the
compute node where the task ran.  As long as the compute node remains up, and within
the file retention time of the task, you can retrieve those files via the Batch API.
However, if you need the files to remain available even if the compute node is taken
down (for example, as part of a pool resize), or after the retention time has expired,
you must persist those files to a durable store.

This library encapsulates a convention for persisting job and task outputs in Azure blob
storage.  This allows client code to easily locate the outputs for a given job or
task, allowing those outputs to be listed or retrieved by ID and purpose.  For example,
a client can use the library to request 'list all the intermediate files for task 7'
or 'get me the thumbnail preview for job "mymovie"' without needing to know names or locations.

The categorization of persisted files as 'output', 'preview', etc. is done using the
JobOutputKind and TaskOutputKind types.  For job output files, the predefined kinds
are "JobOutput" and "JobPreview"; for task output files, "TaskOutput", "TaskPreview",
"TaskLog" and "TaskIntermediate".  You can also define custom kinds if these
are useful in your workflow.

## Prerequisites

The library uses the Azure Storage account linked to your Batch account.  If your Batch account
doesn't have a linked storage account, you can configure one using the [Azure portal](https://portal.azure.com).

## Usage

The library is intended for use in both task code and client code -- in task code to
persist files, in client code to list and retrieve them.

### Persisting Files in Task Code

To persist a file from task code, use the JobOutputStorage and TaskOutputStorage
constructors that take a job output container URL, and call the SaveAsync method:

    var linkedStorageAccount = new CloudStorageAccount(/* credentials */);
    var jobId = Environment.GetEnvironmentVariable("AZ_BATCH_JOB_ID");
    var taskId = Environment.GetEnvironmentVariable("AZ_BATCH_TASK_ID");

    var taskOutputStorage = new TaskOutputStorage(linkedStorageAccount, jobId, taskId);

    await taskOutputStorage.SaveAsync(TaskOutputKind.TaskOutput, "frame_full_res.jpg");
    await taskOutputStorage.SaveAsync(TaskOutputKind.TaskPreview, "frame_low_res.jpg");

Note that all output files from a job, including task outputs, are stored in the same container. This means that
[storage throttling limits](https://azure.microsoft.com/documentation/articles/storage-performance-checklist/#blobs)
may be enforced if a large number of tasks try to persist files at the same time.

### Listing and Retrieving Files in Client Code

To access persisted files from client code, you must configure the client with
the details of the linked storage account.  Then use the JobOutputStorage and
TaskOutputStorage constructors that take a CloudStorageAccount, or the extension
methods on CloudJob and CloudTask.

    var job = await batchClient.JobOperations.GetJobAsync(jobId);
    var jobOutputStorage = job.OutputStorage(linkedStorageAccount);

    var jobOutputBlob = jobOutputStorage.ListOutputs(JobOutputKind.JobOutput)
                                        .SingleOrDefault()
                                        as CloudBlockBlob;

    if (jobOutputBlob != null)
    {
        await jobOutputBlob.DownloadToFileAsync("movie.mp4", FileMode.Create);
    }

## Conventions

The conventions library defines paths in Azure blob storage for output storage.
All outputs from a job, including task outputs, are stored in a single container.
Within that container, outputs are stored by kind and (for task outputs) task ID.
This section describes the conventions for the job output container name and for
paths within the job output container.

### Job Output Container Name

The job output container name is formed according to the following rules:

* Normalize the job ID to lower case. (Due to the restricted set of letters
  permitted in IDs, there are no locale issues with this normalization.)
* If prepending "job-" to the normalized ID gives a valid container name,
  use that.
* Otherwise:
  * Calculate the SHA1 hash of the normalized ID, and express it
    as a 40-character hex string.
  * Replace all underscores, colons, and sequences of one or more hyphens in
    the normalized ID by single hyphens, then remove any leading or trailing
    hyphens.
  * If the resulting string is empty, use the string "job" instead.
  * If the resulting string is longer than 15 characters, truncate it
    to 15 characters. If truncation results in a trailing hyphen, remove
	it.
  * The container name is the string "job-", followed by the truncated
    ID, followed by a hyphen, followed by the hash.

For example, if the job ID is `MyTerrificJob`, then the container name is
`job-myterrificjob` as this is a valid container name. If the job ID is
`my-_EVEN_MORE_-terrific-job`, we cannot use `job-my-_even_more_-terrific-job`
as this is not a valid container name, so we apply the algorithm:

* The SHA1 hash of `my-_even_more_-terrific-job` (all lower case) is
  `68b05a7d8aa6aa65b9a6892c667a6c406a16ad65`.
* Replacing hyphens and underscores by single hyphens in the lower case
  ID gives `my-even-more-terrific-job`. There are no leading or trailing
  hyphens to remove.
* Truncating to 15 characters gives us `my-even-more-te`. Again there are
  no leading or trailing hyphens to remove.
* The final container name is `job-my-even-more-te-68b05a7d8aa6aa65b9a6892c667a6c406a16ad65`.

The purpose behind this algorithm is to ensure that jobs are given valid and
unique container names, while preserving human readability as far as possible,
by where possible using the job ID, and in other cases including a prefix
based on the job ID.

### Blob Path

The blob path within the container depends on whether the output is being stored
as a job output or task output.

Job outputs are stored as "${kind}/{filename}".  For example, if the file
"out/mergeresults.txt" is stored under JobOutputKind.JobOutput, then its path
within the container is "$JobOutput/out/mergeresults.txt".

Task outputs are stored as "{taskid}/${kind}/{filename}".  For example, if
the file "analytics.log" from task "analysis-309" is stored under TaskOutputKind.TaskLog,
then its path within the container is "analysis-309/$TaskLog/analytics.log".

The purpose behind this structure is to enable clients to readily locate
outputs based on their kind - for example, "list the main outputs of the job"
or "list the log files for task analysis-309".
