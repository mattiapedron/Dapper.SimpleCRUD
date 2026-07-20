using System;
using System.Data;

namespace Dapper.SimpleCRUDTests;

public readonly record struct OfficeId(int Id) : IConvertible
{
    TypeCode IConvertible.GetTypeCode() => TypeCode.Int32;
    bool IConvertible.ToBoolean(IFormatProvider provider) => throw new InvalidCastException();
    byte IConvertible.ToByte(IFormatProvider provider) => throw new InvalidCastException();
    char IConvertible.ToChar(IFormatProvider provider) => throw new InvalidCastException();
    DateTime IConvertible.ToDateTime(IFormatProvider provider) => throw new InvalidCastException();
    decimal IConvertible.ToDecimal(IFormatProvider provider) => Id;
    double IConvertible.ToDouble(IFormatProvider provider) => Id;
    short IConvertible.ToInt16(IFormatProvider provider) => throw new InvalidCastException();
    int IConvertible.ToInt32(IFormatProvider provider) => Id;
    long IConvertible.ToInt64(IFormatProvider provider) => Id;
    sbyte IConvertible.ToSByte(IFormatProvider provider) => throw new InvalidCastException();
    float IConvertible.ToSingle(IFormatProvider provider) => Id;
    string IConvertible.ToString(IFormatProvider provider) => Id.ToString();
    object IConvertible.ToType(Type conversionType, IFormatProvider provider) => throw new NotImplementedException();
    ushort IConvertible.ToUInt16(IFormatProvider provider) => throw new InvalidCastException();
    uint IConvertible.ToUInt32(IFormatProvider provider) => (uint)Id;
    ulong IConvertible.ToUInt64(IFormatProvider provider) => (ulong)Id;

    public class MapperTypeHandler : Dapper.SqlMapper.TypeHandler<OfficeId>
    {
        public override OfficeId Parse(object value)
        {
            if (value is null || value is DBNull) throw new InvalidOperationException($"Cannot parse a null value as OfficeId");
            return new OfficeId(Convert.ToInt32(value));
        }

        public override void SetValue(IDbDataParameter parameter, OfficeId entityId)
        {
            parameter.DbType = DbType.Int32;
            parameter.Value = entityId.Id;
        }
    }
}
