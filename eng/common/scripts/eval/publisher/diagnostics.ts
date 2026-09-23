// Preserve useful diagnostics without serializing Azure requests, credentials,
// raw evaluation data, arbitrary exception messages, or response headers.
export function publicationFailure(error, operation) {
    const value = error?.code ?? error?.details?.errorCode;
    const code = typeof value === "string" && /^[A-Za-z][A-Za-z0-9_]{0,79}$/.test(value) ? value : "publication_failed";
    const status = Number.isInteger(error?.statusCode) && error.statusCode >= 400 && error.statusCode <= 599 ? error.statusCode : undefined;
    const requestId = error?.details?.requestId;
    return { status: "failed", operation, errorCode: code, ...(status ? { httpStatus: status } : {}),
        ...(typeof requestId === "string" && /^[a-f0-9-]{36}$/i.test(requestId) ? { requestId } : {}) };
}