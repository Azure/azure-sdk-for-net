# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
"""Execute the data-plane definitions supplied by the Bicep deployment script."""

from datetime import datetime, timezone
import email.utils
import json
import os
import subprocess
import time
import urllib.error
import urllib.parse
import urllib.request

SEARCH_API_VERSION = "2026-04-01"
SEARCH_AUDIENCE = "https://search.azure.com"
STORAGE_AUDIENCE = "https://storage.azure.com/"


class RejectRedirects(urllib.request.HTTPRedirectHandler):
    def redirect_request(self, req, fp, code, msg, headers, newurl):
        raise RuntimeError("Data-plane redirects are not allowed to forward managed identity tokens.")


class DataPlaneClient:
    def __init__(self):
        self._tokens = {}
        self._opener = urllib.request.build_opener(RejectRedirects())

    def _token(self, audience):
        now = time.monotonic()
        cached = self._tokens.get(audience)
        if cached is not None and now - cached[0] < 300:
            return cached[1]
        result = subprocess.run(
            ["az", "account", "get-access-token", "--resource", audience, "--query", "accessToken", "--output", "tsv"],
            capture_output=True,
            text=True,
            check=False,
            timeout=60,
        )
        if result.returncode or not result.stdout.strip():
            raise RuntimeError("Managed identity token acquisition failed; command output suppressed.")
        token = result.stdout.strip()
        self._tokens[audience] = (now, token)
        return token

    def request(self, method, url, audience, body=None, headers=None):
        parsed = urllib.parse.urlsplit(url)
        suffix = {SEARCH_AUDIENCE: ".search.windows.net", STORAGE_AUDIENCE: ".blob.core.windows.net"}.get(audience)
        if (
            suffix is None
            or parsed.scheme != "https"
            or not parsed.hostname
            or not parsed.hostname.endswith(suffix)
            or parsed.username is not None
            or parsed.port not in (None, 443)
        ):
            raise ValueError("Data-plane endpoint does not match its public Azure token audience.")
        data = json.dumps(body).encode("utf-8") if isinstance(body, dict) else body
        deadline = time.monotonic() + 600
        while True:
            request_headers = {
                "Authorization": f"Bearer {self._token(audience)}",
                "Content-Type": "application/json",
                **(headers or {}),
            }
            request = urllib.request.Request(url, data=data, method=method, headers=request_headers)
            try:
                with self._opener.open(request, timeout=60) as response:
                    content = response.read()
                    return json.loads(content) if content else None
            except urllib.error.HTTPError as error:
                status = error.code
                error.close()
                retry_running = status == 409 and method == "POST" and parsed.path.endswith(("/reset", "/run"))
                if (status in (401, 403, 429, 500, 502, 503, 504) or retry_running) and time.monotonic() < deadline:
                    self._tokens.pop(audience, None)
                    print(f"Data-plane {method} returned HTTP {status}; retrying within the readiness deadline.")
                    time.sleep(10)
                    continue
                raise RuntimeError(
                    f"Data-plane {method} failed with HTTP {status}; response body suppressed."
                ) from None


def search_url(endpoint, path):
    return f"{endpoint.rstrip('/')}/{path}?api-version={SEARCH_API_VERSION}"


def wait_for_indexer(client, endpoint, name):
    url = search_url(endpoint, f"indexers/{urllib.parse.quote(name, safe='')}/status")
    deadline = time.monotonic() + 600
    while time.monotonic() < deadline:
        status = client.request("GET", url, SEARCH_AUDIENCE)
        result = status.get("lastResult")
        if result is not None:
            state = result["status"]
            if state == "success":
                if result.get("itemsFailed", 0) or result.get("errors") or result.get("warnings"):
                    raise RuntimeError(f"Indexer '{name}' completed with document failures or enrichment warnings.")
                if result.get("itemsProcessed", 0) < 1:
                    raise RuntimeError(f"Indexer '{name}' completed without processing any documents.")
                print(f"Indexer '{name}' succeeded and processed {result['itemsProcessed']} documents.")
                return
            if state not in ("inProgress", "reset"):
                raise RuntimeError(f"Indexer '{name}' failed with status '{state}'; result details suppressed.")
        time.sleep(10)
    raise TimeoutError(f"Indexer '{name}' did not finish within ten minutes.")


def provision(configuration, client):
    endpoint = configuration["searchEndpoint"]
    for blob in configuration["blobs"]:
        path = "/".join(urllib.parse.quote(part, safe="") for part in (configuration["containerName"], blob["name"]))
        client.request(
            "PUT",
            f"{configuration['storageEndpoint'].rstrip('/')}/{path}",
            STORAGE_AUDIENCE,
            blob["content"].encode("utf-8"),
            {
                "Content-Type": "text/plain; charset=utf-8",
                "x-ms-blob-type": "BlockBlob",
                "x-ms-version": "2023-11-03",
                "x-ms-date": email.utils.format_datetime(datetime.now(timezone.utc), usegmt=True),
                "x-ms-meta-category": "sleeping bag",
            },
        )
        print(f"Uploaded indexing document '{blob['name']}'.")
    for collection, definition in (
        ("indexes", configuration["index"]),
        ("datasources", configuration["datasource"]),
        ("skillsets", configuration["skillset"]),
    ):
        client.request(
            "PUT",
            search_url(endpoint, f"{collection}/{urllib.parse.quote(definition['name'], safe='')}"),
            SEARCH_AUDIENCE,
            definition,
        )
        print(f"Provisioned Search {collection}.")
    for indexer in configuration["indexers"]:
        name = urllib.parse.quote(indexer["name"], safe="")
        client.request("PUT", search_url(endpoint, f"indexers/{name}"), SEARCH_AUDIENCE, indexer)
        # Workers use fresh resources; resetting would race the automatic initial run.
        wait_for_indexer(client, endpoint, indexer["name"])
    result = client.request(
        "POST",
        search_url(endpoint, f"indexes/{urllib.parse.quote(configuration['index']['name'], safe='')}/docs/search"),
        SEARCH_AUDIENCE,
        {"search": "*", "top": 1, "select": "chunk"},
    )
    if not result["value"] or not result["value"][0].get("chunk"):
        raise RuntimeError("Search index is empty or has no searchable document content.")
    print("Azure AI Search index is populated and searchable.")


if __name__ == "__main__":
    provision(json.loads(os.environ["SEARCH_INDEXING_CONFIGURATION"]), DataPlaneClient())
