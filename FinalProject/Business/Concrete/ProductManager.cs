using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public IDataResult <List<Product>> GetAll()
		{
			//İş kodları
			if (DateTime.Now.Hour == 11)
			{
				return new ErrorDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
			}

			return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
		}

		public IResult Add(Product product)
		{
			if (product.ProductName.Length<2)
			{
				return new ErrorResult(Messages.ProductNameInvalid);
			}
			_productDal.Add(product);

			return new SuccessResult(Messages.ProductAdded);
		}

		public void Delete(Product product)
		{
			throw new NotImplementedException();
		}

		public List<Product> GetAllByCategory(int categoryId)
		{
			throw new NotImplementedException();
		}

		public void Update(Product product)
		{
			throw new NotImplementedException();
		}

		public IDataResult <List<Product>> GetAllByCategoryId(int id)
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryID == id));
		}

		public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
		}

		public IDataResult<List<ProductDetailDto>> GetProductDetails()
		{
			return new SuccessDataResult<List<ProductDetailDto>> (_productDal.GetProductDetails());
		}

		public IDataResult<Product> GetById(int productId)
		{
			return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == productId));
		}
	}
}
