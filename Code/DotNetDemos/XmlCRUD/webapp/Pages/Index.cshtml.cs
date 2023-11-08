using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;


namespace webapp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    public string Message { get; private set; } = "PageModel in C#";
    public void OnGet()
    {
        Message += $" Server time is {DateTime.Now}";
    }
}
