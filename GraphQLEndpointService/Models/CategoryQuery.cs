using GraphQL.Types;
using GraphQLEndpointService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLEndpointService.Models
{
    public class CategoryQuery : ObjectGraphType
    {
        public string indexName = "categories";
        public CategoryQuery()
        {
            Field<CategoryResultType>
                                 ("hits",
                                 resolve: context => new ElasticSearchServices().GetByIndex<CategoryResult>(indexName));

            //Get By Id
            Field<CategoryResultType>("categoryId",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return new ElasticSearchServices().GetById<CategoryResult>(id,indexName);

                });

            //Get By Name
            Field<CategoryResultType>("categoryName",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "categoryname" }),
                resolve: context =>
                {
                    var name = context.GetArgument<string>("categoryname");
                    return new ElasticSearchServices().GetByName<CategoryResult>(name,indexName);

                });
        }
    }
}
