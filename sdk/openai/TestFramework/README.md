# Test Framework for Open AI

A trimmed down and simplified version of the `Azure.Core.TestFramework` that is built on top `System.ClientModel` instead of `Azure.Core`. The goal here was to pare down the functionality to just the following two features

- Automatic testing of Sync/Async method pairs
- Support for recording of HTTP/HTTPs requests, and then playback of these requests during tests

This will allow us to use this same framework for the OpenAI tests, without bringing in several external dependencies.
