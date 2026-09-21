// The artifact list alone cannot reveal a newer retry that lost its agent before
// publishing anything. The current build timeline is authoritative for job attempts.
export function latestShardAttempts(timeline, matrix) {
    if (!Array.isArray(timeline?.records) || !matrix || typeof matrix !== "object" || Array.isArray(matrix)) {
        throw new Error("The current build timeline and Prepare matrix are required.");
    }
    const attempts = {};
    for (const [key, entry] of Object.entries(matrix)) {
        if (!/^[A-Za-z0-9_][A-Za-z0-9_-]{0,199}$/.test(key) || !entry?.shardName) throw new Error("Invalid matrix leg identity.");
        const jobs = timeline.records.filter(record => record.type === "Job" && record.identifier === `Eval.RunShard.${key}`);
        for (const record of jobs) {
            if (!Number.isSafeInteger(record.attempt) || record.attempt < 1) throw new Error("Invalid timeline attempt.");
            if (!attempts[entry.shardName] || attempts[entry.shardName].attempt < record.attempt) {
                attempts[entry.shardName] = { attempt: record.attempt, complete: record.state === "completed" &&
                    ["succeeded", "succeededWithIssues", "failed"].includes(record.result) };
            }
        }
        if (!attempts[entry.shardName]) throw new Error("An expected matrix job is missing from the current build timeline.");
    }
    if (!Object.keys(attempts).length) throw new Error("The Prepare matrix is empty.");
    return { schemaVersion: 1, valid: true, attempts };
}