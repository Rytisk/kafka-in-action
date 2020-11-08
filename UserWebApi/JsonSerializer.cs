using System;
using System.Text.Json;
using Confluent.Kafka;

namespace UserWebApi
{
    public class JsonSerializer<T> : ISerializer<T>
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            return data == null
                ? null
                : JsonSerializer.SerializeToUtf8Bytes<T>(data);
        }
    }
}
