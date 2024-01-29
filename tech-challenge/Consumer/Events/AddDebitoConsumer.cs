using Core.Domain.Entities;
using MassTransit;

namespace Consumer.Events
{
    internal class AddDebitoConsumer : IConsumer<Debito>
    {
        public Task Consume(ConsumeContext<Debito> context)
        {
            Console.WriteLine(context.Message);
            return Task.CompletedTask;
        }
    }
}
