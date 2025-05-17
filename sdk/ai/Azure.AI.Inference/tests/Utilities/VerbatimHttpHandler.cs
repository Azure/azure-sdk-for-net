// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Microsoft.Extensions.AI;

/// <summary>
/// An <see cref="HttpMessageHandler"/> that checks the request body against an expected one
/// and sends back an expected response.
/// </summary>
public sealed class VerbatimHttpHandler(string expectedInput, string expectedOutput, bool validateExpectedResponse = false) :
    DelegatingHandler(new HttpClientHandler())
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Assert.That(request.Content, Is.Not.Null);

        string actualInput = await request.Content!.ReadAsStringAsync().ConfigureAwait(false);

        Assert.That(actualInput, Is.Not.Null);
        AssertEqualNormalized(expectedInput, actualInput);

        if (validateExpectedResponse)
        {
            ByteArrayContent newContent = new(Encoding.UTF8.GetBytes(actualInput));
            foreach (var header in request.Content.Headers)
            {
                newContent.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            request.Content = newContent;

            using var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            string actualOutput = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            Assert.That(actualOutput, Is.Not.Null);
            AssertEqualNormalized(expectedOutput, actualOutput);
        }

        return new() { Content = new StringContent(expectedOutput) };
    }

    public static string RemoveWhiteSpace(string text) =>
        text is null ? null :
        Regex.Replace(text, @"\s*", string.Empty);

    private static void AssertEqualNormalized(string expected, string actual)
    {
        // First try to compare as JSON.
        JsonNode expectedNode = null;
        JsonNode actualNode = null;
        try
        {
            expectedNode = JsonNode.Parse(expected);
            actualNode = JsonNode.Parse(actual);
        }
        catch
        {
        }

        if (expectedNode is not null && actualNode is not null)
        {
            if (!JsonNode.DeepEquals(expectedNode, actualNode))
            {
                FailNotEqual(expected, actual);
            }

            return;
        }

        // Legitimately may not have been JSON. Fall back to whitespace normalization.
        if (RemoveWhiteSpace(expected) != RemoveWhiteSpace(actual))
        {
            FailNotEqual(expected, actual);
        }
    }

    private static void FailNotEqual(string expected, string actual) =>
        Assert.Fail(
            $"Expected:{Environment.NewLine}" +
            $"{expected}{Environment.NewLine}" +
            $"Actual:{Environment.NewLine}" +
            $"{actual}");
}
