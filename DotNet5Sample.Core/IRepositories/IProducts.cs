using DotNet5Sample.Core.ViewModels;
using System.Collections.Generic;

namespace DotNet5Sample.Core.Repositories
{
    public interface IProducts
    {
        List<DetailViewModels.ProductViewModel> GetProduct();
        DetailViewModels.ProductViewModel GetById(int id);
        int Create(DetailViewModels.ProductViewModel product);
        int Update(DetailViewModels.ProductViewModel product);
        int Delete(int id);
    }
}
