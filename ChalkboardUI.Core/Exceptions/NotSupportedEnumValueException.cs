namespace ChalkboardUI
{
    public class NotSupportedEnumValueException<TEnum> : Exception
        where TEnum : Enum
    {
        public NotSupportedEnumValueException(TEnum value)
            : base($"Not supported {typeof(TEnum).Name} enum value: {value}")
        {
        }
    }
}