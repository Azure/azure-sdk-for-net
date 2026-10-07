// Stores immutable saved bytes with bounded retries and signals only after the storage result is retained.
import { setTimeout as delay } from "node:timers/promises";
import { rename, writeFile } from "node:fs/promises";
import { boundedFile, blobName, isUtcTimestamp, MAX_ZIP_BYTES, PublicationError, sha256, validateBundle } from "./bundle.ts";

// One reviewed storage/notification target; no queue-time or environment overrides.
export const STORAGE_CONTAINER_URL = "https://evaltestsummary.blob.core.windows.net/vally-results";
export const DASHBOARD_NOTIFICATION_TARGET = Object.freeze({
    origin: "https://azsdk-eval-bue6a7dwanatgpb3.westus3-01.azurewebsites.net",
    audience: "api://258998df-81ec-460c-bdd7-56a9bdde1e48",
});

export async function savePublicationResult(output, result) {
    // A failed status update must not truncate the already-retained storage receipt.
    const temporary = `${output}.tmp`;
    await writeFile(temporary, JSON.stringify(result, null, 2) + "\n");
    await rename(temporary, output);
}

export function publicationFailure(error, operation) {
    const value = error?.code ?? error?.details?.errorCode;
    const code = typeof value === "string" && /^[A-Za-z][A-Za-z0-9_]{0,79}$/.test(value) ? value : "publication_failed";
    const status = Number.isInteger(error?.statusCode) && error.statusCode >= 400 && error.statusCode <= 599 ? error.statusCode : undefined;
    const requestId = error?.details?.requestId;
    return { status: "failed", operation, errorCode: code, ...(status ? { httpStatus: status } : {}),
        ...(typeof requestId === "string" && /^[a-f0-9-]{36}$/i.test(requestId) ? { requestId } : {}) };
}

export function publisherIdentity(token) {
    try {
        // Provenance only: storage authorizes the actual request with Azure RBAC.
        const claims = JSON.parse(Buffer.from(token.split(".")[1], "base64url").toString("utf8"));
        for (const key of ["tid", "oid"]) if (!/^[a-f0-9]{8}(?:-[a-f0-9]{4}){3}-[a-f0-9]{12}$/i.test(claims[key] ?? "")) throw new Error();
        return `${claims.tid}:${claims.oid}`;
    } catch { throw new PublicationError("storage_identity", "The pipeline storage identity could not be determined."); }
}

export async function publishBundle({ bundlePath, client, publisherId, onStored, notify, wait = delay }) {
    if (typeof publisherId !== "string" || !publisherId || publisherId.length > 200) throw new PublicationError("storage_identity", "A pipeline publisher identity is required.");
    // Read and validate ONCE. Every transport retry uses the exact saved bytes.
    const bytes = await boundedFile(bundlePath, MAX_ZIP_BYTES), validated = validateBundle(bytes);
    const name = blobName(validated.manifest), hash = sha256(bytes), owner = sha256(Buffer.from(publisherId));
    const metadata = { schema: "1", sha256: hash, publisher: owner, storedat: new Date().toISOString() };
    const blob = client.getBlockBlobClient(name);
    const store = async () => {
        for (let attempt = 0; attempt < 4; attempt++) {
            try {
                try {
                    await blob.uploadData(bytes, { conditions: { ifNoneMatch: "*" }, metadata,
                        blobHTTPHeaders: { blobContentType: "application/zip" } });
                    return false;
                } catch (error) {
                    if (![409, 412].includes(error.statusCode)) throw error;
                    const saved = await blob.getProperties();
                    if (saved.contentLength !== bytes.length || saved.metadata?.schema !== "1" ||
                        saved.metadata.sha256 !== hash || saved.metadata.publisher !== owner ||
                        !isUtcTimestamp(saved.metadata.storedat)) {
                        throw new PublicationError("submission_conflict", "This build/attempt already has different bytes or a different publisher; nothing was overwritten.");
                    }
                    return true;
                }
            } catch (error) {
                if (error instanceof PublicationError) throw error;
                if (error.statusCode && ![408, 429, 500, 502, 503, 504].includes(error.statusCode)) throw error;
                if (attempt === 3) throw error;
                const retryAfter = error.response?.headers?.get("retry-after"), seconds = Number(retryAfter);
                const milliseconds = retryAfter && Number.isFinite(seconds) ? seconds * 1000 : retryAfter ? Date.parse(retryAfter) - Date.now() : NaN;
                await wait(Math.min(30_000, Math.max(0, Number.isFinite(milliseconds) ? milliseconds : 1000 * 2 ** attempt)));
            }
        }
    };
    const result = { status: "stored", blobName: name, sha256: hash, duplicate: await store(),
        notification: { status: "pending" } };
    await onStored(result);
    try { await notify({ blobName: name, sha256: hash }); result.notification = { status: "succeeded" }; }
    catch { result.notification = { status: "failed", errorCode: "notification_failed" }; }
    return result;
}

export async function notifyDashboard({ target, getToken, fetchImpl = fetch, wait = delay }) {
    const { origin, audience } = DASHBOARD_NOTIFICATION_TARGET;
    const destination = new URL("/api/refresh", origin), body = JSON.stringify(target);
    if (Buffer.byteLength(body) > 2048) throw new PublicationError("invalid_signal", "Refresh signal exceeds 2 KiB.");
    for (let attempt = 0; attempt < 4; attempt++) {
        let response, permanent = false;
        try {
            response = await fetchImpl(destination, { method: "POST", redirect: "error", signal: AbortSignal.timeout(180_000),
                headers: { "content-type": "application/json", authorization: `Bearer ${await getToken(audience)}` }, body });
            if (response.status === 200) {
                const result = await response.json();
                if (result.status === "succeeded" && result.failureCount === 0) return result;
            } else permanent = ![408, 429, 500, 502, 503, 504].includes(response.status);
        } catch { /* Retry only the signal after a timeout, lost response or token outage. */ }
        finally { await response?.body?.cancel().catch(() => {}); }
        if (permanent || attempt === 3) break;
        const header = response?.headers.get("retry-after"), seconds = Number(header);
        const milliseconds = header && Number.isFinite(seconds) ? seconds * 1000 : header ? Date.parse(header) - Date.now() : NaN;
        await wait(Math.min(60_000, Math.max(0, Number.isFinite(milliseconds) ? milliseconds : 1000 * 2 ** attempt)));
    }
    throw new PublicationError("notification_failed", "Dashboard notification failed; the Blob archive remains stored.");
}