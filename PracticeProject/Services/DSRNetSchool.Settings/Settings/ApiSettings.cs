namespace DSRNetSchool.Settings;

public class ApiSettings : IApiSettings
{
    private readonly ISettingsSource source;
    private readonly IIdentityServerSettings identityServerSettings;

    public ApiSettings(ISettingsSource source) => this.source = source;

    public ApiSettings(ISettingsSource source, IIdentityServerSettings identityServerSettings)
    {
        this.source = source;
        this.identityServerSettings = identityServerSettings;
    }

    public IIdentityServerSettings IdentityServer => identityServerSettings ?? new IdentityServerSettings(source);
}
