using ServiceLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.UOW
{
    public interface IUnitOfWork : IDisposable
    {

        IAccountRepository Customers { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        IOrderItemRepository OrderItems { get; }
        ICategoryRepository Categories { get; }
        ICartRepository Carts { get; }
        ICartItemsRepository CartItems { get; }
        IReviewRepository Reviews { get; }
      
        ISessionRepository Sessions { get; }
        IMailRepository Mails { get; }
        IPaymentRepository Payments { get; }
        IBrandRepository Brands { get; }

        Task<int> Save();
    }
}
