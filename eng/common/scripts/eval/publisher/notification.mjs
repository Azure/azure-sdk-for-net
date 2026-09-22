import { setTimeout as delay } from "node:timers/promises";
import { PublicationError } from "./bundle.mjs";

// Reviewed destination/audience pairs, not queue-time configuration. Onboarding
// another dashboard requires a source change; arbitrary HTTPS is not trusted.
export const DASHBOARD_NOTIFICATION_TARGET = Object.freeze({
    origin: "https://azsdk-eval-bue6a7dwanatgpb3.westus3-01.azurewebsites.net",
    audience: "api://258998df-81ec-460c-bdd7-56a9bdde1e48",
});

export function refreshUrl(value, audience) {
    const url = new URL(value);
    if (url.protocol !== "https:" || url.username || url.password || url.port || url.search || url.hash || url.pathname !== "/") {
        throw new PublicationError("invalid_dashboard", "Use the dashboard HTTPS origin without paths or credentials.");
    }
    if (url.origin !== DASHBOARD_NOTIFICATION_TARGET.origin || audience !== DASHBOARD_NOTIFICATION_TARGET.audience) {
        throw new PublicationError("unapproved_notification_target", "The dashboard origin and audience must match a reviewed notification target.");
    }
    return new URL("/api/refresh", url);
}

export async function notifyDashboard({ url, audience, target, getToken, fetchImpl = fetch, wait = delay, maxAttempts = 4 }) {
    const destination = refreshUrl(url, audience), body = JSON.stringify(target);
    if (Buffer.byteLength(body) > 2048) throw new PublicationError("invalid_signal", "Refresh signal exceeds 2 KiB.");
    for (let attempt = 0; attempt < maxAttempts; attempt++) {
        let response, permanent = false;
        try {
            response = await fetchImpl(destination, { method: "POST", redirect: "error", signal: AbortSignal.timeout(180_000),
                headers: { "content-type": "application/json", authorization: `Bearer ${await getToken(audience)}` }, body });
            if (response.status === 200) {
                const result = await response.json();
                if (result.status === "succeeded" && result.failureCount === 0) return result;
            } else permanent = ![408, 429, 500, 502, 503, 504].includes(response.status);
        } catch { /* Timeout/lost response/token outage: retry only the small signal. */ }
        finally { await response?.body?.cancel().catch(() => {}); }
        if (permanent || attempt + 1 === maxAttempts) break;
        const header = response?.headers.get("retry-after"), seconds = Number(header);
        const milliseconds = header && Number.isFinite(seconds) ? seconds * 1000 : header ? Date.parse(header) - Date.now() : NaN;
        await wait(Math.min(60_000, Math.max(0, Number.isFinite(milliseconds) ? milliseconds : 1000 * 2 ** attempt)));
    }
    throw new PublicationError("notification_failed", "Dashboard notification failed; the Blob archive remains stored.");
}