using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework.Constraints;
using System.Data.Common;

namespace PlaywrightNUnitDemo;

[Parallelizable(ParallelScope.Self)]
public class TestCases : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("https://app.asana.com/-/login");

        //await Specific Button to make sure Page Finish loading

        await Page.GetByRole(AriaRole.Button, new() { Name = "Continue", Exact = true }).IsVisibleAsync();

        //await Page.Locator("//*[@autocomplete=\"username\"]").ClickAsync();

        await Page.Locator("//*[@autocomplete=\"username\"]").FillAsync("ben+pose@workwithloop.com");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Continue", Exact = true }).ClickAsync();

        //Entering and click Password

        await Page.Locator("//*[@type=\"password\"]").FillAsync("Password123");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Log in", Exact = true }).ClickAsync();

        //await Home Finish to Load

        await Page.GetByText("Good afternoon, Ben").IsVisibleAsync();
    }

    [Test]
    public async Task TestCase1()
    {
        //Navigate to "Cross-functional project plan, Project."

        await Page.GetByText("Cross-functional project plan, Project").ClickAsync();

        //Await Specific Test to make sure Page Finish loading

        await Page.GetByText("Board").IsVisibleAsync();

        //Verify "Draft project brief" is in the "To do" column.

        await Page.Locator("//div[@class=\"CommentOnlyBoardColumnCardsContainer-cardsList\"]//tr[contains(.,\"Draft project brief\")]").IsVisibleAsync();

        //Confirm tags: "Non-Priority" and "On track."

        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]")
              .Filter(new() { HasText = "Non-Priority" })
              .IsVisibleAsync();

        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]").First
              .Filter(new() { HasText = "On track" })
              .IsVisibleAsync();
    }

    [Test]
    public async Task TestCase2()
    {
        //Navigate to "Cross-functional project plan, Project."

        await Page.GetByText("Cross-functional project plan, Project").ClickAsync();

        //Await Specific Test to make sure Page Finish loading

        await Page.GetByText("Board").IsVisibleAsync();

        //Verify "Schedule kickoff meeting" is in the "To do" column

        await Expect(Page.Locator("//div[@class=\"CommentOnlyBoardColumnCardsContainer-itemList\"]").Nth(1)).ToContainTextAsync("Schedule kickoff meeting");

        //Confirm tags: "Medium" and "At risk."

        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]")
             .Filter(new() { HasText = "Medium" })
             .IsVisibleAsync();

        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]")
              .Filter(new() { HasText = "At risk" })
              .IsVisibleAsync();
    }
    [Test]
    public async Task TestCase3()
    {
        //Navigate to "Cross-functional project plan, Project."

        await Page.GetByText("Cross-functional project plan, Project").ClickAsync();

        //Await Specific Test to make sure Page Finish loading

        await Page.GetByText("Board").IsVisibleAsync();

        //Verify "Share timeline with teammates" is in the "To do" column.

        await Expect(Page.Locator("//div[@class=\"CommentOnlyBoardColumnCardsContainer-itemList\"]").Nth(1)).ToContainTextAsync("Share timeline with teammates");

        //Confirm tags: "High" and "Off track."

        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]")
             .Filter(new() { HasText = "High" })
             .IsVisibleAsync();

        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]")
              .Filter(new() { HasText = "Off track" })
              .IsVisibleAsync();
    }
    [Test]
    public async Task TestCase4()
    {
        //Navigate to "Work Requests."

        await Page.GetByText("Work Requests").ClickAsync();

        //Await Specific Test to make sure Page Finish loading

        await Page.GetByText("New Requests").IsVisibleAsync();

        //Verify  "[Example] Laptop setup for new hire" is in the "New Requests" column.

        await Expect(Page.Locator("//div[@class=\"CommentOnlyBoardColumnCardsContainer-cardsList\"]").First).ToContainTextAsync("[Example] Laptop setup for new hire");

        //Confirm tags: "Medium priority," "Low effort," "New hardware," and "Not Started."

        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]").First
             .Filter(new() { HasText = "Medium priority" })
             .IsVisibleAsync();

        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]").First
              .Filter(new() { HasText = "Low effort" })
              .IsVisibleAsync();

        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]").First
              .Filter(new() { HasText = "New hardware" })
              .IsVisibleAsync();
        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]").First
              .Filter(new() { HasText = "Not Started" })
              .IsVisibleAsync();
    }

    [Test]
    public async Task TestCase5()
    {
        //Navigate to "Work Requests."

        await Page.GetByText("Work Requests").ClickAsync();

        //Await Specific Test to make sure Page Finish loading

        await Page.GetByText("New Requests").IsVisibleAsync();

        //Verify "[Example] Password not working" is in the "In Progress" column.

        await Expect(Page.Locator("//div[@class=\"CommentOnlyBoardColumnCardsContainer-cardsList\"]").Nth(2)).ToContainTextAsync("[Example] Password not working");

        //Confirm tags: "Low effort," "Low priority," "Password reset," and "Waiting."

        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]").Nth(2)
             .Filter(new() { HasText = "Low effort" })
             .IsVisibleAsync();

        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]").Nth(2)
              .Filter(new() { HasText = "Password reset" })
              .IsVisibleAsync();

        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]").Nth(2)
              .Filter(new() { HasText = "Waiting" })
              .IsVisibleAsync();
    }

    [Test]
    public async Task TestCase6()
    {
        //Navigate to "Work Requests."

        await Page.GetByText("Work Requests").ClickAsync();

        //Await Specific Test to make sure Page Finish loading

        await Page.GetByText("New Requests").IsVisibleAsync();

        //Verify "[Example] New keycard for Daniela V" is in the "Completed" column.

        await Expect(Page.Locator("//div[@class=\"CommentOnlyBoardColumnCardsContainer-cardsList\"]").Nth(3)).ToContainTextAsync("[Example] New keycard for Daniela V");

        //Confirm tags: "Low effort," "New hardware," "High Priority," and "Done."

        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]").Nth(3)
             .Filter(new() { HasText = "Low effort" })
             .IsVisibleAsync();

        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]").Nth(3)
              .Filter(new() { HasText = "New hardware" })
              .IsVisibleAsync();

        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]").Nth(3)
              .Filter(new() { HasText = "High Priority" })
              .IsVisibleAsync();

        await Page.Locator("//span[@class=\"TypographyPresentation TypographyPresentation--overflowTruncate\"]").Nth(3)
             .Filter(new() { HasText = "Done" })
             .IsVisibleAsync();
    }
}