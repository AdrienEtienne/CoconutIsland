using System;
using System.Data;
using FluentValidation;

namespace CoconutIsland.Structure.Builder
{
    public abstract class Builder<T> where T : Product
    {
        protected Builder(T product)
        {
            Product = product;
        }

        protected T Product { get; set; }

        protected abstract AbstractValidator<T> GetValidator();

        internal T GetProduct()
        {
            if (Product == null) throw new NoNullAllowedException("Part is currently null.");

            var validator = GetValidator();
            var validationResult = validator.Validate(Product);
            if (!validationResult.IsValid) throw new Exception("Part not valid.");

            return Product;
        }
    }
}