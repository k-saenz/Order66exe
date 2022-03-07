#pragma checksum "C:\Users\Kevin\source\repos\Order66exe v1.1\Views\Home\Info.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2193b7f4ea8add201377cd839a8055ee6d575dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Info), @"mvc.1.0.view", @"/Views/Home/Info.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Kevin\source\repos\Order66exe v1.1\Views\_ViewImports.cshtml"
using Order66exe;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kevin\source\repos\Order66exe v1.1\Views\_ViewImports.cshtml"
using Order66exe.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2193b7f4ea8add201377cd839a8055ee6d575dc", @"/Views/Home/Info.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99a1e691ab1c520caaa05cb2b53af55e60ce1481", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Info : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Discord.WebSocket.SocketRole>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Kevin\source\repos\Order66exe v1.1\Views\Home\Info.cshtml"
  
    ViewData["Title"] = "Server Rules";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Masthead-->
<header class=""masthead"" id=""infoMasthead"">
    <div class=""container px-4 px-lg-5 h-100"">
        <div class=""row gx-4 gx-lg-5 h-100 align-items-center justify-content-center text-center"">
            <div class=""col-lg-8 align-self-end"">
                <h1 class=""text-white font-weight-bold"">Server Info</h1>
                <hr class=""divider"" />
            </div>
            <div class=""col-lg-8 align-self-baseline"">
                <p class=""text-white-75 mb-5"">Find helpful information such as Server Rules, Role Duties and Perks, and other fun things</p>
            </div>
        </div>
    </div>
</header>

<!-- About Section-->
<section class=""page-section bg-primary"" id=""infoTitle"">
    <div class=""container px-4 px-lg-5"">
        <div class=""row gx-4 gx-lg-5 justify-content-center"">
            <div class=""col-lg-8 text-center"">
                <h2 class=""text-white mt-0"">Rules and Stuff</h2>
                <hr class=""divider divider-light"" />
                <p class=""text-white");
            WriteLiteral(@"-75 mb-4"">Before you join, we ask that you read and understand the rules you see here. We all want to have fun, but we also want to stay safe and not hurt anybody's feelings IRL</p>
            </div>
        </div>
    </div>
</section>

<!--Rules list-->

<div class=""accordion-container row align-items-center"">
    <div class=""col-lg-4 text-center card"">
        <div class=""card-body"">

            <h2 class=""text-black mt-0"" id=""RulesAndStuffHeader"">Rules and Stuff</h2>
            <hr class=""divider"" />
            <h4 class=""text-black-50 mt-0"" id=""RulesAndStuffInfo"">Select a topic to learn more</h4>
        </div>
    </div>
    <div class=""accordion accordion-flush col-lg-8"" id=""InfoAccordian"">
        <div class=""accordion-item"">
            <h2 class=""accordion-header"" id=""GeneralRulesHeading"">
                <button class=""accordion-button collapsed"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#GeneralRulesCollapse"" aria-expanded=""false"" aria-controls=""GeneralRulesCollapse"">
           ");
            WriteLiteral(@"         General Rules
                </button>
            </h2>

            <div id=""GeneralRulesCollapse"" class=""accordion-collapse collapse"" aria-labelledby=""GeneralRulesHeading"" data-bs-parent=""#InfoAccordian"">
                <div class=""accordion-body"">
                    <ol class=""list-group list-group-flush"">
                        <li class=""list-group-item"">Keep everything PG - bad words and other inappropriate language/content will be deleted and can lead to mute, kick, or ban</li>
                        <li class=""list-group-item"">No racism, discrimination, toxic behavior, or hate speech in any way, shape, or form</li>
                        <li class=""list-group-item"">No spamming, repetitive content, nor excessive pings</li>
                        <li class=""list-group-item"">Try to keep everything relevant to each channel topic. If the conversation shifts, don't worry too much about it but a mod might let everyone know if its too off-topic</li>
                        <li class=""list-gro");
            WriteLiteral(@"up-item"">Obey the staff</li>
                        <li class=""list-group-item"">Avoid inappropriate nicknames (mods or admins will determine this)</li>
                        <li class=""list-group-item"">No doxing, or gathering people's private information</li>
                        <li class=""list-group-item"">Try to avoid controversial issues (if they come up they will be dealt with accordingly)</li>
                        <li class=""list-group-item"">You don't have to be nice, just don't get personal (in other words, Its just a joke dude)</li>
                        <li class=""list-group-item"">If someone asks you to ""stop"", please do so</li>
                    </ol>
                </div>
            </div>
        </div>

        <div class=""accordion-item"">
            <h2 class=""accordion-header"" id=""VoiceRulesHeading"">
                <button class=""accordion-button collapsed"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#VoiceRulesCollapse"" aria-expanded=""false"" aria-controls=""VoiceRule");
            WriteLiteral(@"sCollapse"">
                    Voice Chat Rules
                </button>
            </h2>

            <div id=""VoiceRulesCollapse"" class=""accordion-collapse collapse"" aria-labelledby=""VoiceRulesHeading"" data-bs-parent=""#InfoAccordian"">
                <div class=""accordion-body"">
                    <ol class=""list-group list-group-flush"">
                        <li class=""list-group-item"">Unless everyone in the call is okay with it, please keep music in its respective channel</li>
                        <li class=""list-group-item"">Think before you <span class=""font-italic"">earrape</span> (aka being too loud). We don't have a problem with it for the most part, but it can get annoying if overdone</li>
                        <li class=""list-group-item"">Depending on the occasion, you and the participants in a call may want to turn on your cameras and/or share your screen. It is purely up to each individual to decide if they want to show their face or not, and what they want us to see on their screen</li>
");
            WriteLiteral(@"                    </ol>
                </div>
            </div>
        </div>

        <div class=""accordion-item"">
            <h2 class=""accordion-header"" id=""RolesHeading"">
                <button class=""accordion-button collapsed"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#RolesCollapse"" aria-expanded=""false"" aria-controls=""RolesCollapse"">
                    Server Roles
                </button>
            </h2>

            <div id=""RolesCollapse"" class=""accordion-collapse collapse"" aria-labelledby=""RolesHeading"" data-bs-parent=""#InfoAccordian"">
                <div class=""accordion-body"">
                    <ul>
");
#nullable restore
#line 99 "C:\Users\Kevin\source\repos\Order66exe v1.1\Views\Home\Info.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li class=\"list-group-item\"");
            BeginWriteAttribute("style", " style=\"", 5990, "\"", 6016, 2);
            WriteAttributeValue("", 5998, "color:", 5998, 6, true);
#nullable restore
#line 101 "C:\Users\Kevin\source\repos\Order66exe v1.1\Views\Home\Info.cshtml"
WriteAttributeValue(" ", 6004, item.Color, 6005, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 101 "C:\Users\Kevin\source\repos\Order66exe v1.1\Views\Home\Info.cshtml"
                                                                              Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n");
#nullable restore
#line 102 "C:\Users\Kevin\source\repos\Order66exe v1.1\Views\Home\Info.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\n\n                </div>\n            </div>\n        </div>\n    </div>\n</div>\n\n\n\n\n\n\n\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Discord.WebSocket.SocketRole>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
