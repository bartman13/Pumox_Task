using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PumoxBackend.Models
{
    public enum JobTitle
    {
        [EnumMember(Value = "Administrator")]
        Administrator,
        [EnumMember(Value = "Developer")]
        Developer,
        [EnumMember(Value = "Architect")]
        Architect,
        [EnumMember(Value = "Manager")]
        Manager
    }
}
