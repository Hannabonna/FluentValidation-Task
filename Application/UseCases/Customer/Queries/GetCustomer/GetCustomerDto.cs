using FluentVal_Task.Application.Models.Query;
using FluentVal_Task.Domain.Entities;

namespace FluentVal_Task.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerDto : BaseDto
    {
        public CustomerEn Data { get; set; }
    }
}