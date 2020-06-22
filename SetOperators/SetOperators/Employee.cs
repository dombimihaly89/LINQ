using System;
using System.Collections.Generic;
using System.Text;

namespace SetOperators
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null) return false;
        //    if (!(obj is Employee)) return false;
        //    return this.ID == ((Employee)obj).ID && this.Name == ((Employee)obj).Name;
        //}

        //public override int GetHashCode()
        //{
        //    return this.ID.GetHashCode() ^ this.Name.GetHashCode();
        //}

    }
}
