namespace DSRNetSchool.Logger;

public interface ILogger
{
    void Debug(string message, params object[] propertyValues);
    void Error(string message, params object[] propertyValues);
    void Information(string message, params object[] propertyValues);
}
