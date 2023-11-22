namespace ObjectComparer
{
    /// <summary>
    /// Apply this attribute to properties which should not be checked for any modifications
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class IgnoreModificationCheckAttribute : Attribute
    {
    }
}
