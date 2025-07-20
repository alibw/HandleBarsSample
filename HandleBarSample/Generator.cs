using System.Text;

namespace HandleBarSample;

public class Generator
{
    public string GenerateWithSb(dynamic cfg)
    {
        var serverName = string.IsNullOrEmpty(cfg.Domain)
            ? cfg.Host
            : cfg.Domain;

        var sb = new StringBuilder();
        sb.AppendLine($"<VirtualHost *:{cfg.VHostPort}>");
        sb.AppendLine($"ServerName {serverName}");
        sb.Append("</VirtualHost>");
        return sb.ToString();
    }
}