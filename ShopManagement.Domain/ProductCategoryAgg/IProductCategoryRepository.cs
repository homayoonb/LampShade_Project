using SM.Application.Contract.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory productCategory);
        ProductCategory GetById(long id);
        EditProductCategory Get(long id);
        List<ProductCategory> GetProductCategories();
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel search);
        bool Exists(Expression<Func<ProductCategory,bool>> exp);
        void SaveChanges();
    }
}
