using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using GraphQL.Types;
using GraphQL;
using GraphQLEndpointService.Handlers;
using GraphQLEndpointService.Models;


namespace GraphQLEndpointService.Controllers
{
    [Route("graphql")]
        
    public class GraphQLController : Controller
    {
        public string indexName;
        public dynamic schema;
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {

            string value = query.Query;
            if (value.Contains("product"))
            {
                indexName = "products";
                schema = new Schema { Query = new ProductQuery() };
            }
            else if (value.Contains("brand"))
            {
                indexName = "brands";
                schema = new Schema { Query = new BrandQuery() };
            }

            else
            {
                indexName = "categories";
                schema = new Schema { Query = new CategoryQuery() };
            }


            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;

            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}