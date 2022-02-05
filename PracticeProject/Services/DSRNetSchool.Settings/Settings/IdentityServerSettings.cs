namespace DSRNetSchool.Settings;

public class IdentityServerSettings : IIdentityServerSettings
{
    private readonly ISettingsSource source;
    public IdentityServerSettings(ISettingsSource source) => this.source = source;

    public string Url => source.GetAsString("IdentityServer:Url");
    public string ClientId => source.GetAsString("IdentityServer:ClientId");
    public string ClientSecret => source.GetAsString("IdentityServer:ClientSecret");
}
