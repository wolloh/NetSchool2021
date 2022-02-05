namespace DSRNetSchool.Settings;

public interface IIdentityServerSettings
{
    string Url { get; }
    string ClientId { get; }
    string ClientSecret { get; }
}
