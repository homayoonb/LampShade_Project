namespace SM.Application.Contract.ProductCategory
{
    public class CreateProductCategory
    {
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        /// <summary>
        /// ساختن صفحه
        /// </summary>
        public string KeyWord { get;  set; }
        public string MetaDescription { get;  set; }
        public string Slug { get;  set; }
    }
}
