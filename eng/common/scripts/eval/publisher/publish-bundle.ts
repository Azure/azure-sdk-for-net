// Publishes a saved build archive, persists the storage result, then signals the fixed dashboard.
import { parseArgs } from "node:util";
import { mkdir } from "node:fs/promises";
import { dirname, resolve } from "node:path";
import { AzureCliCredential } from "@azure/identity";
import { ContainerClient } from "@azure/storage-blob";
import { PublicationError } from "./bundle.ts";
import { STORAGE_CONTAINER_URL, publisherIdentity, publishBundle, notifyDashboard, publicationFailure, savePublicationResult } from "./storage.ts";

let operation = "validate_configuration", save, stored = false;
try {
    const { values } = parseArgs({ options: { bundle: { type: "string" }, result: { type: "string" } } });
    if (!values.bundle || !values.result) throw new PublicationError("invalid_arguments", "Provide --bundle and --result.");
    if (process.env.TF_BUILD && (process.env.SYSTEM_TEAMPROJECT !== "internal" ||
        process.env.BUILD_REASON === "PullRequest" || process.env.BUILD_SOURCEBRANCH !== "refs/heads/main")) {
        throw new PublicationError("untrusted_run", "Publishing requires a trusted internal main-branch run.");
    }
    const output = resolve(values.result);
    if (output === resolve(values.bundle)) throw new PublicationError("invalid_arguments", "The archive and publication result must use different paths.");
    await mkdir(dirname(output), { recursive: true });
    save = result => savePublicationResult(output, result);
    const credential = new AzureCliCredential({ processTimeoutInMs: 30_000 });
    operation = "acquire_storage_token";
    const identity = publisherIdentity((await credential.getToken("https://storage.azure.com/.default")).token);
    console.log("Pipeline storage identity acquired; no token was logged.");
    // publishBundle owns the retry budget; do not multiply it with SDK retries.
    const client = new ContainerClient(STORAGE_CONTAINER_URL, credential, { retryOptions: { maxTries: 1, tryTimeoutInMs: 30_000 } });
    operation = "publish_blob";
    const result = await publishBundle({ bundlePath: resolve(values.bundle), client, publisherId: identity, onStored: async result => {
        operation = "persist_storage_result";
        await save(result); stored = true;
    },
        notify: target => notifyDashboard({ target,
            getToken: async audience => (await credential.getToken(`${audience}/.default`)).token }) });
    try { await save(result); }
    catch { console.warn("##vso[task.logissue type=warning]Archive stored; notification status could not be saved. The original storage receipt is retained."); }
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
    console.error(error instanceof PublicationError ? error.message : operation === "persist_storage_result" ?
        "Archive stored, but its receipt could not be saved; no notification was sent. Retry the same saved archive." :
        "Blob publication failed. Check the service connection, container access and agent network route.");
    process.exitCode = 1;
}