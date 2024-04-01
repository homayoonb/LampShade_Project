

using _0_FrameWork.Application;

namespace SM.Application.Contract.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Update(EditProductCategory command);
        EditProductCategory GetProductCategory(long id);
        List<ProductCategoryViewModel> GetAll();
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel search);
    }
}
