using Application.Repositories;
using Application.Repositories.UnitOfWork;
using Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly Lazy<IAccountRepository> _accountRepository;
    private readonly Lazy<ICategoryRepository> _categoryRepository;
    private readonly Lazy<ICurrencyAmountRepository> _currencyAmountRepository;
    private readonly Lazy<ICurrencyRepository> _currencyRepository;
    private readonly Lazy<IInvoiceRepository> _invoiceRepository;
    private readonly Lazy<IManufacturerRepository> _manufacturerRepository;
    private readonly Lazy<IProductMovementRepository> _productMovementRepository;
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<IStoragePlaceRepository> _storagePlaceRepository;
    private readonly Lazy<IUnitRepository> _unitRepository;
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<IWarehouseRepository> _warehouseRepository;

    private readonly IDbContextTransaction _transaction;

    public UnitOfWork(Lazy<IAccountRepository> accountRepository, Lazy<ICategoryRepository> categoryRepository,
        Lazy<ICurrencyAmountRepository> currencyAmountRepository, Lazy<ICurrencyRepository> currencyRepository,
        Lazy<IInvoiceRepository> invoiceRepository, Lazy<IManufacturerRepository> manufacturerRepository,
        Lazy<IProductMovementRepository> productMovementRepository, Lazy<IProductRepository> productRepository,
        Lazy<IStoragePlaceRepository> storagePlaceRepository, Lazy<IUnitRepository> unitRepository,
        Lazy<IUserRepository> userRepository, Lazy<IWarehouseRepository> warehouseRepository, ApplicationDbContext dbContext)
    {
        _accountRepository = accountRepository;
        _categoryRepository = categoryRepository;
        _currencyAmountRepository = currencyAmountRepository;
        _currencyRepository = currencyRepository;
        _invoiceRepository = invoiceRepository;
        _manufacturerRepository = manufacturerRepository;
        _productMovementRepository = productMovementRepository;
        _productRepository = productRepository;
        _storagePlaceRepository = storagePlaceRepository;
        _unitRepository = unitRepository;
        _userRepository = userRepository;
        _warehouseRepository = warehouseRepository;
        _transaction = dbContext.Database.BeginTransaction();
    }

    public IAccountRepository AccountRepository => _accountRepository.Value;

    public ICategoryRepository CategoryRepository => _categoryRepository.Value;

    public ICurrencyAmountRepository CurrencyAmountRepository => _currencyAmountRepository.Value;

    public ICurrencyRepository CurrencyRepository => _currencyRepository.Value;

    public IInvoiceRepository InvoiceRepository => _invoiceRepository.Value;

    public IManufacturerRepository ManufacturerRepository => _manufacturerRepository.Value;

    public IProductMovementRepository ProductMovementRepository => _productMovementRepository.Value;

    public IProductRepository ProductRepository => _productRepository.Value;

    public IStoragePlaceRepository StoragePlaceRepository => _storagePlaceRepository.Value;

    public IUnitRepository UnitRepository => _unitRepository.Value;

    public IUserRepository UserRepository => _userRepository.Value;

    public IWarehouseRepository WarehouseRepository => _warehouseRepository.Value;

    public void Commit()
    {
        _transaction.Commit();
    }

    public Task CommitAsync()
    {
        return _transaction.CommitAsync();
    }

    public void Dispose()
    {
        _transaction.Dispose();
        GC.SuppressFinalize(this);
    }
}