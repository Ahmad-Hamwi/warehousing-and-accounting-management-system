using Domain.Entities;

namespace Application.Repositories;

public interface IPaymentRepository : IRepositoryCrud<Payment, int>
{
}