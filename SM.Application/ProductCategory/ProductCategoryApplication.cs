using _0_Framework.Application;
using _0_FrameWork.Application;
using ShopManagement.Domain.ProductCategoryAgg;
using SM.Application.Contract.ProductCategory;

namespace SM.Application.ProductCategory
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operationResult=new OperationResult();

            if (_productCategoryRepository.Exists(x=>x.Name == command.Name))
            {
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();

            var productCategory = new ShopManagement.Domain.ProductCategoryAgg.ProductCategory(command.Name, command.Description, command.Picture, command.PictureAlt, command.PictureTitle, command.KeyWord, command.MetaDescription, slug);

            _productCategoryRepository.Create(productCategory);

            _productCategoryRepository.SaveChanges();

            return operationResult.Succedded();
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _productCategoryRepository.GetProductCategories();
        }

        public EditProductCategory GetProductCategory(long id)
        {
            return _productCategoryRepository.Get(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }

        public OperationResult Update(EditProductCategory command)
        {
            var operationResult = new OperationResult();

            var productCategory = _productCategoryRepository.GetById(command.Id);
            if (productCategory == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_productCategoryRepository.Exists(x => x.Name == command.Name))
            {
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();
            productCategory.Edit(command.Name, command.Description, command.Picture, command.PictureAlt, command.PictureTitle, command.KeyWord, command.MetaDescription, slug);

            _productCategoryRepository.SaveChanges();

            return operationResult.Succedded();
        }
    }
}
