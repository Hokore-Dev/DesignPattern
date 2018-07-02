using System;
using System.Collections.Generic;

namespace Prototype
{
    public enum ERecordType
    {
        Car,
        Person,
    }

    public abstract class Record
    {
        public abstract Record Clone();
    }

    public class PersonRecord : Record
    {
        string name;
        int age;

        public override Record Clone()
        {
            return (Record)this.MemberwiseClone();
        }
    }

    public class CarRecord : Record
    {
        string carname;
        Guid id;

        public override Record Clone()
        {
            CarRecord clone = (CarRecord)this.MemberwiseClone();
            clone.id = Guid.NewGuid();
            return clone;
        }
    }

    public class RecordFactory
    {
        private static Dictionary<ERecordType, Record> _prototypes =
            new Dictionary<ERecordType, Record>();

        public RecordFactory()
        {
            _prototypes.Add(ERecordType.Car, new CarRecord());
            _prototypes.Add(ERecordType.Person, new PersonRecord());
        }

        public Record CreateRecord(ERecordType type)
        {
            return _prototypes[type].Clone();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
