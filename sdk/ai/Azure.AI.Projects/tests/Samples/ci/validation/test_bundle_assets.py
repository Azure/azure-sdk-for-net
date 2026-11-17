# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.

"""Offline tests for the deployment scripts; no Azure credentials or packages."""

import importlib.util
import json
from pathlib import Path
import sys
import types
import unittest
from unittest.mock import ANY, patch


ROOT = Path(__file__).resolve().parents[1]


def load_module(name, path):
    spec = importlib.util.spec_from_file_location(name, path)
    module = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(module)
    return module


class BundleAssetTests(unittest.TestCase):
    def test_function_implements_dotnet_foo_queue_contract(self):
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
            module = load_module("bundle_function", ROOT / "function_app" / "function_app.py")
        message = types.SimpleNamespace(
            get_body=lambda: json.dumps(
                {"function_args": {"query": "What would foo say?"}, "CorrelationId": "unit-correlation"}
            ).encode()
        )
        responses = []
        module.queue_trigger(message, types.SimpleNamespace(set=responses.append))
        self.assertEqual(
            json.loads(responses[0]),
            {"Value": "Foo received the question: What would foo say?", "CorrelationId": "unit-correlation"},
        )
        self.assertEqual(module.app.bindings["input"]["queue_name"], "%STORAGE_INPUT_QUEUE_NAME%")
        self.assertEqual(module.app.bindings["output"]["queue_name"], "%STORAGE_OUTPUT_QUEUE_NAME%")
        root = (ROOT / "infra" / "main.bicep").read_text()
        self.assertIn("inputQueueName: 'azure-function-foo-input'", root)
        self.assertIn("outputQueueName: 'azure-function-tool-output'", root)

    def test_search_documents_and_index_match_dotnet_samples(self):
        module = load_module("bundle_search", ROOT / "infra" / "search-indexing.py")
        calls = []

        class Client:
            def request(self, method, url, audience, body=None, headers=None):
                calls.append((method, url, audience, body, headers))
                if url.endswith("/status?api-version=" + module.SEARCH_API_VERSION):
                    return {"lastResult": {"startTime": "previous"}}
                if "/docs/search?" in url:
                    return {"value": [{"chunk": "CozyNights sleeping bag"}]}

        configuration = {
            "searchEndpoint": "https://unit.search.windows.net",
            "storageEndpoint": "https://unit.blob.core.windows.net/",
            "containerName": "documents",
            "blobs": [{"name": "product_info.md", "content": (ROOT / "search_documents" / "product_info.md").read_text()}],
            "index": {"name": "sample_index"},
            "datasource": {"name": "datasource"},
            "skillset": {"name": "skillset"},
            "indexers": [{"name": "indexer"}],
        }
        with patch.object(module, "wait_for_indexer") as wait:
            module.provision(configuration, Client())
        wait.assert_called_once_with(ANY, configuration["searchEndpoint"], "indexer", "previous")
        upload = calls[0]
        self.assertEqual(upload[4]["x-ms-meta-category"], "sleeping bag")
        self.assertIn(b"20 degrees Fahrenheit", upload[3])
        self.assertTrue(any("/indexers/indexer/run?" in call[1] for call in calls))
        template = (ROOT / "infra" / "ai-search.bicep").read_text()
        self.assertIn("param indexName string = 'sample_index'", template)
        self.assertIn("{ name: 'category', type: 'Edm.String', filterable: true", template)
        self.assertIn("{ name: 'category', source: '/document/category' }", template)

if __name__ == "__main__":
    unittest.main()
