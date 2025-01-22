using System.Text.Json.Serialization;

namespace SFA.DAS.AODP.Domain.Interfaces;

public interface IPatchApiRequest<TData> : IBaseApiRequest
{
    [JsonIgnore]
    string PatchUrl { get; }

    TData Data { get; set; }
}