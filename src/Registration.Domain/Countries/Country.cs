using System;
using System.Collections.Generic;
using System.Text;
using Registration.Domain.SeedWork;

namespace Registration.Domain.Countries
{
    public class Country : Entity, IAggregateRoot
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int? ParentId { get; private set; }

        public bool IsProvice => this.ParentId == null;

        private Country()
        {

        }

        public Country(string name)
        {
            Name = name;
        }

        public Country(string name, int id)
            : this(name)
        {
            Id = id;
        }

        public Country(string name, int id, int? parentId)
            : this(name, id)
        {
            ParentId = parentId;
        }
    }
}
