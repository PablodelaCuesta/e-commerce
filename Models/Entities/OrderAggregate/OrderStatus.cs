using System.Runtime.Serialization;

namespace Models.Entities
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "PaymentRecevied")]
        PaymentRecevied,
        [EnumMember(Value = "PaymentFailed")]
        PaymentFailed

    }
}
