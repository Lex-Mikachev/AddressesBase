using Microsoft.AspNetCore.Mvc;

namespace AddressesBase;

public class HtmlResult : IActionResult
{
    private string htmlCode;

    public HtmlResult(string html) => htmlCode = html;

    public async Task ExecuteResultAsync(ActionContext context)
    {
        string fullHtmlCode = @$"<!DOCTYPE html>
<html>
<head>
    <title>Address Base : TestTest</title>
    <meta charset=utf-8 />
</head>
<body>
    {htmlCode}
</body>
</html>";
        await context.HttpContext.Response.WriteAsync(fullHtmlCode);
    }

}