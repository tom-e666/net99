using Microsoft.AspNetCore.Mvc.Routing;
using SportStore.Models.ViewModels;

namespace SportStore.Models;

public class ProductListViewModel
{
    public IEnumerable<Product> Products { get; set; }=Enumerable.Empty<Product>();
    public PagingInfo PagingInfo { get; set; } = new PagingInfo();

    public ProductListViewModel()
    {
        
    }
}