CREATE procedure [dbo].[getRandomProduct]
	@product nvarchar(3)
as
begin
	SELECT DISTINCT ProductModel.ProductModelID, ProductModel.Name, ProductPhoto.LargePhoto
	FROM Production.ProductModel 
		JOIN Production.Product ON ProductModel.ProductModelID = Product.ProductModelID 
		JOIN Production.ProductProductPhoto ON Product.ProductID = ProductProductPhoto.ProductID 
		JOIN Production.ProductPhoto ON ProductProductPhoto.ProductPhotoID = ProductPhoto.ProductPhotoID
	WHERE Product.ProductModelID = @product AND ProductModel.ProductModelId IS NOT NULL;
end
go

CREATE procedure dbo.getRandomProductPrice
	@Id nvarchar(3)
as
begin
	SELECT ProductId, Size, ListPrice FROM Production.Product Where Product.ProductModelID = @Id ORDER BY Size
end
go

create procedure [dbo].[getRandomProductBySize]
	@Size nvarchar(2)
as
begin
	SELECT DISTINCT ProductModel.ProductModelID, ProductModel.Name, ProductPhoto.LargePhoto
	FROM Production.ProductModel 
		JOIN Production.Product ON ProductModel.ProductModelID = Product.ProductModelID 
		JOIN Production.ProductProductPhoto ON Product.ProductID = ProductProductPhoto.ProductID 
		JOIN Production.ProductPhoto ON ProductProductPhoto.ProductPhotoID = ProductPhoto.ProductPhotoID
	WHERE Product.Size LIKE @Size AND ProductModel.ProductModelId IS NOT NULL;
end