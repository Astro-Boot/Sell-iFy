using MediatR;
using Sellify.Application.Features.Reviews.Queries.Vms;

namespace Sellify.Application.Features.Reviews.Commands.CreateReview;

public class CreateReviewCommand : IRequest<ReviewVm>
{
    public int ProductId { get; set; }

    public string? Nombre { get; set; }

    public int Rating { get; set; }

    public string? Comentario { get; set; }
}