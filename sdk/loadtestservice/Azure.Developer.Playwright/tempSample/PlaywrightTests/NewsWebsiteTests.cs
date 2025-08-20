// using System.Text.RegularExpressions;
// using System.Threading.Tasks;
// using Microsoft.Playwright;
// using Microsoft.Playwright.NUnit;
// using NUnit.Framework;

// namespace PlaywrightTests;

// [Parallelizable(ParallelScope.Self)]
// [TestFixture]
// public class NewsWebsiteTests : PageTest
// {
//     [Test]
//     public async Task BBCNewsHomePage()
//     {
//         await Page.GotoAsync("https://bbc.com/news");
//         await Expect(Page).ToHaveTitleAsync(new Regex("BBC"));
        
//         // Click on a news category
//         await Page.ClickAsync("text=Technology");
//         await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
//         await Task.Delay(2000);
//     }

//     [Test]
//     public async Task CNNNewsSearch()
//     {
//         await Page.GotoAsync("https://cnn.com");
//         await Expect(Page).ToHaveTitleAsync(new Regex("CNN"));
        
//         // Search for news
//         await Page.ClickAsync("[data-module='SearchModule']");
//         await Page.FillAsync("input[name='q']", "technology news");
//         await Page.PressAsync("input[name='q']", "Enter");
//         await Task.Delay(3000);
//     }

//     [Test]
//     public async Task ReutersHomePage()
//     {
//         await Page.GotoAsync("https://reuters.com");
//         await Expect(Page).ToHaveTitleAsync(new Regex("Reuters"));
        
//         // Browse business section
//         await Page.ClickAsync("text=Business");
//         await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
//         await Task.Delay(2500);
//     }

//     [Test]
//     public async Task TechCrunchBrowse()
//     {
//         await Page.GotoAsync("https://techcrunch.com");
//         await Expect(Page).ToHaveTitleAsync(new Regex("TechCrunch"));
        
//         // Browse startups section
//         await Page.ClickAsync("text=Startups");
//         await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
//         await Task.Delay(2000);
//     }

//     [Test]
//     public async Task TheVergeExplore()
//     {
//         await Page.GotoAsync("https://theverge.com");
//         await Expect(Page).ToHaveTitleAsync(new Regex("The Verge"));
        
//         // Explore tech section
//         await Page.ClickAsync("text=Tech");
//         await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
//         await Task.Delay(2000);
//     }
// }
