using NetEscapades.AspNetCore.SecurityHeaders.Headers.ContentSecurityPolicy;
using SampleMvc.Models;

namespace SampleMvc.Extensions;

public static class ContentSecurityPolicyExtensions
{
    public static StyleSourceDirectiveBuilder WithStyleHashes(
        this StyleSourceDirectiveBuilder builder, 
        ContentSecurityPolicySettings contentSecurityPolicySettings)
    {
        foreach (var hash in contentSecurityPolicySettings.StyleHashes)
        {
            builder.WithHash256(hash);
        }
        return builder;
    }
    
    public static ScriptSourceDirectiveBuilder WithScriptHashes(
        this ScriptSourceDirectiveBuilder builder, 
        ContentSecurityPolicySettings contentSecurityPolicySettings)
    {
        foreach (var hash in contentSecurityPolicySettings.ScriptHashes)
        {
            builder.WithHash256(hash);
        }
        return builder;
    }
}