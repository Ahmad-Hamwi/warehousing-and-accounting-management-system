using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Categories;

public class GetCategoryQuery : IRequest<Category>
{
    public int Id { get; init; }
}

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Category>
{
    private readonly ICategoryRepository _repository;

    public GetCategoryQueryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        return _repository.FindByIdAsync(request.Id);
    }
}