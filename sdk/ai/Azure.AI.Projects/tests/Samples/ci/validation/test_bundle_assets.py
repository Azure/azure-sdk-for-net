# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.

"""Offline tests for the deployment scripts; no Azure credentials or packages."""

import importlib.util
import json
from pathlib import Path
import sys
import types
import unittest
from unittest.mock import ANY, Mock, patch

ROOT = Path(__file__).resolve().parents[1]


def load_module(name, path):
    spec = importlib.util.spec_from_file_location(name, path)
    module = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(module)
    return module


class BundleAssetTests(unittest.TestCase):
    def test_function_implements_shared_weather_queue_contract(self):
        class FunctionApp:
            def __init__(self):
                self.bindings = {}

            def queue_trigger(self, **kwargs):
                self.bindings["input"] = kwargs
                return lambda function: function

            def queue_output(self, **kwargs):
                self.bindings["output"] = kwargs
                return lambda function: function

        azure = types.ModuleType("azure")
        functions = types.ModuleType("azure.functions")
        functions.FunctionApp = FunctionApp
        functions.QueueMessage = object
        functions.Out = list
        azure.functions = functions
        with patch.dict(sys.modules, {"azure": azure, "azure.functions": functions}):
            module = load_module(
                "bundle_function", ROOT / "function_app" / "function_app.py"
            )
        message = types.SimpleNamespace(
            get_body=lambda: json.dumps(
                {
                    "function_args": {"location": "Seattle"},
                    "CorrelationId": "unit-correlation",
                }
            ).encode()
        )
        responses = []
        module.queue_trigger(message, types.SimpleNamespace(set=responses.append))
        self.assertEqual(
            json.loads(responses[0]),
            {
                "Value": "Weather is 7 degrees and sunny in Seattle",
                "CorrelationId": "unit-correlation",
            },
        )
        self.assertEqual(
            module.app.bindings["input"]["queue_name"], "%STORAGE_INPUT_QUEUE_NAME%"
        )
        self.assertEqual(
            module.app.bindings["output"]["queue_name"], "%STORAGE_OUTPUT_QUEUE_NAME%"
        )
        root = (ROOT / "infra" / "main.bicep").read_text()
        self.assertNotIn("inputQueueName:", root)
        self.assertNotIn("outputQueueName:", root)
        function_template = (ROOT / "infra" / "function-app.bicep").read_text()
        self.assertIn(
            "param inputQueueName string = 'weather-input-queue'", function_template
        )
        self.assertIn(
            "param outputQueueName string = 'weather-output-queue'", function_template
        )

    def test_search_provisions_shared_documents_without_rerunning_indexers(self):
        module = load_module("bundle_search", ROOT / "infra" / "search-indexing.py")
        calls = []

        class Client:
            def request(self, method, url, audience, body=None, headers=None):
                calls.append((method, url, audience, body, headers))
                if "/docs/search?" in url:
                    return {"value": [{"chunk": "Contoso SmartView Glasses"}]}

        configuration = {
            "searchEndpoint": "https://unit.search.windows.net",
            "storageEndpoint": "https://unit.blob.core.windows.net/",
            "containerName": "documents",
            "blobs": [
                {
                    "name": "product_info.md",
                    "content": (
                        ROOT / "search_documents" / "product_info.md"
                    ).read_text(),
                }
            ],
            "index": {"name": "index-sample"},
            "datasource": {"name": "datasource"},
            "skillset": {"name": "skillset"},
            "indexers": [{"name": "indexer"}],
        }
        with patch.object(module, "wait_for_indexer") as wait:
            module.provision(configuration, Client())
        wait.assert_called_once_with(ANY, configuration["searchEndpoint"], "indexer")
        upload = calls[0]
        self.assertIn(b"SmartView Glasses", upload[3])
        indexer_calls = [call for call in calls if "/indexers/" in call[1]]
        self.assertEqual(len(indexer_calls), 1)
        self.assertEqual(indexer_calls[0][0], "PUT")
        template = (ROOT / "infra" / "ai-search.bicep").read_text()
        self.assertIn("param indexName string = 'index-sample'", template)
        self.assertIn("What features do Contoso SmartView Glasses offer?", template)
        self.assertNotIn("name: 'category'", template)

    def test_search_waits_for_automatic_initial_indexer_run(self):
        module = load_module("bundle_search", ROOT / "infra" / "search-indexing.py")
        client = Mock()
        client.request.side_effect = [
            {"lastResult": None},
            {"lastResult": {"status": "inProgress", "itemsProcessed": 0}},
            {"lastResult": {"status": "success", "itemsProcessed": 1}},
        ]
        with patch.object(module.time, "sleep") as sleep:
            module.wait_for_indexer(
                client, "https://unit.search.windows.net", "indexer"
            )
        self.assertEqual(client.request.call_count, 3)
        client.request.assert_called_with(
            "GET",
            module.search_url(
                "https://unit.search.windows.net", "indexers/indexer/status"
            ),
            module.SEARCH_AUDIENCE,
        )
        self.assertEqual(sleep.call_count, 2)

    def test_search_accepts_initial_run_completed_before_first_poll(self):
        module = load_module("bundle_search", ROOT / "infra" / "search-indexing.py")
        client = Mock()
        client.request.return_value = {
            "lastResult": {"status": "success", "itemsProcessed": 1}
        }
        with patch.object(module.time, "sleep") as sleep:
            module.wait_for_indexer(
                client, "https://unit.search.windows.net", "indexer"
            )
        client.request.assert_called_once()
        sleep.assert_not_called()

    def test_search_rejects_empty_or_partially_failed_initial_runs(self):
        module = load_module("bundle_search", ROOT / "infra" / "search-indexing.py")
        for result in (
            {"status": "success", "itemsProcessed": 0},
            {"status": "success", "itemsProcessed": 1, "itemsFailed": 1},
            {
                "status": "success",
                "itemsProcessed": 1,
                "errors": [{"message": "failure"}],
            },
            {
                "status": "success",
                "itemsProcessed": 1,
                "warnings": [{"message": "warning"}],
            },
            {"status": "persistentFailure"},
        ):
            with self.subTest(result=result):
                client = Mock()
                client.request.return_value = {"lastResult": result}
                with patch.object(module.time, "sleep") as sleep:
                    with self.assertRaises(RuntimeError):
                        module.wait_for_indexer(
                            client, "https://unit.search.windows.net", "indexer"
                        )
                sleep.assert_not_called()

    def test_search_initial_run_has_bounded_readiness_wait(self):
        module = load_module("bundle_search", ROOT / "infra" / "search-indexing.py")
        client = Mock()
        client.request.return_value = {"lastResult": None}
        with patch.object(module.time, "monotonic", side_effect=[0, 0, 601]):
            with patch.object(module.time, "sleep"):
                with self.assertRaises(TimeoutError):
                    module.wait_for_indexer(
                        client, "https://unit.search.windows.net", "indexer"
                    )
        client.request.assert_called_once()


if __name__ == "__main__":
    unittest.main()
