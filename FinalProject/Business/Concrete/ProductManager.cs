﻿using Business.Abstract;
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

		public List<Product> GetAll()
		{
			//İş kodları
			return _productDal.GetAll();
		}

		public void Add(Product product)
		{
			throw new NotImplementedException();
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

		public List<Product> GetAllByCategoryId(int id)
		{
			return _productDal.GetAll(p => p.CategoryID == id);
		}

		public List<Product> GetByUnitPrice(decimal min, decimal max)
		{
			return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
		}

		public List<ProductDetailDto> GetProductDetails()
		{
			return _productDal.GetProductDetails();
		}
	}
}
