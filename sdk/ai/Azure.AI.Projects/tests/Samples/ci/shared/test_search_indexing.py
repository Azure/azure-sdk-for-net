# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
"""Offline tests of the Bicep-managed Search data-plane executor."""

import importlib.util
import io
from pathlib import Path
from types import SimpleNamespace
import urllib.error

import pytest

spec = importlib.util.spec_from_file_location(
    "search_indexing", Path(__file__).parent / "infra" / "search-indexing.py"
)
indexing = importlib.util.module_from_spec(spec)
spec.loader.exec_module(indexing)

ENDPOINT = "https://sample.search.windows.net"


def test_token_acquisition_failure_does_not_expose_command_output(monkeypatch):
    monkeypatch.setattr(
        indexing.subprocess,
        "run",
        lambda *args, **kwargs: SimpleNamespace(returncode=1, stdout="secret-token"),
    )
    with pytest.raises(RuntimeError, match="output suppressed") as error:
        indexing.DataPlaneClient()._token(indexing.SEARCH_AUDIENCE)
    assert "secret-token" not in str(error.value)


def test_tokens_are_cached_per_audience(monkeypatch):
    calls = []

    def run(command, **kwargs):
        calls.append(command)
        return SimpleNamespace(returncode=0, stdout=f"token-{len(calls)}")

    monkeypatch.setattr(indexing.subprocess, "run", run)
    client = indexing.DataPlaneClient()
    assert (
        client._token(indexing.SEARCH_AUDIENCE)
        == client._token(indexing.SEARCH_AUDIENCE)
        == "token-1"
    )
    assert client._token(indexing.STORAGE_AUDIENCE) == "token-2"
    assert len(calls) == 2
    assert all(kwargs not in calls[0] for kwargs in ("role", "login"))


@pytest.mark.parametrize(
    "url,audience",
    [
        ("http://sample.search.windows.net/indexes", indexing.SEARCH_AUDIENCE),
        (
            "https://sample.search.windows.net.evil.invalid/indexes",
            indexing.SEARCH_AUDIENCE,
        ),
        ("https://user@sample.search.windows.net/indexes", indexing.SEARCH_AUDIENCE),
        ("https://sample.search.windows.net:8443/indexes", indexing.SEARCH_AUDIENCE),
        ("https://sample.blob.core.windows.net/documents", indexing.SEARCH_AUDIENCE),
        (ENDPOINT, "https://untrusted.invalid"),
    ],
)
def test_invalid_endpoint_is_rejected_before_token_acquisition(
    url, audience, monkeypatch
):
    client = indexing.DataPlaneClient()
    monkeypatch.setattr(
        client, "_token", lambda audience: pytest.fail("Token must not be acquired")
    )
    with pytest.raises(ValueError, match="token audience"):
        client.request("GET", url, audience)


def test_redirect_does_not_forward_authorization():
    with pytest.raises(RuntimeError, match="redirects"):
        indexing.RejectRedirects().redirect_request(
            None, None, 302, "", {}, "https://untrusted.invalid"
        )


@pytest.mark.parametrize(
    "code,method,path",
    [
        (403, "GET", "/indexes"),
        (429, "GET", "/indexes"),
        (409, "POST", "/indexers/test/run"),
    ],
)
def test_transient_http_failure_is_retried_and_logged(
    code, method, path, monkeypatch, capsys
):
    client = indexing.DataPlaneClient()
    monkeypatch.setattr(client, "_token", lambda audience: "secret-token")
    monkeypatch.setattr(indexing.time, "sleep", lambda seconds: None)
    calls = []

    def open_request(request, **kwargs):
        calls.append(request)
        if len(calls) == 1:
            raise urllib.error.HTTPError(
                request.full_url, code, "", {}, io.BytesIO(b"sensitive-response")
            )
        return io.BytesIO(b'{"value": []}')

    monkeypatch.setattr(client._opener, "open", open_request)
    assert client.request(
        method,
        indexing.search_url(ENDPOINT, path.lstrip("/")),
        indexing.SEARCH_AUDIENCE,
    ) == {"value": []}
    assert len(calls) == 2
    assert "retrying" in capsys.readouterr().out


@pytest.mark.parametrize("code", [400, 409])
def test_permanent_http_failure_is_not_retried_and_body_is_suppressed(
    code, monkeypatch
):
    client = indexing.DataPlaneClient()
    monkeypatch.setattr(client, "_token", lambda audience: "secret-token")

    def open_request(request, **kwargs):
        raise urllib.error.HTTPError(
            request.full_url, code, "", {}, io.BytesIO(b"sensitive-response")
        )

    monkeypatch.setattr(client._opener, "open", open_request)
    monkeypatch.setattr(
        indexing.time,
        "sleep",
        lambda seconds: pytest.fail("Permanent error must not be retried"),
    )
    with pytest.raises(RuntimeError, match=f"HTTP {code}") as error:
        client.request(
            "PUT",
            indexing.search_url(ENDPOINT, "indexes/test"),
            indexing.SEARCH_AUDIENCE,
        )
    assert "sensitive-response" not in str(error.value)
    assert "secret-token" not in str(error.value)


def test_authorization_retry_has_a_deadline(monkeypatch):
    client = indexing.DataPlaneClient()
    monkeypatch.setattr(client, "_token", lambda audience: "secret-token")
    times = iter([0, 601])
    monkeypatch.setattr(indexing.time, "monotonic", lambda: next(times))

    def open_request(request, **kwargs):
        raise urllib.error.HTTPError(request.full_url, 403, "", {}, io.BytesIO())

    monkeypatch.setattr(client._opener, "open", open_request)
    with pytest.raises(RuntimeError, match="HTTP 403"):
        client.request(
            "GET", indexing.search_url(ENDPOINT, "indexes"), indexing.SEARCH_AUDIENCE
        )


def test_indexer_waits_for_its_automatic_initial_execution(monkeypatch):
    results = iter(
        [
            None,
            {"status": "inProgress", "startTime": "new"},
            {"status": "success", "startTime": "new", "itemsProcessed": 1},
        ]
    )
    client = SimpleNamespace(request=lambda *args: {"lastResult": next(results)})
    sleeps = []
    monkeypatch.setattr(indexing.time, "sleep", sleeps.append)
    indexing.wait_for_indexer(client, ENDPOINT, "sample-indexer")
    assert sleeps == [10, 10]


@pytest.mark.parametrize(
    "result",
    [
        {"status": "persistentFailure"},
        {"status": "transientFailure"},
        {"status": "success", "itemsProcessed": 0},
        {"status": "success", "itemsProcessed": 1, "itemsFailed": 1},
        {
            "status": "success",
            "itemsProcessed": 1,
            "warnings": [{"message": "warning"}],
        },
        {"status": "success", "itemsProcessed": 1, "errors": [{"message": "error"}]},
    ],
)
def test_unsuccessful_indexer_fails_explicitly(result):
    client = SimpleNamespace(
        request=lambda *args: {"lastResult": {"startTime": "new", **result}}
    )
    with pytest.raises(RuntimeError):
        indexing.wait_for_indexer(client, ENDPOINT, "sample-indexer")


def test_indexer_has_a_deadline(monkeypatch):
    times = iter([0, 601])
    monkeypatch.setattr(indexing.time, "monotonic", lambda: next(times))
    with pytest.raises(TimeoutError):
        indexing.wait_for_indexer(SimpleNamespace(), ENDPOINT, "sample-indexer")


@pytest.mark.parametrize(
    "documents", [[{"chunk": "product content"}], [], [{"chunk": ""}]]
)
def test_provision_uploads_definitions_and_waits_for_both_initial_indexer_runs(
    documents,
):
    configuration = {
        "searchEndpoint": ENDPOINT,
        "storageEndpoint": "https://sample.blob.core.windows.net",
        "containerName": "documents",
        "blobs": [
            {"name": "product.md", "content": "Markdown"},
            {"name": "product.txt", "content": "Text"},
        ],
        "index": {"name": "sample"},
        "datasource": {"name": "sample-datasource"},
        "skillset": {"name": "sample-skillset"},
        "indexers": [{"name": "markdown"}, {"name": "documents"}],
    }
    calls = []
    status_calls = {}

    def request(method, url, audience, body=None, headers=None):
        calls.append((method, url, audience, body, headers))
        if url.split("?")[0].endswith("/status"):
            count = status_calls.get(url, 0)
            status_calls[url] = count + 1
            return {
                "lastResult": {
                    "status": "success",
                    "startTime": f"run-{count}",
                    "itemsProcessed": 1,
                }
            }
        if url.split("?")[0].endswith("/docs/search"):
            return {"value": documents}
        return None

    client = SimpleNamespace(request=request)
    if documents and documents[0]["chunk"]:
        indexing.provision(configuration, client)
    else:
        with pytest.raises(RuntimeError, match="empty"):
            indexing.provision(configuration, client)
    assert [call[0] for call in calls[:5]] == ["PUT"] * 5
    assert all(
        call[2] == indexing.STORAGE_AUDIENCE
        and call[4]["x-ms-blob-type"] == "BlockBlob"
        for call in calls[:2]
    )
    assert [
        call[1].split("?")[0].rsplit("/", 1)[-1] for call in calls if call[0] == "POST"
    ] == ["search"]
    assert list(status_calls.values()) == [1, 1]
    assert (
        len([call for call in calls if call[0] == "PUT" and "/indexers/" in call[1]])
        == 2
    )
