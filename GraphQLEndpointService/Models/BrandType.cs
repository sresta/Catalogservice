using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLEndpointService.Models
{
    public class BrandType : ObjectGraphType<Brands>
    {
        public BrandType()
        {
            Field(x => x.id).Description("The Id of the Droid.");
            Field(x => x.brandname, nullable: true).Description("The name of the Droid.");
        }
    }
    public class BrandSourceType : ObjectGraphType<BrandSource>
    {
        public BrandSourceType()
        {
            Field(x => x._source.id).Description("The Id of the Droid.");
            Field(x => x._source.brandname, nullable: true).Description("The name of the Droid.");
        }
    }

    public class BrandHitType : ObjectGraphType<BrandHits>
    {
        public BrandHitType()
        {
            Field<ListGraphType<BrandSourceType>>("_source", resolve: context => context.Source.hits);
        }
    }

    public class BrandResultType : ObjectGraphType<BrandResult>
    {
        public BrandResultType()
        {
            Field<BrandHitType>("hits", resolve: context => context.Source.hits);
        }
    }
}
