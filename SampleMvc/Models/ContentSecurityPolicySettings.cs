namespace SampleMvc.Models;

public class ContentSecurityPolicySettings
{
    public List<string> StyleHashes { get; set; } = [];
    public List<string> ScriptHashes { get; set; } = [];
}