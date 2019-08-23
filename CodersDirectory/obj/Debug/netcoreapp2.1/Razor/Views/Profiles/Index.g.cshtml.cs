#pragma checksum "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59da2bdf48050be72d35e30d40d8382dfbac476e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profiles_Index), @"mvc.1.0.view", @"/Views/Profiles/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Profiles/Index.cshtml", typeof(AspNetCore.Views_Profiles_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59da2bdf48050be72d35e30d40d8382dfbac476e", @"/Views/Profiles/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b84493a46768a4cc7f48769af53aea8fc624da3d", @"/Views/_ViewImports.cshtml")]
    public class Views_Profiles_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProfileIndexViewModel>
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
            BeginContext(30, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
            BeginContext(77, 127, true);
            WriteLiteral("\r\n<h2 class=\"text-center\">Welcome to Coders Directory</h2>\r\n<h3 class=\"text-center\">Announcements</h3>\r\n<p class=\"text-center\">");
            EndContext();
            BeginContext(205, 18, false);
#line 9 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
                  Write(Model.Announcement);

#line default
#line hidden
            EndContext();
            BeginContext(223, 10, true);
            WriteLiteral("</p>\r\n\r\n\r\n");
            EndContext();
#line 12 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
 if (User.IsInRole("NewUser"))
{

#line default
#line hidden
            BeginContext(268, 132, true);
            WriteLiteral("    <h3 class=\"text-center\">New Users</h3>\r\n    <p>Before you can view other member profiles, you must</p>\r\n    <ul>\r\n        <li>\r\n");
            EndContext();
#line 18 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
         if (Model.EmailVerified == true)
        {
           

#line default
#line hidden
            BeginContext(466, 32, false);
#line 20 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
      Write(Html.Raw("Verify your email - "));

#line default
#line hidden
            EndContext();
            BeginContext(498, 46, true);
            WriteLiteral("<span style=\"color: green;\">Completed</span>\r\n");
            EndContext();
#line 21 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
        }
        else
        {
           

#line default
#line hidden
            BeginContext(592, 42, false);
#line 24 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
      Write(Html.Raw("Verify your email - Go to the "));

#line default
#line hidden
            EndContext();
            BeginContext(648, 52, false);
#line 25 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
      Write(Html.ActionLink("Manage Account", "Index", "Manage"));

#line default
#line hidden
            EndContext();
            BeginContext(714, 47, false);
#line 26 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
      Write(Html.Raw(" page to send a confirmation email."));

#line default
#line hidden
            EndContext();
#line 26 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
                                                           
        }

#line default
#line hidden
            BeginContext(774, 29, true);
            WriteLiteral("        </li>\r\n        <li>\r\n");
            EndContext();
#line 30 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
          if (Model.ProfileCreated == true)
         {
             

#line default
#line hidden
            BeginContext(874, 34, false);
#line 32 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
        Write(Html.Raw("Create your profile - "));

#line default
#line hidden
            EndContext();
            BeginContext(908, 46, true);
            WriteLiteral("<span style=\"color: green;\">Completed</span>\r\n");
            EndContext();
#line 33 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
         }
         else
         {
             

#line default
#line hidden
            BeginContext(1007, 69, false);
#line 36 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
        Write(Html.ActionLink("Create and save your profile", "Create", "Profiles"));

#line default
#line hidden
            EndContext();
#line 36 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
                                                                                   
         }

#line default
#line hidden
            BeginContext(1090, 303, true);
            WriteLiteral(@"        </li>
    </ul>
    <p>Once you have completed those two steps, an administrator will review your account. If approved, your profile will be published on the site and you will be able to search other user profiles.</p>
    <p>If your account is not approved within five business days, please ");
            EndContext();
            BeginContext(1394, 46, false);
#line 41 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
                                                                    Write(Html.ActionLink("contact us", "About", "Home"));

#line default
#line hidden
            EndContext();
            BeginContext(1440, 7, true);
            WriteLiteral(".</p>\r\n");
            EndContext();
#line 42 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
}
else if(User.IsInRole("Admins") || User.IsInRole("ApprovedUser"))
{

#line default
#line hidden
            BeginContext(1520, 571, true);
            WriteLiteral(@"<h3 class=""text-center"">New Members/Recently Updated</h3>
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
#line 67 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
         if (Model.RecentProfiles == null || Model.RecentProfiles.Count() == 0)
        {

#line default
#line hidden
            BeginContext(2183, 62, true);
            WriteLiteral("            <tr><td>No recent profiles to display.</td></tr>\r\n");
            EndContext();
#line 70 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
        }
        else
        {
        

#line default
#line hidden
#line 73 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
         foreach (var item in Model.RecentProfiles)
        {

#line default
#line hidden
            BeginContext(2345, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2405, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a2ea002d43344c09fe684d72c255b71", async() => {
                BeginContext(2454, 9, false);
#line 77 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
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
#line 77 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
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
            BeginContext(2467, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2535, 44, false);
#line 80 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Languages));

#line default
#line hidden
            EndContext();
            BeginContext(2579, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2647, 39, false);
#line 83 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.City));

#line default
#line hidden
            EndContext();
            BeginContext(2686, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2754, 40, false);
#line 86 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.State));

#line default
#line hidden
            EndContext();
            BeginContext(2794, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2862, 42, false);
#line 89 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Country));

#line default
#line hidden
            EndContext();
            BeginContext(2904, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 92 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
        }

#line default
#line hidden
#line 92 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
         
        }

#line default
#line hidden
            BeginContext(2970, 590, true);
            WriteLiteral(@"        </tbody>
 </table>
<h3 class=""text-center"">Favorite Profiles</h3>
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
#line 118 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
     if (Model.FavoriteProfiles == null || Model.FavoriteProfiles.Count() == 0)
    {

#line default
#line hidden
            BeginContext(3648, 60, true);
            WriteLiteral("        <tr><td>No favorite profiles to display.</td></tr>\r\n");
            EndContext();
#line 121 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
    }
    else
    {
        

#line default
#line hidden
#line 124 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
         foreach (var item in Model.FavoriteProfiles)
        {

#line default
#line hidden
            BeginContext(3798, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3858, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc147ff8a126479597ed886a86cdf774", async() => {
                BeginContext(3907, 9, false);
#line 128 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
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
#line 128 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
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
            BeginContext(3920, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3988, 44, false);
#line 131 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Languages));

#line default
#line hidden
            EndContext();
            BeginContext(4032, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(4100, 39, false);
#line 134 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.City));

#line default
#line hidden
            EndContext();
            BeginContext(4139, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(4207, 40, false);
#line 137 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.State));

#line default
#line hidden
            EndContext();
            BeginContext(4247, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(4315, 42, false);
#line 140 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Country));

#line default
#line hidden
            EndContext();
            BeginContext(4357, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 143 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
        }

#line default
#line hidden
#line 143 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
         
    }

#line default
#line hidden
            BeginContext(4419, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
#line 147 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(4455, 82, true);
            WriteLiteral("    <h3 class=\"text-center\">Account Error</h3>\r\n    <p class=\"text-center\">Please ");
            EndContext();
            BeginContext(4538, 59, false);
#line 151 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
                             Write(Html.ActionLink("contact an adminstrator", "About", "Home"));

#line default
#line hidden
            EndContext();
            BeginContext(4597, 26, true);
            WriteLiteral(" about your account.</p>\r\n");
            EndContext();
#line 152 "C:\Users\Me\projects\CodersDirectory\CodersDirectory\Views\Profiles\Index.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProfileIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591