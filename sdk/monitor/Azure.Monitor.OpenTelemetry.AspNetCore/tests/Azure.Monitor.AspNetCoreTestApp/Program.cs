// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This is an ASP.NET Core test app used in unit tests.
// Unit Tests are expected to define their own routes and middleware.
#if NET
using Microsoft.AspNetCore.Builder;

namespace Azure.Monitor.AspNetCoreTestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // Default response to verify connectivity when setting up new tests.
            // using var response = await client.GetAsync("/");
            // response.EnsureSuccessStatusCode();
            // Assert.Equal("Hello World!", await response.Content.ReadAsStringAsync());
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
#endif
