#pragma checksum "C:\Users\vvgon\source\github\tech-i-know\dotnetdemos\blazor\blazorlearningserverapp\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d9efff49d432c184e5316a99710e93542b9a63a"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorLearningServerApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\vvgon\source\github\tech-i-know\dotnetdemos\blazor\blazorlearningserverapp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vvgon\source\github\tech-i-know\dotnetdemos\blazor\blazorlearningserverapp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\vvgon\source\github\tech-i-know\dotnetdemos\blazor\blazorlearningserverapp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\vvgon\source\github\tech-i-know\dotnetdemos\blazor\blazorlearningserverapp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\vvgon\source\github\tech-i-know\dotnetdemos\blazor\blazorlearningserverapp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\vvgon\source\github\tech-i-know\dotnetdemos\blazor\blazorlearningserverapp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\vvgon\source\github\tech-i-know\dotnetdemos\blazor\blazorlearningserverapp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\vvgon\source\github\tech-i-know\dotnetdemos\blazor\blazorlearningserverapp\_Imports.razor"
using BlazorLearningServerApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\vvgon\source\github\tech-i-know\dotnetdemos\blazor\blazorlearningserverapp\_Imports.razor"
using BlazorLearningServerApp.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 4 "C:\Users\vvgon\source\github\tech-i-know\dotnetdemos\blazor\blazorlearningserverapp\Pages\Index.razor"
       
    // simple string value can be added and displayed using c#
    private string msgStringOne = "Blazor";
    private string consoleMsg = "Hello Blazor World";

    // we can add some styling to this string using C#
    private string _stringFontStyle = "italic";
    private string _stringColor = "#ce9178";

    //console print test
    protected override void OnInitialized()
    {
        JSRuntime.InvokeAsync<string>("console.log", consoleMsg);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
