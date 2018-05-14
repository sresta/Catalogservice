using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLEndpointService.Models
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Field(x => x.id).Description("The Id of the Droid.");
            Field(x => x.categoryname, nullable: true).Description("The name of the Droid.");
        }
    }

    public class CategorySourceType : ObjectGraphType<CategorySource>
    {
        public CategorySourceType()
        {
            Field(x => x._source.id).Description("The Id of the Droid.");
            Field(x => x._source.categoryname, nullable: true).Description("The name of the Droid.");
        }
    }

    public class CategoryHitsType : ObjectGraphType<CategoryHits>
    {
        public CategoryHitsType()
        {
            Field<ListGraphType<CategorySourceType>>("_source", resolve: context => context.Source.hits);
        }
    }

    public class CategoryResultType : ObjectGraphType<CategoryResult>
    {
        public CategoryResultType()
        {
            Field<CategoryHitsType>("hits", resolve: context => context.Source.hits);
        }
    }
}
