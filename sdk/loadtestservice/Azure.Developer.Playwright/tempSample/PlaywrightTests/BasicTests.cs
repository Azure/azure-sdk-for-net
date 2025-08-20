// using System.Text.RegularExpressions;
// using System.Threading.Tasks;
// using Microsoft.Playwright;
// using Microsoft.Playwright.NUnit;
// using NUnit.Framework;

// namespace PlaywrightTests;

// [Parallelizable(ParallelScope.Self)]
// [TestFixture]
// public class BasicTests : PageTest
// {
//     [Test]
//     public async Task GoogleHomePage()
//     {
//         await Page.GotoAsync("https://www.google.com");
//         await Expect(Page).ToHaveTitleAsync(new Regex("Google"));
        
//         // Check that the search box exists
//         await Expect(Page.Locator("input[name='q']")).ToBeVisibleAsync();
//     }

//     [Test]
//     public async Task BingHomePage()
//     {
//         await Page.GotoAsync("https://www.bing.com");
//         await Expect(Page).ToHaveTitleAsync(new Regex("Bing"));
        
//         // Check that the search box exists
//         await Expect(Page.Locator("input[name='q']")).ToBeVisibleAsync();
//     }

//     [Test]
//     public async Task WikipediaHomePage()
//     {
//         await Page.GotoAsync("https://www.wikipedia.org");
//         await Expect(Page).ToHaveTitleAsync(new Regex("Wikipedia"));
        
//         // Check that the Wikipedia logo exists
//         await Expect(Page.Locator(".central-featured-logo")).ToBeVisibleAsync();
//     }

//     [Test]
//     public async Task GitHubHomePage()
//     {
//         await Page.GotoAsync("https://github.com");
//         await Expect(Page).ToHaveTitleAsync(new Regex("GitHub"));
        
//         // Check that the sign up button exists
//         await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Sign up" })).ToBeVisibleAsync();
//     }

//     [Test]
//     public async Task StackOverflowHomePage()
//     {
//         await Page.GotoAsync("https://stackoverflow.com");
//         await Expect(Page).ToHaveTitleAsync(new Regex("Stack Overflow"));
        
//         // Check that the search box exists
//         await Expect(Page.Locator("input[name='q']")).ToBeVisibleAsync();
//     }
// }
