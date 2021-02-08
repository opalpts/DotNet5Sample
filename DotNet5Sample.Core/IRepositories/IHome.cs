using DotNet5Sample.Core.ViewModels;
using System.Collections.Generic;

namespace DotNet5Sample.Core.Repositories
{
    public interface IHome
    {
        List<DetailViewModels.OfferViewModel> GetTable();
    }
}
