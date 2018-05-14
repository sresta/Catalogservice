using GraphQL.Types;
using GraphQLEndpointService.Services;

namespace GraphQLEndpointService.Models
{
    public class BrandQuery:ObjectGraphType
    {
        public string indexName = "brands";
        public BrandQuery()
        {
            Field<BrandResultType>("brands", 
                resolve: context => new ElasticSearchServices().GetByIndex<BrandResult>(indexName));

            //Get By Id
            Field<BrandResultType>("brandId",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return new ElasticSearchServices().GetById<BrandResult>(id,indexName);

                });

            //Get By Name
            Field<BrandResultType>("brandName",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "bname" }),
                resolve: context =>
                {
                    var name = context.GetArgument<string>("bname");
                    return new ElasticSearchServices().GetByName<BrandResult>(name,indexName);

                });
        }
    }
}
