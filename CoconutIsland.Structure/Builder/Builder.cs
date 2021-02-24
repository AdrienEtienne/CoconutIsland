using System;
using System.Data;
using FluentValidation;

namespace CoconutIsland.Structure.Builder
{
    public abstract class Builder<T> where T : Product
    {
        protected Builder(T product)
        {
            this.Product = product;
        }


        protected T Product { get; set; }

        protected abstract AbstractValidator<T> GetValidator();


        internal T GetProduct()
        {
            if ( this.Product == null ) throw new NoNullAllowedException("Part is currently null.");

            var validator = this.GetValidator();
            var validationResult = validator.Validate(this.Product);
            if ( !validationResult.IsValid ) throw new Exception("Part not valid.");

            return this.Product;
        }
    }
}