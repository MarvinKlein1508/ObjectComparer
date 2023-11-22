using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.Tests.Models
{
    internal class TestModel
    {
        public string TestString { get; set; } = string.Empty;
        public string? TestStringNullable { get; set; }

        public int TestInt { get; set; }
        public int? TestIntNullable { get; set; } = null;

        public decimal TestDecimal { get; set; }
        public decimal? TestDecimalNullable { get; set; } = null;

        public float TestFloat { get; set; }
        public float? TestFloatNullable { get; set; }

        public double TestDouble { get; set; }
        public double? TestDoubleNullable { get; set; }

        public long TestLong { get; set; }
        public long? TestLongNullable { get; set; } = null;
        
        public short TestShort { get; set; }
        public short? TestShortNullable { get; set; } = null;

        public bool TestBoolean { get; set; }
        public bool? TestBooleanNullable { get; set; } = null;

        public byte TestByte { get; set; }
        public byte? TestByteNullable { get; set; } = null;

        public DateOnly TestDateOnly { get; set; } = DateOnly.FromDateTime(DateTime.Today.Date);
        public DateOnly? TestDateOnlyNullable { get; set; } = null;

        public TimeOnly TestTimeOnly { get; set; } = TimeOnly.FromDateTime(DateTime.Now);
        public TimeOnly? TestTimeOnlyNullable { get; set; } = null;

        public DateTime TestDatetime { get; set; } = DateTime.Today;
        public DateTime? TestDatetimeNullable { get; set; } = null;

        public Guid TestGuid { get; set; } = Guid.NewGuid();
        public Guid? TestGuidNullable { get; set; } = null;

        public List<string> TestListString { get; set; } = new();
        public List<string?> TestListStringNullable { get; set; } = new();

        public List<object> TestList { get; set; } = new();
        public List<object>? TestListNullable { get; set; } = null;

        public TestSubModel TestSubModel { get; set; } = new();
        public TestSubModel? TestSubModelNullable { get; set; } = null;


        public DayOfWeek TestEnum { get; set; } = DayOfWeek.Monday;
        public DayOfWeek? TestEnumNullable { get; set; } = null;

        public uint TestUInt { get; set; }
        public uint? TestUIntNullable { get; set; } = null;

        public ulong TestULong { get; set; }
        public uint? TestULongNullable { get; set; } = null;

        public ushort TestUShort { get; set; }
        public ushort? TestUShortNullable { get; set; } = null;

        public dynamic TestDynamic { get; set; } = string.Empty;
        public dynamic? TestDynamicNullable { get; set; } = null;

        public sbyte TestSByte { get; set; }
        public sbyte? TestSByteNullable { get; set; } = null;

        public char TestChar { get; set; } = 'A';
        public char? TestCharNullable { get; set; } = null;

        public nint TestNInt { get; set; }
        public nint? TestNIntNullable { get; set; } = null;

        public nuint TestNUInt { get; set; }
        public nuint? TestNUIntNullable { get; set; } = null;

    }
}
