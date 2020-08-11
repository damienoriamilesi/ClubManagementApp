﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace ClubManagementApp.Domain.Aggregates
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        // EF requires a paramterless ctor
        protected Entity() {        }

        protected Entity(TId id)
        {
            if(Equals(id, default(TId)))
            {
                throw new ArgumentException("The ID cannot be the type's default value", "id");
            }
             Id = id;
        }

        public TId Id { get; protected set; }

        public bool Equals([AllowNull] Entity<TId> other)
        {
            if (other == null) return false;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object otherObject)
        {
            var entity = otherObject as Entity<TId>;
            if (entity != null)
            {
                return Equals(entity);
            }
            return base.Equals(otherObject);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}