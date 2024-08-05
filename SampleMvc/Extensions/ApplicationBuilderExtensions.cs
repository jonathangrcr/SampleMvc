using Microsoft.Extensions.Options;
using SampleMvc.Models;

namespace SampleMvc.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseNonDevelopmentSecurityHeaders(this IApplicationBuilder app, 
        ContentSecurityPolicySettings contentSecurityPolicySettings)
    {
        var policies = new HeaderPolicyCollection()
            .AddDefaultSecurityHeaders()
            .AddContentSecurityPolicy(policy =>
            {
                policy.AddDefaultSrc().Self();
                policy.AddImgSrc().Self().Data();
                policy.AddStyleSrc()
                    .Self()
                    .WithStyleHashes(contentSecurityPolicySettings)
                    .UnsafeHashes();
                policy.AddScriptSrc()
                    .Self()
                    .WithScriptHashes(contentSecurityPolicySettings)
                    .UnsafeEval();
            })
            .AddCrossOriginResourcePolicy(policy =>
            {
                policy.SameOrigin();
            })
            .AddCustomHeader("Pragma", "no-cache");
        app.UseSecurityHeaders(policies);
        return app;
    }

    public static IApplicationBuilder UseDevelopmentSecurityHeaders(this IApplicationBuilder app, 
        ContentSecurityPolicySettings contentSecurityPolicySettings)
    {
        var policies = new HeaderPolicyCollection()
            .AddFrameOptionsDeny()
            .AddXssProtectionBlock()
            .AddContentTypeOptionsNoSniff()
            .AddReferrerPolicyStrictOriginWhenCrossOrigin()
            .AddContentSecurityPolicy(policy =>
            {
                policy.AddDefaultSrc().Self();
                policy.AddImgSrc().Self().Data();
                policy.AddStyleSrc()
                    .Self()
                    .WithStyleHashes(contentSecurityPolicySettings)
                    .UnsafeHashes();
                policy.AddScriptSrc()
                    .Self()
                    .WithScriptHashes(contentSecurityPolicySettings)
                    .UnsafeEval();
            })
            .AddCrossOriginResourcePolicy(policy =>
            {
                policy.SameOrigin();
            })
            .AddCustomHeader("Pragma", "no-cache");
        app.UseSecurityHeaders(policies);
        return app;
    }
}