import { parseArgs } from "node:util";
import { mkdir, writeFile } from "node:fs/promises";
import { dirname, resolve } from "node:path";
import { AzureCliCredential } from "@azure/identity";
import { ContainerClient } from "@azure/storage-blob";
import { PublicationError } from "./bundle.mjs";
import { containerUrl, publisherIdentity, publishBundle } from "./storage.mjs";
import { notifyDashboard, refreshUrl } from "./notification.mjs";

try {
    const { values } = parseArgs({ options: { bundle: { type: "string" }, result: { type: "string" } } });
    if (!values.bundle || !values.result) throw new PublicationError("invalid_arguments", "Provide --bundle and --result.");
    if (process.env.TF_BUILD && (process.env.SYSTEM_TEAMPROJECT !== "internal" ||
        process.env.BUILD_REASON === "PullRequest" || process.env.BUILD_SOURCEBRANCH?.startsWith("refs/pull/"))) {
        throw new PublicationError("untrusted_run", "Publishing requires a trusted internal, non-PR run.");
    }
    const destination = containerUrl(process.env.EVAL_STORAGE_CONTAINER_URL);
    const shouldNotify = process.env.EVAL_NOTIFY_DASHBOARD?.toLowerCase() === "true";
    if (shouldNotify) {
        refreshUrl(process.env.EVAL_DASHBOARD_URL);
        if (!/^(api:\/\/|https:\/\/)[^\s?#]+$/.test(process.env.EVAL_DASHBOARD_AUDIENCE ?? "")) {
            throw new PublicationError("invalid_audience", "An application audience is required for notifications.");
        }
    }
    const credential = new AzureCliCredential({ processTimeoutInMs: 30_000 });
    const identity = publisherIdentity((await credential.getToken("https://storage.azure.com/.default")).token);
    const client = new ContainerClient(destination, credential, { retryOptions: { maxTries: 3, tryTimeoutInMs: 30_000 } });
    const output = resolve(values.result); await mkdir(dirname(output), { recursive: true });
    const save = result => writeFile(output, JSON.stringify(result, null, 2) + "\n");
    const result = await publishBundle({ bundlePath: resolve(values.bundle), client, publisherId: identity, onStored: save,
        verifyRetry: process.env.EVAL_PUBLISH_SMOKE_TEST?.toLowerCase() === "true",
        notify: shouldNotify ? target => notifyDashboard({ url: process.env.EVAL_DASHBOARD_URL, target,
            getToken: async () => (await credential.getToken(`${process.env.EVAL_DASHBOARD_AUDIENCE.replace(/\/$/, "")}/.default`)).token }) : undefined });
    await save(result);
    console.log(`Result archive stored: ${result.blobName} (duplicate: ${result.duplicate}).`);
    if (result.retryVerified) console.log("Smoke test: retrying the same saved ZIP was idempotent; one archive remains.");
    if (result.notification.status === "failed") console.warn("##vso[task.logissue type=warning]Blob upload succeeded; dashboard refresh failed. Retry the signal or reconcile the cache later.");
    else console.log(`Dashboard notification: ${result.notification.status}.`);
} catch (error) {
    // Azure SDK exceptions may contain request URLs/headers; never print raw errors.
    console.error(error instanceof PublicationError ? error.message : "Blob publication failed. Check the service connection, container access and agent network route.");
    process.exitCode = 1;
}