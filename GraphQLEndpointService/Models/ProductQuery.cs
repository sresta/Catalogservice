using GraphQL.Types;
using GraphQLEndpointService.Services;

namespace GraphQLEndpointService.Models
{
    public class ProductQuery : ObjectGraphType
    {
        public string indexName = "products";
        public ProductQuery()
        {
            Field<ProductResultType>
                     ("hits",
                     resolve: context => new ElasticSearchServices().GetByIndex<ProductResult>(indexName));


            Field<ProductResultType>("productid",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return new ElasticSearchServices().GetById<ProductResult>(id,indexName);

                });

            Field<ProductType>("productname",
               arguments: new QueryArguments(
                   new QueryArgument<StringGraphType>() { Name = "name" }),
               resolve: context =>
               {
                   var name = context.GetArgument<string>("name");
                   return new ElasticSearchServices().GetByName<ProductResult>(name,indexName);

               });
        }
    }
}


