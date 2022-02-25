using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Behaviours
{
    public class ValidationBehaviour<Trequest, Tresponse> : IPipelineBehavior<Trequest, Tresponse>
    {
        private readonly IEnumerable<IValidator<Trequest>> _validators;
        public ValidationBehaviour(IEnumerable<IValidator<Trequest>> validators)
        {
            _validators = validators;
        }
        public Task<Tresponse> Handle(Trequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Tresponse> next)
        {
            throw new System.NotImplementedException();
        }
    }
}
