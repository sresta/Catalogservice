using GraphQL.Types;
using GraphQLEndpointService.Models;

namespace GraphQLEndpointService.Models
{

    public class ProductType : ObjectGraphType<Products>
    {
        public ProductType()
        {
            Field(x => x.id).Description("The Id of the Droid.");
            Field(x => x.productname, nullable: true).Description("The name of the product.");
            Field(x => x.quantity).Description("The quantity of the products.");
            Field(x => x.price).Description("The price of the products.");

        }
    }
    public class ProductSourceType : ObjectGraphType<ProductSource>
    {
        public ProductSourceType()
        {
            Field(m => m._source.id);
            Field(m => m._source.productname);
            Field(m => m._source.quantity);
            Field(m => m._source.price);

        }
    }

    public class ProductHitsType : ObjectGraphType<ProductHits>
    {
        public ProductHitsType()
        {

            Field<ListGraphType<ProductSourceType>>("_source", resolve: context => context.Source.hits);
            
        }
    }
    public class ProductResultType : ObjectGraphType<ProductResult>
    {
        public ProductResultType()
        {
            Field<ProductHitsType>("hits", resolve: context => context.Source.hits);
        }
    }
}

