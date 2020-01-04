using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Web.Exceptions
{
    public class RequestValidationExceptionProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public RequestValidationExceptionProblemDetails(FluentValidation.ValidationException exception)
        {
            this.Title = exception.Message;
            this.Status = StatusCodes.Status400BadRequest;
        }
    }
}
