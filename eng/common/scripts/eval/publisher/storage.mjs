import { setTimeout as delay } from "node:timers/promises";
import { boundedFile, blobName, MAX_ZIP_BYTES, PublicationError, sha256, validateBundle } from "./bundle.mjs";

export function containerUrl(value) {
    const url = new URL(value);
    if (url.protocol !== "https:" || url.username || url.password || url.search || url.hash || url.port ||
        !/^[a-z0-9]{3,24}\.blob\.core\.(windows\.net|usgovcloudapi\.net|chinacloudapi\.cn)$/.test(url.hostname) ||
        !/^\/[a-z0-9][a-z0-9-]{1,61}[a-z0-9]$/.test(url.pathname) || url.pathname.includes("--")) {
        throw new PublicationError("invalid_container", "Use a normal HTTPS Azure Blob container URL without keys or SAS.");
    }
    return url.href;
}

export function publisherIdentity(token) {
    try {
        // Provenance only: storage authorizes the actual request with Azure RBAC.
        const claims = JSON.parse(Buffer.from(token.split(".")[1], "base64url").toString("utf8"));
        for (const key of ["tid", "oid"]) if (!/^[a-f0-9-]{36}$/i.test(claims[key] ?? "")) throw new Error();
        return `${claims.tid}:${claims.oid}`;
    } catch { throw new PublicationError("storage_identity", "The pipeline storage identity could not be determined."); }
}

export async function publishBundle({ bundlePath, client, publisherId, onStored = async () => {}, notify,
    maxAttempts = 4, wait = delay, now = () => new Date() }) {
    if (!Number.isInteger(maxAttempts) || maxAttempts < 1 || maxAttempts > 10) throw new PublicationError("invalid_arguments", "Invalid upload retry count.");
    if (typeof publisherId !== "string" || !publisherId || publisherId.length > 200) throw new PublicationError("storage_identity", "A pipeline publisher identity is required.");
    // Read and validate ONCE. Every transport retry uses the exact saved bytes.
    const bytes = await boundedFile(bundlePath, MAX_ZIP_BYTES), validated = validateBundle(bytes);
    const name = blobName(validated.manifest), hash = sha256(bytes), owner = sha256(Buffer.from(publisherId));
    const metadata = { schema: "1", sha256: hash, publisher: owner, storedat: now().toISOString() };
    const blob = client.getBlockBlobClient(name);
    const store = async () => {
        for (let attempt = 0; attempt < maxAttempts; attempt++) {
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
                        !Number.isFinite(Date.parse(saved.metadata.storedat))) {
                        throw new PublicationError("submission_conflict", "This build/attempt already has different bytes or a different publisher; nothing was overwritten.");
                    }
                    return true;
                }
            } catch (error) {
                if (error instanceof PublicationError) throw error;
                if (error.statusCode && ![408, 429, 500, 502, 503, 504].includes(error.statusCode)) throw error;
                if (attempt + 1 === maxAttempts) throw error;
                await wait(Math.min(30_000, 1000 * 2 ** attempt));
            }
        }
    };
    const result = { status: "stored", blobName: name, sha256: hash, duplicate: await store(),
        notification: { status: notify ? "pending" : "not_requested" } };
    await onStored(result);
    if (notify) {
        try { await notify({ blobName: name, sha256: hash }); result.notification = { status: "succeeded" }; }
        catch { result.notification = { status: "failed", errorCode: "notification_failed" }; }
    }
    return result;
}