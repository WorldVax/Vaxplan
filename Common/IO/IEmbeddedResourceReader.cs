namespace Vaxplan.Common.IO
{
    public interface IEmbeddedResourceReader
    {
        T Read<T>(string pattern);
    }
}
