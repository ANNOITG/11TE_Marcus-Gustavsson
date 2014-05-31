using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using ProductStoreClient;

namespace ProjectsStoreClient
{
    class Program
    { 
        // I have chosen to expand the program somewhat from the boundries of the tutorial,
        //too expand my knowledge for future projects.
        //
        //THIS IS A CLIENT TOO PROJECT "ProductStore"
        //
        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                // Sets the base uri for HTTP requests
                client.BaseAddress = new Uri("http://localhost:5548/");
                // Clears and sets the Accept header so that the server knows to send data in JSON format
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                Console.WriteLine("Existing products:");                
                // Get entire set of entries, (a for loop like this is not an optimal sulotuion due too the fact that if 
                //there is an entry missing in the sequense the loop will break, but the better 
                //alternetive would requier an total rebuild of the api with an ODATA endpoint)
                //I chose tho add this function anyway, I learned about ODATA thanks too this.
                for (int x = 1; x != 0; x++)
                {
                    // Sets the response variable too contain the desired entry
                    response = await client.GetAsync("api/products/" + x);
                    // Checks if the request does not correspont with an actual entry  
                    if (response.IsSuccessStatusCode)
                    {
                        // Creates an object according too the Product class containing data from the API. 
                        Product product = await response.Content.ReadAsAsync<Product>();

                        // Display product entry
                        Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                    }
                    else
                    {
                        // Breaks if there isn't an entry corresponding with the request
                        break;
                    }
                }
                     
                // HTTP POST

                // Creates a static product var "Gizmo"
                var gizmo = new Product() { Name = "Gizmo", Price = 100, Category = "Widget" };
                // Sets the response var too contain the new product entry "Gizmo"
                response = await client.PostAsJsonAsync("api/products", gizmo);
                // Checks if the api path is valid 
                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    Uri gizmoUrl = response.Headers.Location;

                    // Displays new product
                    Product newProduct = await response.Content.ReadAsAsync<Product>();
                    Console.WriteLine("\nNew product entry:\n{0}\t${1}\t{2}", 
                        newProduct.Name, newProduct.Price, newProduct.Category);

                    // HTTP PUT
                    gizmo.Price = 80;   // Update price
                    response = await client.PutAsJsonAsync(gizmoUrl, gizmo);

                    // Displays updated product
                    response = await client.GetAsync(gizmoUrl);
                    Product updatedProduct = await response.Content.ReadAsAsync<Product>();
                    Console.WriteLine("\nUpdated product entry:\n{0}\t${1}\t{2}", 
                        updatedProduct.Name, updatedProduct.Price, updatedProduct.Category);

                    // HTTP DELETE
                    response = await client.DeleteAsync(gizmoUrl);

                    // Trying to display the deleted product
                    response = await client.GetAsync(gizmoUrl);
                    // if will never run, always else
                    if (response.IsSuccessStatusCode)
                    {
                        // Creates an object according too the Product class containing data from the API. 
                        Product deletedProduct = await response.Content.ReadAsAsync<Product>();

                        // Display product entry
                        Console.WriteLine("\nTrying Gizmo:\nDeleted product entry\n{0}\t${1}\t{2}",
                        deletedProduct.Name, deletedProduct.Price, deletedProduct.Category);
                    }
                    else
                    {
                        Console.WriteLine("\nTrying Gizmo:\nNothing here!");
                    } 
                }

                Console.ReadKey();
            }
        }
    }
}