using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Bannerlord.EditingTools.Utilities {
	public static class ReflectionUtility {
		public static PropertyInfo GetInstanceProperty<T>(T instance, string propertyName) {
			return typeof(T).GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		public static object GetPropertyValue<T>(T instance, string propertyName) {
			var propertyInfo = GetInstanceProperty<T>(instance, propertyName);
			return propertyInfo.GetValue(instance);
		}

		public static FieldInfo GetInstanceField<T>(T instance, string fieldName) {
			return typeof(T).GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		public static object GetFieldValue<T>(T instance, string fieldName) {
			var fieldInfo = GetInstanceField<T>(instance, fieldName);
			return fieldInfo.GetValue(instance);
		}

		public static MethodInfo GetInstanceMethodInfo<T>(T instance, string methodName) {
			return typeof(T).GetMethod(methodName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}
	}
}
