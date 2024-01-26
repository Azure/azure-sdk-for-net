// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !NETFRAMEWORK

using Microsoft.AspNetCore.Mvc;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => this.Ok("HomeController Index");

        public IActionResult Get(int id) => this.Ok($"HomeController Get '{id}'");
    }
}
#endif
