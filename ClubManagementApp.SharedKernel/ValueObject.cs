using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
 
namespace ClubManagementApp.SharedKernel
{
    public class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;  

            T other = obj as T;
            return Equals(other);
        }

        //public override int GetHashCode()
        //{
        //    //IEnumerable<FieldInfo> fields = GetFields();
        //}

        private IEnumerable<FieldInfo> GetFields()
        {
            throw new NotImplementedException();
        }

        public bool Equals([AllowNull] T other)
        {
            throw new NotImplementedException();
        }
    }
}
