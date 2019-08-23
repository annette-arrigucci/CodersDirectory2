#pragma checksum "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\SearchResults.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2db4af8ca46ac4fe37d7d67e49c19595152ee94"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profiles_SearchResults), @"mvc.1.0.view", @"/Views/Profiles/SearchResults.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Profiles/SearchResults.cshtml", typeof(AspNetCore.Views_Profiles_SearchResults))]
namespace AspNetCore
{
    #line hidden
#line 8 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\_ViewImports.cshtml"
using CodersDirectory.Models.AdminViewModels;

#line default
#line hidden
#line 3 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\_ViewImports.cshtml"
using CodersDirectory.Models.AccountViewModels;

#line default
#line hidden
#line 4 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\_ViewImports.cshtml"
using CodersDirectory.Models.ManageViewModels;

#line default
#line hidden
#line 5 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\_ViewImports.cshtml"
using CodersDirectory.Models.ProfileViewModels;

#line default
#line hidden
#line 6 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\_ViewImports.cshtml"
using CodersDirectory.Models;

#line default
#line hidden
#line 7 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2db4af8ca46ac4fe37d7d67e49c19595152ee94", @"/Views/Profiles/SearchResults.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b84493a46768a4cc7f48769af53aea8fc624da3d", @"/Views/_ViewImports.cshtml")]
    public class Views_Profiles_SearchResults : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProfileSummaryViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\SearchResults.cshtml"
  
    ViewData["Title"] = "Search Results";

#line default
#line hidden
            BeginContext(88, 47, true);
            WriteLiteral("\r\n<h2 class=\"text-center\">Search Results</h2>\r\n");
            EndContext();
            BeginContext(136, 53, false);
#line 7 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\SearchResults.cshtml"
Write(Html.ActionLink("Search Again", "Search", "Profiles"));

#line default
#line hidden
            EndContext();
            BeginContext(189, 517, true);
            WriteLiteral(@"

<table class=""table"">
    <thead>
        <tr>
            <th style=""width: 20%;"">
                Name
            </th>
            <th style=""width: 25%;"">
                Languages/Frameworks
            </th>
            <th style=""width: 13.7%;"">
                City
            </th>
            <th style=""width: 13.7%;"">
                State
            </th>
            <th style=""width: 13.7%;"">
                Country
            </th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 30 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\SearchResults.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(755, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(815, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d745fc26e5b45f78490ce3f190fc565", async() => {
                BeginContext(864, 9, false);
#line 34 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\SearchResults.cshtml"
                                                               Write(item.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 34 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\SearchResults.cshtml"
                                              WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(877, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(945, 44, false);
#line 37 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\SearchResults.cshtml"
               Write(Html.DisplayFor(modelItem => item.Languages));

#line default
#line hidden
            EndContext();
            BeginContext(989, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1057, 39, false);
#line 40 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\SearchResults.cshtml"
               Write(Html.DisplayFor(modelItem => item.City));

#line default
#line hidden
            EndContext();
            BeginContext(1096, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1164, 40, false);
#line 43 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\SearchResults.cshtml"
               Write(Html.DisplayFor(modelItem => item.State));

#line default
#line hidden
            EndContext();
            BeginContext(1204, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1272, 42, false);
#line 46 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\SearchResults.cshtml"
               Write(Html.DisplayFor(modelItem => item.Country));

#line default
#line hidden
            EndContext();
            BeginContext(1314, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 49 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\SearchResults.cshtml"
        }

#line default
#line hidden
            BeginContext(1369, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProfileSummaryViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591