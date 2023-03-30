using System.Runtime.Serialization;

namespace Infrastructure.Exceptions;

[Serializable]
public class NotFoundDataException : Exception
{
    public NotFoundDataException(string key) : base($"Not found item {key} by search key")
    {
    }

    protected NotFoundDataException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(
        serializationInfo, streamingContext)
    {
    }
}