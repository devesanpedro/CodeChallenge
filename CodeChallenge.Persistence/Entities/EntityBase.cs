using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Persistence.Entities
{
    public abstract class EntityBase<TIdentifier> : IEntity<TIdentifier>
    {
        public TIdentifier Id { get; set; }
    }
}
