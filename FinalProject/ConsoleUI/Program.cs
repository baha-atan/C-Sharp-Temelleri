﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			//DTOs : Data Transformation Object
			ProdcutTest();
			//CategoryTest();
		}

		private static void CategoryTest()
		{
			CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
			foreach (var category in categoryManager.GetAll())
			{
				Console.WriteLine(category.CategoryName);
			}
		}

		private static void ProdcutTest()
		{
			ProductManager productManager = new ProductManager(new EfProductDal());

			foreach (var product in productManager.GetProductDetails())
			{
				Console.WriteLine(product.ProductName + "/" + product.CategoryName);
			}
		}
	}
}
