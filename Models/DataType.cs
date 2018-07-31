using System;

namespace Models
{
    public enum DataType
    {
        None = 0,
        String = 1,
        Number = 2,
        Integer = 4,
        DateTime = 8,
        Boolean = 16,
        LookupId = 32
    }
}