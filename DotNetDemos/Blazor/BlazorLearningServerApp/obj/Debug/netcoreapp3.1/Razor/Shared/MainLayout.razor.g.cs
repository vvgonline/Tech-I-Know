#pragma checksum "C:\Users\vvgon\source\repos\Tech-I-Know\DotNetDemos\Blazor\BlazorLearningServerApp\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf15a1e6eff93cebe6874a913c9873fb3776a68c"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorLearningServerApp.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\vvgon\source\repos\Tech-I-Know\DotNetDemos\Blazor\BlazorLearningServerApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vvgon\source\repos\Tech-I-Know\DotNetDemos\Blazor\BlazorLearningServerApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\vvgon\source\repos\Tech-I-Know\DotNetDemos\Blazor\BlazorLearningServerApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\vvgon\source\repos\Tech-I-Know\DotNetDemos\Blazor\BlazorLearningServerApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\vvgon\source\repos\Tech-I-Know\DotNetDemos\Blazor\BlazorLearningServerApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\vvgon\source\repos\Tech-I-Know\DotNetDemos\Blazor\BlazorLearningServerApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\vvgon\source\repos\Tech-I-Know\DotNetDemos\Blazor\BlazorLearningServerApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\vvgon\source\repos\Tech-I-Know\DotNetDemos\Blazor\BlazorLearningServerApp\_Imports.razor"
using BlazorLearningServerApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\vvgon\source\repos\Tech-I-Know\DotNetDemos\Blazor\BlazorLearningServerApp\_Imports.razor"
using BlazorLearningServerApp.Shared;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "main");
            __builder.AddAttribute(1, "role", "main");
            __builder.AddAttribute(2, "class", "container-fluid");
            __builder.AddMarkupContent(3, "\r\n    ");
            __builder.AddMarkupContent(4, @"<header>
        <nav class=""navbar navbar-expand navbar-dark bg-dark"">
            <a class=""navbar-brand"" href=""/"">Blazor-Server-Side-Learning-App</a>
            <button class=""navbar-toggler"" aria-expanded=""false"" aria-controls=""navbarsExample02"" aria-label=""Toggle navigation"" type=""button"" data-toggle=""collapse"" data-target=""#navbarsExample02"">
                <span class=""navbar-toggler-icon""></span>
            </button>

            <div class=""collapse navbar-collapse"" id=""navbarsExample02"">
                <ul class=""navbar-nav mr-auto"">
                    <li class=""nav-item"">
                        <a class=""nav-link active"" href=""about"">
                            About
                            <span class=""sr-only"">(current)</span>
                        </a>
                    </li>
                </ul>
                <form class=""form-inline my-2 my-md-0"">
                    <input class=""form-control"" type=""text"" placeholder=""Search"">
                </form>
            </div>
        </nav>
    </header>
    <br><p></p><br>
    ");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "container");
            __builder.AddMarkupContent(7, "\r\n        ");
            __builder.AddContent(8, 
#nullable restore
#line 28 "C:\Users\vvgon\source\repos\Tech-I-Know\DotNetDemos\Blazor\BlazorLearningServerApp\Shared\MainLayout.razor"
         Body

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(9, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n    <br><p></p><br>\r\n    ");
            __builder.OpenElement(11, "footer");
            __builder.AddAttribute(12, "class", "text-center");
            __builder.AddMarkupContent(13, "\r\n        ");
            __builder.OpenElement(14, "p");
            __builder.AddContent(15, "© ");
            __builder.AddContent(16, 
#nullable restore
#line 32 "C:\Users\vvgon\source\repos\Tech-I-Know\DotNetDemos\Blazor\BlazorLearningServerApp\Shared\MainLayout.razor"
                        DateTime.Now.Year.ToString()

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(17, "\r\n            ");
            __builder.AddMarkupContent(18, "<a href=\"https://Vvgonline.net\" target=\"_blank\">\r\n                Vvgonline.net\r\n            </a>\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
