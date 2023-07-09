using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnumerationDemo
{
    public abstract class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>> where TEnum : Enumeration<TEnum>
    {
        private static readonly Type _enumType = typeof(TEnum);

        private static readonly Dictionary<int, TEnum?> _enumerations = GetEnumerations();

        public int Value { get; protected init; }

        public string Name { get; protected init; }
        protected Enumeration(int value, string name) { Value = value; Name = name; }

        public static TEnum? FromName(string name) => _enumerations.Values.SingleOrDefault(x => x.Name == name);

        public static TEnum? FromValue(int value) => _enumerations.TryGetValue(value, out var result) ? result : default;

        private static Dictionary<int, TEnum?> GetEnumerations() => _enumType
        .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
        .Where(x => _enumType.IsAssignableFrom(x.FieldType))//满足此条件，说明x的类型与TType相同
        .Select(x => (TEnum?)x.GetValue(default)).ToDictionary(x => x?.Value ?? 0);//将x转化为TEnum类型并转为字典

        public bool Equals(Enumeration<TEnum>? other) => other is not null && GetType() == other.GetType() && other.Value == Value;

        public override bool Equals(object? obj) => obj is Enumeration<TEnum> other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Value, Name);

    }
}
