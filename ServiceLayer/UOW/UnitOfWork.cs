using AutoMapper;
using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ServiceLayer.Repositories.Interfaces;
using ServiceLayer.SERVICES.Repositories.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        //private readonly IOptions<EmailSettings> _settings;
        //IOptions<StripeSettings> _stripeSettings;

        public IAccountRepository Customers { get; private set; }
        public IProductRepository Products { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IOrderItemRepository OrderItems { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public ICartRepository Carts { get; private set; }
        public ICartItemsRepository CartItems { get; private set; }
        public IReviewRepository Reviews { get; private set; }
        public ISessionRepository Sessions { get; private set; }
        public IMailRepository Mails { get; private set; }
        public IPaymentRepository Payments { get; private set; }
        public IBrandRepository Brands { get; private set; }

        public UnitOfWork(ApplicationContext context,/* IConfiguration configuration,*/
            UserManager<User> userManager, IMapper mapper,
            IHttpContextAccessor httpContextAccessor/*, IOptions<EmailSettings> setting, IOptions<StripeSettings> stripeSettings*/)
        {
            _context = context;
            //_configuration = configuration;
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            //_settings = setting;
            //_stripeSettings = stripeSettings;

            Customers = new AccountRepository(_context, _userManager, _configuration, _mapper, _httpContextAccessor);
            Carts = new CartRepository(_context, _mapper);
            CartItems = new CartItemsRepository(_context, _mapper);
            Categories = new CategoryRepository(_context, _mapper);
            Orders = new OrderRepository(_context, _mapper, _httpContextAccessor, _userManager);
            OrderItems = new OrderItemRepository(_context, _mapper, _httpContextAccessor, _userManager);
            Products = new ProductRepository(_context, _mapper);
            Reviews = new ReviewRepository(_context, _mapper);
            //Sessions = new SessionRepository();
           // Mails = new MailRepository(_context, _settings);
           // Payments = new PaymentRepository(_context, _stripeSettings, _mapper);
            Brands = new BrandRepository(_context, _mapper);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
