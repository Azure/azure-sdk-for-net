import { parseArgs } from "node:util";
import { mkdir, writeFile } from "node:fs/promises";
import { dirname, resolve } from "node:path";
import { AzureCliCredential } from "@azure/identity";
import { ContainerClient } from "@azure/storage-blob";
import { PublicationError } from "./bundle.mjs";
import { containerUrl, publisherIdentity, publishBundle } from "./storage.mjs";
import { notifyDashboard, refreshUrl } from "./notification.mjs";
import { publicationFailure } from "./diagnostics.mjs";

let operation = "validate_configuration", save, stored = false;
try {
    const { values } = parseArgs({ options: { bundle: { type: "string" }, result: { type: "string" } } });
    if (!values.bundle || !values.result) throw new PublicationError("invalid_arguments", "Provide --bundle and --result.");
    if (process.env.TF_BUILD && (process.env.SYSTEM_TEAMPROJECT !== "internal" ||
        process.env.BUILD_REASON === "PullRequest" || process.env.BUILD_SOURCEBRANCH?.startsWith("refs/pull/"))) {
        throw new PublicationError("untrusted_run", "Publishing requires a trusted internal, non-PR run.");
    }
    const output = resolve(values.result); await mkdir(dirname(output), { recursive: true });
    save = result => writeFile(output, JSON.stringify(result, null, 2) + "\n");
    const destination = containerUrl(process.env.EVAL_STORAGE_CONTAINER_URL);
    const shouldNotify = process.env.EVAL_NOTIFY_DASHBOARD?.toLowerCase() === "true";
    if (shouldNotify) {
        // Reject the pair before either storage or notification credentials are acquired.
        refreshUrl(process.env.EVAL_DASHBOARD_URL, process.env.EVAL_DASHBOARD_AUDIENCE);
    }
    const credential = new AzureCliCredential({ processTimeoutInMs: 30_000 });
    operation = "acquire_storage_token";
    const identity = publisherIdentity((await credential.getToken("https://storage.azure.com/.default")).token);
    console.log("Pipeline storage identity acquired; no token was logged.");
    const client = new ContainerClient(destination, credential, { retryOptions: { maxTries: 3, tryTimeoutInMs: 30_000 } });
    operation = "publish_blob";
    const result = await publishBundle({ bundlePath: resolve(values.bundle), client, publisherId: identity, onStored: async result => {
        await save(result); stored = true;
    },
        notify: shouldNotify ? target => notifyDashboard({ url: process.env.EVAL_DASHBOARD_URL,
            audience: process.env.EVAL_DASHBOARD_AUDIENCE, target,
            getToken: async audience => (await credential.getToken(`${audience}/.default`)).token }) : undefined });
    await save(result);
    console.log(`Result archive stored: ${result.blobName} (duplicate: ${result.duplicate}).`);
    if (result.notification.status === "failed") console.warn("##vso[task.logissue type=warning]Blob upload succeeded; dashboard refresh failed. Retry the signal or reconcile the cache later.");
    else console.log(`Dashboard notification: ${result.notification.status}.`);
} catch (error) {
    // Azure SDK exceptions may contain request URLs/headers; never print raw errors.
    const failure = publicationFailure(error, operation);
    if (save && !stored) {
        try { await save(failure); } catch { /* Preserve the primary, sanitized failure. */ }
    }
    console.error(`Publication diagnostic: ${JSON.stringify(failure)}`);
    console.error(error instanceof PublicationError ? error.message : "Blob publication failed. Check the service connection, container access and agent network route.");
    process.exitCode = 1;
}