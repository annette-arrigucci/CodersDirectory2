#pragma checksum "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Manage\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b883c03952f3a575ac219fd5705d305dcce7ef0c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manage_Index), @"mvc.1.0.view", @"/Views/Manage/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Manage/Index.cshtml", typeof(AspNetCore.Views_Manage_Index))]
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
#line 1 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Manage\_ViewImports.cshtml"
using CodersDirectory.Views.Manage;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b883c03952f3a575ac219fd5705d305dcce7ef0c", @"/Views/Manage/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b84493a46768a4cc7f48769af53aea8fc624da3d", @"/Views/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24268b3254176d70443d1fb70d0ce3a89ca5e07c", @"/Views/Manage/_ViewImports.cshtml")]
    public class Views_Manage_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SendVerificationEmail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Manage\Index.cshtml"
  
    ViewData["Title"] = "Profile";
    ViewData.AddActivePage(ManageNavPages.Index);

#line default
#line hidden
            BeginContext(117, 6, true);
            WriteLiteral("\r\n<h4>");
            EndContext();
            BeginContext(124, 17, false);
#line 7 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Manage\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(141, 7, true);
            WriteLiteral("</h4>\r\n");
            EndContext();
            BeginContext(149, 51, false);
#line 8 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Manage\Index.cshtml"
Write(Html.Partial("_StatusMessage", Model.StatusMessage));

#line default
#line hidden
            EndContext();
            BeginContext(200, 61, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n            ");
            EndContext();
            BeginContext(261, 60, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f30568e2c1e4fb6be76ff568035404e", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 11 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Manage\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(321, 204, true);
            WriteLiteral("\r\n            <div class=\"form-group\">\r\n                <label>Username</label>\r\n                <br />\r\n                <!--<input asp-for=\"Username\" class=\"form-control\" disabled />-->\r\n                ");
            EndContext();
            BeginContext(526, 24, false);
#line 16 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Manage\Index.cshtml"
           Write(Html.Raw(Model.Username));

#line default
#line hidden
            EndContext();
            BeginContext(550, 122, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label>Email</label>\r\n                <br />\r\n");
            EndContext();
#line 21 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Manage\Index.cshtml"
                 if (Model.IsEmailConfirmed)
                {

#line default
#line hidden
            BeginContext(737, 71, true);
            WriteLiteral("                    <div class=\"input-group\">\r\n                        ");
            EndContext();
            BeginContext(809, 21, false);
#line 24 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Manage\Index.cshtml"
                   Write(Html.Raw(Model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(830, 171, true);
            WriteLiteral("\r\n                        <span class=\"input-group-addon\" aria-hidden=\"true\"><span class=\"glyphicon glyphicon-ok text-success\"></span></span>\r\n                    </div>\r\n");
            EndContext();
#line 27 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Manage\Index.cshtml"
                }
                else
                {
                    

#line default
#line hidden
            BeginContext(1082, 21, false);
#line 30 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Manage\Index.cshtml"
               Write(Html.Raw(Model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1105, 48, true);
            WriteLiteral("                    <br />\r\n                    ");
            EndContext();
            BeginContext(1153, 349, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eba200c75c664dd4a0d00466c7c28b76", async() => {
                BeginContext(1232, 62, true);
                WriteLiteral("\r\n                        <input type=\"hidden\" name=\"verEmail\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1294, "\"", 1314, 1);
#line 33 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Manage\Index.cshtml"
WriteAttributeValue("", 1302, Model.Email, 1302, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1315, 180, true);
                WriteLiteral(" />\r\n                        <input type=\"submit\" class=\"btn btn-default\" style=\"margin-top: 10px;\" name=\"SendVerification\" value=\"Send verification email\" />\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1502, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 36 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Manage\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(1523, 44, true);
            WriteLiteral("                </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
