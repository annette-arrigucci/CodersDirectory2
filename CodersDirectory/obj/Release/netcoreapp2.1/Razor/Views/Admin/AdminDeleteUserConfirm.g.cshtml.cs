#pragma checksum "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Admin\AdminDeleteUserConfirm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ad359a1e62523614d60cb66866116f6162fa180"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AdminDeleteUserConfirm), @"mvc.1.0.view", @"/Views/Admin/AdminDeleteUserConfirm.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/AdminDeleteUserConfirm.cshtml", typeof(AspNetCore.Views_Admin_AdminDeleteUserConfirm))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ad359a1e62523614d60cb66866116f6162fa180", @"/Views/Admin/AdminDeleteUserConfirm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b84493a46768a4cc7f48769af53aea8fc624da3d", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AdminDeleteUserConfirm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AdminDeleteUserViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AdminDeleteUserConfirmPost", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Admin\AdminDeleteUserConfirm.cshtml"
  
    ViewData["Title"] = "Confirm Delete User";

#line default
#line hidden
            BeginContext(88, 148, true);
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-md-4 col-md-offset-4\">\r\n        <h2>Confirm Delete</h2>\r\n        <p>Are you sure you want to delete the user ");
            EndContext();
            BeginContext(237, 14, false);
#line 8 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Admin\AdminDeleteUserConfirm.cshtml"
                                               Write(Model.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(251, 16, true);
            WriteLiteral(" ?</p>\r\n        ");
            EndContext();
            BeginContext(267, 420, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "05799977feaf4849bd06d96ca9b96136", async() => {
                BeginContext(350, 48, true);
                WriteLiteral("\r\n            <input type=\"hidden\" name=\"userId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 398, "\"", 419, 1);
#line 10 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Admin\AdminDeleteUserConfirm.cshtml"
WriteAttributeValue("", 406, Model.UserId, 406, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(420, 191, true);
                WriteLiteral(" />\r\n            <input type=\"submit\" value=\"Yes\" class=\"btn btn-danger\" style=\"width: 100px;\" />\r\n            <input type=\"button\" class=\"btn btn-default\" value=\"Cancel\" style=\"width:100px;\"");
                EndContext();
                BeginWriteAttribute("onclick", " onclick=\"", 611, "\"", 666, 3);
                WriteAttributeValue("", 621, "location.href=\'", 621, 15, true);
#line 12 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Admin\AdminDeleteUserConfirm.cshtml"
WriteAttributeValue("", 636, Url.Action("Index", "Admin"), 636, 29, false);

#line default
#line hidden
                WriteAttributeValue("", 665, "\'", 665, 1, true);
                EndWriteAttribute();
                BeginContext(667, 13, true);
                WriteLiteral(" />\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(687, 22, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AdminDeleteUserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
