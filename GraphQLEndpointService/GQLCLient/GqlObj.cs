using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLEndpointService.GQLCLient
{
    public class GqlObj
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Salary { get; set; }

        public static void Main(string[] args);
        {
            var client = new GraphQLClient("http://localhost:9200/employee");
            var query = @"
                            query($id: String) { 
                                employee(id: $id) {
                                    id
                                    name
                                    department
                                    salary
                                }
                            }
                        ";

            var obj = client.Query(query, new { id = "1" }).Get<GqlObj>("employee");
            if (obj != null)
            {
                Console.WriteLine(obj.id+obj.name);
            }
            else
            {
                Console.WriteLine("Null :(");
            }
        }
    }
}

